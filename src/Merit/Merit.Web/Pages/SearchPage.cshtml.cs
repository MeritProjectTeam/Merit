using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;
using Merit.CompanyService;
using Merit.Data.Models;
using Merit.MeritService;
using Merit.PersonalInfoService;
using Merit.WantsService;
using Microsoft.AspNetCore.Identity;
using Microsoft.AspNetCore.Mvc;
using Microsoft.AspNetCore.Mvc.RazorPages;

namespace Merit.Web.Pages
{
    public class SearchPageModel : PageModel
    {
        private IProfileService profileService = new ProfileService();
        
        private IMeritService meritService = new MeritService.MeritService();
        private IWantsService wantsService = new WantsService.WantsService();
        private ICompanyService companyService = new Merit.CompanyService.CompanyService();

        private readonly UserManager<IdentityUser> userManager;
        private readonly SignInManager<IdentityUser> signInManager;

        public SearchPageModel(UserManager<IdentityUser> userManager, SignInManager<IdentityUser> signInManager)
        {
            this.signInManager = signInManager;
            this.userManager = userManager;
        }
        [BindProperty(SupportsGet = true)]
        public int SearchType { get; set; }
        [BindProperty(SupportsGet = true)]
        public string SearchTerm { get; set; } = "";
        [BindProperty]
        public string Message { get; set; } = "";

        [BindProperty]
        public List<CompanyInfo> SearchCompanyList { get; set; }
        [BindProperty]
        public List<CompanyInfo> companies { get; set; }

        [BindProperty]
        public List<PersonalInfo> SearchPersonList { get; set; }
        [BindProperty]
        public List<PersonalInfo> persons { get; set; }

        public IActionResult OnGet()
        {
            if (!signInManager.IsSignedIn(User))
            {
                return Redirect("/Login");
            }

            //IdentityUser identity = await userManager.GetUserAsync(User);
            //IUser pUser = identity.GetUser();
            
            if(SearchTerm != "")
            {
                switch (SearchType)
                {
                    case 1:
                        OnPostSearchPerson();
                        break;
                    case 2:
                        OnPostPersonByMerit();
                        break;
                    case 3:
                        OnPostPersonByWant();
                        break;
                    case 4:
                        OnPostSearchCompany();
                        break;
                    case 5:
                        OnPostCompanyByMerit();
                        break;
                    case 6:
                        OnPostCompanyByWant();
                        break;
                    default:
                        break;
                }
            }

            return Page();
        }



        public void OnPostSearchCompany()
        {
            if (!signInManager.IsSignedIn(User))
            {
                Redirect("/Login");
            }
            if (!string.IsNullOrEmpty(SearchTerm))
            {
                companies = companyService.GetAllCompany();
                SearchCompanyList = companies.Where(a => a.CompanyName.ToLower().Contains(SearchTerm.ToLower())).ToList();
            }
            
            
        }

        public void OnPostSearchPerson()
        {
            if (!signInManager.IsSignedIn(User))
            {
                Redirect("/Login");
            }
            if (!string.IsNullOrEmpty(SearchTerm))
            {
                persons = profileService.GetAllPersons();
                SearchPersonList = persons.Where(a => a.LastName.ToLower().Contains(SearchTerm.ToLower())).ToList();
            }
           
        }

        public void OnPostPersonByMerit()
        {
            if (!signInManager.IsSignedIn(User))
            {
                Redirect("/Login");
            }
            if (!string.IsNullOrEmpty(SearchTerm))
            {
                List<PersonalMerit> pml = meritService.GetAllPersonalMerits();
                List<PersonalMerit> spml = pml.Where(x => x.Category.ToLower() == SearchTerm.ToLower()).ToList();
                persons = profileService.GetAllPersons();
                SearchPersonList = new();
                foreach (var y in spml)
                {
                    PersonalInfo aaa = new PersonalInfo();
                    aaa = persons.FirstOrDefault(x => x.PersonalUserId == y.PersonalUserId);
                    SearchPersonList.Add(aaa);
                }
            }
            
        }

        public void OnPostCompanyByMerit()
        {
            if (!signInManager.IsSignedIn(User))
            {
                Redirect("/Login");
            }
            if (!string.IsNullOrEmpty(SearchTerm))
            {
                List<CompanyMerit> cml = meritService.GetAllCompanyMerits();
                List<CompanyMerit> scml = cml.Where(x => x.Category.ToLower().Contains(SearchTerm.ToLower())).ToList();
                companies = companyService.GetAllCompany();
                SearchCompanyList = new();
                foreach (var y in scml)
                {
                    CompanyInfo aaa = new CompanyInfo();
                    aaa = companies.FirstOrDefault(x => x.CompanyUserId == y.CompanyUserId);
                    SearchCompanyList.Add(aaa);
                }
            }
            

        }

        public void OnPostPersonByWant()
        {
            if (!signInManager.IsSignedIn(User))
            {
                Redirect("/Login");
            }
            if (!string.IsNullOrEmpty(SearchTerm))
            {
                List<PersonalWants> pwl = wantsService.AllPersonalWantsToList();
                List<PersonalWants> spwl = pwl.Where(x => x.Want.ToLower() == SearchTerm.ToLower()).ToList();
                persons = profileService.GetAllPersons();
                SearchPersonList = new();
                foreach (var person in spwl)
                {
                    PersonalInfo personToAdd = new PersonalInfo();
                    personToAdd = persons.FirstOrDefault(x => x.PersonalUserId == person.PersonalUserId);
                    if (!SearchPersonList.Contains(personToAdd))
                    {
                        SearchPersonList.Add(personToAdd);
                    }
                }
            }
            
        }

        public void OnPostCompanyByWant()
        {
            if (!signInManager.IsSignedIn(User))
            {
                Redirect("/Login");
            }
            if (!string.IsNullOrEmpty(SearchTerm))
            {
                List<CompanyWants> cwl = wantsService.AllCompanyWantsToList();
                List<CompanyWants> scwl = cwl.Where(x => x.Want.ToLower() == SearchTerm.ToLower()).ToList();
                companies = companyService.GetAllCompany();
                SearchCompanyList = new();
                foreach (var company in scwl)
                {
                    CompanyInfo companyToAdd = new CompanyInfo();
                    companyToAdd = companies.FirstOrDefault(x => x.CompanyUserId == company.CompanyUserId);
                    if (!SearchCompanyList.Contains(companyToAdd))
                    {
                        SearchCompanyList.Add(companyToAdd);
                    }
                }
            }
        }
    }
}
