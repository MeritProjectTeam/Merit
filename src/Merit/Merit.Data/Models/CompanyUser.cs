using System.Collections.Generic;

namespace Merit.Data.Models
{
    public class CompanyUser
    {

        public int CompanyUserId { get; set; }
        public string UserName { get; set; }
        public string Email { get; set; }
        public string Password { get; set; }
        public CompanyInfo CompanyInfo { get; set; }
        public ICollection<CompanyMerit> CompanyMerits { get; set; }
        public ICollection<CompanyWants> CompanyWants { get; set; }
        public CompanyImage CompanyImage { get; set; }

    }
}
