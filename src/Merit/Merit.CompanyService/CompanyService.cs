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
        public void SaveCompany(CompanyInfo company)
        {
            using (var db = new MeritContext())
            {
                db.Add(company);
                db.SaveChanges();
            }
        }
        public CompanyInfo Get(int id)
        {
            using (var db = new MeritContext())
                return db.CompanyInfo
                    .FirstOrDefault(p => p.CompanyUserID == id);
        }
    }
}
