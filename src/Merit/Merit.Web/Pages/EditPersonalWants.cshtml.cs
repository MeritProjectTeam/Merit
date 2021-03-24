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

        public string Message { get; set; }
        public string alertlook { get; set; }

        [BindProperty(SupportsGet = true)]
        public bool Visi { get; set; } = false;

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

        public void OnPostEdit()
        {
            wService.EditPersonalWant(PWant);
            Visi = true;
            alertlook = "success";
            Message = "Önskemål ändrat";
            SelectedPersonalWantId = 0;
            OnGet();
        }

        public void OnPostDelete()
        {
            wService.DeletePersonalWant(PWant);
            Visi = true;
            alertlook = "danger";
            Message = "Önskemål borttaget";
            SelectedPersonalWantId = 0;
            OnGet();
        }
    }
}
