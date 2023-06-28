using Microsoft.AspNetCore.Identity;

namespace DB.Models
{
	public class User : IdentityUser
	{
		public string? FirstName { get; set; }
		public string? LastName { get; set; }
		public ICollection<Lecture>? AssignedLectures { get; set; }
		public ICollection<LectureParticipant>? LectureParticipants { get; set; }
	}
}
