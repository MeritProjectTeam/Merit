using System;
using System.Collections.Generic;
using System.ComponentModel.DataAnnotations;
using System.Text;

namespace Merit.Data.Models
{
    public class Company
    {
        public int CompanyId { get; set; }
        public string CompanyName { get; set; }
        public string OrgNumber { get; set; }
        public string ContactName { get; set; }
        public string Email { get; set; }
        public string Phone { get; set; }
        public string Street { get; set; }
        public string ZipCode { get; set; }
        public string City { get; set; }
        public ICollection<CompanyMerit> CompanyMerits { get; set; }

    }
}
