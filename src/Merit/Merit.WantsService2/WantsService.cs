using Merit.Data.Data;
using Merit.Data.Models;
using System;
using System.Collections.Generic;
using System.Linq;

namespace Merit.WantsService
{
    public class WantsService : IWantsService
    {


        public void CreateCompanyWant(CompanyWants companyWant)
        {
            
            using (var db = new MeritContext())
            {
                db.Add(companyWant);
                db.SaveChanges();

            }

        }



        public void CreatePersonalWant(PersonalWants personalWant)
        {
            using (var db = new MeritContext())
            {
                db.Add(personalWant);
                db.SaveChanges();

            }
        }

        public List<CompanyWants> GetCompanyWants(int userId)
        {
            using (var db = new MeritContext())
            {
                return db.CompanyWants
                    .Where(x => x.CompanyUserId == userId)
                    .ToList();
            }
        }

        public List<PersonalWants> GetPersonalWants(int userId)
        {
            using (var db = new MeritContext())
            {
                return db.PersonalWants
                    .Where(x => x.PersonalUserId == userId)
                    .ToList();
            }
        }
    }
}
