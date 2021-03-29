using Merit.Data.Models;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Merit.WantsService
{
    public interface IWantsService
    {
        public void CreatePersonalWant(PersonalWants personalWant);
        public void CreateCompanyWant(CompanyWants companyWant);
        public List<PersonalWants> GetAllPersonalWants(int userId);
        public List<CompanyWants> GetAllCompanyWants(int userId);
        PersonalWants GetPersonalWant(int id);
        CompanyWants GetCompanyWant(int id);
        public void EditCompanyWant(CompanyWants updatedWant);
        public void EditPersonalWant(PersonalWants updatedWant);
        public void DeleteCompanyWant(CompanyWants deleteWant);
        public void DeletePersonalWant(PersonalWants deleteWant);
        public List<PersonalWants> AllPersonalWantsToList();
        public List<CompanyWants> AllCompanyWantsToList();
    }
}
