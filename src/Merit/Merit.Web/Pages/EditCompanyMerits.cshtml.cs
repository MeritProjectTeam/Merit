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
        public List<CompanyMerit> CompanyMeritList { get; set; }
        [BindProperty]
        public CompanyMerit CMerit { get; set; }
        
        [BindProperty(SupportsGet = true)]
        public int SelectedMeritID { get; set; }
        public string CategoryText { get; set; }
        [BindProperty]
        public string SubCategoryText { get; set; }
        [BindProperty]
        public string DescriptionText { get; set; }
        [BindProperty]
        public string DurationText { get; set; }

        int userId = AccountService.Account.CheckCookie();
        public void OnGet()
        {
            CompanyMeritList = meritService.ReadCompanyMerits(userId);
        }
        public IActionResult OnPostEdit()
        {
            meritService.UpdateCompanyMerit(CMerit);

            return RedirectToAction("Index");
        }
        public IActionResult OnPostDelete()
        {
            meritService.DeleteCompanyMerit(CMerit);

            return RedirectToAction("Index");
        }
    }
}
