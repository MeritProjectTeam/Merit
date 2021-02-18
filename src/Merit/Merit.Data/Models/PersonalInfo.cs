using System;
using System.Collections.Generic;
using System.ComponentModel.DataAnnotations;
using System.Text;


namespace Merit.Data.Models
{
    public class PersonalInfo
    {
        public int PersonalInfoId { get; set; } = 0;
        public string FirstName { get; set; } = "-";
        public string LastName { get; set; } = "-";
        public string PhoneNumber { get; set; } = "-";
        public DateTime DateOfBirth { get; set; } = default;
        public string City { get; set; } = "-";
        public string Street { get; set; } = "-";
        public string ZipCode { get; set; } = "-";
     
        public int UserID { get; set; }
        public User User { get; set; }
    }
}
