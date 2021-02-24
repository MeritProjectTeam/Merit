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
        void UpdatePersonalMerit(PersonalMerit personalMerit);
    }
}
