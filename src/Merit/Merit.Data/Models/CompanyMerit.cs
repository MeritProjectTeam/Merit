using System;
using System.Collections.Generic;
using System.ComponentModel.DataAnnotations;
using System.Text;

namespace Merit.Data.Models
{
    public class CompanyMerit
    {
        public int CompanyMeritID { get; set; }
        public string Category { get; set; }
        public string SubCategory { get; set; }
        public string Description { get; set; }
        public int CompanyID { get; set; } // Foreign key not working. 
    }
}

