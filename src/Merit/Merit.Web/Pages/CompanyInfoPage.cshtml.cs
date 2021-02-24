using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;
using Merit.AccountService;
using Merit.CompanyService;
using Merit.Data.Models;
using Merit.MeritService;
using Merit.WantsService;
using Microsoft.AspNetCore.Mvc;
using Microsoft.AspNetCore.Mvc.RazorPages;

namespace Merit.Web.Pages
{
    public class CompanyInfoPageModel : PageModel
    {
        private ICompanyService companyService = new CompanyService.CompanyService();
        private IAccount accountService = new Account();
        private IMeritService meritService = new MeritService.MeritService();
        private IWantsService wantsService = new WantsService.WantsService();

        [BindProperty]
        public CompanyUser AUser { get; set; }
        [BindProperty]
        public CompanyInfo CompanyInfo { get; set; }
        [BindProperty]
        public List<CompanyMerit> CompanyMerits { get; set; }

        [BindProperty]
        public List<CompanyWants> CompanyWants { get; set; }

        public void OnGet()
        {
            int userId = Account.CheckCookie();
            AUser = accountService.GetCompanyUser(userId);
            CompanyInfo = companyService.Get(userId);
            CompanyWants = wantsService.GetCompanyWants(userId);
            //if (CompanyInfo == null)
            //{
            //    CompanyInfo = new CompanyInfo();
            //}
            CompanyMerits = meritService.ReadCompanyMerits(userId);
        }
    }
}
