﻿using Merit.Data.Data;
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
            using var db = new MeritContext();
            return db.CompanyInfo
                .FirstOrDefault(c => c.CompanyUserId == id);
        }
        public void SaveCompany(CompanyInfo company)
        {
            using MeritContext db = new MeritContext();

            db.Add(company);
            db.SaveChanges();
        }
        public void EditCompanyInfo(CompanyInfo info)
        {
            using var db = new MeritContext();
            
            var existingInfo = db.CompanyInfo.FirstOrDefault(c => c.CompanyUserId == info.CompanyUserId);

            if (existingInfo != null)
            {
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

        public List<CompanyInfo> GetAllCompany()
        {
            List<CompanyInfo> aaa = new List<CompanyInfo>();
            using var db = new MeritContext();
            return aaa = db.CompanyInfo.ToList();
        }

        public void DeleteCompanyInfo(int userId)
        {
            using var db = new MeritContext();
            var imageInfo = db.CompanyImages.FirstOrDefault(x => x.CompanyUserId == userId);
            if (imageInfo != null)
            {
                db.CompanyImages.Remove(imageInfo);
            }
            var companyInfo = db.CompanyInfo.FirstOrDefault(x => x.CompanyUserId == userId);
            db.CompanyInfo.Remove(companyInfo);
            db.SaveChanges();
        }
    }
}
