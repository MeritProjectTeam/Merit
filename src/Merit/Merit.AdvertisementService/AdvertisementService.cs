using Merit.Data.Data;
using Merit.Data.Models;
using System;

namespace Merit.AdvertisementService
{
    public class AdvertisementService : IAdvertisementService
    {
        public int SaveAdvertisement(CompanyAdvertisement companyAdvertisement)
        {
            var db = new MeritContext();

            db.CompanyAdvertisements.Add(companyAdvertisement);
            db.SaveChanges();

            return companyAdvertisement.CompanyAdvertisementId;

        }

        public void SaveVisibleMerit(VisibleMerit merit)
        {
            var db = new MeritContext();
            db.VisibleMerits.Add(merit);
            db.SaveChanges();
        }

        public void SaveVisibleWant(VisibleWant want)
        {
            var db = new MeritContext();
            db.VisibleWants.Add(want);
            db.SaveChanges();
        }

        public void UpdateAdvertisement(CompanyAdvertisement companyAdvertisement)
        {
            var db = new MeritContext();

            db.CompanyAdvertisements.Update(companyAdvertisement);
            db.SaveChanges();
        }
    }
}
