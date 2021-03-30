using Merit.AccountService;
using Merit.Data.Models;
using Merit.Web.Areas.Identity.Data;
using Microsoft.AspNetCore.Identity;
using Microsoft.AspNetCore.Identity.UI.Services;
using Microsoft.AspNetCore.Mvc;
using Microsoft.AspNetCore.Mvc.RazorPages;
using Microsoft.AspNetCore.WebUtilities;
using System.ComponentModel.DataAnnotations;
using System.Text;
using System.Text.Encodings.Web;
using System.Threading.Tasks;

namespace Merit.Web.Pages
{
    public class RegisterModel : PageModel
    {
        private readonly SignInManager<IdentityUser> signInManager;
        private readonly UserManager<IdentityUser> userManager;
        private readonly IEmailSender emailSender;
        private readonly IAccount accountService = new Account();

        [BindProperty]
        public InputModel Input { get; set; }

        public RegisterModel(UserManager<IdentityUser> userManager, SignInManager<IdentityUser> signInManager, IEmailSender emailSender)
        {
            this.signInManager = signInManager;
            this.userManager = userManager;
            this.emailSender = emailSender;
        }

        public async Task<IActionResult> OnPostAsync(string returnUrl = null)
        {
            returnUrl ??= Url.Content("~/");

            if (ModelState.IsValid)
            {
                var user = new MeritWebUser { Email = Input.Email, UserName = Input.Email };
                var result = await userManager.CreateAsync(user, Input.Password);
                if (result.Succeeded)
                {
                    if (Input.AccountType == AccountType.Personal)
                    {
                        accountService.AddAccount(new PersonalUser()
                        {
                            Identity = user.Id
                        });
                    }
                    else if (Input.AccountType == AccountType.Company)
                    {
                        accountService.AddAccount(new CompanyUser()
                        {
                            Identity = user.Id
                        });
                    }

                    await signInManager.SignInAsync(user, isPersistent: false);

                    var type = user.GetAccountType();
                    if (type == AccountType.Personal)
                    {
                        return Redirect("/PersonalInfoPage");
                    }
                    else if (type == AccountType.Company)
                    {
                        return Redirect("/CompanyInfoPage");
                    }
                }

                foreach (var error in result.Errors)
                {
                    ModelState.AddModelError(string.Empty, error.Description);
                }
            }

            // Fallback.
            return Page();
        }

        public class InputModel
        {
            [Required(ErrorMessage = "Du måste ange en e-post.")]
            [EmailAddress]
            [Display(Name = "E-post")]
            public string Email { get; set; }

            [Required(ErrorMessage = "Du måste ange ett lösenord.")]
            [StringLength(100, ErrorMessage = "Lösenordet måste vara minst {2} och max {1} tecken långt.", MinimumLength = 6)]
            [DataType(DataType.Password)]
            [Display(Name = "Lösenord")]
            public string Password { get; set; }

            [DataType(DataType.Password)]
            [Display(Name = "Bekräfta Lösenord")]
            [Compare("Password", ErrorMessage = "Inmatningarna för lösenord matchar inte varandra.")]
            public string ConfirmPassword { get; set; }

            [Required]
            [Display(Name = "Välj Användartyp")]
            public AccountType AccountType { get; set; }

            [Required(ErrorMessage = "Du måste läsa och acceptera policyn för att fortsätta")]
            [Display(Name = "Jag har läst och accepterar integritetspolicyn.")]
            public bool PrivacyConsent { get; set; }
        }
    }
}