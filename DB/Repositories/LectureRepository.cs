using DB.Dto;
using DB.Models;
using DB.Repositories.Interfaces;
using Microsoft.EntityFrameworkCore;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace DB.Repositories
{
	public class LectureRepository : ILectureRepository
	{
		private readonly MyDbContext _dbContext;

		public LectureRepository(MyDbContext dbContext)
		{
			_dbContext = dbContext;
		} 

		public List<Lecture> GetListByDate(DateTime date, string userId)
		{
			return _dbContext.Lectures.FromSql($"GetLecturesByDate {date}").ToList();
		}

		public Lecture GetById(int id)
		{
			return _dbContext.Lectures.FromSql($"GetLectureById {id}").ToList()[0];
		}

		public void AddLecture(LectureAddEditDto lecture)
		{
			_dbContext.Database.ExecuteSql(
				$"AddLecture {lecture.Topic}, {lecture.Date.ToDateTime(new TimeOnly(0, 0, 0))}, {lecture.StartHour.ToTimeSpan()}, {lecture.EndHour.ToTimeSpan()}, {lecture.HallId}, {lecture.LecturerId}"
			);
			_dbContext.SaveChanges();
		}

		public void EditLecture(LectureAddEditDto lecture)
		{
			_dbContext.Database.ExecuteSql(
				$"EditLecture {lecture.Id}, {lecture.Topic}, {lecture.Date.ToDateTime(new TimeOnly(0, 0, 0))}, {lecture.StartHour.ToTimeSpan()}, {lecture.EndHour.ToTimeSpan()}, {lecture.HallId}"
			);
			_dbContext.SaveChanges();
		}

		public void DeleteLecture(int id)
		{
			_dbContext.Database.ExecuteSql($"DeleteLecture {id}");
			_dbContext.SaveChanges();
		}
	}
}
