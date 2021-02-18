using System;
using System.IO;
using System.Linq;
using System.Security.Cryptography;
using System.Text;
using Merit.Data.Data;
using Merit.Data.Models;

namespace Merit.AccountService
{
    public class Account : IAccount
    {
        public void AddAccount(User user)
        {
            //krypteringen sker på server-sidan, bör bytas till klient-sidan
            using (var db = new MeritContext())
            {
                user.Password = EncryptPassword(user.Password);
                db.Add(user);
                db.SaveChanges();
            }
        }
        public User GetUser(int id)
        {
            using (var db = new MeritContext())
                return db.Users
                    .FirstOrDefault(p => p.UserID == id);

        }

        public int CheckExistingAccount(User user)
        {
            using var db = new MeritContext() ;

            var userNameExists = db.Users
                .FirstOrDefault(x => x.UserName.ToLower() == user.UserName.ToLower());
            var emailExists = db.Users
                .FirstOrDefault(x => x.Email.ToLower() == user.Email.ToLower());

            if (userNameExists != null)
            {
                return 101;
            }
            else if (emailExists != null)
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

        public int CheckLogin(User user)
        {
            using var db = new MeritContext();
            var validLogin = db.Users
                .FirstOrDefault(x => x.UserName.ToLower() == user.UserName.ToLower() && x.Password == EncryptPassword(user.Password));
            if (validLogin != null)
            {
                return validLogin.UserID;
            }
            return 0;
        }
    }
}
