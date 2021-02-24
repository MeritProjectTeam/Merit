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
                return db.PersonalInfo
                    .FirstOrDefault(p => p.PersonalUserID == id);
        }
        public void SavePersonalInfo(PersonalInfo info)
        {
            using (var db = new MeritContext())
            {
                db.PersonalInfo.Add(info);
                db.SaveChanges();
            }
        }
       public void UpdatePersonalInfo(PersonalInfo newInfo)
        {
            using (var db = new MeritContext())
            { 
                PersonalInfo dbPersonalInfo = db.PersonalInfo.FirstOrDefault(x => x.PersonalUserID == newInfo.PersonalUserID);
                db.PersonalInfo.Remove(dbPersonalInfo);
                db.PersonalInfo.Add(newInfo);
                db.SaveChanges();
            };
        }
    }
}
