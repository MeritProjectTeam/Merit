using System;
using System.Collections.Generic;
using System.IO;
using System.Linq;
using System.Threading.Tasks;
using Merit.AccountService;
using Merit.CompanyService;
using Merit.Data.Models;
using Merit.MeritService;
using Merit.PersonalInfoService;
using Merit.WantsService;
using Microsoft.AspNetCore.Identity;
using Microsoft.AspNetCore.Mvc;
using Microsoft.AspNetCore.Mvc.RazorPages;

namespace Merit.Web.Pages
{
    public class CompanyInfoPageModel : PageModel
    {
        private ICompanyService companyService = new CompanyService.CompanyService();
        private IAccount accountService = new Account();
        private IMeritService meritService = new MeritService.MeritService();
        private IWantsService wantsService = new WantsService.WantsService();
        private IProfileService profileService = new ProfileService();

        private readonly UserManager<IdentityUser> userManager;
        private readonly SignInManager<IdentityUser> signInManager;

        public CompanyInfoPageModel(UserManager<IdentityUser> userManager, SignInManager<IdentityUser> signInManager)
        {
            this.signInManager = signInManager;
            this.userManager = userManager;
        }

        [BindProperty]
        public CompanyUser AUser { get; set; }
        [BindProperty]
        public CompanyInfo CompanyInfo { get; set; }
        [BindProperty]
        public List<CompanyMerit> CompanyMerits { get; set; }

        [BindProperty]
        public List<CompanyWants> CompanyWants { get; set; }
        [BindProperty]
        public string ImageUrl { get; set; }
        [BindProperty(SupportsGet =true)]
        public bool uploaded { get; set; }

        public async Task<IActionResult> OnGetAsync()
        {
            if (!signInManager.IsSignedIn(User))
            {
                return Redirect("/Login");
            }

            IdentityUser identity = await userManager.GetUserAsync(User);
            IUser cUser = identity.GetUser();

            AUser = accountService.GetCompanyUser(cUser.Identity);
            if (cUser is CompanyUser companyUser)
            {
                CompanyInfo = companyService.Get(companyUser.CompanyUserId);
                CompanyWants = wantsService.GetAllCompanyWants(companyUser.CompanyUserId);
                CompanyMerits = meritService.ReadCompanyMerits(companyUser.CompanyUserId);

            }
            CompanyImage img = await profileService.GetImage(AUser);
            if (img == null)
            {
                ImageUrl = "http://placehold.it/300x300";
            }
            else
            {
                string imageBase64Data = Convert.ToBase64String(img.ImageData);
                ImageUrl = string.Format($"data:image/jpg;base64, {imageBase64Data}");
            }
            return Page();
        }
       
       
        public async Task OnPostAsync()
        {
            if (!signInManager.IsSignedIn(User))
            {
                Redirect("/Login");
            }

            IdentityUser identity = await userManager.GetUserAsync(User);
            IUser cUser = identity.GetUser();

            AUser = accountService.GetCompanyUser(cUser.Identity);
            await UploadImageAsync();
            
        }

        public async Task<IActionResult> UploadImageAsync()
        {
            if (!signInManager.IsSignedIn(User))
            {
                return Redirect("/Login");
            }



            CompanyImage img = new CompanyImage();
            var files = Request.Form.Files;

            var file = files[0];
            img.ImageTitle = file.FileName;
            img.CompanyUserId = AUser.CompanyUserId;

            using (MemoryStream ms = new MemoryStream())
            {
                file.CopyTo(ms);
                img.ImageData = ms.ToArray();
            }
            await profileService.SaveImage(img);

            return await OnGetAsync();
        }
    }
}
