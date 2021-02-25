using Merit.Data.Data;
using Merit.Data.Models;
using Microsoft.EntityFrameworkCore;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Merit.PersonalInfoService
{
    public class ProfileService : IProfileService
    {
        public void EditPersonalInfo(PersonalInfo info)
        {
            using (var db = new MeritContext())
            {
                var existingInfo = Get(info.PersonalInfoId);
                
                if (existingInfo != null)
                {
                    db.Entry(existingInfo).State = EntityState.Modified;

                    existingInfo.FirstName = info.FirstName;
                    existingInfo.LastName = info.LastName;
                    existingInfo.PhoneNumber = info.PhoneNumber;
                    existingInfo.City = info.City;
                    existingInfo.Street = info.Street;
                    existingInfo.ZipCode = info.ZipCode;
                    existingInfo.DateOfBirth = info.DateOfBirth;
                    db.SaveChanges();
                }
            }
        }

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
