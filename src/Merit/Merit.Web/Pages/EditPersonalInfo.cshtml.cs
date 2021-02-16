using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;
using Microsoft.AspNetCore.Mvc;
using Microsoft.AspNetCore.Mvc.RazorPages;
using Merit.PersonalInfoService;
using Merit.Data.Models;
using Merit.Data.Interfaces;
using Merit.Data.DbServices;

namespace Merit.Web.Pages
{
    public class EditPersonalInfoModel : PageModel
    {
        private readonly IProfileInfoService profileService = new EditProfileService();

        public PersonalInfo APerson { get; set; }

        //[BindProperty]
        //public string FirstName { get; set; }
        //public string LastName { get; set; }
        //public string Email { get; set; }
        //public string Street { get; set; }
        //public string Zipcode { get; set; }
        //public string City { get; set; }
        //public string Phone { get; set; }
        //public DateTime DateOfBirth { get; set; }

        public void OnGet()
        {
            //Profile = profileService.Get(2);

            //nedan ska kopplas mot inloggad person
            APerson = profileService.Get(7);

        }
        public IActionResult OnPost()
        {
            return RedirectToPage("EditPersonalInfo");
        }
    }
}
