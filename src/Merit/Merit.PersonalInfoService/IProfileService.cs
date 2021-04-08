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
        public Task SaveImage(PersonalImage image);
        public Task SaveImage(CompanyImage image);
        public Task<CompanyImage> GetImage(CompanyUser companyUser);
        public Task<PersonalImage> GetImage(PersonalUser personalUser);

        public List<PersonalInfo> GetAllPersons();
    }
}
