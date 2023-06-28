using DB.Dto;
using DB.Models;
using DB.Repositories.Interfaces;
using DB.Services.Interfaces;
using Microsoft.EntityFrameworkCore;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace DB.Services
{
    public class LectureService : ILectureService
    {
        private readonly ILectureRepository _lectureRepository;
        private readonly IHallService _hallService;
        private readonly IUserService _userService;

        private int CalculateRowSpan(TimeSpan startHour, TimeSpan endHour)
        {
            TimeSpan timeSpan = endHour - startHour;
            return (int)timeSpan.TotalMinutes / 30;
        }

        public LectureService(ILectureRepository lectureRepository, IHallService hallService, IUserService userService)
        {
            _lectureRepository = lectureRepository;
            _hallService = hallService;
            _userService = userService;
        }

        public List<LectureDto> GetListByDate(DateOnly date, string userId)
        {
            DateTime formattedDate = date.ToDateTime(new TimeOnly(0, 0, 0));
            List<Lecture> lectureList = _lectureRepository.GetListByDate(formattedDate, userId);
            List<LectureDto> result = new List<LectureDto>();
            foreach( Lecture l in lectureList )
            {
                result.Add(new LectureDto
                {
                    Id = l.Id,
                    Topic = l.Topic,
                    StartHour = TimeOnly.FromTimeSpan(l.StartHour),
                    EndHour = TimeOnly.FromTimeSpan(l.EndHour),
                    RowSpan = CalculateRowSpan(l.StartHour, l.EndHour),
                    HallId = l.HallId,
                    IsUserParticipant = _userService.IsUserParticipant(l.Id, userId),
                    IsUserLecturer = (l.LecturerId == userId)
                });
            }
            return result;
        }

        public LectureDetailsDto GetDetailsById(int id)
        {
            Lecture lecture = _lectureRepository.GetById(id);
            LectureDetailsDto result = new LectureDetailsDto
            {
                Id = lecture.Id,
                Topic = lecture.Topic,
                Date = DateOnly.FromDateTime(lecture.Date),
                StartHour = TimeOnly.FromTimeSpan(lecture.StartHour),
                EndHour = TimeOnly.FromTimeSpan(lecture.EndHour),
                Hall = _hallService.GetById(lecture.HallId),
                Lecturer = _userService.GetLecturerById(lecture.LecturerId),
                ParticipantCount = _userService.GetParticipantCount(lecture.Id)
            };
            return result;
        }

        public LectureAddEditDto GetEditById(int id)
        {
			Lecture lecture = _lectureRepository.GetById(id);
			LectureAddEditDto result = new LectureAddEditDto
			{
                Id = lecture.Id,
				Topic = lecture.Topic,
				Date = DateOnly.FromDateTime(lecture.Date),
				StartHour = TimeOnly.FromTimeSpan(lecture.StartHour),
				EndHour = TimeOnly.FromTimeSpan(lecture.EndHour),
                HallId = lecture.HallId,
                LecturerId = lecture.LecturerId
			};
			return result;
		}

        public bool AddLecture(LectureAddEditDto lecture)
        {
            List<LectureDto> lectureList = GetListByDate(lecture.Date, "");
            foreach(LectureDto l in lectureList)
            {
                if(l.HallId != lecture.HallId) continue;
                if((lecture.StartHour >= l.StartHour && lecture.StartHour < l.EndHour) ||
                   (lecture.EndHour > l.StartHour && lecture.EndHour <= l.EndHour))
                {
                    return false;
                }
            }
            _lectureRepository.AddLecture(lecture);
            return true;
        }

        public bool EditLecture(LectureAddEditDto lecture)
        {
			List<LectureDto> lectureList = GetListByDate(lecture.Date, "");
			foreach (LectureDto l in lectureList)
			{
                if (l.Id == lecture.Id) continue;
				if (l.HallId != lecture.HallId) continue;
				if ((lecture.StartHour >= l.StartHour && lecture.StartHour < l.EndHour) ||
				   (lecture.EndHour > l.StartHour && lecture.EndHour <= l.EndHour))
				{
					return false;
				}
			}
			_lectureRepository.EditLecture(lecture);
			return true;
		}

        public void DeleteLecture(int id)
        {
            _lectureRepository.DeleteLecture(id);
        }
    }
}
