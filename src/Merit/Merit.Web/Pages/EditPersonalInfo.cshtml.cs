using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;
using Microsoft.AspNetCore.Mvc;
using Microsoft.AspNetCore.Mvc.RazorPages;
using Merit.PersonalInfoService;

namespace Merit.Web.Pages
{
    public class EditPersonalInfoModel : PageModel
    {
        private readonly IPersonalInfoService profileService = new FakeProfileService();

        private Person person = new Person();


        [BindProperty(SupportsGet = true)]
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

        public void OnGet()
        {
            person = profileService.Get(2);

            FirstName = person.FirstName;
            LastName = person.LastName;
            Email = person.Email;
            Street = person.Street;
            Zipcode = person.ZipCode;
            City = person.City;
            Phone = person.PhoneNumber;
            DateOfBirth = person.DateOfBirth;
        }
        public void OnPost()
        {
            profileService.SaveAddress(Street, Zipcode, City);
            profileService.SaveContactInfo(Email, Phone);
            profileService.EditPerson(person);
        }
    }
}
