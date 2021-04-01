using System;
using System.IO;
using System.Linq;
using System.Security.Cryptography;
using System.Text;
using Merit.Data.Data;
using Merit.Data.Models;
using Merit.CompanyService;
using Microsoft.EntityFrameworkCore;

namespace Merit.AccountService
{
    public class Account : IAccount
    {
        public void AddAccount(PersonalUser user)
        {
            //krypteringen sker på server-sidan, bör bytas till klient-sidan
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
            //krypteringen sker på server-sidan, bör bytas till klient-sidan
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
        public void EditCompanyUser(CompanyUser company)
        {
            using var db = new MeritContext();
            db.Attach(company).State = EntityState.Modified;
            db.SaveChanges();
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
