using Merit.Data.Models;
using System;
namespace Merit.AccountService
{
    public interface IAccount
    {
        public void AddAccount(PersonalUser user);
        public void AddAccount(CompanyUser user);
        public PersonalUser GetPersonalUser(string id);
        public void EditPersonalUser(PersonalUser user);
        public void EditCompanyUser(CompanyUser company);
        public CompanyUser GetCompanyUser(string id);
        public int CheckExistingAccount(PersonalUser user);
        public int CheckExistingAccount(CompanyUser user);
        public int[] CheckLogin(User user);

    }
}
