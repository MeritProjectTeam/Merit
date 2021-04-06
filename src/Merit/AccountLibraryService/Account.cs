using Merit.Data;
using Merit.Data.Data;
using Merit.Data.Models;
using Merit.MeritService;
using Merit.PersonalInfoService;
using Merit.WantsService;
using Microsoft.EntityFrameworkCore;
using System;
using System.Collections.Generic;
using System.IO;
using System.Linq;
using System.Security.Cryptography;
using System.Text;

namespace Merit.AccountService
{
    public class Account : IAccount
    {
        private AccountRequest source = new();
        public void AddAccount(PersonalUser user)
        {
            using var db = new MeritContext();
            db.Add(user);
            db.SaveChanges();

            try
            {
                PersonalInfo info = new();
                info.PersonalUserId = user.PersonalUserId;
                db.Add(info);
                db.SaveChanges();
            }
            catch (Exception)
            {
                db.Remove(user);
                db.SaveChanges();
            }
        }

        public void AddAccount(CompanyUser user)
        {
            using var db = new MeritContext();
            db.Add(user);
            db.SaveChanges();

            try
            {
                CompanyInfo info = new();
                info.CompanyUserId = user.CompanyUserId;
                db.Add(info);
                db.SaveChanges();
            }
            catch (Exception)
            {
                db.Remove(user);
                db.SaveChanges();
            }
        }

        public PersonalUser GetPersonalUser(string identity)
        {
            using var db = new MeritContext();
            return db.PersonalUsers
                .FirstOrDefault(p => p.Identity == identity);
        }
        public void EditPersonalUser(PersonalUser user)
        {
            using var db = new MeritContext();
            db.Attach(user).State = EntityState.Modified;
            db.SaveChanges();
        }
        public CompanyUser GetCompanyUser(string identity)
        {
            using var db = new MeritContext();
            return db.CompanyUsers
                .FirstOrDefault(p => p.Identity == identity);
        }
        public void EditCompanyUser(CompanyUser user)
        {
            using var db = new MeritContext();
            db.Attach(user).State = EntityState.Modified;
            db.SaveChanges();
        }

        public CompanyUser GetCompanyUser(int companyUserId)
        {
            using var db = new MeritContext();
            return db.CompanyUsers.FirstOrDefault(x => x.CompanyUserId == companyUserId);
        }
    }
}