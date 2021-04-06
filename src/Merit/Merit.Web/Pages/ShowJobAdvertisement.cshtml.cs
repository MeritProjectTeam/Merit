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
using Microsoft.AspNetCore.Identity;
using Microsoft.AspNetCore.Mvc;
using Microsoft.AspNetCore.Mvc.RazorPages;

namespace Merit.Web.Pages
{
    public class ShowJobAdvertisementModel : PageModel
    {
        private IAdvertisementService advertisementService = new AdvertisementService.AdvertisementService();
        private ICompanyService companyService = new CompanyService.CompanyService();
        private IAccount accountService = new Account();

        private readonly UserManager<IdentityUser> userManager;
        private readonly SignInManager<IdentityUser> signInManager;

        public ShowJobAdvertisementModel(UserManager<IdentityUser> userManager, SignInManager<IdentityUser> signInManager)
        {
            this.signInManager = signInManager;
            this.userManager = userManager;
        }

        [BindProperty(SupportsGet = true)]
        public int AdvertisementId { get; set; }

        [BindProperty(SupportsGet = true)]
        public string SearchTerm { get; set; }

        [BindProperty(SupportsGet = true)]
        public int SearchType { get; set; }
        [BindProperty]
        public bool CompanyUser { get; set; }
        [BindProperty]
        public CompanyUser AUser { get; set; }

        [BindProperty]
        public CompanyInfo CompanyInfo { get; set; }

        [BindProperty]
        public CompanyAdvertisement CompanyAdvertisement { get; set; }
        [BindProperty]
        public List<CompanyMerit> AdvertisementMerits { get; set; }

        [BindProperty]
        public List<CompanyWants> AdvertisementWants { get; set; }

        public async Task<IActionResult> OnGetAsync()
        {
            
            
            if(signInManager.IsSignedIn(User))
            {
                IdentityUser identity = await userManager.GetUserAsync(User);
                IUser cUser = identity.GetUser();
                if(cUser is CompanyUser)
                { AUser = accountService.GetCompanyUser(cUser.Identity);
                    CompanyUser = true;
                }
                else { CompanyUser = false; }
                 }
            
            
            
            CompanyAdvertisement = advertisementService.GetOneCompanyAdvertisement(AdvertisementId);
            CompanyInfo = companyService.Get(CompanyAdvertisement.CompanyUserId);
            AdvertisementMerits = advertisementService.GetAdvertisementMerits(AdvertisementId);
            AdvertisementWants = advertisementService.GetAdvertisementWants(AdvertisementId);

            return Page();

        }

    }
}
