using Merit.Data.Models;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Merit.PersonalInfoService
{
    public interface IProfileService
    {
        public PersonalInfo Get(int id);

        public List<PersonalInfo> GetAll();
        public void SavePersonalInfo(PersonalInfo info);

    }
}
