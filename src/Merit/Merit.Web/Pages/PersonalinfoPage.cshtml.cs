using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;
using Microsoft.AspNetCore.Mvc;
using Microsoft.AspNetCore.Mvc.RazorPages;
using Merit.PersonalInfoService;
using Merit.MeritService;
using Merit.Data.Models;
using Merit.AccountService;

namespace Merit.Web.Pages
{
    public class PersonalinfoPageModel : PageModel
    {
        private IProfileService profileService = new ProfileService();
        private IAccount accountService = new Account();
        private IMeritService meritService = new MeritService.MeritService();

        [BindProperty]
        public User AUser { get; set; }
        [BindProperty]
        public PersonalInfo PersonalInfo { get; set; }
        [BindProperty]
        public List<PersonalMerit> personalMerits { get; set; }
        
        public void OnGet()
        {
           int userId = Account.CheckCookie();
            AUser = accountService.GetUser(userId);
            PersonalInfo = profileService.Get(userId);
            if (PersonalInfo == null)
            {
                PersonalInfo = new PersonalInfo();
            }
            personalMerits = meritService.ReadPersonalMerits(userId);
        }
    }
}
