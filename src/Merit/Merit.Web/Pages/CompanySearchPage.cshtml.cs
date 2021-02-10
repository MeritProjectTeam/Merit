using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;
using Microsoft.AspNetCore.Mvc;
using Microsoft.AspNetCore.Mvc.RazorPages;
using Merit.PersonalInfoService;

namespace Merit.Web.Pages
{
    public class CompanySearchPageModel : PageModel
    {
        private readonly IPersonalInfoService fakeService = new FakeProfileService();

        [BindProperty]
        public string SearchMerit { get; set; }
        [BindProperty]
        public string SearchSkills { get; set; }
        [BindProperty]
        public string SearchEducation { get; set; }
        public List<Person> People { get; set; }

        public List<Person> theOne = new List<Person>();


        public void OnGet()
        {
            People = fakeService.GetAll();
        }

        public void OnPost()
        {
            foreach (var x in People)
            {
                foreach (var y in x.Merits)
                {
                    if (y.Title == SearchMerit)
                    {
                        theOne.Add(x);
                    }
                }
            }
        }

    }
}
