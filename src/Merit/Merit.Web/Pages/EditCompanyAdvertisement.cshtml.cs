using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;
using Merit.AdvertisementService;
using Merit.Data.Models;
using Merit.MeritService;
using Merit.WantsService;
using Microsoft.AspNetCore.Identity;
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

        private readonly UserManager<IdentityUser> userManager;
        private readonly SignInManager<IdentityUser> signInManager;

        public EditCompanyAdvertisementModel(UserManager<IdentityUser> userManager, SignInManager<IdentityUser> signInManager)
        {
            this.signInManager = signInManager;
            this.userManager = userManager;
        }

        public List<CompanyMerit> CompanyMerits { get; set; }
        public List<CompanyWants> CompanyWants { get; set; }


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
        public async Task<IActionResult> OnGet()
        {
            if (!signInManager.IsSignedIn(User))
            {
                return Redirect("/Login");
            }

            IdentityUser identity = await userManager.GetUserAsync(User);
            IUser cUser = identity.GetUser();

            if (cUser is CompanyUser companyUser)
            {
                companyAdvertisements = advertisementService.GetAllCompanyAdvertisements(companyUser.CompanyUserId);
                LoadDefaults(companyUser);
            }
            else if (cUser is PersonalUser)
            {
                return Redirect("/PersonalInfoPage");
            }



            if (SelectedAdvertisementID != 0)
            {
                SelectedAdvertisement = advertisementService.GetOneCompanyAdvertisement(SelectedAdvertisementID);
            }
            return Page();
        }

        private void LoadDefaults(CompanyUser companyUser)
        {
            CompanyWants = wantsService.GetAllCompanyWants(companyUser.CompanyUserId);
            CompanyMerits = meritService.ReadCompanyMerits(companyUser.CompanyUserId);
        }

        public async Task<IActionResult> OnPostEdit()
        {
            if (!signInManager.IsSignedIn(User))
            {
                return Redirect("/Login");
            }

            IdentityUser identity = await userManager.GetUserAsync(User);
            IUser cUser = identity.GetUser();

            if (cUser is CompanyUser companyUser)
            {
                LoadDefaults(companyUser);
            }
            else if (cUser is PersonalUser)
            {
                return Redirect("/PersonalInfoPage");
            }

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
        public async Task<IActionResult> OnPostDelete()
        {
            if (!signInManager.IsSignedIn(User))
            {
                return Redirect("/Login");
            }

            IdentityUser identity = await userManager.GetUserAsync(User);
            IUser cUser = identity.GetUser();

            if (cUser is CompanyUser companyUser)
            {
                LoadDefaults(companyUser);
            }
            else if (cUser is PersonalUser)
            {
                return Redirect("/PersonalInfoPage");
            }
            advertisementService.DeleteCompanyAdvertisement(SelectedAdvertisement.CompanyAdvertisementId);
            return RedirectToPage();
        }
    }
}
