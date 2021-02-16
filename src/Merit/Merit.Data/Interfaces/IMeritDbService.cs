using Merit.Data.Models;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Merit.Data.Interfaces
{
    public interface IMeritDbService
    {
        void SaveMerit(PersonalMerit merit);
        void SavePersonProfile(PersonalInfo personal);
        void SaveCompanyMerit(CompanyMerit companyMerit);
        void SaveCompanyProfile(Company company);
    }
}
