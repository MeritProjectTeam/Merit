using Merit.Data.Data;
using Merit.Data.Models;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Merit.PersonalInfoService
{
    public class ProfileService : IProfileService
    {
        public PersonalInfo Get(int id)
        {
            using (var db = new MeritContext())
                return db.Persons
                    .FirstOrDefault(p => p.PersonalInfoId == id);
        }
        public List<PersonalInfo> GetAll()
        {
            using (var db = new MeritContext())
            {
                return db.Persons
                    .ToList();
            }
        }

        public void SavePersonalInfo(PersonalInfo info)
        {
            using (var db = new MeritContext())
            {
                db.Persons.Add(info);
                db.SaveChanges();
            }
        }
    }
}
