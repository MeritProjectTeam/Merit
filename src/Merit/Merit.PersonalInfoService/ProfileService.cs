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
            using var db = new MeritContext();
           
            var existingInfo = db.PersonalInfo
                .FirstOrDefault(p => p.PersonalUserId == info.PersonalUserId);
            if (existingInfo != null)
            {
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
        public PersonalInfo Get(int id)
        {
            using var db = new MeritContext();
            return db.PersonalInfo
                .FirstOrDefault(p => p.PersonalUserId == id);
        }        
        public async Task<CompanyImage> GetImage(CompanyUser companyUser)
        {
            using var db = new MeritContext();

            return await db.CompanyImages
                .FirstOrDefaultAsync(i => i.CompanyUserId == companyUser.CompanyUserId);
        }
        public async Task SaveImage(CompanyImage image)
        {
            using var db = new MeritContext();
            
            if (db.CompanyImages.FirstOrDefault(x => x.CompanyUserId == image.CompanyUserId) != null)
            {
                db.CompanyImages.Remove(db.CompanyImages.FirstOrDefault(x => x.CompanyUserId == image.CompanyUserId));
            }
            db.Add(image);
            await db.SaveChangesAsync();
        }
        public async Task<PersonalImage> GetImage(PersonalUser personalUser)
        {
            using var db = new MeritContext();
            return await db.PersonalImages.FirstOrDefaultAsync(i => i.PersonalUserId == personalUser.PersonalUserId);
        }
        public async Task SaveImage(PersonalImage image)
        {
            using var db = new MeritContext();

            if (db.PersonalImages.FirstOrDefault(x => x.PersonalUserId == image.PersonalUserId) != null)
            {
                db.PersonalImages
                    .Remove(db.PersonalImages.FirstOrDefault(x => x.PersonalUserId == image.PersonalUserId));
            }
            db.Add(image);
            await db.SaveChangesAsync();
        }
        public void SavePersonalInfo(PersonalInfo info)
        {
            using var db = new MeritContext();

            db.PersonalInfo.Add(info);
            db.SaveChanges();
        }

        public void DeletePersonalInfo(int userId)
        {
            using var db = new MeritContext();
            var imageInfo = db.PersonalImages.FirstOrDefault(x => x.PersonalUserId == userId);
            if(imageInfo != null)
            { 
                db.PersonalImages.Remove(imageInfo); 
            }
            var personalInfo = db.PersonalInfo.FirstOrDefault(x => x.PersonalUserId == userId);
            db.PersonalInfo.Remove(personalInfo);
            db.SaveChanges();
        }

        public List<PersonalInfo> GetAllPersons()
        {
            using var db = new MeritContext();
            return db.PersonalInfo.ToList();
        }
    }
}
