using DB.Dto;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace DB.Services.Interfaces
{
    public interface IUserService
    {
        public Task<UserDto> GetById(string id);
        public Task<UserAddEditDto> GetEditById(string id);
        public LecturerDto GetLecturerById(string id);
        public Task<List<UserDto>> GetStudentList();
        public Task<List<UserDto>> GetLecturerList();
        public bool IsUserParticipant(int lectureId, string userId);
        public int GetParticipantCount(int lectureId);
        public void ConfirmParticipation(int lectureId, string userId);
        public void CancelParticipation(int lectureId, string userId);
    }
}
