using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;
using Microsoft.AspNetCore.Mvc;
using Microsoft.AspNetCore.Mvc.RazorPages;
using Merit.MeritService;
using Merit.Data.Models;
using Merit.PersonalInfoService;

namespace Merit.Web.Pages
{
    public class EditPersonalMeritsModel : PageModel
    {
        private readonly IMeritService meritService = new MeritService.MeritService();
        public List<PersonalMerit> MeritList { get; set; }
        public PersonalInfo APerson { get; set; }
        public PersonalMerit SelectedMerit { get; set;  }
        [BindProperty(SupportsGet=true)]
        public int SelectedMeritID { get; set; }

        public string SaveCategory { get; set; }
        public string SaveSubCategory { get; set; }
        public string SaveDescription { get; set; }
        public string SaveDuration { get; set; }

        int userId = AccountService.Account.CheckCookie();
        public void OnGet()
        {
            MeritList = meritService.ReadPersonalMerits(userId);
            SelectedMeritID = -1;
        }
        public void OnPostEdit()
        {
            PersonalMerit personalMerit = new PersonalMerit();
            personalMerit.PersonalMeritId = SelectedMeritID;
            personalMerit.Category = SaveCategory;
            personalMerit.SubCategory = SaveSubCategory;
            personalMerit.Description = SaveDescription;
            personalMerit.Duration = SaveDuration;

            meritService.UpdatePersonalMerit(personalMerit);
        }

        public void OnPostDelete()
        {
            
        }
    }
}
