using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;
using Merit.Data.Models;
using Merit.MatchService;
using Microsoft.AspNetCore.Identity;
using Microsoft.AspNetCore.Mvc;
using Microsoft.AspNetCore.Mvc.RazorPages;

namespace Merit.Web.Pages
{
    public class AutomaticMatchModel : PageModel
    {
        private readonly SignInManager<IdentityUser> signInManager;
        private readonly UserManager<IdentityUser> userManager;
        private readonly IMatchService matchService = new MatchService.MatchService();

        public List<CompanyUser> ListOfMatchingCompanyUsers { get; set; }
        public List<PersonalUser> ListOfMatchingPersonalUsers { get; set; }
        public List<CompanyAdvertisement> ListOfMatchingAdvertisiment { get; set; }
        public IUser AUser { get; set; }

        public AutomaticMatchModel(SignInManager<IdentityUser> signInManager, UserManager<IdentityUser> userManager)
        {
            this.signInManager = signInManager;
            this.userManager = userManager;
        }

        public async Task<IActionResult> OnGetAsync()
        {
            if(!signInManager.IsSignedIn(User))
            {
                return Redirect("/Login");
            }
            IdentityUser identity = await userManager.GetUserAsync(User);
            AUser = identity.GetUser();

            if (AUser is PersonalUser personalUser)
            {
                ListOfMatchingCompanyUsers = matchService.MatchPersonalUser(personalUser);
                ListOfMatchingAdvertisiment = matchService.MatchAdvertisement(personalUser);
            }

            else if (AUser is CompanyUser companyUser)
            {
                ListOfMatchingPersonalUsers = matchService.MatchCompanyUser(companyUser);
            }
            return Page();
        }
    }
}
