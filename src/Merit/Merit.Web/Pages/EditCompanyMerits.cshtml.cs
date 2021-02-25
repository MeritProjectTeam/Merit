using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;
using Merit.Data.Models;
using Merit.MeritService;
using Microsoft.AspNetCore.Mvc;
using Microsoft.AspNetCore.Mvc.RazorPages;

namespace Merit.Web.Pages
{
    public class EditCompanyMeritsModel : PageModel
    {
        private IMeritService meritService = new MeritService.MeritService();
        
        
        [BindProperty(SupportsGet = true)]
        public List<CompanyMerit> CompanyMeritList { get; set; }
        [BindProperty]
        public CompanyMerit CMerit { get; set; }
        
        [BindProperty(SupportsGet = true)]
        public int SelectedMeritID { get; set; }
        [BindProperty]
        public string CategoryText { get; set; }
        [BindProperty]
        public string SubCategoryText { get; set; }
        [BindProperty]
        public string DescriptionText { get; set; }

        int userId = AccountService.Account.CheckCookie();
        public void OnGet()
        {
            CompanyMeritList = meritService.ReadCompanyMerits(userId);

            foreach (var merit in CompanyMeritList)
            {
                if (merit.CompanyMeritId == SelectedMeritID)
                {
                    SelectedMeritID = merit.CompanyMeritId;
                    CategoryText = merit.Category;
                    SubCategoryText = merit.SubCategory;
                    DescriptionText = merit.Description;
                }
            }
        }
        public IActionResult OnPostEdit()
        {
            meritService.EditCompanyMerit(CMerit);

            return RedirectToAction("Index");
        }
        public IActionResult OnPostDelete()
        {
            meritService.DeleteCompanyMerit(CMerit);

            return RedirectToAction("Index");
        }
    }
}
