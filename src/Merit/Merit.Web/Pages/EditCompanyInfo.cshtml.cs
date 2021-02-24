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
        public string Information { get; set; }
        [BindProperty]
        public CompanyInfo ACompany { get; set; }

        int companyUserId = AccountService.Account.CheckCookie();
        public void OnGet()
        {
            Information = "";
            if (companyUserId != 0)
            {
                ACompany = companyService.Get(companyUserId);
            }
        }
        public void OnPost()
        {
            Information = "Företagsinfo sparad.";
            ACompany.CompanyUserID = AccountService.Account.CheckCookie();
            companyService.UpdateCompanyInfo(ACompany);

        }
    }
}
