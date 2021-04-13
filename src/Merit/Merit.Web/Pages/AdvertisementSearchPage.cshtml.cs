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
    public class AdvertisementSearchPageModel : PageModel
    {
        private readonly IAdvertisementService advertisementService = new AdvertisementService.AdvertisementService();

        [BindProperty(SupportsGet = true)]
        public string freeText { get; set; }
       

        [BindProperty(SupportsGet = true)]
        public int SearchType { get; set; }


        public List<CompanyAdvertisement> resultSet { get; set; }


        public void OnGet()
        {
            if (freeText != null)
            {
                if (SearchType == 1)
                { resultSet = advertisementService.FreeSearchAdvertisements(freeText); }
                else if (SearchType == 2)
                {
                    resultSet = advertisementService.FreeSearchMeritsInAdvertisements(freeText);
                }
                else if (SearchType == 3)
                {
                    resultSet = advertisementService.FreeSearchWantsInAdvertisements(freeText);
                }

            }
        }



        public void OnPost()
        {
            if (freeText != null && freeText != "")
            {
                switch (SearchType)
                {
                    case 1:
                        resultSet = advertisementService.FreeSearchAdvertisements(freeText);
                        break;
                    case 2:
                        resultSet = advertisementService.FreeSearchMeritsInAdvertisements(freeText);
                        break;
                    case 3:
                        resultSet = advertisementService.FreeSearchWantsInAdvertisements(freeText);
                        break;
                    default:
                        break;
                }
            }
        }

    }
}
