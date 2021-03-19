using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;
using Merit.AccountService;
using Merit.AdvertisementService;
using Merit.CompanyService;
using Merit.Data.Models;
using Merit.MeritService;
using Merit.PersonalInfoService;
using Merit.WantsService;
using Microsoft.AspNetCore.Mvc;
using Microsoft.AspNetCore.Mvc.RazorPages;

namespace Merit.Web.Pages
{
    public class ShowJobAdvertisementModel : PageModel
    {
        private IAdvertisementService advertisementService = new AdvertisementService.AdvertisementService();
        private ICompanyService companyService = new CompanyService.CompanyService();
       

        [BindProperty(SupportsGet =true)]
        public int AdvertisementId { get; set; }

        
        [BindProperty]
        public CompanyInfo CompanyInfo { get; set; }

        [BindProperty]
        public CompanyAdvertisement CompanyAdvertisement { get; set; }
        [BindProperty]
        public List<CompanyMerit> AdvertisementMerits { get; set; }

        [BindProperty]
        public List<CompanyWants> AdvertisementWants { get; set; }
        
        public void OnGet()
        {
            CompanyAdvertisement = advertisementService.GetCompanyAdvertisement(AdvertisementId);
            CompanyInfo = companyService.Get(CompanyAdvertisement.CompanyUserId);

            AdvertisementMerits = advertisementService.GetAdvertisementMerits(AdvertisementId);

            AdvertisementWants = advertisementService.GetAdvertisementWants(AdvertisementId);



            //AUser = accountService.GetCompanyUser(userId);
            //CompanyInfo = companyService.Get(userId);
            //hämta annons id
            //hämta meriter och wants med hjälp av annonsid
            
        }

    }
}
