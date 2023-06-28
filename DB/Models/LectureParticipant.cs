namespace DB.Models
{
    public class LectureParticipant
    {
        public int LectureId { get; set; }
        public Lecture? Lecture { get; set; }
        public string? ParticipantId { get; set; }
        public User? Participant { get; set; }
    }
}
