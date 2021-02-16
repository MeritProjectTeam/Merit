using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;
using Merit.Data.DbServices;
using Merit.Data.Interfaces;
using Merit.MeritService;
using Microsoft.AspNetCore.Mvc;
using Microsoft.AspNetCore.Mvc.RazorPages;

namespace Merit.Web.Pages
{
    public class AddMeritBusinessModel : PageModel
    {
        public bool SavedBusinessMerit { get; set; } = false;
        IMeritDbService CompanyMeritService = new Services();

        [BindProperty]
        public NewMeritBusiness BusinessMerit { get; set; }

        public void OnGet()
        {
        }

        public void OnPost()
        {
            SavedBusinessMerit = true;
            //(BusinessMerit);
        }
    }
}
