﻿using System;
using System.Collections.Generic;
using System.ComponentModel.DataAnnotations.Schema;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Merit.Data.Models
{
    public class CompanyAdvertisement
    {
        public int CompanyAdvertisementId { get; set; }
        public string Profession { get; set; }
        public string Place { get; set; }
        public string Extent { get; set; }
        public string Duration { get; set; }
        public string FormOfEmployment { get; set; }
        public string Information { get; set; }
        public ICollection<VisibleMerit> VisibleMerits { get; set; }
        public ICollection<VisibleWant> VisibleWants { get; set; }
        public string Salary { get; set; }
        public int CompanyUserId { get; set; }
        public CompanyUser CompanyUser { get; set; }
        [NotMapped]
        public ICollection<CompanyMerit> CompanyMerits { get; set; }
        [NotMapped]
        public ICollection<CompanyWants> CompanyWants { get; set; }

    }
}
