﻿using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Merit.Data.Models
{
    public class PersonalUser
    {
        public int PersonalUserId { get; set; }
        public string UserName { get; set; }
        public string Email { get; set; }
        public string Password { get; set; }
        public PersonalInfo PersonalInfo { get; set; }
        public ICollection<PersonalMerit> PersonalMerits { get; set; }

        public ICollection<PersonalWants> PersonalWants { get; set; }
    }
}
