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

        public CompanyAdvertisement GetOneCompanyAdvertisement(int advertisementId)
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

        public List<CompanyAdvertisement> GetAllCompanyAdvertisements(int userId)
        {
            var db = new MeritContext();
            return db.CompanyAdvertisements.Where(x => x.CompanyUserId == userId).ToList();
        }

        public void EditCompanyAdvertisement(CompanyAdvertisement companyAdvertisementToEdit)
        {
            var db = new MeritContext();
            db.CompanyAdvertisements.Update(companyAdvertisementToEdit);
            db.SaveChanges();
        }

        public void DeleteCompanyAdvertisement(int selectedAdvertisementId)
        {
            var db = new MeritContext();
            CompanyAdvertisement AdvertisementToRemove = db.CompanyAdvertisements.Find(selectedAdvertisementId);
            DeleteVisibleMerits(selectedAdvertisementId);
            DeleteVisibleWants(selectedAdvertisementId);
            db.CompanyAdvertisements.Remove(AdvertisementToRemove);
            db.SaveChanges();
        }

        public void DeleteVisibleMerits(int selectedAdvertisementId)
        {
            var db = new MeritContext();
            var visibleMerits = db.VisibleMerits.Where(x => x.CompanyAdvertisementId == selectedAdvertisementId);
            foreach (var merit in visibleMerits)
            {
                db.VisibleMerits.Remove(merit);
            }
            db.SaveChanges();
        }

        public void DeleteVisibleWants(int selectedAdvertisementId)
        {
            var db = new MeritContext();
            var visibleWants = db.VisibleWants.Where(x => x.CompanyAdvertisementId == selectedAdvertisementId);
            foreach (var want in visibleWants)
            {
                db.VisibleWants.Remove(want);
            }
            db.SaveChanges();
        }

        public ICollection<VisibleMerit> GetVisibleMerits(int selectedAdvertisementId)
        {
            var db = new MeritContext();
            return db.VisibleMerits.Where(x => x.CompanyAdvertisementId == selectedAdvertisementId).ToList();
        }

        public ICollection<VisibleWant> GetVisibleWants(int selectedAdvertisementId)
        {
            var db = new MeritContext();
            return db.VisibleWants.Where(x => x.CompanyAdvertisementId == selectedAdvertisementId).ToList();
        }
    }
}
