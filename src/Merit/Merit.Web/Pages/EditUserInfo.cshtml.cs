using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;
using Merit.AccountService;
using Merit.Data.Data;
using Merit.Data.Models;
using Merit.PersonalInfoService;
using Microsoft.AspNetCore.Mvc;
using Microsoft.AspNetCore.Mvc.RazorPages;
using Microsoft.EntityFrameworkCore;

namespace Merit.Web.Pages
{
    public class EditUserInfoModel : PageModel
    {
        private readonly IAccount AccountService = new Account();

        [BindProperty(SupportsGet = true)]
        public PersonalUser AUser { get; set; }

        int UserId = Account.CheckCookie();

        [BindProperty]
        public string PasswordCheck1 { get; set; }
        [BindProperty]
        public string PasswordCheck2 { get; set; }
        [BindProperty]
        public string Email { get; set; }

        public bool Visi { get; set; }
        public string EditMessage { get; set; }
        public string TypeMessage { get; set; }

        public void OnGet()
        {
            UserId = Account.CheckCookie();
            if (UserId != 0)
            {
                AUser = AccountService.GetPersonalUser(UserId);
            }
        }

        public void OnPost()
        {
            AUser = AccountService.GetPersonalUser(UserId);
            AUser.Email = Email;
            if (PasswordCheck1 != null)
            {
                AUser.Password = Account.EncryptPassword(PasswordCheck1);
            }
            AccountService.EditPersonalUser(AUser);
            Visi = true;
            EditMessage = "Användarprofil uppdaterad!";
            TypeMessage = "success";
        }
    }
}
