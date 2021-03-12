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
        public string Category { get; set; }
        public string SubCategory { get; set; }
        public string Description { get; set; }
        public List<CompanyMerit> Merits { get; set; }
        public List<CompanyWants> Wants { get; set; }
    }
}
