using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;
using Microsoft.AspNetCore.Mvc;
using Microsoft.AspNetCore.Mvc.RazorPages;

namespace Merit.Web.Pages
{
    public class LogOutModel : PageModel
    {
        public IActionResult OnGet()
        {
            AccountService.Account.CreateCookie(null);

            return Redirect("/Index");
        }
    }
}
