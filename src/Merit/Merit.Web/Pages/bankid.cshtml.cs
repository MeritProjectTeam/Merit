using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;
using Merit.Web.Services;
using Merit.AccountService;
using Merit.Web.Services.BankId;
using Microsoft.AspNetCore.Identity;
using Microsoft.AspNetCore.Mvc;
using Microsoft.AspNetCore.Mvc.RazorPages;
using System;
using System.Threading.Tasks;

namespace Merit.Web.Pages
{
    public class bankidModel : PageModel
    public class BankIdModel : PageModel
    {
        public async Task OnGetAsync()
        private BankIdService bankId;
        private const string internalErrorMessage = "Något gick fel, vänligen försök igen.";
        private UserManager<IdentityUser> userManager;
        private SignInManager<IdentityUser> signInManager;
        private readonly IAccount accountService = new Account();

        public BankIdData Data { get; set; }

        public BankIdModel(BankIdService bankId,
                           UserManager<IdentityUser> userManager,
                           SignInManager<IdentityUser> signInManager)
        {
            var bankid = new BankIdTestService();
            var ip = HttpContext.Connection.RemoteIpAddress.ToString();
            BankIdResponse response = await bankid.BeginAuthorizeAsync(bankid.TestPersonalNumber, ip);
            ViewData["TestResponse"] = response is BankIdSignResponse signResponse 
                ? signResponse.ToString() 
                : response.ToString();
            this.bankId = bankId;
            this.userManager = userManager;
            this.signInManager = signInManager;
        }

        public RedirectResult OnGet()
        {
            return Redirect("/LogIn");
        }

        public async Task<IActionResult> OnGetCancelAsync(Guid order)
        {
            await bankId.CancelAsync(order);
            return new JsonResult(new object());
        }

        public async Task OnGetOtherDeviceAsync()
        {
            IBankIdResponse response;
            try
            {
                response = await StartAuthAsync();
            }
            catch (BankIdException)
            {
                Data.StatusMessage = internalErrorMessage;
                return;
            }

            if(response is AuthResponse authResponse)
            {
                Data.QrString = $@"bankid:///?autostarttoken={authResponse.AutoStartToken}";
                Data.OrderRef = authResponse.OrderRef;
            }
        }

        public async Task<IActionResult> OnGetCollectAsync(Guid order)
        {
            const string providerName = "BankID";
            Data = new();
            var jsonData = new JsonData();
            IBankIdResponse response;
            try
            {
                response = await bankId.CollectAsync(order);
                jsonData.Message = BankIdService.GetUserMessage(response.MessageCode);
            }
            catch (BankIdException)
            {
                jsonData.Message = internalErrorMessage;
                jsonData.StopCollect = true;
                jsonData.Retry = true;
                return new JsonResult(jsonData);
            }

            if (response is CollectResponse collect)
            {
                if (collect.Status == "complete")
                {
                    var person = collect.CompletionData.User;
                    IdentityUser user = await userManager.FindByLoginAsync(providerName, person.PersonalNumber);
                    if (user is null)
                    {
                        user = new(person.PersonalNumber);
                        var result = await userManager.CreateAsync(user);
                        if (result.Succeeded)
                        {
                            UserLoginInfo loginInfo = new(providerName, person.PersonalNumber, person.Name);
                            await userManager.AddLoginAsync(user, loginInfo);
                            accountService.AddAccount(new Merit.Data.Models.PersonalUser()
                            {
                                Identity = user.Id,
                            });
                        }
                    }
                    await signInManager.SignInAsync(user, true);

                    jsonData.StopCollect = true;
                    jsonData.Redirect = true;
                }
                else if(collect.Status == "failed")
                {
                    jsonData.StopCollect = true;
                    jsonData.Retry = true;
                }
                else if (collect.HintCode == "started" || collect.HintCode == "outstandingTransaction")
                {
                    jsonData.ShowQr = true;
                }

                return new JsonResult(jsonData);
            }

            jsonData.StopCollect = true;
            return new JsonResult(jsonData);
        }

        public async Task<IActionResult> OnGetThisDeviceAsync()
        {
            IBankIdResponse response;
            try
            {
                response = await StartAuthAsync();
            }
            catch (BankIdException)
            {
                Data.StatusMessage = internalErrorMessage;
                return Page();
            }
            if (response is AuthResponse authResponse)
            {
                var link = $@"bankid:///?autostarttoken={authResponse.AutoStartToken}&redirect=null";
                return Redirect(link);
            }
            return Page();
        }

        private async Task<IBankIdResponse> StartAuthAsync(string personalNr = null)
        {
            string ip = HttpContext.Connection.RemoteIpAddress.ToString();
            Data = new();
            var result = await bankId.AuthorizeAsync(personalNr, ip);
            Data.MessageCode = result.MessageCode;
            Data.StatusMessage = BankIdService.GetUserMessage(Data.MessageCode);
            return result;
        }

        public class BankIdData
        {
            /// <summary>
            /// Interval for Collect-call in milliseconds.
            /// </summary>
            public int RefreshInterval { get; set; } = 2000;
            public int Timeout { get; set; }
            public MessageCode MessageCode { get; set; }
            public string QrString { get; set; }
            public string StatusMessage { get; set; }
            public Guid OrderRef { get; set; }
        }

        public class JsonData
        {
            public string Message { get; set; }
            public bool ShowQr { get; set; } = false;
            public bool StopCollect { get; set; } = false;
            public bool Redirect { get; set; } = false;
            public bool Retry { get; internal set; } = false;
        }
    }
}