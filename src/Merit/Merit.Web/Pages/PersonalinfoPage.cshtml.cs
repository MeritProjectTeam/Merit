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
        private readonly IPersonalInfoService profileService = new FakeProfileService();
        public string FirstName { get; set; }
        public string LastName { get; set; }
        public string Email { get; set; }
        public string Street { get; set; }
        public string Zipcode { get; set; }
        public string City { get; set; }
        public string Phone { get; set; }
        public DateTime DateOfBirth { get; set; }

        public List<PersonalMerit> personalMerits = new List<PersonalMerit>();
        //public void OnGet()
        //{
        //    var person = profileService.Get(1);
            
        //    FirstName = person.FirstName;
        //    LastName = person.LastName;
        //    Street = person.Street;
        //    Zipcode = person.ZipCode;
        //    City = person.City;
        //    Phone = person.PhoneNumber;
        //    DateOfBirth = person.DateOfBirth;
        //}
    }
}
