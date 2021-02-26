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

namespace Merit.Web.Pages
{
    public class PersonalinfoPageModel : PageModel
    {
        private IProfileService profileService = new ProfileService();
        private IAccount accountService = new Account();
        private IMeritService meritService = new MeritService.MeritService();
        private IWantsService wantsService = new WantsService.WantsService();
        
        
        


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
        public void OnGet()
        {
            int userId = Account.CheckCookie();

            AUser = accountService.GetPersonalUser(userId);
            PersonalImage img = profileService.GetImage(AUser);
            if (img == null)
            {
                ImageUrl = "http://placehold.it/300x300";
            }
            else
            {
                string imageBase64Data = Convert.ToBase64String(img.ImageData);
                ImageUrl = string.Format($"data:image/jpg;base64, {imageBase64Data}");
            }
            PersonalInfo = profileService.Get(userId);
            PersonalWants = wantsService.GetAllPersonalWants(userId);
            
            PersonalMerits = meritService.ReadPersonalMerits(userId);
        }
        public void OnPost()
        {
            int userId = Account.CheckCookie();
            AUser = accountService.GetPersonalUser(userId);
            UploadImage();
        }

        public IActionResult UploadImage()
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
            profileService.SaveImage(img);

            return RedirectToPage();
        }
        
       
    }
}
