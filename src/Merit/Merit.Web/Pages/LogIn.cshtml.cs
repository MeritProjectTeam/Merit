using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;
using Microsoft.AspNetCore.Mvc;
using Microsoft.AspNetCore.Mvc.RazorPages;
using Merit.AccountService;
using Merit.Data.Models;
using System.ComponentModel.DataAnnotations;
using System.Xml.Linq;
using Microsoft.AspNetCore.Identity;
using Microsoft.AspNetCore.Authentication;

namespace Merit.Web.Pages
{
    public class LogInModel : PageModel
    {
        private readonly UserManager<IdentityUser> userManager;
        private readonly SignInManager<IdentityUser> signInManager;

        [BindProperty]
        public InputModel Input { get; set; }

        public LogInModel(UserManager<IdentityUser> userManager, SignInManager<IdentityUser> signInManager)
        {
            this.userManager = userManager;
            this.signInManager = signInManager;
        }

        public async Task OngetAsync()
        {
            // Clear external login cookies.
            await HttpContext.SignOutAsync(IdentityConstants.ExternalScheme);
        }

        public async Task<IActionResult> OnPostAsync()
        {
            if (ModelState.IsValid)
            {
                var result = await signInManager.PasswordSignInAsync(Input.Email, Input.Password, isPersistent: true, lockoutOnFailure: false);
                if (result.Succeeded)
                {
                    return Redirect("/PersonalInfoPage");
                }
                else
                {
                    ModelState.AddModelError(string.Empty, "Ogiltig inloggning.");
                    return Page();
                }

            }
            return Page();
        }

        public class InputModel
        {
            [Required(ErrorMessage = "Du måste fylla i din e-post.")]
            [EmailAddress(ErrorMessage = "Ogiltig e-post.")]
            [Display(Name = "E-post")]
            public string Email { get; set; }

            [Required(ErrorMessage = "Du måste fylla i ditt lösenord.")]
            [DataType(DataType.Password)]
            [Display(Name = "Lösenord")]
            public string Password { get; set; }

            [Display(Name = "Kom ihåg mig?")]
            public bool RememberMe { get; set; }
        }
    }
}
