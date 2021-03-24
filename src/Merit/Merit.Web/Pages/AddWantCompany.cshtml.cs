using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;
using Merit.Data.Models;
using Merit.WantsService;
using Microsoft.AspNetCore.Mvc;
using Microsoft.AspNetCore.Mvc.RazorPages;

namespace Merit.Web.Pages
{
    public class AddWantCompanyModel : PageModel
    {
        private readonly IWantsService wantsService = new WantsService.WantsService();
        public bool Visi { get; set; } = false;
        public bool Neggo { get; set; }
        [BindProperty]
        public CompanyWants CompanyWant { get; set; }
        public string Message { get; set; }
        public string alertlook { get; set; }
        public void OnGet()
        {
        }
        public void OnPost()
        {
            Visi = true;
            if (CompanyWant.Want != null)
            {
                alertlook = "success";
                Message = "Önskemål skapat!";
                int userId = AccountService.Account.CheckCookie();
                if (userId != 0)
                {
                    CompanyWant.CompanyUserId = userId;
                    wantsService.CreateCompanyWant(CompanyWant);

                }
                
            }
            else
            {
                Message = "Fyll i rutan";
                alertlook = "danger";
            }

        }
    }
}
