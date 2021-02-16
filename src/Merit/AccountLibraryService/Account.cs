using System;
using System.IO;
using System.Linq;
using System.Security.Cryptography;
using System.Text;
using Merit.Data.Data;
using Merit.Data.Models;

namespace AccountLibraryService
{
    public class Account : IAccount
    {
        public void AddAccount(User user)
        {
            //krypteringen sker på servicesidan, bör bytas till webbsidan
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
            string input;
            using StreamReader sr = new StreamReader("wwwroot/Datafile/MeritAccountMockar.csv");
            while ((input = sr.ReadLine()) != null)
            {
                string[] splitInput = input.Split(",");
                if (splitInput[0].ToLower() == user.UserName.ToLower())
                {
                    return 101;
                }
                if (splitInput[1].ToLower() == user.Email.ToLower())
                {
                    return 102;
                }
            }
            return 100;
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

        public bool CheckLogin(User user)
        {
            string input;
            using StreamReader sr = new StreamReader("wwwroot/Datafile/MeritAccountMockar.csv");
            while ((input = sr.ReadLine()) != null)
            {
                string[] splitInput = input.Split(",");
                if (splitInput[0].ToLower() == user.UserName.ToLower() && splitInput[2] == EncryptPassword(user.Password))
                {
                    return true;
                }
            }
            return false;
        }
    }
}
