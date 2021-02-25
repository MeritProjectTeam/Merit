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

        public List<PersonalWants> GetPersonalWants(int userId);
        public List<CompanyWants> GetCompanyWants(int userId);

    }
}
