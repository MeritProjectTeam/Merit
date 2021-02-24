using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;
using Merit.AccountService;
using Merit.CompanyService;
using Merit.Data.Models;
using Merit.MeritService;
using Microsoft.AspNetCore.Mvc;
using Microsoft.AspNetCore.Mvc.RazorPages;

namespace Merit.Web.Pages
{
    public class CompanyInfoPageModel : PageModel
    {
        private ICompanyService companyService = new CompanyService.CompanyService();
        private IAccount accountService = new Account();
        private IMeritService meritService = new MeritService.MeritService();

        [BindProperty]
        public User AUser { get; set; }
        [BindProperty]
        public Company CompanyInfo { get; set; }
        [BindProperty]
        public List<CompanyMerit> CompanyMerits { get; set; }

        public void OnGet()
        {
            int userId = Account.CheckCookie();
            AUser = accountService.GetUser(userId);
            CompanyInfo = companyService.Get(userId);
            if (CompanyInfo == null)
            {
                CompanyInfo = new Company();
            }
            CompanyMerits = meritService.ReadCompanyMerits(userId);
        }
    }
}
