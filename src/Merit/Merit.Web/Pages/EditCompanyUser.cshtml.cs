using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;
using Merit.AccountService;
using Merit.Data.Models;
using Microsoft.AspNetCore.Identity;
using Microsoft.AspNetCore.Mvc;
using Microsoft.AspNetCore.Mvc.RazorPages;

namespace Merit.Web.Pages
{
    public class EditCompanyUserModel : PageModel
    {
        private readonly IAccount AccountService = new Account();

        private readonly UserManager<IdentityUser> userManager;
        private readonly SignInManager<IdentityUser> signInManager;

        public EditCompanyUserModel(UserManager<IdentityUser> userManager, SignInManager<IdentityUser> signInManager)
        {
            this.signInManager = signInManager;
            this.userManager = userManager;
        }


        [BindProperty(SupportsGet = true)]
        public CompanyUser ACompanyUser { get; set; }

        [BindProperty]
        public string PasswordCheck1 { get; set; }
        [BindProperty]
        public string PasswordCheck2 { get; set; }
        [BindProperty]
        public string Email { get; set; }

        public bool Visi { get; set; }
        public string EditMessage { get; set; }
        public string TypeMessage { get; set; }

        public async Task<IActionResult> OnGetAsync()
        {
            if (!signInManager.IsSignedIn(User))
            {
                return Redirect("/Login");
            }

            IdentityUser identity = await userManager.GetUserAsync(User);
            IUser cUser = identity.GetUser();

            ACompanyUser = AccountService.GetCompanyUser(cUser.Identity);
            return Page();
        }

        public async Task<IActionResult> OnPostAsync()
        {
            if (!signInManager.IsSignedIn(User))
            {
                return Redirect("/Login");
            }

            IdentityUser identity = await userManager.GetUserAsync(User);
            IUser cUser = identity.GetUser();



            ACompanyUser = AccountService.GetCompanyUser(cUser.Identity);
            ACompanyUser.Email = Email;
            if (PasswordCheck1 != null)
            {
                ACompanyUser.Password = Account.EncryptPassword(PasswordCheck1);
            }
            AccountService.EditCompanyUser(ACompanyUser);
            Visi = true;
            EditMessage = "Användarprofil uppdaterad!";
            TypeMessage = "success";
            return Page();
        }
    }
}
