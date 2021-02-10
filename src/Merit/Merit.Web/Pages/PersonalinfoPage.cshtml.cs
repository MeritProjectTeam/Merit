using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;
using Microsoft.AspNetCore.Mvc;
using Microsoft.AspNetCore.Mvc.RazorPages;
using Merit.ProfileService;

namespace Merit.Web.Pages
{
    public class PersonalinfoPageModel : PageModel
    {
        private readonly IProfileService profileService = new MockProfileService();

        [BindProperty(SupportsGet=true)]
        public string FirstName { get; set; }

        [BindProperty(SupportsGet = true)]
        public string LastName { get; set; }

        [BindProperty(SupportsGet = true)]
        public string Email { get; set; }

        [BindProperty(SupportsGet = true)]
        public string Street { get; set; }

        [BindProperty(SupportsGet = true)]
        public string Zipcode { get; set; }

        [BindProperty(SupportsGet = true)]
        public string City { get; set; }

        [BindProperty(SupportsGet = true)]
        public string Phone { get; set; }

        [BindProperty(SupportsGet = true)]
        public DateTime DateOfBirth { get; set; }

        public List<PersonMerit> personalMerits = new List<PersonMerit>();
        
        public List<PersonEducation> personalEducation = new List<PersonEducation>();

        public void OnGet()
        {
            var mockProfile = new MockProfileService();
            var person = mockProfile.Get(2);
            
            FirstName = person.FirstName;
            LastName = person.LastName;
            Email = person.Email;
            Street = person.Street;
            Zipcode = person.ZipCode;
            City = person.City;
            Phone = person.Phone;
            DateOfBirth = person.DateOfBirth;
        }
    }

    public class PersonMerit
    {
        public string MeritName { get; set; }
        public DateTime StartDate { get; set; }
        public DateTime EndDate { get; set; }
    }

    public class PersonEducation
    {
        public string EducationName { get; set; }
        public DateTime StartEducation { get; set; }
        public DateTime EndEducation { get; set; }
    }
}
