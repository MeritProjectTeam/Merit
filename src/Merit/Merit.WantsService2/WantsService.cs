using Merit.Data.Data;
using Merit.Data.Models;
using System;
using System.Collections.Generic;

namespace Merit.WantsService
{
    public class WantsService : IWantsService
    {


        public void CreateCompanyWant(string want, int userId)
        {
            CompanyWants companyWant = new CompanyWants();

            companyWant.Want = want;
            companyWant.CompanyUserId = userId;

            using (var db = new MeritContext())
            {
                db.Add(companyWant);
                db.SaveChanges();

            }

        }



        public void CreatePersonalWant(string want, int userId)
        {
            PersonalWants personalWant = new PersonalWants();

            personalWant.Want = want;
            personalWant.PersonalUserId = userId;

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
               
            }
        }

        public List<PersonalWants> GetPersonalWants(int userId)
        {
            throw new NotImplementedException();
        }
    }
}
