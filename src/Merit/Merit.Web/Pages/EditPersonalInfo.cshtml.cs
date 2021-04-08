using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;
using Microsoft.AspNetCore.Mvc;
using Microsoft.AspNetCore.Mvc.RazorPages;
using Merit.PersonalInfoService;
using Merit.Data.Models;
using Microsoft.EntityFrameworkCore;
using Microsoft.AspNetCore.Identity;
using Merit.AccountService;

namespace Merit.Web.Pages
{
    public class EditPersonalInfoModel : PageModel
    {
        private readonly IProfileService profileService = new ProfileService();
        private readonly UserManager<IdentityUser> userManager;
        private readonly SignInManager<IdentityUser> signInManager;
        private readonly IAccount accountService = new Account();

        public EditPersonalInfoModel(UserManager<IdentityUser> userManager, SignInManager<IdentityUser> signInManager)
        {
            this.signInManager = signInManager;
            this.userManager = userManager;
        }

        [BindProperty]
        public string Information { get; set; }
        [BindProperty]
        public PersonalInfo APerson { get; set; }

        public bool Visi { get; set; }

        public async Task<IActionResult> OnGetAsync()
        {
            if (!signInManager.IsSignedIn(User))
            {
                return Redirect("/Login");
            }

            IdentityUser identity = await userManager.GetUserAsync(User);
            IUser pUser = identity.GetUser();
            Information = "";
            if (pUser is PersonalUser personalUser)
            {
                APerson = profileService.Get(personalUser.PersonalUserId);
            }
            else if (pUser is CompanyUser)
            {
                return Redirect("/CompanyInfoPage");
            }
            return Page();
        }
        public async Task<IActionResult> OnPostAsync()
        {
            if (!signInManager.IsSignedIn(User))
            {
                return Redirect("/Login");
            }

            IdentityUser identity = await userManager.GetUserAsync(User);
            IUser pUser = identity.GetUser();
            Visi = true;
            Information = "Profilinfo sparad.";
            if (pUser is PersonalUser personalUser)
            {
                APerson.PersonalUserId = personalUser.PersonalUserId;
            }
            profileService.EditPersonalInfo(APerson);
            return Page();
        }
        public async Task<IActionResult> OnPostDeleteAsync()
        {
            if (!signInManager.IsSignedIn(User))
            {
                return Redirect("/Login");
            }

            IdentityUser identity = await userManager.GetUserAsync(User);
            IUser pUser = identity.GetUser();
           
            
            if (pUser is PersonalUser personalUser)
            {
                APerson.PersonalUserId = personalUser.PersonalUserId;
            }
            accountService.DeletePersonalUser(APerson.PersonalUserId);
            await signInManager.SignOutAsync();
            await userManager.DeleteAsync(identity);

            return RedirectToPage("/ConfirmedRemovedAccount");
        }
    }
}
