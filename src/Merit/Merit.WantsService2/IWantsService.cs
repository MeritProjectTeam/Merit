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
        public void CreatePersonalWant(string want, int userId);
        public void CreateCompanyWant(string want, int userId);

        public List<PersonalWants> GetPersonalWants(int userId);
        public List<CompanyWants> GetCompanyWants(int userId);

    }
}
