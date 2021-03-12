using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;
using Merit.Data.Models;
using Merit.WantsService;
using Microsoft.AspNetCore.Mvc;
using Microsoft.AspNetCore.Mvc.RazorPages;
using Merit.AccountService;

namespace Merit.Web.Pages
{
    public class EditPersonalWantsModel : PageModel
    {
        private IWantsService wService = new WantsService.WantsService();

        [BindProperty(SupportsGet = true)]
        public List<PersonalWants> PersonalWantsList { get; set; }

        [BindProperty(SupportsGet = true)]
        public int SelectedPersonalWantId { get; set; }
        [BindProperty]
        public string WantText { get; set; }
        [BindProperty]
        public PersonalWants PWant { get; set; }


        int personalUserId = Account.CheckCookie();

        public void OnGet()
        {
            PersonalWantsList = wService.GetAllPersonalWants(personalUserId);

            foreach (var want in PersonalWantsList)
            {
                if (want.PersonalWantsID == SelectedPersonalWantId)
                {
                    SelectedPersonalWantId = want.PersonalWantsID;
                    WantText = want.Want;
                }

            }
        }

        public IActionResult OnPostEdit()
        {
            wService.EditPersonalWant(PWant);
            return RedirectToAction("index");
        }

        public IActionResult OnPostDelete()
        {
            wService.DeletePersonalWant(PWant);
            return RedirectToAction("index");
        }
    }
}
