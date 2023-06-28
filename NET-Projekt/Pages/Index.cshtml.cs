using Microsoft.AspNetCore.Mvc;
using Microsoft.AspNetCore.Authorization;
using Microsoft.AspNetCore.Mvc.RazorPages;
using Microsoft.AspNetCore.Identity;
using DB.Models;
using DB.Dto;
using DB.Services.Interfaces;
using System.Security.Policy;
using System.ComponentModel.DataAnnotations;

namespace NET_Projekt.Pages
{
	[Authorize]
	public class IndexModel : PageModel
	{
		private readonly UserManager<User> _userManager;
		private readonly SignInManager<User> _signInManager;
		private readonly IHallService _hallService;
		private readonly ILectureService _lectureService;

		[BindProperty(SupportsGet = true)]
		public DateOnly Date { get; set; }
		private readonly DateOnly MinDate = new DateOnly(1, 1, 1);

		public List<HallDto> Halls { get; set; }

		public List<LectureDto> Lectures { get; set; }

		public List<TimeOnly> Hours { get; set; }

		public IndexModel(
			UserManager<User> userManager,
			SignInManager<User> signInManager,
			IHallService hallService,
			ILectureService lectureService
		)
		{
			_userManager = userManager;
			_signInManager = signInManager;
			_hallService = hallService;
			_lectureService = lectureService;
            Halls = _hallService.GetList();
            Hours = new List<TimeOnly>()
			{ 
				new TimeOnly(8, 0, 0),
                new TimeOnly(8, 30, 0),
                new TimeOnly(9, 0, 0),
                new TimeOnly(9, 30, 0),
                new TimeOnly(10, 0, 0),
                new TimeOnly(10, 30, 0),
                new TimeOnly(11, 0, 0),
                new TimeOnly(11, 30, 0),
                new TimeOnly(12, 0, 0),
                new TimeOnly(12, 30, 0),
                new TimeOnly(13, 0, 0),
                new TimeOnly(13, 30, 0),
                new TimeOnly(14, 0, 0),
                new TimeOnly(14, 30, 0),
                new TimeOnly(15, 0, 0)
            };
		}

		public async Task<IActionResult> OnGet()
		{
            if (Date.CompareTo(MinDate) == 0)
			{
                Date = DateOnly.FromDateTime(DateTime.Now);
            }
			Lectures = _lectureService.GetListByDate(Date, _userManager.GetUserId(User));
			return Page();
		}

        public async Task<IActionResult> OnPostLogoutAsync()
		{
			await _signInManager.SignOutAsync();
			return RedirectToPage();
		}
	}
}