using Merit.Data.Models;
using System;
namespace AccountLibraryService
{
    public interface IAccount
    {
        public void AddAccount(User user);
        public int CheckExistingAccount(User user);
        public bool CheckLogin(User user);
        public User GetUser(int id);
    }
}
