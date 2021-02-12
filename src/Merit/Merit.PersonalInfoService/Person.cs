using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using Merit.PersonalInfoService;

namespace Merit.PersonalInfoService
{
    public class Person
    {
        public int Id { get; set; }
        public string FirstName { get; set; }
        public string LastName { get; set; }
        public string PhoneNumber { get; set; }
        public string Email { get; set; }
        public DateTime DateOfBirth { get; set; }
        public string City { get; set; }
        public string Street { get; set; }
        public string ZipCode { get; set; }

        //denna nedan behöver kopplas till det andra biblioteket med orginal-meriten
        public List<Merit> Merits { get; set; }
        public List<Education> Educations { get; set; }
        public List<Skills> Skillz { get; set; }
    }
}
