using Microsoft.EntityFrameworkCore;
using DB.Models;
using Microsoft.AspNetCore.Identity.EntityFrameworkCore;
using Microsoft.AspNetCore.Identity;

namespace DB
{
	public class MyDbContext : IdentityDbContext
	{
		public MyDbContext(DbContextOptions<MyDbContext> options) : base(options) { }

		public DbSet<Hall> Halls { get; set; }
		public DbSet<Lecture> Lectures { get; set; }
		public DbSet<LectureParticipant> LecturesParticipants { get; set; }

		protected override void OnModelCreating(ModelBuilder modelBuilder)
		{
			base.OnModelCreating(modelBuilder);

			modelBuilder.Entity<Hall>()
				.ToTable("Halls");
			modelBuilder.Entity<Hall>()
				.HasKey(h => h.Id);
			modelBuilder.Entity<Hall>()
				.Property(h => h.Id)
				.UseIdentityColumn(seed: 1, increment: 1);
			modelBuilder.Entity<Hall>()
				.Property(h => h.Name)
				.IsRequired();

			modelBuilder.Entity<Lecture>()
				.ToTable("Lectures");
			modelBuilder.Entity<Lecture>()
				.HasKey(l => l.Id);
			modelBuilder.Entity<Lecture>()
				.Property(l => l.Id)
				.UseIdentityColumn(seed: 1, increment: 1);
			modelBuilder.Entity<Lecture>()
				.Property(l => l.Topic)
				.IsRequired();
			modelBuilder.Entity<Lecture>()
				.Property(l => l.Date)
				.IsRequired();
			modelBuilder.Entity<Lecture>()
				.Property(l => l.StartHour)
				.IsRequired();
			modelBuilder.Entity<Lecture>()
				.Property(l => l.EndHour)
				.IsRequired();
			modelBuilder.Entity<Lecture>()
				.HasOne(l => l.Hall)
				.WithMany(h => h.Lectures)
				.HasForeignKey(l => l.HallId);
			modelBuilder.Entity<Lecture>()
				.HasOne(l => l.Lecturer)
				.WithMany(le => le.AssignedLectures)
				.HasForeignKey(l => l.LecturerId);

			modelBuilder.Entity<LectureParticipant>()
				.ToTable("LecturesParticipants");
			modelBuilder.Entity<LectureParticipant>()
				.HasKey(lp => new { lp.LectureId, lp.ParticipantId });
			modelBuilder.Entity<LectureParticipant>()
				.HasOne(lp => lp.Lecture)
				.WithMany(l => l.LectureParticipants)
				.HasForeignKey(lp => lp.LectureId);
			modelBuilder.Entity<LectureParticipant>()
				.HasOne(lp => lp.Participant)
				.WithMany(p => p.LectureParticipants)
				.HasForeignKey(lp => lp.ParticipantId);

			CreateInitialData(modelBuilder);
		}

		private void CreateInitialData(ModelBuilder modelBuilder)
		{
			// Użytkownicy
			PasswordHasher<User> passwordHasher = new PasswordHasher<User>();
			User adminUser = new User
			{
				Id = "1",
				UserName = "admin@test.pl",
				NormalizedUserName = "ADMIN@TEST.PL",
				FirstName = "Admin",
				LastName = "Admin",
				Email = "admin@test.pl",
				NormalizedEmail = "ADMIN@TEST.PL",
				EmailConfirmed = true,
			};
			adminUser.PasswordHash = passwordHasher.HashPassword(adminUser, "admin123");
			User studentUser = new User
			{
				Id = "2",
				UserName = "student@test.pl",
				NormalizedUserName = "STUDENT@TEST.PL",
				FirstName = "Jan",
				LastName = "Kowalski",
				Email = "student@test.pl",
				NormalizedEmail = "STUDENT@TEST.PL",
				EmailConfirmed = true,
			};
			studentUser.PasswordHash = passwordHasher.HashPassword(studentUser, "student123");
			User lecturerUser = new User
			{
				Id = "3",
				UserName = "lecturer@test.pl",
				NormalizedUserName = "LECTURER@TEST.PL",
				FirstName = "Adam",
				LastName = "Mickiewicz",
				Email = "lecturer@test.pl",
				NormalizedEmail = "LECTURER@TEST.PL",
				EmailConfirmed = true,
			};
			lecturerUser.PasswordHash = passwordHasher.HashPassword(lecturerUser, "lecturer123");
			modelBuilder.Entity<User>()
				.HasData(adminUser, studentUser, lecturerUser);

			// Role
			modelBuilder.Entity<IdentityRole>()
				.HasData(
					new IdentityRole { Id = "1", Name = "Admin", NormalizedName = "ADMIN" },
					new IdentityRole { Id = "2", Name = "Student", NormalizedName = "STUDENT" },
					new IdentityRole { Id = "3", Name = "Wykładowca", NormalizedName = "WYKŁADOWCA" }
				);

			// Przypisanie roli użytkownikom
			modelBuilder.Entity<IdentityUserRole<string>>()
				.HasData(
					new IdentityUserRole<string> { UserId = adminUser.Id, RoleId = "1" },
					new IdentityUserRole<string> { UserId = studentUser.Id, RoleId = "2" },
					new IdentityUserRole<string> { UserId = lecturerUser.Id, RoleId = "3" }
				);

			// Sale wykładowe
			modelBuilder.Entity<Hall>()
				.HasData(
					new Hall { Id = 1, Name = "Sala W1"},
					new Hall { Id = 2, Name = "Sala W2" },
					new Hall { Id = 3, Name = "Sala W3" },
					new Hall { Id = 4, Name = "Sala W4" }
				);

			// Wykłady
			Lecture lecture1 = new Lecture
			{
				Id = 1,
				Topic = "Teoria liczb i kryptografia",
				Date = new DateTime(2023, 6, 15),
				StartHour = new TimeSpan(8, 30, 0),
				EndHour = new TimeSpan(9, 0, 0),
				HallId = 1,
				LecturerId = lecturerUser.Id
			};
			Lecture lecture2 = new Lecture
			{
				Id = 2,
				Topic = "Geometria fraktalna",
				Date = new DateTime(2023, 6, 15),
				StartHour = new TimeSpan(10, 0, 0),
				EndHour = new TimeSpan(12, 0, 0),
				HallId = 3,
				LecturerId = lecturerUser.Id
			};
			Lecture lecture3 = new Lecture
			{
				Id = 3,
				Topic = "Teoria grafów i jej zastosowania",
				Date = new DateTime(2023, 6, 16),
				StartHour = new TimeSpan(9, 30, 0),
				EndHour = new TimeSpan(10, 30, 0),
				HallId = 2,
				LecturerId = lecturerUser.Id
			};
			Lecture lecture4 = new Lecture
			{
				Id = 4,
				Topic = "Statystyka i analiza danych",
				Date = new DateTime(2023, 6, 16),
				StartHour = new TimeSpan(8, 30, 0),
				EndHour = new TimeSpan(11, 0, 0),
				HallId = 4,
				LecturerId = lecturerUser.Id
			};
			modelBuilder.Entity<Lecture>()
				.HasData(lecture1, lecture2, lecture3, lecture4);

			// Przypisanie uczestników do wykładów
			modelBuilder.Entity<LectureParticipant>()
				.HasData(
					new LectureParticipant { LectureId = lecture2.Id, ParticipantId = studentUser.Id },
					new LectureParticipant { LectureId = lecture3.Id, ParticipantId = studentUser.Id }
				);
		}
	}
}
