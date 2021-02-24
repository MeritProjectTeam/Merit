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
        [BindProperty(SupportsGet  = true)]
        public List<PersonalMerit> MeritList { get; set; }
        public PersonalInfo APerson { get; set; }
        [BindProperty(SupportsGet=true)]
        public int SelectedMeritID { get; set; }

        public string CategoryText { get; set; }
        public string SubCategoryText { get; set; }
        public string DescriptionText { get; set; }
        public string DurationText { get; set; }

        int userId = AccountService.Account.CheckCookie();

        public void OnGet()
        {
            MeritList = meritService.ReadPersonalMerits(userId);
            foreach (var x in MeritList)
            {
                if (x.PersonalMeritId == SelectedMeritID)
                {
                    CategoryText = x.Category;
                    SubCategoryText = x.SubCategory;
                    DescriptionText = x.Description;
                    DurationText = x.Duration;
                }
            }
        }
        public void OnPostEdit()
        {
            PersonalMerit personalMerit = new PersonalMerit();
            personalMerit.PersonalMeritId = SelectedMeritID;
            personalMerit.Category = CategoryText;
            personalMerit.SubCategory = SubCategoryText;
            personalMerit.Description = DescriptionText;
            personalMerit.Duration = DurationText;

            meritService.UpdatePersonalMerit(personalMerit);
        }

        public void OnPostDelete()
        {
            
        }
    }
}
