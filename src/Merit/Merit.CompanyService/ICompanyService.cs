using Merit.Data.Models;
using System;


namespace Merit.CompanyService
{
    public interface ICompanyService
    {
        public Company Get(int id);

        public void SaveCompanyInfo(Company companyInfo);
        public void UpdateCompanyInfo(Company newCompanyInfo);
        public void SaveCompany(Company company);
        public Company Get(int id);
    }
}