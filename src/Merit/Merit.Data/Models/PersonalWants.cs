using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Merit.Data.Models
{
    public class PersonalWants
    {
        public int PersonalWantsID { get; set; }
        public string Want { get; set; }
        public int PersonalUserId { get; set; }
        public PersonalUser PersonalUser { get; set; }
    }
}
