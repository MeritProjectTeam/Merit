using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;
using Microsoft.AspNetCore.Mvc;
using Microsoft.AspNetCore.Mvc.RazorPages;
using Merit.ProfileService;

namespace Merit.Web.Pages
{
    public class ProfileModel : PageModel
    {
        private readonly IProfileService profileService = new MockProfileService();

        [BindProperty]
        public string FirstName { get; set; }
        [BindProperty]
        public string LastName { get; set; }
        [BindProperty]
        public string Email { get; set; }
        [BindProperty]
        public string Street { get; set; }
        [BindProperty]
        public string Zipcode { get; set; }
        [BindProperty]
        public string City { get; set; }
        [BindProperty]
        public string Phone { get; set; }
        [BindProperty]
        public DateTime DateOfBirth { get; set; }

        public int Age { get; set; }

        public void OnGet()
        {

        }

        public void OnPost()
        {
            profileService.SavePerson(FirstName, LastName, DateOfBirth);
            profileService.SaveAddress(Street, Zipcode, City);
            profileService.SaveContactInfo(Email, Phone);
            Age = profileService.GetAgeFor(FirstName, LastName);
        }
    }
}
