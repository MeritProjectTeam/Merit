using Merit.Data.Models;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Merit.MeritService
{
    public interface IMeritService
    {
        PersonalMerit GetPersonalMerit(int id);
        void SaveMerit(PersonalMerit merit);
        void SaveMeritBusiness(CompanyMerit bMerit);
        List<PersonalMerit> ReadPersonalMerits(int userId);
        List<CompanyMerit> ReadCompanyMerits(int companyUserId);
        void EditPersonalMerit(PersonalMerit personalMerit);
        void EditCompanyMerit(CompanyMerit merit);
        CompanyMerit GetCompanyMerit(int id);
        void DeleteCompanyMerit(CompanyMerit cMerit);
        void DeletePersonalMerit(PersonalMerit pMerit);

        public List<PersonalMerit> GetAllPersonalMerits();
        public List<CompanyMerit> GetAllCompanyMerits();
    }
}
