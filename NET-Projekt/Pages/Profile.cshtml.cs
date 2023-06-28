using Microsoft.AspNetCore.Identity;
using Microsoft.AspNetCore.Mvc;
using Microsoft.AspNetCore.Mvc.RazorPages;
using DB.Models;
using DB.Dto;
using Microsoft.AspNetCore.Authorization;
using DB.Services.Interfaces;

namespace NET_Projekt.Pages
{
    [Authorize]
    public class ProfileModel : PageModel
    {
        private readonly UserManager<User> _userManager;
        private readonly SignInManager<User> _signInManager;
        private readonly IUserService _userService;

        public UserDto AuthorizedUser { get; set; }

        public ProfileModel(UserManager<User> userManager, SignInManager<User> signInManager, IUserService userService)
        {
            _userManager = userManager;
            _signInManager = signInManager;
            _userService = userService;
        }

        public async void OnGet()
        {
            string userId = _userManager.GetUserId(User);
            AuthorizedUser = await _userService.GetById(userId);
        }

		public async Task<IActionResult> OnPostLogoutAsync()
		{
			await _signInManager.SignOutAsync();
			return RedirectToPage();
		}
	}
}
