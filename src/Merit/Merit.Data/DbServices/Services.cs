using Merit.Data.Data;
using Merit.Data.Interfaces;
using Merit.Data.Models;
using Merit.MeritService;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Merit.Data.DbServices
{
    public class Services : IMeritDbService
    {
       
        

        public void SaveMerit(PersonalMerit merit)
        {
            using (var db = new MeritContext())
            {
                db.Add(merit);
                db.SaveChanges();
            }
        }

        public void SavePersonProfile(PersonalInfo person)
        {
            using (var db = new MeritContext())
            {
                db.Add(person);
                db.SaveChanges();
            }
        }

        public void SaveCompanyMerit(CompanyMerit companyMerit)
        {
            using (var db = new MeritContext())
            {
                db.Add(companyMerit);
                db.SaveChanges();
            }
        }

        public void SaveCompanyProfile(Company company)
        {
            using (var db = new MeritContext())
            {
                db.Add(company);
                db.SaveChanges();
            }
        
        }
    }
}
