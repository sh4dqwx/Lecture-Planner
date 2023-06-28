using DB.Dto;
using DB.Models;
using Microsoft.AspNetCore.Authorization;
using Microsoft.AspNetCore.Identity;
using Microsoft.AspNetCore.Mvc;
using Microsoft.AspNetCore.Mvc.RazorPages;
using Microsoft.AspNetCore.Razor.TagHelpers;

namespace NET_Projekt.Pages
{
    [Authorize(Roles = "Admin")]
    public class AddUserModel : PageModel
    {
        private readonly UserManager<User> _userManager;
        private readonly SignInManager<User> _signInManager;
        private readonly IUserStore<User> _userStore;
        private readonly IUserEmailStore<User> _emailStore;

        [BindProperty]
        public UserAddEditDto NewUser { get; set; }

        public AddUserModel(UserManager<User> userManager, SignInManager<User> signInManager, IUserStore<User> userStore)
        {
            _userManager = userManager;
            _signInManager = signInManager;
            _userStore = userStore;
            _emailStore = (IUserEmailStore<User>)_userStore;
        }

        public async Task<IActionResult> OnPost()
        {
            if (!ModelState.IsValid) return Page();
            User user = new User();
            user.FirstName = NewUser.FirstName;
            user.LastName = NewUser.LastName;
            await _userStore.SetUserNameAsync(user, NewUser.Email, CancellationToken.None);
            await _emailStore.SetEmailAsync(user, NewUser.Email, CancellationToken.None);

            var result = await _userManager.CreateAsync(user, NewUser.Password);
            var roleResult = await _userManager.AddToRoleAsync(user, NewUser.Role);

			if (!result.Succeeded || !roleResult.Succeeded)
            {
                foreach(var error in result.Errors)
                {
					ModelState.AddModelError(string.Empty, error.Description);
				}
                return Page();
            }

            return RedirectToPage("Users");
        }

		public async Task<IActionResult> OnPostLogoutAsync()
		{
			await _signInManager.SignOutAsync();
			return RedirectToPage();
		}
	}
}
