using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace DB.Dto
{
    public class LectureDetailsDto
    {
        public int Id { get; set; }
        public string Topic { get; set; }
        public DateOnly Date { get; set; }
        public TimeOnly StartHour { get; set; }
        public TimeOnly EndHour { get; set; }
        public HallDto Hall { get; set; }
        public LecturerDto Lecturer { get; set; }
        public int ParticipantCount { get; set; }
    }
}
