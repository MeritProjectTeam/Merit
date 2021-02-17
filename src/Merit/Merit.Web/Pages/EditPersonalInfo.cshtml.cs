using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;
using Microsoft.AspNetCore.Mvc;
using Microsoft.AspNetCore.Mvc.RazorPages;
using Merit.PersonalInfoService;
using Merit.Data.Models;

namespace Merit.Web.Pages
{
    public class EditPersonalInfoModel : PageModel
    {
        private readonly IPersonalInfoService profileService = new PersonalInfoService.ProfileService();

        public PersonalInfo APerson { get; set; }
       
        public void OnGet()
        {
            //Profile = profileService.Get(2);

            //nedan ska kopplas mot inloggad person
            //APerson = profileService.Get(7);

        }
        public IActionResult OnPost()
        {
            return RedirectToPage("EditPersonalInfo");
        }
    }
}
