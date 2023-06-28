using DB.Dto;
using DB.Models;
using DB.Repositories.Interfaces;
using DB.Services;
using DB.Services.Interfaces;
using Moq;

namespace Testy
{
	public class LectureServiceTests
	{
		private LectureService _lectureService;
		private Mock<ILectureRepository> _lectureRepositoryMock;
		private Mock<IHallService> _hallServiceMock;
		private Mock<IUserService> _userServiceMock;

		[SetUp]
		public void Setup()
		{
			_lectureRepositoryMock = new Mock<ILectureRepository>();
			_hallServiceMock = new Mock<IHallService>();
			_userServiceMock = new Mock<IUserService>();
			_lectureService = new LectureService(_lectureRepositoryMock.Object, _hallServiceMock.Object, _userServiceMock.Object);
		}

		[Test]
		public void AddLecture_WhenNoOverlappingLectures_ReturnsTrue()
		{
			// Arrange
			var lecture = new LectureAddEditDto
			{
				Id = 3,
				Topic = "Test",
				Date = new DateOnly(2023, 6, 28),
				StartHour = new TimeOnly(10, 0),
				EndHour = new TimeOnly(12, 0),
				HallId = 1,
				LecturerId = "1"
			};

			var existingLectures = new List<Lecture>
			{
				new Lecture
				{
					Id = 1,
					Topic = "Existing1",
					Date = new DateTime(2023, 6, 28),
					StartHour = new TimeSpan(8, 0, 0),
					EndHour = new TimeSpan(9, 0, 0),
					HallId = 1,
					LecturerId = "1"
				},
				new Lecture
				{
					Id = 2,
					Topic = "Existing2",
					Date = new DateTime(2023, 6, 28),
					StartHour = new TimeSpan(13, 0, 0),
					EndHour = new TimeSpan(14, 0, 0),
					HallId = 1,
					LecturerId = "1"
				}
			};

			_lectureRepositoryMock
				.Setup(r => r.GetListByDate(lecture.Date.ToDateTime(new TimeOnly(0, 0, 0)), ""))
				.Returns(existingLectures);

			// Act
			var result = _lectureService.AddLecture(lecture);

			// Assert
			Assert.True(result);
		}

		[Test]
		public void AddLecture_WhenOverlappingLectures_ReturnsFalse()
		{
			// Arrange
			var lecture = new LectureAddEditDto
			{
				Id = 3,
				Topic = "Test",
				Date = new DateOnly(2023, 6, 28),
				StartHour = new TimeOnly(8, 0),
				EndHour = new TimeOnly(12, 0),
				HallId = 1,
				LecturerId = "1"
			};

			var existingLectures = new List<Lecture>
			{
				new Lecture
				{
					Id = 1,
					Topic = "Existing1",
					Date = new DateTime(2023, 6, 28),
					StartHour = new TimeSpan(8, 0, 0),
					EndHour = new TimeSpan(9, 0, 0),
					HallId = 1,
					LecturerId = "1"
				},
				new Lecture
				{
					Id = 2,
					Topic = "Existing2",
					Date = new DateTime(2023, 6, 28),
					StartHour = new TimeSpan(13, 0, 0),
					EndHour = new TimeSpan(14, 0, 0),
					HallId = 1,
					LecturerId = "1"
				}
			};

			_lectureRepositoryMock
				.Setup(r => r.GetListByDate(lecture.Date.ToDateTime(new TimeOnly(0, 0, 0)), ""))
				.Returns(existingLectures);

			// Act
			var result = _lectureService.AddLecture(lecture);

			// Assert
			Assert.False(result);
		}
	}
}