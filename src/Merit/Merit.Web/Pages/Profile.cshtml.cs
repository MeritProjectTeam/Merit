using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;
using Microsoft.AspNetCore.Mvc;
using Microsoft.AspNetCore.Mvc.RazorPages;
using Merit.ProfileService;
using Merit.Data.Interfaces;
using Merit.Data.DbServices;

namespace Merit.Web.Pages
{
    public class ProfileModel : PageModel
    {
        //private readonly IProfileService profileService = new MockProfileService();
        IMeritDbService dbService = new Services();

        [BindProperty]
        public Data.Models.PersonalInfo APerson { get; set; }


        //[BindProperty]
        //public string FirstName { get; set; }
        //[BindProperty]
        //public string LastName { get; set; }
        //[BindProperty]
        //public string Email { get; set; }
        //[BindProperty]
        //public string Street { get; set; }
        //[BindProperty]
        //public string Zipcode { get; set; }
        //[BindProperty]
        //public string City { get; set; }
        //[BindProperty]
        //public string Phone { get; set; }
        //[BindProperty]
        //public DateTime DateOfBirth { get; set; }

        //public int Age { get; set; }

        public void OnGet()
        {
            //dbService.SavePersonProfile();
        }

        public void OnPost()
        {
            dbService.SavePersonProfile(APerson);
            //profileService.SavePerson(FirstName, LastName, DateOfBirth);
            //profileService.SaveAddress(Street, Zipcode, City);
            //profileService.SaveContactInfo(Email, Phone);
            //Age = profileService.GetAgeFor(FirstName, LastName);
        }
    }
}
