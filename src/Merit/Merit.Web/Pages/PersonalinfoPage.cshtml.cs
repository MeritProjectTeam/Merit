using Merit.AccountService;
using Merit.Data.Models;
using Merit.MeritService;
using Merit.PersonalInfoService;
using Merit.WantsService;
using Microsoft.AspNetCore.Mvc;
using Microsoft.AspNetCore.Mvc.RazorPages;
using System;
using System.Collections.Generic;
using System.IO;
using System.Threading.Tasks;
using System.Threading;
using Microsoft.AspNetCore.Identity;

namespace Merit.Web.Pages
{
    public class PersonalinfoPageModel : PageModel
    {
        private IProfileService profileService = new ProfileService();
        private IAccount accountService = new Account();
        private IMeritService meritService = new MeritService.MeritService();
        private IWantsService wantsService = new WantsService.WantsService();

        private readonly UserManager<IdentityUser> userManager;
        private readonly SignInManager<IdentityUser> signInManager;

        public PersonalinfoPageModel(UserManager<IdentityUser> userManager, SignInManager<IdentityUser> signInManager)
        {
            this.signInManager = signInManager;
            this.userManager = userManager;
        }

        [BindProperty]
        public PersonalUser AUser { get; set; }
        [BindProperty]
        public PersonalInfo PersonalInfo { get; set; }
        [BindProperty]
        public List<PersonalMerit> PersonalMerits { get; set; }

        [BindProperty]
        public List<PersonalWants> PersonalWants { get; set; }

        [BindProperty]
        public string ImageUrl { get; set; }
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
            AUser = accountService.GetPersonalUser(pUser.Identity);
            PersonalImage img = await profileService.GetImage(AUser);
            if (img == null)
            {
                ImageUrl = "http://placehold.it/300x300";
            }
            else
            {
                string imageBase64Data = Convert.ToBase64String(img.ImageData);
                ImageUrl = string.Format($"data:image/jpg;base64, {imageBase64Data}");
            }
            if (pUser is PersonalUser personalUser)
            {
                PersonalInfo = profileService.Get(personalUser.PersonalUserId);
                PersonalWants = wantsService.GetAllPersonalWants(personalUser.PersonalUserId);
                PersonalMerits = meritService.ReadPersonalMerits(personalUser.PersonalUserId);
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
            AUser = accountService.GetPersonalUser(pUser.Identity);
            await UploadImage();
            return await OnGetAsync();
        }

        public async Task UploadImage()
        {
            PersonalImage img = new PersonalImage();
            var files = Request.Form.Files;
            var file = files[0];
            img.ImageTitle = file.FileName;
            img.PersonalUserId = AUser.PersonalUserId;
            
            using (MemoryStream ms = new MemoryStream())
            {
                file.CopyTo(ms);
                img.ImageData = ms.ToArray();
            }
            await profileService.SaveImage(img);
        }
        
       
    }
}
