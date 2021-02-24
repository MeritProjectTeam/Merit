using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;
using Microsoft.AspNetCore.Mvc;
using Microsoft.AspNetCore.Mvc.RazorPages;

using Merit.Data.Models;
using Merit.PersonalInfoService;

namespace Merit.Web.Pages
{
    public class ProfileModel : PageModel
    {
        public IProfileService profileService = new ProfileService();

        [BindProperty]
        public Data.Models.PersonalInfo APerson { get; set; }


        public void OnGet()
        {
            
        }

        public void OnPost()
        {
            int userId = AccountService.Account.CheckCookie();
            if (userId != 0)
            {
                APerson.PersonalUserID = userId;
                profileService.SavePersonalInfo(APerson);
            }
        }
    }
}
