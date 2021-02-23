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
        public Company ACompany { get; set; }

        int companyId = AccountService.Account.CheckCookie();
        public void OnGet()
        {
            Information = "";
            if (companyId != 0)
            {
                ACompany = companyService.Get(companyId);
            }
        }
        public void OnPost()
        {
            Information = "Företagsinfo sparad.";
            ACompany.CompanyId = AccountService.Account.CheckCookie();
            companyService.UpdateCompanyInfo(ACompany);

        }
    }
}
