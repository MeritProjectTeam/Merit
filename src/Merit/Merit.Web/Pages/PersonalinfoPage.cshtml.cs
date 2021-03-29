using Merit.AccountService;
using Merit.Data.Models;
using Merit.MeritService;
using Merit.PersonalInfoService;
using Merit.WantsService;
using Microsoft.AspNetCore.Mvc;
using Microsoft.AspNetCore.Mvc.RazorPages;
using System;
using System.Collections.Generic;
using System.IO;
using System.Threading.Tasks;
using System.Threading;
using Merit.CompanyService;
using System.Linq;

namespace Merit.Web.Pages
{
    public class PersonalinfoPageModel : PageModel
    {
        private IProfileService profileService = new ProfileService();
        private IAccount accountService = new Account();
        private IMeritService meritService = new MeritService.MeritService();
        private IWantsService wantsService = new WantsService.WantsService();
        private ICompanyService companyService = new Merit.CompanyService.CompanyService();
        


        [BindProperty]
        public PersonalUser AUser { get; set; }
        [BindProperty]
        public PersonalInfo PersonalInfo { get; set; }
        [BindProperty]
        public List<PersonalMerit> PersonalMerits { get; set; }

        [BindProperty]
        public List<PersonalWants> PersonalWants { get; set; }

        [BindProperty]
        public string ImageUrl { get; set; }

        [BindProperty]
        public string SearchCompanyString { get; set; }
        [BindProperty(SupportsGet =true)]
        public List<CompanyInfo> SearchCompanyList { get; set; }
        [BindProperty(SupportsGet =true)]
        public List<CompanyInfo> companies { get; set; }

        [BindProperty(SupportsGet =true)]
        public int CompanySelectInt { get; set; }
        [BindProperty(SupportsGet =true)]
        public CompanyInfo SelectedComp { get; set; }
        [BindProperty(SupportsGet =true)]
        public string SelectedCompUrl { get; set; }

        [BindProperty(SupportsGet =true)]
        public List<CompanyMerit> CompanyMeritList { get; set; }
        [BindProperty(SupportsGet =true)]
        public List<CompanyWants> CompanyWantList { get; set; }
        //------------------------------------
        [BindProperty(SupportsGet =true)]
        public string SearchPersonString { get; set; }
        [BindProperty(SupportsGet = true)]
        public List<PersonalInfo> SearchPersonList { get; set; }
        [BindProperty(SupportsGet = true)]
        public List<PersonalInfo> persons { get; set; }

        [BindProperty(SupportsGet =true)]
        public int PersonSelectedInt { get; set; }
        [BindProperty(SupportsGet = true)]
        public PersonalInfo SelectedPerson { get; set; }
        [BindProperty(SupportsGet = true)]
        public string SelectedPersonUrl { get; set; }

        [BindProperty(SupportsGet =true)]
        public List<PersonalMerit> PersonalMeritList { get; set; }
        [BindProperty(SupportsGet =true)]
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

        public void OnGet()
        {
            int userId = Account.CheckCookie();

            AUser = accountService.GetPersonalUser(userId);
            PersonalImage img = profileService.GetImage(AUser);
            if (img == null)
            {
                ImageUrl = "http://placehold.it/300x300";
            }
            else
            {
                string imageBase64Data = Convert.ToBase64String(img.ImageData);
                ImageUrl = string.Format($"data:image/jpg;base64, {imageBase64Data}");
            }
            PersonalInfo = profileService.Get(userId);
            PersonalWants = wantsService.GetAllPersonalWants(userId);            
            PersonalMerits = meritService.ReadPersonalMerits(userId);

            //-------
            if (CompanySelectInt != 0)
            {
                SelectedComp = companyService.Get(CompanySelectInt);
                CompanyMeritList = meritService.ReadCompanyMerits(CompanySelectInt);
                CompanyWantList = wantsService.GetAllCompanyWants(CompanySelectInt);
                CompanyUser companyUser = accountService.GetCompanyUser(SelectedComp.CompanyUserID);
                CompanyImage cImg = profileService.GetImage(companyUser);
                if (cImg == null)
                {
                    SelectedCompUrl = "http://placehold.it/300x300";
                }
                else
                {
                    string imageBase64Data = Convert.ToBase64String(cImg.ImageData);
                    SelectedCompUrl = string.Format($"data:image/jpg;base64, {imageBase64Data}");
                }
            }
            if (PersonSelectedInt != 0)
            {
                SelectedPerson = profileService.Get(PersonSelectedInt);
                PersonalMeritList = meritService.ReadPersonalMerits(PersonSelectedInt);
                PersonalWantList = wantsService.GetAllPersonalWants(PersonSelectedInt);
                PersonalUser personalUser = accountService.GetPersonalUser(SelectedPerson.PersonalUserID);
                PersonalImage pImg = profileService.GetImage(personalUser);
                if (pImg == null)
                {
                    SelectedPersonUrl = "http://placehold.it/300x300";
                }
                else
                {
                    string imageBase64Data = Convert.ToBase64String(pImg.ImageData);
                    SelectedPersonUrl = string.Format($"data:image/jpg;base64, {imageBase64Data}");
                }
            }
        }
        public void OnPostUploadImage()
        {
            int userId = Account.CheckCookie();
            AUser = accountService.GetPersonalUser(userId);
            UploadImage();
        }

        public IActionResult UploadImage()
        {
            PersonalImage img = new PersonalImage();
            var files = Request.Form.Files;
            var file = files[0];
            img.ImageTitle = file.FileName;
            img.PersonalUserId = AUser.PersonalUserId;

            using (MemoryStream ms = new MemoryStream())
            {
                file.CopyTo(ms);
                img.ImageData = ms.ToArray();
            }
            profileService.SaveImage(img);

            return RedirectToPage();
        }

        public void OnPostSearchCompany()
        {
            if (!string.IsNullOrEmpty(SearchCompanyString))
            {
                companies = companyService.GetAllCompany();
                SearchCompanyList = companies.Where(a => a.CompanyName.ToLower().Contains(SearchCompanyString.ToLower())).ToList();
            }
            OnGet();
        }

        public void OnPostSearchPerson()
        {
            if (!string.IsNullOrEmpty(SearchPersonString))
            {
                persons = profileService.GetAllPersons();
                SearchPersonList = persons.Where(a => a.LastName.ToLower().Contains(SearchPersonString.ToLower())).ToList();
            }
            OnGet();
        }

        public void OnPostPersonByMerit()
        {
            if (!string.IsNullOrEmpty(SearchPersonMeritString))
            {
                List<PersonalMerit> pml = meritService.GetAllPersonalMerits();
                List<PersonalMerit> spml = pml.Where(x => x.Category.ToLower()==SearchPersonMeritString.ToLower()).ToList();
                persons = profileService.GetAllPersons();
                foreach (var y in spml)
                {
                    PersonalInfo aaa = new PersonalInfo();
                    aaa = persons.FirstOrDefault(x => x.PersonalUserID == y.PersonalUserId);
                    SearchPersonList.Add(aaa);
                }
            }
            OnGet();
        }

        public void OnPostCompanyByMerit()
        {
            if (!string.IsNullOrEmpty(SearchCompanyMeritString))
            {
                List<CompanyMerit> cml = meritService.GetAllCompanyMerits();
                List<CompanyMerit> scml = cml.Where(x => x.Category.ToLower().Contains(SearchCompanyMeritString.ToLower())).ToList();
                companies = companyService.GetAllCompany();
                foreach (var y in scml)
                {
                    CompanyInfo aaa = new CompanyInfo();
                    aaa = companies.FirstOrDefault(x => x.CompanyUserID == y.CompanyUserId);
                    SearchCompanyList.Add(aaa);
                }
            }
            OnGet();
        }

        public void OnPostPersonByWant()
        {
            if (!string.IsNullOrEmpty(SearchPersonWantString))
            {
                List<PersonalWants> pwl = wantsService.AllPersonalWantsToList();
                List<PersonalWants> spwl = pwl.Where(x => x.Want.ToLower() == SearchPersonWantString.ToLower()).ToList();
                persons = profileService.GetAllPersons();
                foreach (var y in spwl)
                {
                    PersonalInfo aaa = new PersonalInfo();
                    aaa = persons.FirstOrDefault(x => x.PersonalUserID == y.PersonalUserId);
                    SearchPersonList.Add(aaa);
                }
            }
            OnGet();
        }

        public void OnPostCompanyByWant()
        {
            if (!string.IsNullOrEmpty(SearchCompanyWantString))
            {
                List<CompanyWants> cwl = wantsService.AllCompanyWantsToList();
                List<CompanyWants> scwl = cwl.Where(x => x.Want.ToLower() == SearchCompanyWantString.ToLower()).ToList();
                companies = companyService.GetAllCompany();
                foreach (var y in scwl)
                {
                    CompanyInfo aaa = new CompanyInfo();
                    aaa = companies.FirstOrDefault(x => x.CompanyUserID == y.CompanyUserId);
                    SearchCompanyList.Add(aaa);
                }
            }
            OnGet();
        }
    }
}
