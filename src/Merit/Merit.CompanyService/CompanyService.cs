using Merit.Data.Data;
using Merit.Data.Models;
using Microsoft.EntityFrameworkCore;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Merit.CompanyService
{
    public class CompanyService : ICompanyService
    {
        public CompanyInfo Get(int id)
        {
            using (var db = new MeritContext())
                return db.CompanyInfo
                    .FirstOrDefault(c => c.CompanyUserID == id);
        }
        public void SaveCompany(CompanyInfo company)
        {
            using (var db = new MeritContext())
            {
                db.Add(company);
                db.SaveChanges();
            }
        }
        public void UpdateCompanyInfo(CompanyInfo newCompanyInfo)
        {
            using (var db = new MeritContext())
            {
                CompanyInfo dbCompanyInfo = db.CompanyInfo.FirstOrDefault(x => x.CompanyUserID == newCompanyInfo.CompanyUserID);
                db.CompanyInfo.Remove(dbCompanyInfo);
                db.CompanyInfo.Add(newCompanyInfo);
                db.SaveChanges();
            };
        }
        public void EditCompanyInfo(CompanyInfo info)
        {
            using (var db = new MeritContext())
            {
                var existingInfo = Get(info.CompanyInfoId);

                if (existingInfo != null)
                {
                    db.Entry(existingInfo).State = EntityState.Modified;

                    existingInfo.CompanyName = info.CompanyName;
                    existingInfo.ContactName = info.ContactName;
                    existingInfo.Phone = info.Phone;
                    existingInfo.Street = info.Street;
                    existingInfo.ZipCode = info.ZipCode;
                    existingInfo.OrgNumber = info.OrgNumber;
                    existingInfo.City = info.City;

                    db.SaveChanges();
                }
            }
        }
    }
}
