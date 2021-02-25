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
          
            foreach (var merit in MeritList)
            {
                if (merit.PersonalMeritId == SelectedMeritID) 
                {
                    SelectedMeritID = merit.PersonalMeritId;
                    CategoryText = merit.Category;
                    SubCategoryText = merit.SubCategory;
                    DescriptionText = merit.Description;
                    DurationText = merit.Duration;
                }
            }
        }
        public IActionResult OnPostEdit()
        {
            meritService.UpdatePersonalMerit(PMerit);
            return RedirectToPage("EditPersonalMerits");
        }

        public IActionResult OnPostDelete()
        {
            meritService.DeletePersonalMerit(PMerit);

            return RedirectToPage("EditPersonalMerits");
        }
    }
}
