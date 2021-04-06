using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;
using Merit.Data.Models;
using Merit.WantsService;
using Microsoft.AspNetCore.Mvc;
using Microsoft.AspNetCore.Mvc.RazorPages;
using Merit.AccountService;
using Microsoft.AspNetCore.Identity;

namespace Merit.Web.Pages
{
    public class EditPersonalWantsModel : PageModel
    {
        private IWantsService wService = new WantsService.WantsService();

        private readonly UserManager<IdentityUser> userManager;
        private readonly SignInManager<IdentityUser> signInManager;

        public EditPersonalWantsModel(UserManager<IdentityUser> userManager, SignInManager<IdentityUser> signInManager)
        {
            this.signInManager = signInManager;
            this.userManager = userManager;
        }


        [BindProperty(SupportsGet = true)]
        public List<PersonalWants> PersonalWantsList { get; set; }

        [BindProperty(SupportsGet = true)]
        public int SelectedPersonalWantId { get; set; }
        [BindProperty]
        public string WantText { get; set; }
        [BindProperty]
        public PersonalWants PWant { get; set; }

        public string Message { get; set; }
        public string alertlook { get; set; }

        [BindProperty(SupportsGet = true)]
        public bool Visi { get; set; } = false;

        public async Task<IActionResult> OnGetAsync()
        {
            if (!signInManager.IsSignedIn(User))
            {
                return Redirect("/Login");
            }

            IdentityUser identity = await userManager.GetUserAsync(User);
            IUser pUser = identity.GetUser();

            if (pUser is PersonalUser personalUser)
            {
                PersonalWantsList = wService.GetAllPersonalWants(personalUser.PersonalUserId);
            }
            else if (pUser is CompanyUser)
            {
                return Redirect("/CompanyInfoPage");
            }
            foreach (var want in PersonalWantsList)
            {
                if (want.PersonalWantsID == SelectedPersonalWantId)
                {
                    SelectedPersonalWantId = want.PersonalWantsID;
                    WantText = want.Want;
                }

            }
            return Page();
        }

        public async Task OnPostEdit()
        {
            wService.EditPersonalWant(PWant);
            Visi = true;
            alertlook = "success";
            Message = "Önskemål ändrat";
            SelectedPersonalWantId = 0;
            await OnGetAsync();
        }

        public async Task OnPostDelete()
        {
            wService.DeletePersonalWant(PWant);
            Visi = true;
            alertlook = "danger";
            Message = "Önskemål borttaget";
            SelectedPersonalWantId = 0;
            await OnGetAsync();
        }
    }
}
