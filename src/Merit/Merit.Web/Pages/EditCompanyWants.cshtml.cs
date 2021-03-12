using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;
using Merit.Data.Models;
using Merit.WantsService;
using Microsoft.AspNetCore.Mvc;
using Microsoft.AspNetCore.Mvc.RazorPages;

namespace Merit.Web.Pages
{
    public class EditCompanyWantsModel : PageModel
    {
        private IWantsService wService = new WantsService.WantsService();

        [BindProperty(SupportsGet = true)]
        public List<CompanyWants> CompanyWantsList { get; set; }

        [BindProperty(SupportsGet = true)]
        public int SelectedCompanyWantId { get; set; }

        [BindProperty]
        public string WantText { get; set; }

        [BindProperty]
        public CompanyWants CWant { get; set; }



        int companyUserId = AccountService.Account.CheckCookie();

        public void OnGet()
        {
            CompanyWantsList = wService.GetAllCompanyWants(companyUserId);

            foreach (var want in CompanyWantsList)
            {
                if(want.CompanyWantsId == SelectedCompanyWantId)
                {
                    SelectedCompanyWantId = want.CompanyWantsId;
                    WantText = want.Want;
                }

            }
        }

        public IActionResult OnPostEdit()
        {
            wService.EditCompanyWant(CWant);
            return RedirectToAction("index");
        }

        public IActionResult OnPostDelete()
        {
            wService.DeleteCompanyWant(CWant);
            return RedirectToAction("index");
        }
    }
}
