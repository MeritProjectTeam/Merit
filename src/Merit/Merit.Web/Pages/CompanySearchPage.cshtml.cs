using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;
using Microsoft.AspNetCore.Mvc;
using Microsoft.AspNetCore.Mvc.RazorPages;
using Merit.PersonalInfoService;
using Merit.MeritService;

namespace Merit.Web.Pages
{
    public class CompanySearchPageModel : PageModel
    {
        //    private readonly IPersonalInfoService fakeService = new FakeProfileService();

        //    [BindProperty(SupportsGet = true)]
        //    public string SearchMerit { get; set; }
        //    [BindProperty]
        //    public string SearchSkills { get; set; }
        //    [BindProperty]
        //    public string SearchEducation { get; set; }
        //    public List<Personal> People { get; set; }

        //    [BindProperty(SupportsGet= true)]
        //    public List<Person> TheOne {  get;  set;  }
        //    public List<NewMerit> Merits { get; set; }
        //    public Person MyMan { get; set; }


        //    public void OnGet()
        //    {
        //        People = fakeService.GetAll();
        //        TheOne = SearchMeritFunc(SearchMerit,  People);
        //    }

        //    public void OnPost()
        //    {
        //    }
        //    // MAX Superfunktioner
        //    public List<Person> SearchMeritFunc(string searchTerm, List<Person> people)
        //    {
        //        if (string.IsNullOrEmpty(searchTerm))
        //        {
        //            return people;
        //        }
        //        List<Person> PeoplesX = new List<Person>();
        //        PeoplesX = people.Where(x => x.FirstName.Contains(searchTerm)).ToList();
        //        return PeoplesX;
        //    }

        //    public List<Person> SearchPersonByMerit(string searchTerm, List<Person> people)
        //    {
        //        if (string.IsNullOrEmpty(searchTerm))
        //        {
        //            return people;
        //        }

        //        List<Person> PeoplesX = new List<Person>();

        //        return PeoplesX;
        //    }
    }
}
