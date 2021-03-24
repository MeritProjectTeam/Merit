using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;
using Merit.CompanyService;
using Microsoft.AspNetCore.Mvc;
using Microsoft.AspNetCore.Mvc.RazorPages;
using Merit.Data.Models;

namespace Merit.Web.Pages
{
    public class EditCompanyInfoModel : PageModel
    {
        private readonly ICompanyService companyService = new CompanyService.CompanyService();

        [BindProperty]
        public string Message { get; set; }
        [BindProperty]
        public CompanyInfo ACompany { get; set; }
        public bool Visi { get; set; }

        int companyUserId = AccountService.Account.CheckCookie();
        public void OnGet()
        {
            if (companyUserId != 0)
            {
                ACompany = companyService.Get(companyUserId);
            }
        }
        public void OnPost()
        {
            Visi = true;
            Message = "Företagsinfo sparad.";
            ACompany.CompanyUserID = AccountService.Account.CheckCookie();
            companyService.EditCompanyInfo(ACompany);
        }
    }
}
