using Merit.Data.Data;
using Merit.Data.Interfaces;
using Merit.Data.Models;
using System;
using System.Collections.Generic;
using System.Text;
using System.Threading.Tasks;
using System.Linq;


namespace Merit.Data.DbServices
{
    public class EditProfileService : IProfileInfoService
    {
        public PersonalInfo EditPerson(PersonalInfo person)
        {
            throw new NotImplementedException();
        }
        public PersonalInfo Get(int id)
        {
            using (var db = new MeritContext())
                return db.Persons
                    .FirstOrDefault(p => p.PersonalInfoId == id);
            
        }
        public List<PersonalInfo> GetAll()
        {
            throw new NotImplementedException();
        }
    }
}
