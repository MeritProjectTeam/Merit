using Merit.Data.Models;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Merit.PersonalInfoService
{
    public interface IProfileService
    {
        public PersonalInfo Get(int id);
        public void SavePersonalInfo(PersonalInfo info);
        public void EditPersonalInfo(PersonalInfo info);

        public void SaveImage(PersonalImage image);

        public CompanyImage GetImage(CompanyUser companyUser);

        public void SaveImage(CompanyImage image);

        public PersonalImage GetImage(PersonalUser personalUser);
    }
}
