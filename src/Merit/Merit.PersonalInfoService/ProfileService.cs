using Merit.Data.Data;
using Merit.Data.Models;
using Microsoft.EntityFrameworkCore;
using System;
using System.Collections.Generic;
using System.IO;
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
        public CompanyImage GetImage(CompanyUser companyUser)
        {
            using (var db = new MeritContext())
            {
                return db.CompanyImages.FirstOrDefault(i => i.CompanyUserId == companyUser.CompanyUserId);
            }
        }

        public void SaveImage(CompanyImage image)
        {
            using (var db = new MeritContext())
            {
                if (db.CompanyImages.FirstOrDefault(x => x.CompanyUserId == image.CompanyUserId) != null)
                {
                    db.CompanyImages.Remove(db.CompanyImages.FirstOrDefault(x => x.CompanyUserId == image.CompanyUserId));
                }
                db.Add(image);
                db.SaveChanges();
            }
        }
        public PersonalImage GetImage(PersonalUser personalUser)
        {
            using (var db = new MeritContext())
            {
                return db.PersonalImages.FirstOrDefault(i => i.PersonalUserId == personalUser.PersonalUserId);
            }
        }

        public void SaveImage(PersonalImage image)
        {
            using (var db = new MeritContext())
            {
                if (db.PersonalImages.FirstOrDefault(x => x.PersonalUserId == image.PersonalUserId) != null)
                {
                    db.PersonalImages.Remove(db.PersonalImages.FirstOrDefault(x => x.PersonalUserId == image.PersonalUserId));
                }
                db.Add(image);
                db.SaveChanges();
            }
        }

        public void SavePersonalInfo(PersonalInfo info)
        {
            using (var db = new MeritContext())
            {
                db.PersonalInfo.Add(info);
                db.SaveChanges();
            }
        }
    }
}
