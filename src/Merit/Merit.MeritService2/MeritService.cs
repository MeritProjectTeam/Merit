using Merit.Data.Data;
using Merit.Data.Models;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Merit.MeritService
{
    public class MeritService : IMeritService
    {
        

        public void SaveMerit(PersonalMerit merit)
        {
            //behöver denna också en metod som plockar in vem som är inloggad?

            using (var db = new MeritContext())
            {
                db.PersonalMerits.Add(merit);
                db.SaveChanges();
            }
        }
        
        public void SaveMeritBusiness(CompanyMerit merit)
        {
            using (var db = new MeritContext())
            {
                db.CompanyMerits.Add(merit);
                db.SaveChanges();
            }
        }

        public List<PersonalMerit> ReadPersonalMerits(int userId)
        {
            using (var db = new MeritContext())
            {
                var l = db.PersonalMerits
                    .Where(l => l.UserID == userId)
                    .AsEnumerable()
                    .ToList();
                return l;
            }
        }

        public List<CompanyMerit> ReadCompanyMerits(int companyUserId)
        {
            using (var db = new MeritContext())
            {
                var l = db.CompanyMerits
                    .Where(l => l.CompanyId == companyUserId)
                    .AsEnumerable()
                    .ToList();
                return l;
            }
        }
    }
}
