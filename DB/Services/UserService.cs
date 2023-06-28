using DB.Dto;
using DB.Models;
using DB.Services.Interfaces;
using Microsoft.AspNetCore.Identity;
using Microsoft.EntityFrameworkCore;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace DB.Services
{
    public class UserService : IUserService
    {
        private readonly MyDbContext _dbContext;
        private readonly UserManager<User> _userManager;

        public UserService(MyDbContext dbContext, UserManager<User> userManager)
        {
            _dbContext = dbContext;
            _userManager = userManager;
        }

        public async Task<UserDto> GetById(string id)
        {
            User user = (User)_dbContext.Users.FromSql($"GetUserById {id}").ToList()[0];
            var roles = await _userManager.GetRolesAsync(user);
            string userRole = roles.FirstOrDefault();
            UserDto result = new UserDto
            {
                Id = user.Id,
                FirstName = user.FirstName,
                LastName = user.LastName,
                Role = userRole,
                Email = user.Email
            };
            return result;
        }

        public async Task<UserAddEditDto> GetEditById(string id)
        {
			User user = (User)_dbContext.Users.FromSql($"GetUserById {id}").ToList()[0];
			var roles = await _userManager.GetRolesAsync(user);
			string userRole = roles.FirstOrDefault();
			UserAddEditDto result = new UserAddEditDto
			{
				Id = user.Id,
				FirstName = user.FirstName,
				LastName = user.LastName,
				Role = userRole,
				Email = user.Email,
                Password = "",
                ConfirmPassword = ""
			};
			return result;
		}

        public LecturerDto GetLecturerById(string id)
        {
            User user = (User)_dbContext.Users.FromSql($"GetUserById {id}").ToList()[0];
            LecturerDto result = new LecturerDto
            {
                Id = user.Id,
                FirstName = user.FirstName,
                LastName = user.LastName
            };
            return result;
        }

        public async Task<List<UserDto>> GetStudentList()
        {
            var userList = await _userManager.GetUsersInRoleAsync("Student");
            List<UserDto> result = new List<UserDto>();
            foreach(var user in userList)
            {
                result.Add(new UserDto
                {
                    Id = user.Id,
                    FirstName = user.FirstName,
                    LastName = user.LastName,
                    Role = "Student",
                    Email = user.Email
                });
            }
            return result;
        }

		public async Task<List<UserDto>> GetLecturerList()
		{
			var userList = await _userManager.GetUsersInRoleAsync("Wykładowca");
			List<UserDto> result = new List<UserDto>();
			foreach (var user in userList)
			{
				result.Add(new UserDto
				{
					Id = user.Id,
					FirstName = user.FirstName,
					LastName = user.LastName,
					Role = "Wykładowca",
					Email = user.Email
				});
			}
			return result;
		}

		public bool IsUserParticipant(int lectureId, string userId)
        {
            int isUserParticipant = _dbContext.LecturesParticipants.FromSql($"IsUserParticipant {lectureId}, {userId}").ToList().Count;
            if (isUserParticipant > 0) return true;
            else return false;
        }

        public int GetParticipantCount(int lectureId)
        {
            int participantCount = _dbContext.LecturesParticipants.FromSql($"GetParticipants {lectureId}").ToList().Count;
            return participantCount;
        }

        public void ConfirmParticipation(int lectureId, string userId)
        {
            _dbContext.Database.ExecuteSql($"ConfirmParticipation {lectureId}, {userId}");
        }

        public void CancelParticipation(int lectureId, string userId)
        {
			_dbContext.Database.ExecuteSql($"CancelParticipation {lectureId}, {userId}");
		}
    }
}
