using Merit.Data.Data;
using Merit.Data.Models;
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
            using (var db = new MeritContext())
            {
                db.PersonalMerits.Add(merit);
                db.SaveChanges();
            }
        }
        public void SaveMeritBusiness(CompanyMerit merit)
        {
            using (var db = new MeritContext())
            {
                db.CompanyMerits.Add(merit);
                db.SaveChanges();
            }
        }
        public List<PersonalMerit> ReadPersonalMerits(int userId)
        {
            using (var db = new MeritContext())
            {
                var l = db.PersonalMerits
                    .Where(l => l.PersonalUserId == userId)
                    .AsEnumerable()
                    .ToList();
                return l;
            }
        }
        public List<CompanyMerit> ReadCompanyMerits(int companyUserId)
        {
            using (var db = new MeritContext())
            {
                var l = db.CompanyMerits
                    .Where(l => l.CompanyUserId == companyUserId)
                    .AsEnumerable()
                    .ToList();
                return l;
            }
        }
        public void UpdatePersonalMerit(PersonalMerit merit)
        {
            using (var db = new MeritContext())
            {
                var existingMerit = GetPersonalMerit(merit.PersonalMeritId);
                
                if (existingMerit!= null)
                {
                    existingMerit.Category = merit.Category;
                    existingMerit.SubCategory = merit.SubCategory;
                    existingMerit.Description = merit.Description;
                    existingMerit.Duration = merit.Duration;
                    db.SaveChanges();
                }
            }
        }
        public PersonalMerit GetPersonalMerit(int id)
        {
            using (var db = new MeritContext())
            {
                return db.PersonalMerits
                    .FirstOrDefault(m => m.PersonalMeritId == id);
            }
        }
    }
}
