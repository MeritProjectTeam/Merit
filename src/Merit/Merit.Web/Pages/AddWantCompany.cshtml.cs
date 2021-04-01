using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;
using Merit.Data.Models;
using Merit.WantsService;
using Microsoft.AspNetCore.Identity;
using Microsoft.AspNetCore.Mvc;
using Microsoft.AspNetCore.Mvc.RazorPages;

namespace Merit.Web.Pages
{
    public class AddWantCompanyModel : PageModel
    {
        private readonly IWantsService wantsService = new WantsService.WantsService();

        private readonly UserManager<IdentityUser> userManager;
        private readonly SignInManager<IdentityUser> signInManager;

        public AddWantCompanyModel(UserManager<IdentityUser> userManager, SignInManager<IdentityUser> signInManager)
        {
            this.signInManager = signInManager;
            this.userManager = userManager;
        }
        public bool Visi { get; set; } = false;
        [BindProperty]
        public CompanyWants CompanyWant { get; set; }
        public string Message { get; set; }
        public string alertlook { get; set; }
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
            if (CompanyWant.Want != null)
            {
                alertlook = "success";
                Message = "Önskemål skapat!";
                if (cUser is CompanyUser companyUser)
                {
                    CompanyWant.CompanyUserId = companyUser.CompanyUserId;
                }
                wantsService.CreateCompanyWant(CompanyWant);
            }
            else
            {
                Message = "Fyll i rutan";
                alertlook = "danger";
            }
            return Page();
        }
    }
}
