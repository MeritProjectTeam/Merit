using Merit.AccountService;
using Microsoft.AspNetCore.Authentication;
using Microsoft.AspNetCore.Identity;
using Microsoft.AspNetCore.Mvc;
using Microsoft.AspNetCore.Mvc.RazorPages;
using System.ComponentModel.DataAnnotations;
using System.Threading.Tasks;

namespace Merit.Web.Pages
{
    public class LogInModel : PageModel
    {
        private readonly UserManager<IdentityUser> userManager;
        private readonly SignInManager<IdentityUser> signInManager;

        [BindProperty]
        public InputModel Input { get; set; }

        public LogInModel(UserManager<IdentityUser> userManager, SignInManager<IdentityUser> signInManager)
        {
            this.userManager = userManager;
            this.signInManager = signInManager;
        }

        public async Task OngetAsync()
        {
            // Clear external login cookies.
            await HttpContext.SignOutAsync(IdentityConstants.ExternalScheme);
        }

        public async Task<IActionResult> OnPostAsync()
        {
            if (ModelState.IsValid)
            {
                var result = await signInManager.PasswordSignInAsync(Input.Email, Input.Password, isPersistent: true, lockoutOnFailure: false);
                if (result.Succeeded)
                {
                    IdentityUser user = await userManager.GetUserAsync(User);
                    var type = user.GetAccountType();
                    if (type == AccountType.Personal)
                    {
                        return RedirectToPage("/PersonalInfoPage");
                    }
                    else if (type == AccountType.Company)
                    {
                        return RedirectToPage("/CompanyInfoPage");
                    }
                }
                else
                {
                    ModelState.AddModelError(string.Empty, "Ogiltig inloggning.");
                    return Page();
                }
            }
            return Page();
        }

        public class InputModel
        {
            [Required(ErrorMessage = "Du måste fylla i din e-post.")]
            [EmailAddress(ErrorMessage = "Ogiltig e-post.")]
            [Display(Name = "E-post")]
            public string Email { get; set; }

            [Required(ErrorMessage = "Du måste fylla i ditt lösenord.")]
            [DataType(DataType.Password)]
            [Display(Name = "Lösenord")]
            public string Password { get; set; }

            [Display(Name = "Kom ihåg mig?")]
            public bool RememberMe { get; set; }
        }
    }
}