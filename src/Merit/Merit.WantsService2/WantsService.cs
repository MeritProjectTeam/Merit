using Merit.Data.Data;
using Merit.Data.Models;
using Microsoft.EntityFrameworkCore;
using System;
using System.Collections.Generic;
using System.Linq;

namespace Merit.WantsService
{
    public class WantsService : IWantsService
    {
        public void CreateCompanyWant(CompanyWants companyWant)
        {
            using var db = new MeritContext();
            db.Add(companyWant);
            db.SaveChanges();
        }
        public void CreatePersonalWant(PersonalWants personalWant)
        {
            using var db = new MeritContext();
            db.Add(personalWant);
            db.SaveChanges();
        }
        public void EditPersonalWant(PersonalWants updatedWant)
        {
            using var db = new MeritContext();
            var existingWant = db.PersonalWants
                .FirstOrDefault(p => p.PersonalWantsID == updatedWant.PersonalWantsID);
            if (existingWant != null)
            {
                existingWant.Want = updatedWant.Want;

                db.SaveChanges();
            }
        }
        public void EditCompanyWant(CompanyWants updatedWant)
        {
            using var db = new MeritContext();

            var existingWant = db.CompanyWants
                .FirstOrDefault(w => w.CompanyWantsId == updatedWant.CompanyWantsId);

            if (existingWant != null)
            {
                existingWant.Want = updatedWant.Want;

                db.SaveChanges();
            }
        }
        public CompanyWants GetCompanyWant(int id)
        {
            using var db = new MeritContext();
            return db.CompanyWants
                .FirstOrDefault(c => c.CompanyWantsId == id);
        }
        public List<CompanyWants> GetAllCompanyWants(int userId)
        {
            using var db = new MeritContext();
            return db.CompanyWants
                .Where(c => c.CompanyUser.CompanyUserId == userId)
                .ToList();
        }
        public PersonalWants GetPersonalWant(int id)
        {
            using var db = new MeritContext();
            return db.PersonalWants
                .FirstOrDefault(p => p.PersonalWantsID == id);
        }
        public List<PersonalWants> GetAllPersonalWants(int userId)
        {
            using var db = new MeritContext();
            return db.PersonalWants
                .Where(p => p.PersonalUser.PersonalUserId == userId)
                .ToList();
        }
        public void DeleteCompanyWant(CompanyWants companyWant)
        {
            using (var db = new MeritContext())
            {
                var q = db.CompanyWants
                    .FirstOrDefault(q => q.CompanyWantsId == companyWant.CompanyWantsId);

                if (q != null)
                {
                    db.Remove(q);
                    db.SaveChanges();
                }

            }
        }
        public void DeletePersonalWant(PersonalWants personalWant)
        {
            using (var db = new MeritContext())
            {
                var q = db.PersonalWants
                    .FirstOrDefault(q => q.PersonalWantsID == personalWant.PersonalWantsID);

                if (q != null)
                {
                    db.Remove(q);
                    db.SaveChanges();
                }
                    
            }
        }
    }
}
