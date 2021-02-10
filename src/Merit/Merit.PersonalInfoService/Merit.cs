using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Merit.PersonalInfoService
{
    public class Merit
    {
        public string Title { get; set; }
        public string Category { get; set; }

        public Merit(string aaa, string bbb)
        {
            Title = aaa;
            Category = bbb;
        }
    }
}
