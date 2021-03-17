using System;
using System.Collections.Generic;
using System.ComponentModel.DataAnnotations;
using System.Text;

namespace Merit.Data.Models
{
    public class CompanyMerit
    {
        public int CompanyMeritId { get; set; }
        public string Category { get; set; }
        public string SubCategory { get; set; }
        public string Description { get; set; }
        public int CompanyUserId { get; set; }
        public CompanyUser CompanyUser { get; set; }

    }
}

