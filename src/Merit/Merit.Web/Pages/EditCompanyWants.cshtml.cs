using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;
using Merit.AdvertisementService;
using Merit.Data.Models;
using Merit.WantsService;
using Microsoft.AspNetCore.Identity;
using Microsoft.AspNetCore.Mvc;
using Microsoft.AspNetCore.Mvc.RazorPages;

namespace Merit.Web.Pages
{
    public class EditCompanyWantsModel : PageModel
    {
        private IWantsService wService = new WantsService.WantsService();
        private IAdvertisementService advertisementService = new AdvertisementService.AdvertisementService();

        private readonly UserManager<IdentityUser> userManager;
        private readonly SignInManager<IdentityUser> signInManager;

        public EditCompanyWantsModel(UserManager<IdentityUser> userManager, SignInManager<IdentityUser> signInManager)
        {
            this.signInManager = signInManager;
            this.userManager = userManager;
        }

        [BindProperty]
        public List<CompanyWants> CompanyWantsList { get; set; }

        [BindProperty(SupportsGet = true)]
        public int SelectedCompanyWantId { get; set; }

        [BindProperty]
        public string WantText { get; set; }

        [BindProperty]
        public CompanyWants CWant { get; set; }

        public string Message { get; set; }

        [BindProperty]
        public bool Visi { get; set; } = false;

        [BindProperty]
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
                CompanyWantsList = wService.GetAllCompanyWants(companyUser.CompanyUserId);
                if (SelectedCompanyWantId != 0 && CompanyWantsList.FirstOrDefault(x => x.CompanyWantsId == SelectedCompanyWantId) == null)
                {
                    return Redirect($"/CompanyInfoPage");
                }
            }
            else if (cUser is PersonalUser)
            {
                return Redirect("/PersonalInfoPage");
            }
            foreach (var want in CompanyWantsList)
            {
                if (want.CompanyWantsId == SelectedCompanyWantId)
                {
                    SelectedCompanyWantId = want.CompanyWantsId;
                    WantText = want.Want;
                }

            }

            if (SelectedCompanyWantId != 0 && advertisementService.WantExistsInAdvertisement(SelectedCompanyWantId))
            {
                Success = false;
                Visi = true;
                Message = "Obs! Denna want är länkad till en eller flera annonser.";
            }
            return Page();
        }

        public async Task OnPostEdit()
        {

            wService.EditCompanyWant(CWant);
            Visi = true;
            Success = true;
            Message = "Önskemål ändrat";
            SelectedCompanyWantId = 0;
            await OnGetAsync();
        }

        public async Task OnPostDelete()
        {

            if (advertisementService.WantExistsInAdvertisement(CWant.CompanyWantsId))
            {
                Message = "Du kan inte ta bort wanten, den används i en annons.";
                Visi = true;
                Success = false;
                SelectedCompanyWantId = 0;
            }
            else
            {
                wService.DeleteCompanyWant(CWant);
                Visi = true;
                Success = true;
                Message = "Önskemål borttaget";
                SelectedCompanyWantId = 0;
            }

            await OnGetAsync();
        }
    }
}
