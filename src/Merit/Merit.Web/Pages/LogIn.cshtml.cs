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

        [BindProperty]
        public string LoginMessage { get; set; }

        public void OnGet()
        {
        }

        public void OnPost()
        {
            int userId = Account.CheckLogin(UserLogin);
            if (userId != 0)
            {
                LoginMessage = "Inloggningen lyckades!";
                AccountService.Account.CreateCookie(userId);
            }
            else
            {
                LoginMessage = "Felaktigt användarnamn eller lösenord";
            }
        }

    }
}
