using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;
using Microsoft.AspNetCore.Mvc;
using Microsoft.AspNetCore.Mvc.RazorPages;
using Merit.MeritService;
using Merit.Data.Models;
using Merit.WantsService;
using Merit.AdvertisementService;

namespace Merit.Web.Pages
{
    public class AddJobAdvertisementModel : PageModel
    {
        [BindProperty]
        public int myString { get; set; }

        public IMeritService meritService = new MeritService.MeritService();
        public IWantsService wantsService = new WantsService.WantsService();
        public IAdvertisementService advertisementService = new AdvertisementService.AdvertisementService();
        //public List<CompanyMerit> MeritList { get; set; }
        [BindProperty]
        public List<int> WantsId { get; set; }
        [BindProperty]
        public List<int> MeritsId { get; set; }
        public List<CompanyMerit> CompanyMerits { get; set; }
        public List<CompanyWants> CompanyWants { get; set; }
        [BindProperty]
        public int companyUserId { get; set; } = AccountService.Account.CheckCookie();
        [BindProperty]
        public CompanyAdvertisement CompanyAdd { get; set; }
        public void OnGet()
        {
           
            CompanyMerits = meritService.ReadCompanyMerits(companyUserId);
            CompanyWants = wantsService.GetAllCompanyWants(companyUserId);
        }

        public IActionResult OnPost()
        {
            CompanyMerits = meritService.ReadCompanyMerits(companyUserId);
            CompanyWants = wantsService.GetAllCompanyWants(companyUserId);

            int advertisementId = advertisementService.SaveAdvertisement(CompanyAdd);
            
            foreach (var id in MeritsId)
            {
               
                VisibleMerit x = new VisibleMerit();
                x.CompanyMeritId = id;
                x.CompanyAdvertisementId = advertisementId;
                advertisementService.SaveVisibleMerit(x);
            }
           
            foreach (var id in WantsId)
            {

                VisibleWant x = new VisibleWant();
                x.CompanyWantsId = id;
                x.CompanyAdvertisementId = advertisementId;
                advertisementService.SaveVisibleWant(x);
            }

            //felmeddelande om ej skapats

            //return RedirectToPage($"/ShowJobAdvertisement?AdvertisementId={advertisementId}");
            return RedirectToPage("ShowJobAdvertisement", new { advertisementid = advertisementId });


        }
    }
}
