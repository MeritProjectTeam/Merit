using System;
using System.IO;
using System.Security.Cryptography;
using System.Text;

namespace AccountLibraryService
{
    public class Account : IAccount
    {
        public void AddAccount(User user)
        {
            using StreamWriter sw = new StreamWriter("wwwroot/Datafile/MeritAccountMockar.csv", true);
            sw.WriteLine($"{user.UserName},{user.Email},{EncryptPassword(user.Password)}");
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
