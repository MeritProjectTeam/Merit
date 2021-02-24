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

        private int sMeritId;


        [BindProperty(SupportsGet  = true)]
        public List<PersonalMerit> MeritList { get; set; }
        [BindProperty(SupportsGet=true)]
        public int SelectedMeritID { get; set; }
        [BindProperty]
        public string CategoryText { get; set; }
        [BindProperty]
        public string SubCategoryText { get; set; }
        [BindProperty]
        public string DescriptionText { get; set; }
        [BindProperty]
        public string DurationText { get; set; }
        [BindProperty]
        public PersonalMerit PMerit { get; set; }

        int userId = AccountService.Account.CheckCookie();

        public void OnGet()
        {
            MeritList = meritService.ReadPersonalMerits(userId);
          
            foreach (var x in MeritList)
            {
                if (x.PersonalMeritId == SelectedMeritID) 
                {
                    if (SelectedMeritID != 0) 
                    {
                        sMeritId = SelectedMeritID;
                    }
                    CategoryText = x.Category;
                    SubCategoryText = x.SubCategory;
                    DescriptionText = x.Description;
                    DurationText = x.Duration;
                }
            }
        }
        public void OnPost()
        {
            //PMerit.PersonalMeritId = id;
            //personalMerit.PersonalMeritId = SelectedMeritID;
            //personalMerit.Category = CategoryText;
            //personalMerit.SubCategory = SubCategoryText;
            //personalMerit.Description = DescriptionText;
            //personalMerit.Duration = DurationText;

            meritService.UpdatePersonalMerit(PMerit);
        }
    }
}
