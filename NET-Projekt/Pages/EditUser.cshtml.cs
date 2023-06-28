using DB.Dto;
using DB.Models;
using DB.Services.Interfaces;
using Microsoft.AspNetCore.Authorization;
using Microsoft.AspNetCore.Identity;
using Microsoft.AspNetCore.Mvc;
using Microsoft.AspNetCore.Mvc.RazorPages;

namespace NET_Projekt.Pages
{
    [Authorize(Roles = "Admin")]
    public class EditUserModel : PageModel
    {
        private readonly UserManager<User> _userManager;
        private readonly SignInManager<User> _signInManager;
        private readonly IUserService _userService;

        [BindProperty]
        public UserAddEditDto SelectedUser { get; set; }

        public EditUserModel(UserManager<User> userManager, SignInManager<User> signInManager, IUserService userService)
        {
            _userManager = userManager;
            _signInManager = signInManager;
            _userService = userService;
        }

        public async Task<IActionResult> OnGet(string id)
        {
            SelectedUser = await _userService.GetEditById(id);
            return Page();
        }

        public async Task<IActionResult> OnPost()
        {
            if (!ModelState.IsValid) return Page();

            User user = await _userManager.FindByIdAsync(SelectedUser.Id);
            user.FirstName = SelectedUser.FirstName;
            user.LastName = SelectedUser.LastName;
            user.UserName = SelectedUser.Email;
            user.Email = SelectedUser.Email;

            var result = await _userManager.UpdateAsync(user);
            var token = await _userManager.GeneratePasswordResetTokenAsync(user);
            var passwordResult = await _userManager.ResetPasswordAsync(user, token, SelectedUser.Password);
            
            var currentRoles = await _userManager.GetRolesAsync(user);
            foreach(var role in currentRoles)
            {
                await _userManager.RemoveFromRoleAsync(user, role);
            }
			var roleResult = await _userManager.AddToRoleAsync(user, SelectedUser.Role);

			if (!result.Succeeded || !passwordResult.Succeeded || !roleResult.Succeeded)
            {
                foreach(var error in result.Errors)
                {
					ModelState.AddModelError(string.Empty, error.Description);
				}
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
