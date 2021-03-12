using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;
using Microsoft.AspNetCore.Mvc;
using Microsoft.AspNetCore.Mvc.RazorPages;
using Merit.MeritService;
using Merit.Data.Models;
using Merit.WantsService;

namespace Merit.Web.Pages
{
    public class AddJobAdvertisementModel : PageModel
    {
        [BindProperty]
        public int myString { get; set; }

        public IMeritService meritService = new MeritService.MeritService();
        public IWantsService wantsService = new WantsService.WantsService();
        public List<CompanyMerit> MeritList { get; set; }
        [BindProperty]
        public List<int> WantsId { get; set; }
        [BindProperty]
        public List<int> MeritsId { get; set; }
        public List<CompanyMerit> CompanyMerits { get; set; }
        public List<CompanyWants> CompanyWants { get; set; }
        int companyUserId = AccountService.Account.CheckCookie();

        public CompanyAdvertisement CompanyAdd { get; set; }
        public void OnGet()
        {
            CompanyMerits = meritService.ReadCompanyMerits(companyUserId);
            CompanyWants = wantsService.GetAllCompanyWants(companyUserId);
        }

        public void OnPost()
        {
            CompanyMerits = meritService.ReadCompanyMerits(companyUserId);
            CompanyWants = wantsService.GetAllCompanyWants(companyUserId);
        }
    }
}
