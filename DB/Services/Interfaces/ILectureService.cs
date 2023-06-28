using DB.Dto;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace DB.Services.Interfaces
{
    public interface ILectureService
    {
        public List<LectureDto> GetListByDate(DateOnly date, string userId);
        public LectureDetailsDto GetDetailsById(int id);
        public LectureAddEditDto GetEditById(int id);
        public bool AddLecture(LectureAddEditDto lecture);
        public bool EditLecture(LectureAddEditDto lecture);
        public void DeleteLecture(int id);
    }
}
