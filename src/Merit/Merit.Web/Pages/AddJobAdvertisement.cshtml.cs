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
using Microsoft.AspNetCore.Identity;

namespace Merit.Web.Pages
{
    public class AddJobAdvertisementModel : PageModel
    {
        [BindProperty]
        public int myString { get; set; }

        public IMeritService meritService = new MeritService.MeritService();
        public IWantsService wantsService = new WantsService.WantsService();
        public IAdvertisementService advertisementService = new AdvertisementService.AdvertisementService();

        private readonly UserManager<IdentityUser> userManager;
        private readonly SignInManager<IdentityUser> signInManager;

        public AddJobAdvertisementModel(UserManager<IdentityUser> userManager, SignInManager<IdentityUser> signInManager)
        {
            this.signInManager = signInManager;
            this.userManager = userManager;
        }
        [BindProperty]
        public List<int> WantsId { get; set; }
        [BindProperty]
        public List<int> MeritsId { get; set; }
        public List<CompanyMerit> CompanyMerits { get; set; }
        public List<CompanyWants> CompanyWants { get; set; }
        [BindProperty]
        public CompanyAdvertisement CompanyAdd { get; set; }
        [BindProperty]
        public int CompanyUserId { get; set; }
        public async Task<IActionResult> OnGet()
        {
            if (!signInManager.IsSignedIn(User))
            {
                return Redirect("/Login");
            }

            IdentityUser identity = await userManager.GetUserAsync(User);
            IUser pUser = identity.GetUser();
            if (pUser is PersonalUser)
            {
                return Redirect("/PersonalInfoPage");
            }
            else if (pUser is CompanyUser companyUser)
            {
                CompanyMerits = meritService.ReadCompanyMerits(companyUser.CompanyUserId);
                CompanyWants = wantsService.GetAllCompanyWants(companyUser.CompanyUserId);
                CompanyUserId = companyUser.CompanyUserId;
            }

            return Page();
        }

        public async Task<IActionResult> OnPost()
        {
            if (!signInManager.IsSignedIn(User))
            {
                return Redirect("/Login");
            }

            IdentityUser identity = await userManager.GetUserAsync(User);
            IUser pUser = identity.GetUser();
            if (pUser is PersonalUser)
            {
                return Redirect("/PersonalInfoPage");
            }
            else if (pUser is CompanyUser companyUser)
            {
                CompanyMerits = meritService.ReadCompanyMerits(companyUser.CompanyUserId);
                CompanyWants = wantsService.GetAllCompanyWants(companyUser.CompanyUserId);
                CompanyUserId = companyUser.CompanyUserId;
            }


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

            return RedirectToPage("ShowJobAdvertisement", new { advertisementid = advertisementId });


        }
    }
}
