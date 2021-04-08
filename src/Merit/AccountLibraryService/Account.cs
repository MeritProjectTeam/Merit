using Merit.AdvertisementService;
using Merit.CompanyService;
using Merit.Data;
using Merit.Data.Data;
using Merit.Data.Models;
using Merit.MeritService;
using Merit.PersonalInfoService;
using Merit.WantsService;
using Microsoft.EntityFrameworkCore;
using System;
using System.Collections.Generic;
using System.IO;
using System.Linq;
using System.Security.Cryptography;
using System.Text;

namespace Merit.AccountService
{
    public class Account : IAccount
    {
        private AccountRequest source = new();


        private readonly IMeritService meritService = new MeritService.MeritService();
        private readonly IWantsService wantsService = new WantsService.WantsService();
        private readonly IProfileService profileService = new ProfileService();
        private readonly IAdvertisementService advertisementService = new AdvertisementService.AdvertisementService();
        private readonly ICompanyService companyService = new CompanyService.CompanyService();
        public void AddAccount(PersonalUser user)
        {
            using var db = new MeritContext();
            db.Add(user);
            db.SaveChanges();

            try
            {
                PersonalInfo info = new();
                info.PersonalUserId = user.PersonalUserId;
                db.Add(info);
                db.SaveChanges();
            }
            catch (Exception)
            {
                db.Remove(user);
                db.SaveChanges();
            }
        }

        public void AddAccount(CompanyUser user)
        {
            using var db = new MeritContext();
            db.Add(user);
            db.SaveChanges();

            try
            {
                CompanyInfo info = new();
                info.CompanyUserId = user.CompanyUserId;
                db.Add(info);
                db.SaveChanges();
            }
            catch (Exception)
            {
                db.Remove(user);
                db.SaveChanges();
            }
        }

        public PersonalUser GetPersonalUser(string identity)
        {
            using var db = new MeritContext();
            return db.PersonalUsers
                .FirstOrDefault(p => p.Identity == identity);
        }
        public PersonalUser GetPersonalUser(int personalUserId)
        {
            using var db = new MeritContext();
            return db.PersonalUsers
                .FirstOrDefault(p => p.PersonalUserId == personalUserId);
        }
        public void EditPersonalUser(PersonalUser user)
        {
            using var db = new MeritContext();
            db.Attach(user).State = EntityState.Modified;
            db.SaveChanges();
        }
        public CompanyUser GetCompanyUser(string identity)
        {
            using var db = new MeritContext();
            return db.CompanyUsers
                .FirstOrDefault(p => p.Identity == identity);
        }
        public void EditCompanyUser(CompanyUser user)
        {
            using var db = new MeritContext();
            db.Attach(user).State = EntityState.Modified;
            db.SaveChanges();
        }

        public CompanyUser GetCompanyUser(int companyUserId)
        {
            using var db = new MeritContext();
            return db.CompanyUsers.FirstOrDefault(x => x.CompanyUserId == companyUserId);
        }
        public void DeletePersonalUser(int userId)
        {
            using var db = new MeritContext();
            List<PersonalMerit> meritList = meritService.ReadPersonalMerits(userId);
            foreach (var merit in meritList)
            {
                meritService.DeletePersonalMerit(merit);
            }
            List<PersonalWants> wantsList = wantsService.GetAllPersonalWants(userId);
            foreach (var want in wantsList)
            {
                wantsService.DeletePersonalWant(want);
            }
            profileService.DeletePersonalInfo(userId);

            var personalUser = db.PersonalUsers.FirstOrDefault(x => x.PersonalUserId == userId);
            db.PersonalUsers.Remove(personalUser);
            db.SaveChanges();

        }

        public void DeleteCompanyUser(int userId)
        {
            using var db = new MeritContext();
            List<CompanyAdvertisement> list = advertisementService.GetAllCompanyAdvertisements(userId);
                        foreach (var ad in list)
            {
                advertisementService.DeleteCompanyAdvertisement(ad.CompanyAdvertisementId);
            }
            
            List<CompanyMerit> meritList = meritService.ReadCompanyMerits(userId);
            foreach (var merit in meritList)
            {
                meritService.DeleteCompanyMerit(merit);
            }
            List<CompanyWants> wantsList = wantsService.GetAllCompanyWants(userId);
            foreach (var want in wantsList)
            {
                wantsService.DeleteCompanyWant(want);
            }
            companyService.DeleteCompanyInfo(userId);

            var companyUser = db.CompanyUsers.FirstOrDefault(x => x.CompanyUserId == userId);
            db.CompanyUsers.Remove(companyUser);
            db.SaveChanges();


        }
    }
}