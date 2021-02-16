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
        PersonalInfo Get(int id);
        public PersonalInfo EditPerson(PersonalInfo person);
        List<PersonalInfo> GetAll();
    }
}
