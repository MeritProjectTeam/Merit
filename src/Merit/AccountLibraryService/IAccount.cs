using Merit.Data.Models;
using System;
namespace Merit.AccountService
{
    public interface IAccount
    {
        public void AddAccount(User user);
        public int CheckExistingAccount(User user);
        public int CheckLogin(User user);
        public User GetUser(int id);
    }
}
