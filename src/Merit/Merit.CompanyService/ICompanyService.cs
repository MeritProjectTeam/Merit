using Merit.Data.Models;
using System;


namespace Merit.CompanyService
{
    public interface ICompanyService
    {
        public Company Get(int id);

         public void UpdateCompanyInfo(Company newCompanyInfo);
        public void SaveCompany(Company company);
         
    }
}