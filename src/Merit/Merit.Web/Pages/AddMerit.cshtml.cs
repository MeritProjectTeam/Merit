using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;
using Microsoft.AspNetCore.Mvc;
using Microsoft.AspNetCore.Mvc.RazorPages;
using Merit.MeritService;
using Merit.Data.Models;

namespace Merit.Web.Pages
{
    public class AddMeritModel : PageModel
    {
        public bool MeritSaved { get; set; } = false;
        IMeritService meritService = new MeritService.MeritService();
        public string Status { get; set; } = "Success!"; 

        [BindProperty]
        public PersonalMerit AMerit { get; set; }
        public void OnGet()
        {
            
        }
        public void OnPost()
        {
            MeritSaved = true;
            int userId = AccountService.Account.CheckCookie();
            if (userId != 0)
            {
                AMerit.PersonalUserId = userId;
                meritService.SaveMerit(AMerit);
            }
        }
    }
}
