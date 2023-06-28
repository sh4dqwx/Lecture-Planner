using DB.Models;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Reflection;
using System.Text;
using System.Threading.Tasks;

namespace DB.Dto
{
    public class LectureDto
    {
        public int Id { get; set; }
        public string? Topic { get; set; }
        public TimeOnly StartHour { get; set; }
        public TimeOnly EndHour { get; set; }
        public int RowSpan { get; set; }
        public int HallId { get; set; }
        public bool IsUserParticipant { get; set; }
        public bool IsUserLecturer { get; set; }
    }
}
