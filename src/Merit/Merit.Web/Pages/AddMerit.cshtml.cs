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
        public bool Visi { get; set; }
        public string Message { get; set; }
        public string alertlook { get; set; }

        public void OnGet()
        {
            
        }
        public void OnPost()
        {
            Visi = true;
            if (AMerit.Category != null && AMerit.SubCategory != null && AMerit.Description != null)
            {
                Message = "Merit skapat!";
                alertlook = "success";
                int userId = AccountService.Account.CheckCookie();
                if (userId != 0)
                {
                    AMerit.PersonalUserId = userId;
                    meritService.SaveMerit(AMerit);
                }
            }
            else
            {
                alertlook = "danger";
                Message = "Fyll i rutorna!";
            }            
        }
    }
}
