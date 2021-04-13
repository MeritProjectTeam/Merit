using Merit.Data.Data;
using Merit.Data.Models;
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
            return db.CompanyAdvertisements.FirstOrDefault(x => x.CompanyAdvertisementId == advertisementId);
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

        public List<CompanyAdvertisement> FreeSearchAdvertisements(string freeText)
        {
            var db = new MeritContext();
            freeText = freeText.ToLower();
            var result = db.CompanyAdvertisements
               .Where(x => x.Duration.ToLower().Contains(freeText) || x.Extent.ToLower().Contains(freeText) || x.FormOfEmployment.ToLower().Contains(freeText) || x.Information.ToLower().Contains(freeText) || x.Place.ToLower().Contains(freeText) || x.Profession.ToLower().Contains(freeText) || x.Salary.ToLower().Contains(freeText)).ToList();

            List<CompanyAdvertisement> meritSearch = FreeSearchMeritsInAdvertisements(freeText);
            List<CompanyAdvertisement> wantsSearch = FreeSearchWantsInAdvertisements(freeText);

            foreach (var ad in meritSearch)
            {
                if (result.FirstOrDefault(s => s.CompanyAdvertisementId == ad.CompanyAdvertisementId) == null)
                {
                    result.Add(ad);
                }
            }
            foreach (var ad in wantsSearch)
            {
                if (result.FirstOrDefault(s => s.CompanyAdvertisementId == ad.CompanyAdvertisementId) == null)
                {
                    result.Add(ad);
                }
            }

            result.OrderBy(x => x.CompanyAdvertisementId);

            return result;
        }


        public List<CompanyAdvertisement> FreeSearchWantsInAdvertisements(string freeText)
        {
            var db = new MeritContext();
            freeText = freeText.ToLower();
            var advertisements = db.VisibleWants
           .Where(x => x.CompanyWants.Want.ToLower().Contains(freeText))
           .Select(s => s.CompanyAdvertisement).ToList();


            return advertisements;
        }

        public List<CompanyAdvertisement> FreeSearchMeritsInAdvertisements(string freeText)
        {

            var db = new MeritContext();
            freeText = freeText.ToLower();
            var advertisements = db.VisibleMerits
           .Where(x => x.CompanyMerit.Category.ToLower().Contains(freeText) || x.CompanyMerit.SubCategory.ToLower().Contains(freeText) || x.CompanyMerit.Description.ToLower().Contains(freeText))
           .Select(s => s.CompanyAdvertisement).ToList();


            return advertisements;

        }

        public bool WantExistsInAdvertisement(int companyWantId)
        {
            var db = new MeritContext();
            if (db.VisibleWants.FirstOrDefault(x => x.CompanyWantsId == companyWantId) == null)
            {
                return false;
            }
            return true;


        }

        public bool MeritExistsInAdvertisement(int companyMeritId)
        {
            var db = new MeritContext();
            if (db.VisibleMerits.FirstOrDefault(x => x.CompanyMeritId == companyMeritId) == null)
            {
                return false;
            }
            return true;


        }
    }
}
