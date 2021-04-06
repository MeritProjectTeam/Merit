using Merit.Data.Models;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Merit.AdvertisementService
{
    public interface IAdvertisementService
    {
        public int SaveAdvertisement(CompanyAdvertisement companyAdvertisement);

        public void UpdateAdvertisement(CompanyAdvertisement companyAdvertisement);

        public void SaveVisibleMerit(VisibleMerit merit);

        public void SaveVisibleWant(VisibleWant want);

        public CompanyAdvertisement GetOneCompanyAdvertisement(int advertisementId);
        public List<CompanyAdvertisement> GetAllCompanyAdvertisements(int userId);
        public List<CompanyAdvertisement> FreeSearchAdvertisements(string freeText);

        public List<CompanyAdvertisement> FreeSearchMeritsInAdvertisements(string freeText);
        public List<CompanyAdvertisement> FreeSearchWantsInAdvertisements(string freeText);
        public List<CompanyMerit> GetAdvertisementMerits(int advertisementId);

        public List<CompanyWants> GetAdvertisementWants(int advertisementId);
        public void EditCompanyAdvertisement(CompanyAdvertisement companyAdvertisementToEdit);
        public void DeleteCompanyAdvertisement(int selectedAdvertisementId);

        public void DeleteVisibleMerits(int selectedAdvertisementId);
        public void DeleteVisibleWants(int selectedAdvertisementId);
        public ICollection<VisibleMerit> GetVisibleMerits(int selectedAdvertisementId);
        public ICollection<VisibleWant> GetVisibleWants(int selectedAdvertisementId);

        public bool WantExistsInAdvertisement(int companyWantId);
        public bool MeritExistsInAdvertisement(int companyMeritId);
    }
}
