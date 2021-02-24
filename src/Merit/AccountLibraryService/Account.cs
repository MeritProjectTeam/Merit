using System;
using System.IO;
using System.Linq;
using System.Security.Cryptography;
using System.Text;
using Merit.Data.Data;
using Merit.Data.Models;
using Merit.CompanyService;

namespace Merit.AccountService
{
    public class Account : IAccount
    {
        public void AddAccount(PersonalUser user)
        {
            //krypteringen sker på server-sidan, bör bytas till klient-sidan
            using (var db = new MeritContext())
            {
                user.Password = EncryptPassword(user.Password);
                db.Add(user);
                db.SaveChanges();

                try
                {
                    PersonalInfo info = new PersonalInfo();
                    info.PersonalUserID = user.PersonalUserId;
                    db.Add(info);
                    db.SaveChanges();
                }
                catch (Exception)
                {
                    db.Remove(user);
                    db.SaveChanges();
                }
            }
        }
        public void AddAccount(CompanyUser user)
        {
            //krypteringen sker på server-sidan, bör bytas till klient-sidan

            using (var db = new MeritContext())
            {
                user.Password = EncryptPassword(user.Password);
                db.Add(user);
                db.SaveChanges();

                try
                {
                    CompanyInfo info = new CompanyInfo();
                    info.CompanyUserID = user.CompanyUserID;
                    db.Add(info);
                    db.SaveChanges();
                }
                catch (Exception)
                {
                    db.Remove(user);
                    db.SaveChanges();
                }

            }
        }
        public PersonalUser GetUser(int id)
        {
            using (var db = new MeritContext())
                return db.PersonalUsers
                    .FirstOrDefault(p => p.PersonalUserId == id);
        }

        public int CheckExistingAccount(PersonalUser user)
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
                
                userIdAndUserType[0] = companyUserValid.CompanyUserID;
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

    }
}
