using Merit.Data.Models;
using System;
namespace Merit.AccountService
{
    public interface IAccount
    {
        public void AddAccount(PersonalUser user);
        public void AddAccount(CompanyUser user);
        public PersonalUser GetPersonalUser(string identity);
        public PersonalUser GetPersonalUser(int personalUserId);
        public void EditPersonalUser(PersonalUser user);
        public void EditCompanyUser(CompanyUser company);
        public CompanyUser GetCompanyUser(string identity);
        public CompanyUser GetCompanyUser(int companyUserId);
        public void DeletePersonalUser(int userId);

        public void DeleteCompanyUser(int userId);
    }
}
