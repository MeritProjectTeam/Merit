using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;
using Microsoft.AspNetCore.Mvc;
using Microsoft.AspNetCore.Mvc.RazorPages;
using Merit.MeritService;


namespace Merit.Web.Pages
{
    public class AddMeritModel : PageModel
    {

        [BindProperty]
        public NewMerit AMerit { get; set; }

        IMeritService meritService = new MockMeritService();
        public void OnGet()
        {

        }

        public void OnPost()
        {
            meritService.SaveMerit(AMerit);
        }
    }
}
