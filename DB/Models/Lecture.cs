namespace DB.Models
{
    public class Lecture
    {
        public int Id { get; set; }
        public string? Topic { get; set; }
        public DateTime Date { get; set; }
        public TimeSpan StartHour { get; set; }
        public TimeSpan EndHour { get; set; }
        public int HallId { get; set; }
        public Hall? Hall { get; set; }
        public string? LecturerId { get; set; }
        public User? Lecturer { get; set; }
        public ICollection<LectureParticipant>? LectureParticipants { get; set; }
    }
}
