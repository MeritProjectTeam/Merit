using System;
using System.Collections.Generic;
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
        public List<CompanyMerit> Merits { get; set; }
        public List<CompanyWants> Wants { get; set; }
        public string Salary { get; set; }
    }
}
