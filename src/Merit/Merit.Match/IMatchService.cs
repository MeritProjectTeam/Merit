using Merit.Data.Models;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Merit.MatchService
{
    public interface IMatchService
    {
        public List<CompanyUser> MatchPersonalUser(PersonalUser pUser);
        public List<PersonalUser> MatchCompanyUser(CompanyUser cUser);
        public List<CompanyAdvertisement> MatchAdvertisement();

    }
}
