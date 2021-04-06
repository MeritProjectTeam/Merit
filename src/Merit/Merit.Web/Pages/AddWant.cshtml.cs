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
    public class AddWantModel : PageModel
    {
        
        private readonly IWantsService wantsService = new WantsService.WantsService();
        private readonly UserManager<IdentityUser> userManager;
        private readonly SignInManager<IdentityUser> signInManager;

        public AddWantModel(UserManager<IdentityUser> userManager, SignInManager<IdentityUser> signInManager)
        {
            this.signInManager = signInManager;
            this.userManager = userManager;
        }



        public bool Visi { get; set; }
        [BindProperty]
        public PersonalWants PersonalWant { get; set; }
        public string Message { get; set; }
        public string alertlook { get; set; }

        public async Task<IActionResult> OnGetAsync()
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
            if (pUser is CompanyUser)
            {
                return Redirect("/CompanyInfoPage");
            }
            Visi = true;
            if (PersonalWant.Want != null)
            {
                Message = "Önskemål skapat!";
                alertlook = "success";
                if (pUser is PersonalUser personalUser)
                {
                    PersonalWant.PersonalUserId = personalUser.PersonalUserId;
                }
                wantsService.CreatePersonalWant(PersonalWant);
            }
            else
            {
                Message = "Fyll i rutan!";
                alertlook = "danger";
            }
            return Page();
        }
    }
}
