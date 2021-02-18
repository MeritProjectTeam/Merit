using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;
using Microsoft.AspNetCore.Mvc;
using Microsoft.AspNetCore.Mvc.RazorPages;
using Merit.PersonalInfoService;
using Merit.Data.Models;

namespace Merit.Web.Pages
{
    public class EditPersonalInfoModel : PageModel
    {
        private readonly IProfileService profileService = new ProfileService();

        public PersonalInfo APerson { get; set; }

        int userId;
        public void OnGet()
        {
            userId = AccountService.Account.CheckCookie();
            if (userId != 0)
            {
                APerson = profileService.Get(userId);
            }
        }
        public void OnPost()
        {
            if (userId != 0)
            {
                profileService.SavePersonalInfo(APerson);
            }
        }
    }
}
