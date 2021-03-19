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

        public CompanyAdvertisement GetCompanyAdvertisement(int advertisementId);

        public List<CompanyMerit> GetAdvertisementMerits(int advertisementId);

        public List<CompanyWants> GetAdvertisementWants(int advertisementId);


    }
}
