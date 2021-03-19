using Merit.Data.Data;
using Merit.Data.Models;
using System;
using System.Collections.Generic;
using System.Linq;

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

        public CompanyAdvertisement GetCompanyAdvertisement(int advertisementId)
        {
            var db = new MeritContext();
            return db.CompanyAdvertisements.Find(advertisementId);
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

        public List<CompanyMerit> GetAdvertisementMerits(int advertisementId)
        {
            var db = new MeritContext();

            return db.VisibleMerits.Where(s => s.CompanyAdvertisementId == advertisementId).Select(s => s.CompanyMerit).ToList();
        }

        public List<CompanyWants> GetAdvertisementWants(int advertisementId)
        {
            var db = new MeritContext();

            return db.VisibleWants.Where(s => s.CompanyAdvertisementId == advertisementId).Select(s => s.CompanyWants).ToList();
        }
    }
}
