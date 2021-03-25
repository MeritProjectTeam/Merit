using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Merit.Data.Models
{
    public class VisibleWant
    {
        public int CompanyAdvertisementId { get; set; }
        public CompanyAdvertisement CompanyAdvertisement { get; set; }
        public int CompanyWantsId { get; set; }
        public CompanyWants CompanyWants { get; set; }
    }
}
