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
    public class bankidModel : PageModel
    {
        public async Task OnGetAsync()
        {
            var bankid = new BankIdTestService();
            var ip = HttpContext.Connection.RemoteIpAddress.ToString();
            BankIdResponse response = await bankid.BeginAuthorizeAsync(bankid.TestPersonalNumber, ip);
            ViewData["TestResponse"] = response is BankIdSignResponse signResponse 
                ? signResponse.ToString() 
                : response.ToString();
        }
    }
}
