using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Merit.Data.Models
{
    public class CompanyUser
    {
        
            public int CompanyUserID { get; set; }
            public string UserName { get; set; }
            public string Email { get; set; }
            public string Password { get; set; }
            public Company CompanyInfo { get; set; }
            public ICollection<CompanyMerit> CompanyMerits { get; set; }
       
    }
}
