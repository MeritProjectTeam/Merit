using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;
using Merit.Data.Models;
using Merit.MeritService;
using Microsoft.AspNetCore.Identity;
using Microsoft.AspNetCore.Mvc;
using Microsoft.AspNetCore.Mvc.RazorPages;

namespace Merit.Web.Pages
{
    public class AddMeritBusinessModel : PageModel
    {
        public bool Visi { get; set; } = false;
        
        IMeritService CompanyMeritService = new MeritService.MeritService();

        private readonly UserManager<IdentityUser> userManager;
        private readonly SignInManager<IdentityUser> signInManager;

        public AddMeritBusinessModel(UserManager<IdentityUser> userManager, SignInManager<IdentityUser> signInManager)
        {
            this.signInManager = signInManager;
            this.userManager = userManager;
        }

        [BindProperty]
        public CompanyMerit ACompanyMerit { get; set; }
        [BindProperty]
        public string Information { get; set; }
        public string alertlook { get; set; }
        public bool TESTING { get; set; }


        public async Task<IActionResult> OnGetAsync()
        {
            if (!signInManager.IsSignedIn(User))
            {
                return Redirect("/Login");
            }

            IdentityUser identity = await userManager.GetUserAsync(User);
            IUser cUser = identity.GetUser();
            if (cUser is PersonalUser)
            {
                return Redirect("/PersonalInfoPage");
            }
            Information = "";
            return Page();
        }

        public async Task<IActionResult> OnPostAsync()
        {
            if (!signInManager.IsSignedIn(User))
            {
                return Redirect("/Login");
            }

            IdentityUser identity = await userManager.GetUserAsync(User);
            IUser cUser = identity.GetUser();
            if (cUser is PersonalUser)
            {
                return Redirect("/PersonalInfoPage");
            }

            Visi = true;
            if (ACompanyMerit.Category != null && ACompanyMerit.SubCategory != null && ACompanyMerit.Description != null)
            {
                if (cUser is CompanyUser companyUser)
                {
                    ACompanyMerit.CompanyUserId = companyUser.CompanyUserId;
                }
                CompanyMeritService.SaveMeritBusiness(ACompanyMerit);
                alertlook = "success";
                Information = "Merit sparad!";
                TESTING = true;
            }
            else
            {
                Information = "Fyll i uppgifterna!";
                alertlook = "danger";
            }
            return Page();

        }
    }
}
