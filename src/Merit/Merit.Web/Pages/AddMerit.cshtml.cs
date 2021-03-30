using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;
using Microsoft.AspNetCore.Mvc;
using Microsoft.AspNetCore.Mvc.RazorPages;
using Merit.MeritService;
using Merit.Data.Models;
using Microsoft.AspNetCore.Identity;
using System.Security.Claims;

namespace Merit.Web.Pages
{
    public class AddMeritModel : PageModel
    {
        IMeritService meritService = new MeritService.MeritService();

        private readonly UserManager<IdentityUser> userManager;
        

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
            if (User != null)
            {
                var userGuid = User.FindFirstValue(ClaimTypes.NameIdentifier);

                Visi = true;
                if (AMerit.Category != null && AMerit.SubCategory != null && AMerit.Description != null && userGuid != null)
                {
                    Message = "Merit skapat!";
                    alertlook = "success";
                    //int userId = AccountService.Account.CheckCookie();
                    //if (userId != 0)
                    //{
                    //    AMerit.PersonalUserId = userId;
                    //    meritService.SaveMerit(AMerit);
                    //}
                    AMerit.PersonalUserId = meritService.GetUserId(userGuid);
                    meritService.SaveMerit(AMerit);
                }
                else
                {
                    alertlook = "danger";
                    Message = "Fyll i rutorna!";
                }
            }
        }
    }
}
