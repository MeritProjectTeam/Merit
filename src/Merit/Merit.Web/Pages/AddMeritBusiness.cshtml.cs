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
        public CompanyMerit BusinessMerit { get; set; }

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
