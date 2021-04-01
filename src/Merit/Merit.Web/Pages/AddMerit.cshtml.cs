using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;
using Microsoft.AspNetCore.Mvc;
using Microsoft.AspNetCore.Mvc.RazorPages;
using Merit.MeritService;
using Merit.Data.Models;
using Microsoft.AspNetCore.Identity;
using System.Security.Claims;

namespace Merit.Web.Pages
{
    public class AddMeritModel : PageModel
    {
        IMeritService meritService = new MeritService.MeritService();

        private readonly UserManager<IdentityUser> userManager;
        private readonly SignInManager<IdentityUser> signInManager;

        public AddMeritModel(UserManager<IdentityUser> userManager, SignInManager<IdentityUser> signInManager)
        {
            this.signInManager = signInManager;
            this.userManager = userManager;
        }

        [BindProperty]
        public PersonalMerit AMerit { get; set; }
        public bool Visi { get; set; }
        public string Message { get; set; }
        public string alertlook { get; set; }

        public void OnGet()
        {
            
        }
        public async Task<IActionResult> OnPostAsync()
        {
            if (!signInManager.IsSignedIn(User))
            {
                return Redirect("/Login");
            }

            IdentityUser identity = await userManager.GetUserAsync(User);
            IUser pUser = identity.GetUser();
            if (pUser is CompanyUser)
            {
                return Redirect("/CompanyInfoPage");
            }

            Visi = true;
            if (AMerit.Category != null && AMerit.SubCategory != null && AMerit.Description != null)
            {
                Message = "Merit skapat!";
                alertlook = "success";
                if (pUser is PersonalUser personalUser)
                {
                    AMerit.PersonalUserId = personalUser.PersonalUserId;
                }
                meritService.SaveMerit(AMerit);
            }
            else
            {
                alertlook = "danger";
                Message = "Fyll i rutorna!";
            }
            return Page();
        }
    }
}
