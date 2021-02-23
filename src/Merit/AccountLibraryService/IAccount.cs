using Merit.Data.Models;
using System;
namespace Merit.AccountService
{
    public interface IAccount
    {
        public void AddAccount(PersonalUser user);
        public void AddAccount(CompanyUser user);
        public PersonalUser GetUser(int id);
        public int CheckExistingAccount(PersonalUser user);
        public int CheckExistingAccount(CompanyUser user);
        public int CheckLogin(PersonalUser user);
        
    }
}
