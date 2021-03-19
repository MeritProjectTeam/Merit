using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;
using Merit.AdvertisementService;
using Merit.Data.Models;
using Microsoft.AspNetCore.Mvc;
using Microsoft.AspNetCore.Mvc.RazorPages;

namespace Merit.Web.Pages
{
    //Edit company advertisement får foreign key error
    //Merits och Wants listas inte i edit-rutan
    //Merits och wants listas inte listboxen av annonser



    public class EditCompanyAdvertisementModel : PageModel
    {
        private IAdvertisementService advertisementService = new AdvertisementService.AdvertisementService();

        int userId = AccountService.Account.CheckCookie();

        [BindProperty]
        public CompanyAdvertisement SelectedAdvertisement { get; set; }

        [BindProperty(SupportsGet = true)]
        public int SelectedAdvertisementID { get; set; }

        [BindProperty]
        public List<CompanyAdvertisement> companyAdvertisements { get; set; }
        public void OnGet()
        {
            companyAdvertisements = advertisementService.GetAllCompanyAdvertisements(userId);

            if (SelectedAdvertisementID != 0)
            {
                SelectedAdvertisement = advertisementService.GetOneCompanyAdvertisement(SelectedAdvertisementID);
            }
        }

        public void OnPostEdit()
        {
            advertisementService.EditCompanyAdvertisement(SelectedAdvertisement);
        }
        public void OnPostDelete()
        {
            advertisementService.DeleteCompanyAdvertisement(SelectedAdvertisementID);
        }
    }
}
