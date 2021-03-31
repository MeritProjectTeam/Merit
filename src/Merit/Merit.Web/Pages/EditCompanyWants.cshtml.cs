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
    public class EditCompanyWantsModel : PageModel
    {
        private IWantsService wService = new WantsService.WantsService();

        private readonly UserManager<IdentityUser> userManager;
        private readonly SignInManager<IdentityUser> signInManager;

        public EditCompanyWantsModel(UserManager<IdentityUser> userManager, SignInManager<IdentityUser> signInManager)
        {
            this.signInManager = signInManager;
            this.userManager = userManager;
        }

        [BindProperty(SupportsGet = true)]
        public List<CompanyWants> CompanyWantsList { get; set; }

        [BindProperty(SupportsGet = true)]
        public int SelectedCompanyWantId { get; set; }

        [BindProperty]
        public string WantText { get; set; }

        [BindProperty]
        public CompanyWants CWant { get; set; }

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
            IUser cUser = identity.GetUser();

            if (cUser is CompanyUser companyUser)
            {
                CompanyWantsList = wService.GetAllCompanyWants(companyUser.CompanyUserId);
            }
            foreach (var want in CompanyWantsList)
            {
                if(want.CompanyWantsId == SelectedCompanyWantId)
                {
                    SelectedCompanyWantId = want.CompanyWantsId;
                    WantText = want.Want;
                }

            }
            return Page();
        }

        public void OnPostEdit()
        {
            wService.EditCompanyWant(CWant);
            Visi = true;
            Message = "Önskemål ändrat";
            SelectedCompanyWantId = 0;
            Redirect("/EditCompanyWants");
        }

        public void OnPostDelete()
        {
            wService.DeleteCompanyWant(CWant);
            Visi = true;
            Message = "Önskemål borttaget";
            SelectedCompanyWantId = 0;
            Redirect("/EditCompanyWants");
        }
    }
}
