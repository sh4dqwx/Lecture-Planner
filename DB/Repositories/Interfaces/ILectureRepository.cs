using DB.Dto;
using DB.Models;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace DB.Repositories.Interfaces
{
	public interface ILectureRepository
	{
		public List<Lecture> GetListByDate(DateTime date, string userId);
		public Lecture GetById(int id);
		public void AddLecture(LectureAddEditDto lecture);
		public void EditLecture(LectureAddEditDto lecture);
		public void DeleteLecture(int id);
	}
}
