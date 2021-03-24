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
        //private readonly IAccount Account = new Account();

        //[BindProperty]
        //public User UserLogin { get; set; }
        //public string LoginMessage { get; set; }
        //public bool Visi { get; set; }

        //public void OnGet()
        //{
        //}

        //public IActionResult OnPost()
        //{
        //    int[] userIdAndUserType = Account.CheckLogin(UserLogin);

        //    if (userIdAndUserType[0] != 0)
        //    {

        //        LoginMessage = "Inloggningen lyckades!";
        //        AccountService.Account.CreateCookie(userIdAndUserType[0]);
        //        if (userIdAndUserType[1] == 1)
        //        { return Redirect("/PersonalInfoPage"); }
        //        else if (userIdAndUserType[1] == 2)
        //        { return Redirect("/CompanyInfoPage"); }
        //    }
        //    Visi = true;
        //    LoginMessage = "Felaktigt anv�ndarnamn eller l�senord";
        //    return Page();
        //}
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

        public class InputModel
        {
            [Required(ErrorMessage = "Du m�ste fylla i din e-post.")]
            [EmailAddress(ErrorMessage = "Ogiltig e-post.")]
            [Display(Name = "E-post")]
            public string Email { get; set; }

            [Required(ErrorMessage = "Du m�ste fylla i ditt l�senord.")]
            [DataType(DataType.Password)]
            [Display(Name = "L�senord")]
            public string Password { get; set; }

            [Display(Name = "Kom ih�g mig?")]
            public bool RememberMe { get; set; }
        }
    }
}
