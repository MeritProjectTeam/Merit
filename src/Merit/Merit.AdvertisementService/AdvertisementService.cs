using Merit.Data.Data;
using Merit.Data.Models;
using System;
using System.Linq;

namespace Merit.AdvertisementService
{
    public class AdvertisementService : IAdvertisementService
    {
        //public int GetAdvertisementId(int userId)
        //{
        //    using (var db = new MeritContext())
        //    {
        //        db.CompanyAdvertisements.FirstOrDefault(z => z.CompanyUserId == userId).
        //    }
        //    return
        //}

        public int SaveAdvertisement(CompanyAdvertisement companyAdvertisement)
        {
            var db = new MeritContext();

            db.CompanyAdvertisements.Add(companyAdvertisement);
            db.SaveChanges();

            return companyAdvertisement.CompanyAdvertisementId;
           
        }

        public void UpdateAdvertisement(CompanyAdvertisement companyAdvertisement)
        {
            var db = new MeritContext();

            db.CompanyAdvertisements.Update(companyAdvertisement);
            db.SaveChanges();
        }
    }
}
