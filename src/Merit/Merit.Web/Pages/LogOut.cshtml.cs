using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;
using Microsoft.AspNetCore.Identity;
using Microsoft.AspNetCore.Mvc;
using Microsoft.AspNetCore.Mvc.RazorPages;

namespace Merit.Web.Pages
{
    public class LogOutModel : PageModel
    {
        private readonly SignInManager<IdentityUser> signInManager;

        public LogOutModel(SignInManager<IdentityUser> signInManager)
        {
            this.signInManager = signInManager;
        }
        public async Task<IActionResult> OnGetAsync()
        {
            await signInManager.SignOutAsync();
            return Redirect("/Index");
        }
    }
}
