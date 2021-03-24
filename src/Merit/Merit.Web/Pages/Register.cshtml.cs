using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;
using Microsoft.AspNetCore.Mvc;
using Microsoft.AspNetCore.Mvc.RazorPages;
using Merit.AccountService;
using Merit.Data.Models;
using Merit.PersonalInfoService;
using Merit.CompanyService;
using System.ComponentModel.DataAnnotations;
using System.Xml.Linq;
using Microsoft.AspNetCore.Identity;

namespace LoginWebTesting.Pages
{
    public class RegisterModel : PageModel
    {
        private readonly SignInManager<IdentityUser> signInManager;
        private readonly UserManager<IdentityUser> userManager;

        [BindProperty]
        InputModel Input { get; set; }

        public RegisterModel(UserManager<IdentityUser> userManager, SignInManager<IdentityUser> signInManager)
        {
            this.signInManager = signInManager;
            this.userManager = userManager;
        }

        public void OnGetAsync()
        {

        }

        public async Task<IActionResult> OnPostAsync()
        {
            if (ModelState.IsValid)
            {

            }

            // Fallback.
            return Page();
        }

        public class InputModel
{
            [Required]
            [EmailAddress]
            [Display(Name = "E-post")]
            public string Email { get; set; }

            [Required]
            [StringLength(100, ErrorMessage = "Lösenordet måste vara minst {2} och max {1} tecken långt.", MinimumLength = 6)]
            [DataType(DataType.Password)]
            [Display(Name = "Lösenord")]
            public string Password { get; set; }

            [DataType(DataType.Password)]
            [Display(Name = "Bekräfta Lösenord")]
            [Compare("Password", ErrorMessage = "Inmatningarna för lösenord matchar inte varandra.")]
            public string ConfirmPassword { get; set; }
        }
        //[BindProperty]
        //public User NewUser { get; set; }

        //[BindProperty]
        //public string PasswordCheck { get; set; }
        //[BindProperty]
        //public int AccountType { get; set; }

        //[BindProperty]
        //public string RegisterMessage { get; set; }
        //private readonly IAccount account = new Account();
        //private readonly IProfileService profileService = new ProfileService();

        //public bool Visi { get; set; }
        //public string TypeString { get; set; }

        //public void OnGet()
        //{
        //}

        //public void OnPost()
        //{
        //    if (NewUser.Password == PasswordCheck)
        //    {
        //        if (AccountType == 1)
        //        {
        //            PersonalUser NewAccount = new PersonalUser() { UserName = NewUser.UserName, Email = NewUser.Email, Password = NewUser.Password };
        //            switch (account.CheckExistingAccount(NewAccount))
        //            {
        //                case 100:
        //                    account.AddAccount(NewAccount);
        //                    RegisterMessage = "Registreringen lyckades!";
        //                    Visi = true;
        //                    TypeString = "success";
        //                    break;
        //                case 101:
        //                    RegisterMessage = "Användarnamnet upptaget.";
        //                    Visi = true;
        //                    TypeString = "warning";
        //                    break;
        //                case 102:
        //                    RegisterMessage = "Epost-adressen finns redan registrerad.";
        //                    Visi = true;
        //                    TypeString = "warning";
        //                    break;
        //                default:
        //                    break;
        //            }
        //        }
        //        else if (AccountType == 2)
        //        {
        //            CompanyUser NewAccount = new CompanyUser() { UserName = NewUser.UserName, Email = NewUser.Email, Password = NewUser.Password };
        //            switch (account.CheckExistingAccount(NewAccount))
        //            {
        //                case 100:
        //                    account.AddAccount(NewAccount);
        //                    RegisterMessage = "Registreringen lyckades!";
        //                    Visi = true;
        //                    TypeString = "success";
        //                    break;
        //                case 101:
        //                    RegisterMessage = "Användarnamnet upptaget.";
        //                    Visi = true;
        //                    TypeString = "warning";
        //                    break;
        //                case 102:
        //                    RegisterMessage = "Epost-adressen finns redan registrerad.";
        //                    Visi = true;
        //                    TypeString = "warning";
        //                    break;
        //                default:
        //                    break;
        //            }
        //        }
        //    }
        //    else
        //    {
        //        RegisterMessage = "Lösenorden stämmer inte överens.";
        //        Visi = true;
        //        TypeString = "danger";
        //    }
        //}


    }
}
