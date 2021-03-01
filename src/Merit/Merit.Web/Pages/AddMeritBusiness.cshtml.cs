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
    public class AddMeritBusinessModel : PageModel
    {
        public bool SavedBusinessMerit { get; set; } = false;
        
        IMeritService CompanyMeritService = new MeritService.MeritService();


        [BindProperty]
        public CompanyMerit ACompanyMerit { get; set; }
        [BindProperty]
        public string Information { get; set; }


        public void OnGet()
        {
            Information = "";
        }

        public void OnPost()
        {
            SavedBusinessMerit = true;
            int companyUserId = AccountService.Account.CheckCookie();
            if (companyUserId != 0)
            {
                ACompanyMerit.CompanyUserId = companyUserId;          //TA BORT KOMMENTARTECKNEN EFTER MERGE MED NYA DATABASEN!!!
                CompanyMeritService.SaveMeritBusiness(ACompanyMerit);
                Information = "Merit sparad.";
            }

        }
    }
}
