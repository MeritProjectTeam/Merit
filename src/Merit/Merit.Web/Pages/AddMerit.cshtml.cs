using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;
using Microsoft.AspNetCore.Mvc;
using Microsoft.AspNetCore.Mvc.RazorPages;
using Merit.Data.DbServices;
using Merit.MeritService;
using Merit.Data.Models;
using Merit.Data.Interfaces;

namespace Merit.Web.Pages
{
    public class AddMeritModel : PageModel
    {
        IMeritDbService meritService = new Services();

        [BindProperty]
        public PersonalMerit AMerit { get; set; }

        public void OnGet()
        {
            
        }
        public void OnPost()
        {
            AMerit.PersonalMeritId = 7;
            meritService.SaveMerit(AMerit);
        }
    }
}
