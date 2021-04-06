using Merit.Data.Data;
using Merit.Data.Models;
using Microsoft.EntityFrameworkCore;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Merit.MeritService
{
    public class MeritService : IMeritService
    {
        public void SaveMerit(PersonalMerit merit)
        {
            using var db = new MeritContext();
            db.PersonalMerits.Add(merit);
            db.SaveChanges();
        }
        public void SaveMeritBusiness(CompanyMerit merit)
        {
            using var db = new MeritContext();
            db.CompanyMerits.Add(merit);
            db.SaveChanges();
        }
        public List<PersonalMerit> ReadPersonalMerits(int userId)
        {
            using (var db = new MeritContext())
            {
                var l = db.PersonalMerits
                    .Where(l => l.PersonalUser.PersonalUserId == userId)
                    .ToList();
                return l;
            }
        }
        public List<CompanyMerit> ReadCompanyMerits(int companyUserId)
        {
            using (var db = new MeritContext())
            {
                var l = db.CompanyMerits
                    .Where(l => l.CompanyUser.CompanyUserId == companyUserId)
                    .ToList();
                return l;
            }
        }
        public void EditPersonalMerit(PersonalMerit merit)
        {
            using var db = new MeritContext();
            
            var existingMerit = db.PersonalMerits
                .FirstOrDefault(p => p.PersonalMeritId == merit.PersonalMeritId);
            if (existingMerit != null)
            {
                existingMerit.Category = merit.Category;
                existingMerit.SubCategory = merit.SubCategory;
                existingMerit.Description = merit.Description;
                existingMerit.Duration = merit.Duration;
                db.SaveChanges();
            }
        }
        public PersonalMerit GetPersonalMerit(int id)
        {
            using var db = new MeritContext();
            return db.PersonalMerits
                .FirstOrDefault(m => m.PersonalMeritId == id);
        }
        public CompanyMerit GetCompanyMerit(int id)
        {
            using var db = new MeritContext();

            return db.CompanyMerits
                .FirstOrDefault(c => c.CompanyMeritId == id);
        }
        public void EditCompanyMerit(CompanyMerit merit)
        {
            using var db = new MeritContext();
            
            var existingMerit = db.CompanyMerits
                .FirstOrDefault(c => c.CompanyMeritId == merit.CompanyMeritId);

            if (existingMerit != null)
            {
                existingMerit.Category = merit.Category;
                existingMerit.SubCategory = merit.SubCategory;
                existingMerit.Description = merit.Description;
                db.SaveChanges();
            }
        }
        public void DeleteCompanyMerit(CompanyMerit merit)
        {
            using (var db = new MeritContext())
            {
                var q = db.CompanyMerits
                    .FirstOrDefault(q => q.CompanyMeritId == merit.CompanyMeritId);
                if (q !=null)
                {
                    db.Remove(q);
                    db.SaveChanges();
                }
            }
        }
        public void DeletePersonalMerit(PersonalMerit merit)
        {
            using (var db = new MeritContext())
            {
                var q = db.PersonalMerits
                    .FirstOrDefault(q => q.PersonalMeritId == merit.PersonalMeritId);
                if (q != null)
                {
                    db.Remove(q);
                    db.SaveChanges();
                }
            }
        }
    }
}
