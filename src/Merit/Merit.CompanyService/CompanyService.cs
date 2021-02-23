using Merit.Data.Data;
using Merit.Data.Models;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Merit.CompanyService
{
    public class CompanyService : ICompanyService
    {
        public Company Get(int id)
        {
            using (var db = new MeritContext())
                return db.Companies
                    .FirstOrDefault(c => c.CompanyUserID == id);
        }
        public void SaveCompany(Company company)
        {
            using (var db = new MeritContext())
            {
                db.Companies.Add(company);
                db.SaveChanges();
            }
        }
        public void UpdateCompanyInfo(Company newCompanyInfo)
        {
            using (var db = new MeritContext())
            {
                Company dbCompanyInfo = db.Companies.FirstOrDefault(x => x.CompanyUserID == newCompanyInfo.CompanyUserID);
                db.Companies.Remove(dbCompanyInfo);
                db.Companies.Add(newCompanyInfo);
                db.SaveChanges();
            };
        }
        


    }


}
