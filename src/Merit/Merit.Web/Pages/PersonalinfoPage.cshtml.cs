using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;
using Microsoft.AspNetCore.Mvc;
using Microsoft.AspNetCore.Mvc.RazorPages;
using Merit.PersonalInfoService;
using Merit.MeritService;
using Merit.Data.Models;

namespace Merit.Web.Pages
{
    public class PersonalinfoPageModel : PageModel
    {
        private readonly IProfileService profileService = new ProfileService();

        [BindProperty]
        public User AUser { get; set; }
        [BindProperty]
        public PersonalInfo PersonalInfo { get; set; }
        [BindProperty]
        public List<PersonalMerit> personalMerits { get; set; }

        public void OnGet()
        {
        //    var person = profileService.Get(1);

        //    FirstName = person.FirstName;
        //    LastName = person.LastName;
        //    Street = person.Street;
        //    Zipcode = person.ZipCode;
        //    City = person.City;
        //    Phone = person.PhoneNumber;
        //    DateOfBirth = person.DateOfBirth;
        }
    }
}
