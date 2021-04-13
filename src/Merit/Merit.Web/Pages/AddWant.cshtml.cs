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
    public class AddWantModel : PageModel
    {
        
        private readonly IWantsService wantsService = new WantsService.WantsService();
        public bool WantSaved { get; set; } = false;
        [BindProperty]
        public PersonalWants PersonalWant { get; set; }
        public void OnGet()
        {
        }
        public void OnPost()
        {
            WantSaved = true;
            int userId = AccountService.Account.CheckCookie();
            if (userId != 0)
            {
                PersonalWant.PersonalUserId = userId;
                wantsService.CreatePersonalWant(PersonalWant);

            }

        }
    }
}
