using Merit.Data.Models;
using System;


namespace Merit.CompanyService
{
    public interface ICompanyService
    {
        public void SaveCompany(Company company);
        public Company Get(int id);
    }
}