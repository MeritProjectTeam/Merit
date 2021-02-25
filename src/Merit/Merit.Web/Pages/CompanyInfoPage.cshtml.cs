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
        public void OnGet()
        {
            int userId = Account.CheckCookie();
            AUser = accountService.GetCompanyUser(userId);
            CompanyInfo = companyService.Get(userId);
            CompanyImage img = profileService.GetImage(AUser);
            if (img == null)
            {
                ImageUrl = "http://placehold.it/300x300";
            }
            else
            {
                string imageBase64Data = Convert.ToBase64String(img.ImageData);
                ImageUrl = string.Format($"data:image/jpg;base64, {imageBase64Data}");
            }
            CompanyWants = wantsService.GetCompanyWants(userId);
           
            CompanyMerits = meritService.ReadCompanyMerits(userId);
        }
       
       
        public void OnPost()
        {
            int userId = Account.CheckCookie();
            AUser = accountService.GetCompanyUser(userId);
            UploadImage();
        }

        public IActionResult UploadImage()
        {
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
            profileService.SaveImage(img);

            return RedirectToPage();
        }
    }
}
