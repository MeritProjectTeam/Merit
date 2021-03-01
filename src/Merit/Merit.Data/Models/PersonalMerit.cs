using System;
using System.Collections.Generic;
using System.ComponentModel.DataAnnotations;
using System.Text;

namespace Merit.Data.Models
{
    public class PersonalMerit
    {
        public int PersonalMeritId { get; set; }
        public string Category { get; set; }
        public string SubCategory { get; set; }
        public string Description { get; set; }
        public string Duration { get; set; }

        public int PersonalUserId { get; set; } // Foreign key
        public PersonalUser PersonalUser { get; set; }

    }
}


