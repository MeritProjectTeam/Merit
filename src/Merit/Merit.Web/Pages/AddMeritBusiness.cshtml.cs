using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;
using Merit.MeritService;
using Microsoft.AspNetCore.Mvc;
using Microsoft.AspNetCore.Mvc.RazorPages;

namespace Merit.Web.Pages
{
    public class AddMeritBusinessModel : PageModel
    {
        [BindProperty]
        public NewMeritBusiness BusinessMerit { get; set; }

        IMeritService meritService = new MockMeritService();

        public void OnGet()
        {
        }

        public void OnPost()
        {
            meritService.SaveMeritBusiness(BusinessMerit);
        }
    }
}
