using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;
using Microsoft.AspNetCore.Mvc;
using Microsoft.AspNetCore.Mvc.RazorPages;
using AccountLibraryService;
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
            if (Account.CheckLogin(UserLogin))
            {
                LoginMessage = "Inloggningen lyckades!";
            }
            else
            {
                LoginMessage = "Felaktigt användarnamn eller lösenord";
            }
        }

    }
}
