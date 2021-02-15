using System;
using System.Collections.Generic;
using System.ComponentModel.DataAnnotations;
using System.Text;
using Merit.MeritService;


namespace Merit.Data.Models
{
    public class PersonalInfo
    {
        public int PersonalInfoId { get; set; }
        public string FirstName { get; set; }
        public string LastName { get; set; }
        public string PhoneNumber { get; set; }
        public string Email { get; set; }
        public DateTime DateOfBirth { get; set; }
        public string City { get; set; }
        public string Street { get; set; }
        public string ZipCode { get; set; }
        public ICollection<PersonalMerit> PersonalMerits { get; set; }

    }
}
