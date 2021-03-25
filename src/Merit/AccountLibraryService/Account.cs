﻿using System;
using System.IO;
using System.Linq;
using System.Security.Cryptography;
using System.Text;
using Merit.Data.Data;
using Merit.Data.Models;
using Merit.CompanyService;
using Merit.Data;

namespace Merit.AccountService
{
    public class Account : IAccount
    {
        private AccountRequest source = new();
        public void AddAccount(PersonalUser user)
        {
            user.Password = EncryptPassword(user.Password);
            source.AddAccount(user);
        }

        public void AddAccount(CompanyUser user)
        {
            user.Password = EncryptPassword(user.Password);
            source.AddAccount(user);
        }

        public PersonalUser GetPersonalUser(int id) => source.GetPersonalUser(id);
        public CompanyUser GetCompanyUser(int id) => source.GetCompanyUser(id);

        public AccountCheck CheckExistingAccount(PersonalUser user)
        {
            using var db = new MeritContext() ;

            var userNameExists = db.PersonalUsers
                .FirstOrDefault(x => x.UserName.ToLower() == user.UserName.ToLower());
            var emailExists = db.PersonalUsers
                .FirstOrDefault(x => x.Email.ToLower() == user.Email.ToLower());

            var companyUserNameExists = db.CompanyUsers
                .FirstOrDefault(x => x.UserName.ToLower() == user.UserName.ToLower());
            var companyEmailExists = db.CompanyUsers
                .FirstOrDefault(x => x.Email.ToLower() == user.Email.ToLower());

            if (userNameExists != null || companyUserNameExists != null)
            {   
                return AccountCheck.NameExists;
            }
            else if (emailExists != null || companyEmailExists != null)
            {
                return AccountCheck.MailExists;
            }
            else
            {
                return AccountCheck.NoUserExists;
            }
        }

        public int CheckExistingAccount(CompanyUser user)
        {
            using var db = new MeritContext();

            var userNameExists = db.PersonalUsers
                .FirstOrDefault(x => x.UserName.ToLower() == user.UserName.ToLower());
            var emailExists = db.PersonalUsers
                .FirstOrDefault(x => x.Email.ToLower() == user.Email.ToLower());

            var companyUserNameExists = db.CompanyUsers
                .FirstOrDefault(x => x.UserName.ToLower() == user.UserName.ToLower());
            var companyEmailExists = db.CompanyUsers
                .FirstOrDefault(x => x.Email.ToLower() == user.Email.ToLower());

            if (userNameExists != null || companyUserNameExists != null)
            {
                return 101;
            }
            else if (emailExists != null || companyEmailExists != null)
            {
                return 102;
            }
            else
            {
                return 100;
            }
        }
        public static string EncryptPassword(string password)
        {
            MD5 mD5 = MD5.Create();
            byte[] inputBytes = Encoding.ASCII.GetBytes(password);
            byte[] hash = mD5.ComputeHash(inputBytes);

            string result = "";

            foreach (var h in hash)
            {
                result += h.ToString("X2");
            }

            return result;
        }

        public int[] CheckLogin(User user)
        {
            using var db = new MeritContext();
            var personalUserValid = db.PersonalUsers
                .FirstOrDefault(x => x.UserName.ToLower() == user.UserName.ToLower() && x.Password == EncryptPassword(user.Password));
            var companyUserValid = db.CompanyUsers
                .FirstOrDefault(x => x.UserName.ToLower() == user.UserName.ToLower() && x.Password == EncryptPassword(user.Password));

            int[] userIdAndUserType = new int[] {0,0};
            if (personalUserValid != null)
            {
                userIdAndUserType[0] = personalUserValid.PersonalUserId;
                userIdAndUserType[1] = 1;
                return userIdAndUserType;
            }
            else if (companyUserValid != null)
            {
                
                userIdAndUserType[0] = companyUserValid.CompanyUserId;
                userIdAndUserType[1] = 2;
                return userIdAndUserType;
            }
            return  userIdAndUserType;
        }
        public static void CreateCookie(int? userId)
        {
            using StreamWriter sw = new StreamWriter("wwwroot/DataFile/cookie.txt", false);
            sw.WriteLine(userId);
        }
        public static int CheckCookie()
        {
            using StreamReader sr = new StreamReader("wwwroot/DataFile/cookie.txt");
            bool ok = int.TryParse(sr.ReadLine(), out int id);
            if(ok)
            {
                return id;
            }
            return 0;
        }

        // TODO: Tempfix
        int IAccount.CheckExistingAccount(PersonalUser user)
        {
            throw new NotImplementedException();
        }
    }
}
