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
        IMeritService meritService = new MeritService.MeritService();
        

        [BindProperty]
        public PersonalMerit AMerit { get; set; }

        public void OnGet()
        {
            
        }
        public void OnPost()
        {
            int userId = AccountService.Account.CheckCookie();
            if (userId != 0)
            {
                AMerit.UserID = userId;
                meritService.SaveMerit(AMerit); 
            }
            
        }
    }
}
