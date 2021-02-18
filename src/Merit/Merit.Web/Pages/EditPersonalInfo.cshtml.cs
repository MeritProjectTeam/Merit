using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;
using Microsoft.AspNetCore.Mvc;
using Microsoft.AspNetCore.Mvc.RazorPages;
using Merit.PersonalInfoService;
using Merit.Data.Models;
using Microsoft.EntityFrameworkCore;

namespace Merit.Web.Pages
{
    public class EditPersonalInfoModel : PageModel
    {
        private readonly IProfileService profileService = new ProfileService();

        [BindProperty]
        public PersonalInfo APerson { get; set; }

        int userId = AccountService.Account.CheckCookie();
        public void OnGet()
        {
            if (userId != 0)
            {
                APerson = profileService.Get(userId);
            }
        }
        public void OnPost()
        {
           APerson.UserID = AccountService.Account.CheckCookie();
            profileService.UpdatePersonalInfo(APerson);

        }
    }
}
