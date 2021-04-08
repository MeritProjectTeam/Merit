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
        //private IAccount accountService = new Account();
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


        [BindProperty]
        public string SearchCompanyString { get; set; }
        [BindProperty(SupportsGet = true)]
        public List<CompanyInfo> SearchCompanyList { get; set; }
        [BindProperty(SupportsGet = true)]
        public List<CompanyInfo> companies { get; set; }

        [BindProperty(SupportsGet = true)]
        public int CompanySelectInt { get; set; }
        [BindProperty(SupportsGet = true)]
        public CompanyInfo SelectedComp { get; set; }
        [BindProperty(SupportsGet = true)]
        public string SelectedCompUrl { get; set; }

        [BindProperty(SupportsGet = true)]
        public List<CompanyMerit> CompanyMeritList { get; set; }
        [BindProperty(SupportsGet = true)]
        public List<CompanyWants> CompanyWantList { get; set; }
        //------------------------------------
        [BindProperty(SupportsGet = true)]
        public string SearchPersonString { get; set; }
        [BindProperty(SupportsGet = true)]
        public List<PersonalInfo> SearchPersonList { get; set; }
        [BindProperty(SupportsGet = true)]
        public List<PersonalInfo> persons { get; set; }

        [BindProperty(SupportsGet = true)]
        public int PersonSelectedInt { get; set; }
        [BindProperty(SupportsGet = true)]
        public PersonalInfo SelectedPerson { get; set; }
        [BindProperty(SupportsGet = true)]
        public string SelectedPersonUrl { get; set; }

        [BindProperty(SupportsGet = true)]
        public List<PersonalMerit> PersonalMeritList { get; set; }
        [BindProperty(SupportsGet = true)]
        public List<PersonalWants> PersonalWantList { get; set; }
        //------------------------------------
        [BindProperty(SupportsGet = true)]
        public string SearchPersonMeritString { get; set; }

        [BindProperty(SupportsGet = true)]
        public string SearchCompanyMeritString { get; set; }

        [BindProperty(SupportsGet = true)]
        public string SearchPersonWantString { get; set; }

        [BindProperty(SupportsGet = true)]
        public string SearchCompanyWantString { get; set; }

        public async Task<IActionResult> OnGetAsync()
        {
            if (!signInManager.IsSignedIn(User))
            {
                return Redirect("/Login");
            }

            IdentityUser identity = await userManager.GetUserAsync(User);
            IUser pUser = identity.GetUser();
            //AUser = accountService.GetPersonalUser(pUser.Identity);
            return Page();
        }



        public async Task OnPostSearchCompanyAsync()
        {
            if (!string.IsNullOrEmpty(SearchCompanyString))
            {
                companies = companyService.GetAllCompany();
                SearchCompanyList = companies.Where(a => a.CompanyName.ToLower().Contains(SearchCompanyString.ToLower())).ToList();
            }
            await OnGetAsync();
        }

        public async Task OnPostSearchPersonAsync()
        {
            if (!string.IsNullOrEmpty(SearchPersonString))
            {
                persons = profileService.GetAllPersons();
                SearchPersonList = persons.Where(a => a.LastName.ToLower().Contains(SearchPersonString.ToLower())).ToList();
            }
            await OnGetAsync();
        }

        public async Task OnPostPersonByMeritAsync()
        {
            if (!string.IsNullOrEmpty(SearchPersonMeritString))
            {
                List<PersonalMerit> pml = meritService.GetAllPersonalMerits();
                List<PersonalMerit> spml = pml.Where(x => x.Category.ToLower() == SearchPersonMeritString.ToLower()).ToList();
                persons = profileService.GetAllPersons();
                foreach (var y in spml)
                {
                    PersonalInfo aaa = new PersonalInfo();
                    aaa = persons.FirstOrDefault(x => x.PersonalUserId == y.PersonalUserId);
                    SearchPersonList.Add(aaa);
                }
            }
            await OnGetAsync();
        }

        public async Task OnPostCompanyByMeritAsync()
        {
            if (!string.IsNullOrEmpty(SearchCompanyMeritString))
            {
                List<CompanyMerit> cml = meritService.GetAllCompanyMerits();
                List<CompanyMerit> scml = cml.Where(x => x.Category.ToLower().Contains(SearchCompanyMeritString.ToLower())).ToList();
                companies = companyService.GetAllCompany();
                foreach (var y in scml)
                {
                    CompanyInfo aaa = new CompanyInfo();
                    aaa = companies.FirstOrDefault(x => x.CompanyUserId == y.CompanyUserId);
                    SearchCompanyList.Add(aaa);
                }
            }
            await OnGetAsync();
        }

        public async Task OnPostPersonByWantAsync()
        {
            if (!string.IsNullOrEmpty(SearchPersonWantString))
            {
                List<PersonalWants> pwl = wantsService.AllPersonalWantsToList();
                List<PersonalWants> spwl = pwl.Where(x => x.Want.ToLower() == SearchPersonWantString.ToLower()).ToList();
                persons = profileService.GetAllPersons();
                foreach (var y in spwl)
                {
                    PersonalInfo aaa = new PersonalInfo();
                    aaa = persons.FirstOrDefault(x => x.PersonalUserId == y.PersonalUserId);
                    SearchPersonList.Add(aaa);
                }
            }
            await OnGetAsync();
        }

        public async Task OnPostCompanyByWantAsync()
        {
            if (!string.IsNullOrEmpty(SearchCompanyWantString))
            {
                List<CompanyWants> cwl = wantsService.AllCompanyWantsToList();
                List<CompanyWants> scwl = cwl.Where(x => x.Want.ToLower() == SearchCompanyWantString.ToLower()).ToList();
                companies = companyService.GetAllCompany();
                foreach (var y in scwl)
                {
                    CompanyInfo aaa = new CompanyInfo();
                    aaa = companies.FirstOrDefault(x => x.CompanyUserId == y.CompanyUserId);
                    SearchCompanyList.Add(aaa);
                }
            }
            await OnGetAsync();
        }

    }
}
