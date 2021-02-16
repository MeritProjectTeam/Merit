using Merit.Data.Models;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Merit.Data.Interfaces
{
    public interface IProfileInfoService
    {
        public PersonalInfo EditPerson(PersonalInfo person);
        public PersonalInfo Get(int id);
        public List<PersonalInfo> GetAll();
    }
}
