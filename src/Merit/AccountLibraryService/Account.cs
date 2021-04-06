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
                return id;
            }
            return 0;
        }

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

        public PersonalUser GetPersonalUser(string id)
        {
            using var db = new MeritContext();
            return db.PersonalUsers
                .FirstOrDefault(p => p.Identity == id);
        }
        public void EditPersonalUser(PersonalUser user)
        {
            using var db = new MeritContext();
            db.Attach(user).State = EntityState.Modified;
            db.SaveChanges();
        }
        public CompanyUser GetCompanyUser(string id)
        {
            using var db = new MeritContext();
            return db.CompanyUsers
                .FirstOrDefault(p => p.Identity == id);
        }

        public void AddAccount(CompanyUser user)
        {
            user.Password = EncryptPassword(user.Password);
            source.AddAccount(user);
        }
        //public static string EncryptPassword(string password)
        //{
        //    MD5 mD5 = MD5.Create();
        //    byte[] inputBytes = Encoding.ASCII.GetBytes(password);
        //    byte[] hash = mD5.ComputeHash(inputBytes);

        //    string result = "";

        //    foreach (var h in hash)
        //    {
        //        result += h.ToString("X2");
        //    }

        //    return result;
        //}
    }
}