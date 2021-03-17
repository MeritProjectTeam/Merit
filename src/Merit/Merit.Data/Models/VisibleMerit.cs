using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Merit.Data.Models
{
    public class VisibleMerit
    {
        public int CompanyAdvertisementId { get; set; }
        public CompanyAdvertisement CompanyAdvertisement { get; set; }
        public int CompanyMeritId { get; set; }
        public CompanyMerit CompanyMerit { get; set; }
    }
}
