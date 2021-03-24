using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;
using Merit.AdvertisementService;
using Merit.Data.Models;
using Merit.MeritService;
using Merit.WantsService;
using Microsoft.AspNetCore.Mvc;
using Microsoft.AspNetCore.Mvc.RazorPages;

namespace Merit.Web.Pages
{
    //meriter och wants sparas inte
    //visa alla annonser även vid on post
    public class EditCompanyAdvertisementModel : PageModel
    {
        public IAdvertisementService advertisementService = new AdvertisementService.AdvertisementService();
        public IMeritService meritService = new MeritService.MeritService();
        public IWantsService wantsService = new WantsService.WantsService();

        public List<CompanyMerit> CompanyMerits { get; set; }
        public List<CompanyWants> CompanyWants { get; set; }

        int userId = AccountService.Account.CheckCookie();

        [BindProperty]
        public List<int> WantsId { get; set; }
        [BindProperty]
        public List<int> MeritsId { get; set; }


        [BindProperty]
        public CompanyAdvertisement SelectedAdvertisement { get; set; }

        [BindProperty(SupportsGet = true)]
        public int SelectedAdvertisementID { get; set; }

        [BindProperty]
        public List<CompanyAdvertisement> companyAdvertisements { get; set; }
        public void OnGet()
        {
            LoadDefaults();

            companyAdvertisements = advertisementService.GetAllCompanyAdvertisements(userId);

            if (SelectedAdvertisementID != 0)
            {
                SelectedAdvertisement = advertisementService.GetOneCompanyAdvertisement(SelectedAdvertisementID);
            }
        }

        private void LoadDefaults()
        {
            CompanyWants = wantsService.GetAllCompanyWants(userId);
            CompanyMerits = meritService.ReadCompanyMerits(userId);
        }

        public IActionResult OnPostEdit()
        {
            LoadDefaults();

            advertisementService.DeleteVisibleMerits(SelectedAdvertisement.CompanyAdvertisementId);
            advertisementService.DeleteVisibleWants(SelectedAdvertisement.CompanyAdvertisementId);

            foreach (var id in MeritsId)
            {
                VisibleMerit x = new();
                x.CompanyAdvertisementId = SelectedAdvertisement.CompanyAdvertisementId;
                x.CompanyMeritId = id;
                advertisementService.SaveVisibleMerit(x);
            }
            foreach (var id in WantsId)
            {
                VisibleWant x = new();
                x.CompanyAdvertisementId = SelectedAdvertisement.CompanyAdvertisementId;
                x.CompanyWantsId = id;
                advertisementService.SaveVisibleWant(x);
            }

            advertisementService.EditCompanyAdvertisement(SelectedAdvertisement);

            return RedirectToPage();
        }
        public IActionResult OnPostDelete()
        {
            LoadDefaults();
            advertisementService.DeleteCompanyAdvertisement(SelectedAdvertisement.CompanyAdvertisementId);
            return RedirectToPage();
        }
    }
}
