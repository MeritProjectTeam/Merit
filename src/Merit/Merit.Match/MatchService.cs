using Merit.AccountService;
using Merit.AdvertisementService;
using Merit.Data.Data;
using Merit.Data.Models;
using Merit.MatchService;
using Merit.MeritService;
using Merit.WantsService;
using System;
using System.Collections.Generic;
using System.Linq;

namespace Merit.MatchService
{
    public class MatchService : IMatchService
    {
        private readonly IWantsService wantsService = new WantsService.WantsService();
        private readonly IMeritService meritService = new MeritService.MeritService();
        private readonly IAdvertisementService advertisementService = new AdvertisementService.AdvertisementService();
        private readonly IAccount accountService = new AccountService.Account();


        public List<PersonalUser> MatchCompanyUser(CompanyUser cUser)
        {
            var db = new MeritContext();
            List<CompanyWants> wants = wantsService.GetAllCompanyWants(cUser.CompanyUserId);
            List<CompanyMerit> merits = meritService.ReadCompanyMerits(cUser.CompanyUserId);
            List<PersonalUser> listOfPersonalUsers = new();

            foreach (var want in wants)
            {
                var q = db.PersonalMerits.Where(q => q.Category.ToLower().Contains(want.Want.ToLower())
                                                  || q.SubCategory.ToLower().Contains(want.Want.ToLower())
                                                  || q.Description.ToLower().Contains(want.Want.ToLower())).ToList();
                foreach (var item in q)
                {
                    if (listOfPersonalUsers.Find(x => x.PersonalUserId == item.PersonalUserId) == null)
                    {
                        listOfPersonalUsers.Add(db.PersonalUsers.FirstOrDefault(x => x.PersonalUserId == item.PersonalUserId));
                    }
                }
            }

            foreach (var merit in merits)
            {
                var q = db.PersonalWants.Where(q => merit.Category.ToLower().Contains(q.Want.ToLower())
                                                  || merit.SubCategory.ToLower().Contains(q.Want.ToLower())
                                                  || merit.Description.ToLower().Contains(q.Want.ToLower())).ToList();
                foreach (var item in q)
                {
                    if (listOfPersonalUsers.Find(x => x.PersonalUserId == item.PersonalUserId) == null)
                    {
                        listOfPersonalUsers.Add(db.PersonalUsers.FirstOrDefault(x => x.PersonalUserId == item.PersonalUserId));
                    }
                }
            }


            return listOfPersonalUsers;
        }

        public List<CompanyUser> MatchPersonalUser(PersonalUser pUser)
        {
            var db = new MeritContext();
            List<PersonalWants> wants = wantsService.GetAllPersonalWants(pUser.PersonalUserId);
            List<PersonalMerit> merits = meritService.ReadPersonalMerits(pUser.PersonalUserId);
            List<CompanyUser> listOfCompanyUsers = new();

            foreach (var want in wants)
            {
                var q = db.CompanyMerits.Where(q => q.Category.ToLower().Contains(want.Want.ToLower())
                                                  || q.SubCategory.ToLower().Contains(want.Want.ToLower())
                                                  || q.Description.ToLower().Contains(want.Want.ToLower())).ToList();
                foreach (var item in q)
                {
                    if (listOfCompanyUsers.Find(x => x.CompanyUserId == item.CompanyUserId) == null)
                    {
                        listOfCompanyUsers.Add(db.CompanyUsers.FirstOrDefault(x => x.CompanyUserId == item.CompanyUserId));
                    }
                }
            }

            foreach (var merit in merits)
            {
                var q = db.CompanyWants.Where(q => merit.Category.ToLower().Contains(q.Want.ToLower())
                                                  || merit.SubCategory.ToLower().Contains(q.Want.ToLower())
                                                  || merit.Description.ToLower().Contains(q.Want.ToLower())).ToList();
                foreach (var item in q)
                {
                    if (listOfCompanyUsers.Find(x => x.CompanyUserId == item.CompanyUserId) == null)
                    {
                        listOfCompanyUsers.Add(db.CompanyUsers.FirstOrDefault(x => x.CompanyUserId == item.CompanyUserId));
                    }
                }
            }


            return listOfCompanyUsers;

        }

        public List<CompanyAdvertisement> MatchAdvertisement(PersonalUser pUser)
        {
            var db = new MeritContext();
            List<PersonalWants> wants = wantsService.GetAllPersonalWants(pUser.PersonalUserId);
            List<PersonalMerit> merits = meritService.ReadPersonalMerits(pUser.PersonalUserId);
            List<CompanyAdvertisement> listOfAdvertisement = new();

            IAdvertisementService advertisementService = new AdvertisementService.AdvertisementService();

            foreach (var want in wants)
            {
                var q = db.CompanyAdvertisements.Where(x => x.Duration.ToLower().Contains(want.Want)
                                                            || x.Extent.ToLower().Contains(want.Want)
                                                            || x.FormOfEmployment.ToLower().Contains(want.Want)
                                                            || x.Information.ToLower().Contains(want.Want)
                                                            || x.Place.ToLower().Contains(want.Want)
                                                            || x.Profession.ToLower().Contains(want.Want)
                                                            || x.Salary.ToLower().Contains(want.Want)).ToList();
                foreach (var advertisement in q)
                {
                    if (listOfAdvertisement.Find(x => x.CompanyUserId == advertisement.CompanyUserId) == null)
                    {
                        listOfAdvertisement.Add(advertisement);
                    }
                }
            }
            foreach (var merit in merits)
            {
                //var q = db.CompanyAdvertisements.Where(advert => MatchAdvertProps(advert, merit)).ToList();

                var q = db.CompanyAdvertisements.Where(x => x.Duration.ToLower().Contains(merit.Category)
                                                        || x.Extent.ToLower().Contains(merit.Category)
                                                        || x.FormOfEmployment.ToLower().Contains(merit.Category)
                                                        || x.Information.ToLower().Contains(merit.Category)
                                                        || x.Place.ToLower().Contains(merit.Category)
                                                        || x.Profession.ToLower().Contains(merit.Category)
                                                        || x.Salary.ToLower().Contains(merit.Category)
                                                        || x.Duration.ToLower().Contains(merit.SubCategory)
                                                        || x.Extent.ToLower().Contains(merit.SubCategory)
                                                        || x.FormOfEmployment.ToLower().Contains(merit.SubCategory)
                                                        || x.Information.ToLower().Contains(merit.SubCategory)
                                                        || x.Place.ToLower().Contains(merit.SubCategory)
                                                        || x.Profession.ToLower().Contains(merit.SubCategory)
                                                        || x.Salary.ToLower().Contains(merit.SubCategory)
                                                        || x.Duration.ToLower().Contains(merit.Description)
                                                        || x.Extent.ToLower().Contains(merit.Description)
                                                        || x.FormOfEmployment.ToLower().Contains(merit.Description)
                                                        || x.Information.ToLower().Contains(merit.Description)
                                                        || x.Place.ToLower().Contains(merit.Description)
                                                        || x.Profession.ToLower().Contains(merit.Description)
                                                        || x.Salary.ToLower().Contains(merit.Description))
                    .ToList();
                                                        


                foreach (var advertisement in q)
                {
                    if (listOfAdvertisement.Find(x=> x.CompanyUserId == advertisement.CompanyUserId) == null)
                    {
                        listOfAdvertisement.Add(advertisement);
                    }
                }
                var q2 = db.VisibleWants.ToList();

                foreach (var want in q2)
                {
                CompanyWants cw = db.CompanyWants.FirstOrDefault(x => x.CompanyWantsId == want.CompanyWantsId);
                    
                    if (merit.Category.ToLower().Contains(cw.Want.ToLower()) || merit.SubCategory.ToLower().Contains(cw.Want.ToLower()) || merit.Description.ToLower().Contains(cw.Want.ToLower()))
                    {
                        if (listOfAdvertisement.Find(x => x.CompanyAdvertisementId == want.CompanyAdvertisementId) == null)
                        {
                            listOfAdvertisement.Add(advertisementService.GetOneCompanyAdvertisement(want.CompanyAdvertisementId));
                        }
                    }
            }
            }
          

            return listOfAdvertisement;
        }

        //private bool MatchAdvertProps(CompanyAdvertisement advert, PersonalMerit merit) =>
        //    MatchMeritProps(advert.Duration, merit)
        //    || MatchMeritProps(advert.Extent, merit)
        //    || MatchMeritProps(advert.FormOfEmployment, merit)
        //    || MatchMeritProps(advert.Information, merit)
        //    || MatchMeritProps(advert.Place, merit)
        //    || MatchMeritProps(advert.Profession, merit)
        //    || MatchMeritProps(advert.Salary, merit);



        //private bool MatchMeritProps(string value, PersonalMerit merit) =>
        //    value.Contains(merit.Category, StringComparison.InvariantCultureIgnoreCase)
        //    || value.Contains(merit.SubCategory, StringComparison.InvariantCultureIgnoreCase)
        //    || value.Contains(merit.Description, StringComparison.InvariantCultureIgnoreCase);
             


    }
}
