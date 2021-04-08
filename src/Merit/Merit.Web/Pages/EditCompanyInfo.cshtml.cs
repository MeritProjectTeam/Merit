using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;
using Merit.CompanyService;
using Microsoft.AspNetCore.Mvc;
using Microsoft.AspNetCore.Mvc.RazorPages;
using Merit.Data.Models;
using Microsoft.AspNetCore.Identity;
using Merit.AccountService;

namespace Merit.Web.Pages
{
    public class EditCompanyInfoModel : PageModel
    {
        private readonly ICompanyService companyService = new CompanyService.CompanyService();
        private readonly IAccount accountService = new Account();

        private readonly UserManager<IdentityUser> userManager;
        private readonly SignInManager<IdentityUser> signInManager;

        public EditCompanyInfoModel(UserManager<IdentityUser> userManager, SignInManager<IdentityUser> signInManager)
        {
            this.signInManager = signInManager;
            this.userManager = userManager;
        }

        [BindProperty]
        public string Message { get; set; }
        [BindProperty]
        public CompanyInfo ACompany { get; set; }
        public bool Visi { get; set; }

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
                ACompany = companyService.Get(companyUser.CompanyUserId);
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

            Visi = true;
            Message = "Företagsinfo sparad.";
            if (cUser is CompanyUser companyUser)
            {
                ACompany.CompanyUserId = companyUser.CompanyUserId;
            }
            else if (cUser is PersonalUser)
            {
                return Redirect("/PersonalInfoPage");
            }
            companyService.EditCompanyInfo(ACompany);
            
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
            
            if (pUser is CompanyUser companyUser)
            {
                ACompany.CompanyUserId = companyUser.CompanyUserId;
            }
            accountService.DeleteCompanyUser(ACompany.CompanyUserId);
            await signInManager.SignOutAsync();
            await userManager.DeleteAsync(identity);

            return RedirectToPage("/ConfirmedRemovedAccount");
        }
    }
}
