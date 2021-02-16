using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;
using Microsoft.AspNetCore.Mvc;
using Microsoft.AspNetCore.Mvc.RazorPages;
using AccountLibraryService;
using Merit.Data.Models;

namespace LoginWebTesting.Pages
{
    public class RegisterModel : PageModel
    {
        [BindProperty]
        public User NewAccount { get; set; }

        [BindProperty]
        public string PasswordCheck { get; set; }

        [BindProperty]
        public string RegisterMessage { get; set; }
        private readonly IAccount account = new Account();

        public void OnGet()
        {
        }

        public void OnPost()
        {

            if (NewAccount.Password == PasswordCheck)
            {
                switch (account.CheckExistingAccount(NewAccount))
                {
                    case 100:
                        account.AddAccount(NewAccount);
                        RegisterMessage = "Registreringen lyckades!";
                        break;
                    case 101:
                        RegisterMessage = "Användarnamnet upptaget.";
                        break;
                    case 102:
                        RegisterMessage = "Epost-adressen finns redan registrerad.";
                        break;
                    default:
                        break;
                }
            }
            else
            {
                RegisterMessage = "Lösenorden stämmer inte överens.";
            }
        }


    }
}
