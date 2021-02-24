﻿using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

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

    }
}
