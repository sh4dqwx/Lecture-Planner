using DB.Models;
using DB.Dto;
using Microsoft.AspNetCore.Authorization;
using Microsoft.AspNetCore.Identity;
using Microsoft.AspNetCore.Mvc;
using Microsoft.AspNetCore.Mvc.RazorPages;
using System.Diagnostics.Eventing.Reader;
using DB.Services.Interfaces;

namespace NET_Projekt.Pages
{
	[Authorize]
    public class DetailsModel : PageModel
    {
		private readonly UserManager<User> _userManager;
		private readonly SignInManager<User> _signInManager;
		private readonly ILectureService _lectureService;
		private readonly IUserService _userService;

		[BindProperty]
		public LectureDetailsDto Lecture { get; set; }

		public bool IsUserParticipant { get; set; }

		public bool IsUserLecturer { get; set; }

		public DetailsModel(
			UserManager<User> userManager,
			SignInManager<User> signInManager,
			ILectureService lectureService,
			IUserService userService
		)
		{
			_userManager = userManager;
			_signInManager = signInManager;
			_lectureService = lectureService;
			_userService = userService;
		}

		public async Task<IActionResult> OnGet(int id, bool isUserParticipant, bool isUserLecturer)
        {
			Lecture = _lectureService.GetDetailsById(id);
			IsUserParticipant = isUserParticipant;
			IsUserLecturer = isUserLecturer;
			return Page();
		}

		public async Task<IActionResult> OnPostConfirmParticipation()
		{
			int lectureId = int.Parse(Request.Form["lectureId"]);
			string userId = _userManager.GetUserId(User);

			_userService.ConfirmParticipation(lectureId, userId);
			Lecture = _lectureService.GetDetailsById(lectureId);
			IsUserParticipant = true;
			
			return Page();
		}

		public async Task<IActionResult> OnPostCancelParticipation()
		{
			int lectureId = int.Parse(Request.Form["lectureId"]);
			string userId = _userManager.GetUserId(User);

			_userService.CancelParticipation(lectureId, userId);
			Lecture = _lectureService.GetDetailsById(lectureId);
			IsUserParticipant = false;
			
			return Page();
		}

		public async Task<IActionResult> OnPostDeleteLecture()
		{
			int lectureId = int.Parse(Request.Form["lectureId"]);

			_lectureService.DeleteLecture(lectureId);
			return RedirectToPage("Index");
		}

        public async Task<IActionResult> OnPostLogoutAsync()
        {
            await _signInManager.SignOutAsync();
            return RedirectToPage();
        }
    }
}
