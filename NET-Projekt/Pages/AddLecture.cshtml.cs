using DB.Dto;
using DB.Services.Interfaces;
using Microsoft.AspNetCore.Authorization;
using Microsoft.AspNetCore.Authorization.Infrastructure;
using Microsoft.AspNetCore.Identity;
using Microsoft.AspNetCore.Mvc;
using Microsoft.AspNetCore.Mvc.RazorPages;
using System.ComponentModel.DataAnnotations;
using DB.Models;

namespace NET_Projekt.Pages
{
    [Authorize(Roles = "Wyk³adowca, Admin")]
    public class AddLectureModel : PageModel
    {
		private readonly UserManager<User> _userManager;
		private readonly SignInManager<User> _signInManager;
		private readonly IHallService _hallService;
		private readonly ILectureService _lectureService;

		[BindProperty]
		public LectureAddEditDto Lecture { get; set; }

		public List<HallDto> Halls { get; set; }

		public AddLectureModel(UserManager<User> userManager, SignInManager<User> signInManager, IHallService hallService, ILectureService lectureService)
		{
			_userManager = userManager;
			_signInManager = signInManager;
			_hallService = hallService;
			_lectureService = lectureService;
			Halls = _hallService.GetList();
		}

		public IActionResult OnPost()
		{
			if (!ModelState.IsValid) return Page();
			Lecture.LecturerId = _userManager.GetUserId(User);
			if(Lecture.StartHour >= Lecture.EndHour)
			{
				ModelState.AddModelError("", "Niepoprawne godziny");
				return Page();
			}
			if(!_lectureService.AddLecture(Lecture))
			{
				ModelState.AddModelError("", "Niepoprawne godziny, wyk³ad nak³ada siê na ju¿ istniej¹ce wyk³ady");
				return Page();
			}
			return RedirectToPage("Index");
		}

		public async Task<IActionResult> OnPostLogoutAsync()
		{
			await _signInManager.SignOutAsync();
			return RedirectToPage();
		}
	}
}
