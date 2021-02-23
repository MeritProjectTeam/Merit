using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;
using Microsoft.AspNetCore.Mvc;
using Microsoft.AspNetCore.Mvc.RazorPages;

using Merit.Data.Models;
using Merit.CompanyService;

namespace Merit.Web.Pages
{
    public class CompanyModel : PageModel
    {
        private readonly ICompanyService company = new CompanyService.CompanyService();

        [BindProperty]
        public Company ACompany { get; set; }

        public void OnGet()
        {

        }

        public void OnPost()
        {
            company.SaveCompanyInfo(ACompany);
        }
    }
}
