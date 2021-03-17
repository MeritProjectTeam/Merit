using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;
using Microsoft.AspNetCore.Mvc;
using Microsoft.AspNetCore.Mvc.RazorPages;
using Merit.AccountService;
using Merit.Data.Models;

namespace Merit.Web.Pages
{
    public class LogInModel : PageModel
    {

        [BindProperty]
        public User UserLogin { get; set; }

        private readonly IAccount Account = new Account();

        
        public string LoginMessage { get; set; }

        public bool Visi { get; set; }

        public void OnGet()
        {
        }

        public IActionResult OnPost()
        {
            int[] userIdAndUserType = Account.CheckLogin(UserLogin);

            if (userIdAndUserType[0] != 0)
            {

                LoginMessage = "Inloggningen lyckades!";
                AccountService.Account.CreateCookie(userIdAndUserType[0]);
                if (userIdAndUserType[1] == 1)
                { return Redirect("/PersonalInfoPage"); }
                else if (userIdAndUserType[1] == 2)
                { return Redirect("/CompanyInfoPage"); }
            }
            Visi = true;
            LoginMessage = "Felaktigt användarnamn eller lösenord";
            return Page();
        }
    }
}
