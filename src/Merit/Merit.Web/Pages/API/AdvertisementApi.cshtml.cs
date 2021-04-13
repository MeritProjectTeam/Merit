using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;
using Merit.AccountService;
using Merit.AdvertisementService;
using Merit.Data.Data;
using Merit.Data.Models;
using Merit.MeritService;
using Merit.WantsService;
using Microsoft.AspNetCore.Mvc;
using Microsoft.AspNetCore.Mvc.RazorPages;
using Microsoft.EntityFrameworkCore;

namespace Merit.Web.Pages.API
{
    public class AdvertisementApiModel : PageModel
    {
        public IAdvertisementService advertisementService = new AdvertisementService.AdvertisementService();
        public IMeritService meritService = new MeritService.MeritService();
        public IWantsService wantsService = new WantsService.WantsService();
        public IAccount account = new Account();

        public MeritContext db = new();

        public IActionResult OnGet(int? advertisementId, int? companyId)
        {

            if (advertisementId != null)
            {
                var result = advertisementService.GetOneCompanyAdvertisement((int)advertisementId);
                if(result == null)
                {
                    return new JsonResult("Ingen annons hittades med angivet annonsid");
                }
                result.CompanyMerits = advertisementService.GetAdvertisementMerits((int)advertisementId);
                result.CompanyWants = advertisementService.GetAdvertisementWants((int)advertisementId);

                var companyUserName = db.CompanyUsers.FirstOrDefault(x => x.CompanyUserId == result.CompanyUserId).UserName.ToString();

                return new JsonResult(new { companyUserName, result });
            }
            else if (advertisementId == null && companyId != null)
            {
                var result = advertisementService.GetAllCompanyAdvertisements((int)companyId);
                if (result.Count == 0)
                {
                    return new JsonResult("Inga annonser hittades från det här företaget");
                }
                foreach (var advertisement in result)
                {
                    advertisement.CompanyMerits = advertisementService.GetAdvertisementMerits(advertisement.CompanyAdvertisementId);
                    advertisement.CompanyWants = advertisementService.GetAdvertisementWants(advertisement.CompanyAdvertisementId);
                }

                string CompanyUserName = db.CompanyUsers.FirstOrDefault(x => x.CompanyUserId == (int)companyId).UserName;
                return new JsonResult(new { CompanyUserName, result });
            }
            else
            {
                var result = db.CompanyAdvertisements.ToList();
                if (result.Count == 0)
                {
                    return new JsonResult("Inga annonser hittades i databasen");
                }
                Dictionary<string, CompanyAdvertisement[]> list = new();

                foreach (var advertisement in result)
                {
                    advertisement.CompanyMerits = advertisementService.GetAdvertisementMerits(advertisement.CompanyAdvertisementId);
                    advertisement.CompanyWants = advertisementService.GetAdvertisementWants(advertisement.CompanyAdvertisementId);
                }

                var resultset = result.GroupBy(x => x.CompanyUserId);
                foreach (var group in resultset)
                {
                    list.Add(account.GetCompanyUser(group.Key).UserName, group.ToArray());
                }

                return new JsonResult(list);
            }
        }
    }
}
