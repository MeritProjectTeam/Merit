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
        public bool Visi { get; set; }
        [BindProperty]
        public PersonalWants PersonalWant { get; set; }
        public string Message { get; set; }
        public string alertlook { get; set; }

        public void OnGet()
        {
        }
        public void OnPost()
        {
            Visi = true;
            if (PersonalWant.Want != null)
            {
                Message = "Önskemål skapat!";
                alertlook = "success";
                int userId = AccountService.Account.CheckCookie();
                if (userId != 0)
                {
                    PersonalWant.PersonalUserId = userId;
                    wantsService.CreatePersonalWant(PersonalWant);

                }
            }
            else
            {
                Message = "Fyll i rutan!";
                alertlook = "danger";
            }
        }
    }
}
