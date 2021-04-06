using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;
using Merit.AdvertisementService;
using Merit.Data.Models;
using Merit.MeritService;
using Microsoft.AspNetCore.Identity;
using Microsoft.AspNetCore.Mvc;
using Microsoft.AspNetCore.Mvc.RazorPages;

namespace Merit.Web.Pages
{
    public class EditCompanyMeritsModel : PageModel
    {
        private IMeritService meritService = new MeritService.MeritService();
        private IAdvertisementService advertisementService = new AdvertisementService.AdvertisementService();

        private readonly UserManager<IdentityUser> userManager;
        private readonly SignInManager<IdentityUser> signInManager;

        public EditCompanyMeritsModel(UserManager<IdentityUser> userManager, SignInManager<IdentityUser> signInManager)
        {
            this.signInManager = signInManager;
            this.userManager = userManager;
        }

        [BindProperty]
        public List<CompanyMerit> CompanyMeritList { get; set; }
        [BindProperty]
        public CompanyMerit CMerit { get; set; }

        [BindProperty(SupportsGet = true)]
        public int SelectedMeritID { get; set; }
        [BindProperty]
        public string CategoryText { get; set; }
        [BindProperty]
        public string SubCategoryText { get; set; }
        [BindProperty]
        public string DescriptionText { get; set; }

        public string Message { get; set; }

        [BindProperty]
        public bool Visi { get; set; } = false;

        public bool Success { get; set; }


        public async Task<IActionResult> OnGetAsync()
        {
            if (!signInManager.IsSignedIn(User))
            {
                return Redirect("/Login");
            }

            IdentityUser identity = await userManager.GetUserAsync(User);
            IUser cUser = identity.GetUser();

            if (cUser is CompanyUser companyUser)
            {
                CompanyMeritList = meritService.ReadCompanyMerits(companyUser.CompanyUserId);
                if (SelectedMeritID != 0 && CompanyMeritList.FirstOrDefault(x => x.CompanyMeritId == SelectedMeritID) == null)
                {
                    return Redirect($"/CompanyInfoPage");
                }
            }
            else if (cUser is PersonalUser)
            {
                return Redirect("/PersonalInfoPage");
            }
            foreach (var merit in CompanyMeritList)
            {
                if (merit.CompanyMeritId == SelectedMeritID)
                {
                    SelectedMeritID = merit.CompanyMeritId;
                    CategoryText = merit.Category;
                    SubCategoryText = merit.SubCategory;
                    DescriptionText = merit.Description;
                }
            }
            if (SelectedMeritID != 0 && advertisementService.MeritExistsInAdvertisement(SelectedMeritID))
            {
                Success = false;
                Visi = true;
                Message = "Obs! Denna merit är länkad till en eller flera annonser.";
            }
            return Page();
        }
        public async Task OnPostEdit()
        {
            meritService.EditCompanyMerit(CMerit);
            Visi = true;
            Success = true;
            Message = "Merit ändrad!";
            SelectedMeritID = 0;
            await OnGetAsync();
        }
        public async Task OnPostDelete()
        {


            if (advertisementService.MeritExistsInAdvertisement(CMerit.CompanyMeritId))
            {
                Message = "Du kan inte ta bort meriten, den används i en annons.";
                Visi = true;
                Success = false;
                SelectedMeritID = 0;
            }
            else
            {
                meritService.DeleteCompanyMerit(CMerit);
                Visi = true;
                Success = true;
                Message = "Merit borttagen!";
                SelectedMeritID = 0;
            }
            await OnGetAsync();
        }
    }
}
