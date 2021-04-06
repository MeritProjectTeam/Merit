using System;
using System.Collections.Generic;
using System.ComponentModel.DataAnnotations;
using System.Text;

namespace Merit.Data.Models
{
    public class CompanyInfo
    {
        public int CompanyInfoId { get; set; } = 0;
        public string CompanyName { get; set; } = "-";
        public string OrgNumber { get; set; } = "-";
        public string ContactName { get; set; } = "-";
        public string Phone { get; set; } = "-";
        public string Street { get; set; } = "-";
        public string ZipCode { get; set; } = "-";
        public string City { get; set; } = "-";

        public int CompanyUserId { get; set; }
        public CompanyUser CompanyUser { get; set; }
    }
}
