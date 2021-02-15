using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;
using Microsoft.AspNetCore.Mvc;
using Microsoft.AspNetCore.Mvc.RazorPages;
using Merit.CompanyService;

namespace Merit.Web.Pages
{
    public class CompanyModel : PageModel
    {
        private readonly ICompanyService companyService = new CompanyService.CompanyService();

        [BindProperty]
        public string CompanyName { get; set; }
        [BindProperty]
        public string OrgNumber { get; set; }
        [BindProperty]
        public string ContactPerson { get; set; }
        [BindProperty]
        public string Email { get; set; }
        [BindProperty]
        public string Phone { get; set; }
        [BindProperty]
        public string Street { get; set; }
        [BindProperty]
        public string Zipcode { get; set; }
        [BindProperty]
        public string City { get; set; }

        public void OnGet()
        {

        }

        public void OnPost()
        {
            companyService.SaveCompany(CompanyName, OrgNumber);
            companyService.SaveContactPerson(ContactPerson, Email, Phone);
            companyService.SaveAdress(Street, Zipcode, City);
        }
    }
}
