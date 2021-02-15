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
        
        [BindProperty]
        public Person TestPerson { get; set; }

        public string FirstName { get; set; }
        public string LastName { get; set; }
        public string Email { get; set; }
        public string Street { get; set; }
        public string Zipcode { get; set; }
        public string City { get; set; }
        public string Phone { get; set; }
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
        public IActionResult OnPost()
        {
            person = profileService.EditPerson(person);
            return RedirectToPage("EditPersonalInfo");
        }
    }
}
