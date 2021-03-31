using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;
using Microsoft.AspNetCore.Mvc;
using Microsoft.AspNetCore.Mvc.RazorPages;
using Merit.MeritService;
using Merit.Data.Models;
using Merit.PersonalInfoService;
using Microsoft.EntityFrameworkCore;
using Microsoft.AspNetCore.Identity;

namespace Merit.Web.Pages
{
    public class EditPersonalMeritsModel : PageModel
    {
        private readonly IMeritService meritService = new MeritService.MeritService();
        private readonly UserManager<IdentityUser> userManager;
        private readonly SignInManager<IdentityUser> signInManager;

        public EditPersonalMeritsModel(UserManager<IdentityUser> userManager, SignInManager<IdentityUser> signInManager)
        {
            this.signInManager = signInManager;
            this.userManager = userManager;
        }

        [BindProperty(SupportsGet  = true)]
        public List<PersonalMerit> MeritList { get; set; }

        [BindProperty(SupportsGet=true)]
        public int SelectedMeritID { get; set; }
        [BindProperty]
        public string CategoryText { get; set; }
        [BindProperty]
        public string SubCategoryText { get; set; }
        [BindProperty]
        public string DescriptionText { get; set; }
        [BindProperty]
        public string DurationText { get; set; }
        [BindProperty]
        public PersonalMerit PMerit { get; set; }

        public string Message { get; set; }

        [BindProperty(SupportsGet = true)]
        public bool Visi { get; set; } = false;


        public async Task<IActionResult> OnGetAsync()
        {
            if (!signInManager.IsSignedIn(User))
            {
                return Redirect("/Login");
            }

            IdentityUser identity = await userManager.GetUserAsync(User);
            string guid = identity.Id;
            IUser pUser = identity.GetUser();

            if (pUser is PersonalUser personalUser)
            {
                MeritList = meritService.ReadPersonalMerits(personalUser.PersonalUserId);
            }
            foreach (var merit in MeritList)
            {
                if (merit.PersonalMeritId == SelectedMeritID) 
                {
                    SelectedMeritID = merit.PersonalMeritId;
                    CategoryText = merit.Category;
                    SubCategoryText = merit.SubCategory;
                    DescriptionText = merit.Description;
                    DurationText = merit.Duration;
                }
            }
            return Page();
        }
        public async Task OnPostEdit()
        {
            Visi = true;
            meritService.EditPersonalMerit(PMerit);
            Message = "Merit ändrad";
            SelectedMeritID = 0;
            await OnGetAsync();
        }

        public async Task OnPostDelete()
        {
            meritService.DeletePersonalMerit(PMerit);
            Visi = true;
            Message = "Merit borttagen";
            SelectedMeritID = 0;
            await OnGetAsync();
        }
    }
}
