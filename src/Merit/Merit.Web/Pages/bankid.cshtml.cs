using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;
using Merit.Web.Services;
using Merit.Web.Services.BankId;
using Microsoft.AspNetCore.Mvc;
using Microsoft.AspNetCore.Mvc.RazorPages;

namespace Merit.Web.Pages
{
    public class BankIdModel : PageModel
    {
        private static readonly Dictionary<Guid, IBankIdResponse> PendingOrders = new();
        public async Task OnGetAsync()
        {
            var bankid = new BankIdTestService();
            var ip = HttpContext.Connection.RemoteIpAddress.ToString();
            IBankIdResponse response = await bankid.AuthorizeAsync(bankid.TestPersonalNumber, ip);
            ViewData["AuthResponse"] = response is AuthResponse signResponse 
                ? signResponse.ToString() 
                : (response as ErrorResponse).ToString();

        }
    }
}
