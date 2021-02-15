using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Merit.CompanyService
{
    public class CompanyService : ICompanyService
    {
        private Company currentCompany;
        public void SaveAdress(string street, string zipCode, string city)
        {
            currentCompany = new Company()
            {
                Street = street,
                ZipCode = zipCode,
                City = city
            };
        }

        public void SaveCompany(string companyName, string orgNumber)
        {
            currentCompany = new Company()
            {
                CompanyName = companyName,
                OrgNumber = orgNumber
            };
        }

        public void SaveContactPerson(string contactName, string email, string phone)
        {
            currentCompany = new Company()
            {
                ContactName = contactName,
                Email = email,
                Phone = phone
            };
        }
    }
}
