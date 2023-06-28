using Microsoft.AspNetCore.Mvc.RazorPages;
using Microsoft.AspNetCore.Identity;
using System.ComponentModel.DataAnnotations;
using DB.Models;
using Microsoft.AspNetCore.Mvc;
using Microsoft.AspNetCore.Authorization;

namespace NET_Projekt.Pages
{
    [AllowAnonymous]
    public class LoginModel : PageModel
    {
        private readonly SignInManager<User>? _signInManager;

        public LoginModel(SignInManager<User> signInManager)
        {
            _signInManager = signInManager;
        }

		public string? ReturnUrl { get; set; }

		[BindProperty]
        public LoginInputModel? InputModel { get; set; }

        public void OnGet()
        {
            ReturnUrl ??= Url.Content("~/");
        }

        public async Task<IActionResult> OnPostAsync()
        {
			ReturnUrl ??= Url.Content("~/");
            if (!ModelState.IsValid) return Page();
			var result = await _signInManager.PasswordSignInAsync(
                InputModel.Email,
                InputModel.Password,
                isPersistent: false,
                lockoutOnFailure: false
            );

		    if(!result.Succeeded)
            {
                ModelState.AddModelError("", "Nieprawid³owe dane logowania");
                return Page();
            }

			return LocalRedirect(ReturnUrl);
		}
    }

    public class LoginInputModel
    {
        [Required(ErrorMessage = "Podaj email")]
        [EmailAddress]
        public string? Email { get; set; }

        [Required(ErrorMessage = "Podaj has³o")]
        [DataType(DataType.Password)]
        public string? Password { get; set; }
    }
}
