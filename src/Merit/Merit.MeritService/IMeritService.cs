using System;
using System.IO;
using System.Linq;

using System.Text;
using Merit.Data.Data;
using Merit.Data.Models;


namespace Merit.MeritService
{
    public interface IMeritService
    {
        void SaveMerit(PersonalMerit merit);
        void SaveMeritBusiness(CompanyMerit bMerit);
        List<PersonalMerit> ReadMerit();
        List<CompanyMerit> ReadMerit();

        
    }
}
