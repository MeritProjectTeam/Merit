using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;
using Merit.AccountService;
using Merit.Data.Models;
using Microsoft.AspNetCore.Mvc;
using Microsoft.AspNetCore.Mvc.RazorPages;

namespace Merit.Web.Pages
{
    public class EditCompanyUserModel : PageModel
    {
        private readonly IAccount AccountService = new Account();

        [BindProperty(SupportsGet = true)]
        public CompanyUser ACompanyUser { get; set; }

        int CompanyUserId = Account.CheckCookie();

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
            CompanyUserId = Account.CheckCookie();
            if (CompanyUserId != 0)
            {
                ACompanyUser = AccountService.GetCompanyUser(CompanyUserId);
            }
        }

        public void OnPost()
        {
            ACompanyUser = AccountService.GetCompanyUser(CompanyUserId);
            ACompanyUser.Email = Email;
            if (PasswordCheck1 != null)
            {
                ACompanyUser.Password = Account.EncryptPassword(PasswordCheck1);
            }
            AccountService.EditCompanyUser(ACompanyUser);
            Visi = true;
            EditMessage = "Userprofile updated";
            TypeMessage = "success";
        }
    }
}
