using Microsoft.EntityFrameworkCore.Migrations;

#nullable disable

namespace DB.Migrations
{
    /// <inheritdoc />
    public partial class StoredProcedures : Migration
    {
        /// <inheritdoc />
        protected override void Up(MigrationBuilder migrationBuilder)
        {
            migrationBuilder.UpdateData(
                table: "AspNetUsers",
                keyColumn: "Id",
                keyValue: "1",
                columns: new[] { "ConcurrencyStamp", "PasswordHash", "SecurityStamp" },
                values: new object[] { "8e62db6d-ceab-4bd8-be16-ff170fe1dab9", "AQAAAAIAAYagAAAAEN8TNJonIaieRYYihs9sbLPq0cCFX1/bDW/P7CdY4ZyuxPUc6146wzfq/uEGwRYihQ==", "0cff042e-4b9b-4917-be90-09ac82895fb9" });

            migrationBuilder.UpdateData(
                table: "AspNetUsers",
                keyColumn: "Id",
                keyValue: "2",
                columns: new[] { "ConcurrencyStamp", "PasswordHash", "SecurityStamp" },
                values: new object[] { "e22841c9-2388-41e6-9f84-bf64aa1a3bc2", "AQAAAAIAAYagAAAAEAT5ULxlKUkZ3iLgzxqrBqGW4+ph8kHyYP9+ePmvoMiquZ5aSDOykgPbS7HhQIoAhQ==", "17bb61f5-94a8-433b-92a4-e97ce99aefbe" });

            migrationBuilder.UpdateData(
                table: "AspNetUsers",
                keyColumn: "Id",
                keyValue: "3",
                columns: new[] { "ConcurrencyStamp", "PasswordHash", "SecurityStamp" },
                values: new object[] { "e0b8ce82-d16b-47cc-ace8-58a8296ac900", "AQAAAAIAAYagAAAAEG3SRrHrFlOllofhdcuUQvNrrybdSNeMRmg7w2T23zmjKMvcF/h2dTWrW6SWa/bo3w==", "55f6b809-2ebd-45c3-883f-53bef27d804e" });

            var AddLecture = "CREATE PROCEDURE AddLecture\r\n\t@Topic nvarchar(MAX),\r\n\t@Date datetime2,\r\n\t@StartHour time,\r\n\t@EndHour time,\r\n\t@HallId int,\r\n\t@LecturerId nvarchar(MAX)\r\nAS\r\nBEGIN\r\n\tINSERT INTO Lectures(Topic, Date, StartHour, EndHour, HallId, LecturerId)\r\n\tVALUES(@Topic, @Date, @StartHour, @EndHour, @HallId, @LecturerId)\r\nEND";
            migrationBuilder.Sql(AddLecture);

            var CancelParticipation = "CREATE PROCEDURE CancelParticipation\r\n\t@LectureId int,\r\n\t@UserId nvarchar(MAX)\r\nAS\r\nBEGIN\r\n\tDELETE FROM LecturesParticipants WHERE LectureId = @LectureId AND ParticipantId = @UserId\r\nEND";
			migrationBuilder.Sql(CancelParticipation);

            var ConfirmParticipation = "CREATE PROCEDURE ConfirmParticipation\r\n\t@LectureId int,\r\n\t@UserId nvarchar(MAX)\r\nAS\r\nBEGIN\r\n\tINSERT INTO LecturesParticipants(LectureId, ParticipantId) VALUES(@LectureId, @UserId)\r\nEND";
			migrationBuilder.Sql(ConfirmParticipation);

            var DeleteLecture = "CREATE PROCEDURE DeleteLecture\r\n\t@Id int\r\nAS\r\nBEGIN\r\n\tDELETE FROM Lectures WHERE Id = @Id\r\nEND";
			migrationBuilder.Sql(DeleteLecture);

            var EditLecture = "CREATE PROCEDURE EditLecture\r\n\t@Id int,\r\n\t@Topic nvarchar(MAX),\r\n\t@Date datetime2,\r\n\t@StartHour time,\r\n\t@EndHour time,\r\n\t@HallId int\r\nAS\r\nBEGIN\r\n\tUPDATE Lectures\r\n\tSET Topic = @Topic, Date = @Date, StartHour = @StartHour, EndHour = @EndHour, HallId = @HallId\r\n\tWHERE Id = @Id\r\nEND";
			migrationBuilder.Sql(EditLecture);

            var GetHallById = "CREATE PROCEDURE GetHallById\r\n\t@HallId int\r\nAS\r\nBEGIN\r\n\tSELECT * FROM Halls WHERE Id = @HallId\r\nEND";
            migrationBuilder.Sql(GetHallById);

            var GetHalls = "CREATE PROCEDURE GetHalls\r\nAS\r\nBEGIN\r\n\tSELECT * FROM Halls\r\nEND";
			migrationBuilder.Sql(GetHalls);

            var GetLectureById = "CREATE PROCEDURE GetLectureById\r\n\t@LectureId int\r\nAS\r\nBEGIN\r\n\tSELECT * FROM Lectures WHERE Id = @LectureId\r\nEND";
			migrationBuilder.Sql(GetLectureById);

            var GetLecturesByDate = "CREATE PROCEDURE GetLecturesByDate\r\n\t@Date date\r\nAS\r\nBEGIN\r\n\tSELECT * FROM Lectures WHERE Date = @Date\r\nEND";
			migrationBuilder.Sql(GetLecturesByDate);

            var GetParticipants = "CREATE PROCEDURE GetParticipants\r\n\t@LectureId int\r\nAS\r\nBEGIN\r\n\tSELECT * FROM LecturesParticipants WHERE LectureId = @LectureId\r\nEND";
			migrationBuilder.Sql(GetParticipants);

            var GetUserById = "CREATE PROCEDURE GetUserById\r\n\t@UserId nvarchar(MAX)\r\nAS\r\nBEGIN\r\n\tSELECT * FROM AspNetUsers WHERE Id = @UserId\r\nEND";
			migrationBuilder.Sql(GetUserById);

            var IsUserParticipant = "CREATE PROCEDURE IsUserParticipant\r\n\t@LectureId int,\r\n\t@UserId nvarchar(MAX)\r\nAS\r\nBEGIN\r\n\tSELECT * FROM LecturesParticipants WHERE LectureId = @LectureId AND ParticipantId = @UserId\r\nEND";
			migrationBuilder.Sql(IsUserParticipant);
		}

        /// <inheritdoc />
        protected override void Down(MigrationBuilder migrationBuilder)
        {
            migrationBuilder.UpdateData(
                table: "AspNetUsers",
                keyColumn: "Id",
                keyValue: "1",
                columns: new[] { "ConcurrencyStamp", "PasswordHash", "SecurityStamp" },
                values: new object[] { "c8e7b7a2-8ec2-4180-957e-3fac087ed34c", "AQAAAAIAAYagAAAAEJqrLfGS6tvm0kkOtnVBo+3UmjtFKWAPRfQullLhTSpesYOZaG5byJGNfQlIfpeuWw==", "ab579964-bba9-4b52-9963-330cf850d89e" });

            migrationBuilder.UpdateData(
                table: "AspNetUsers",
                keyColumn: "Id",
                keyValue: "2",
                columns: new[] { "ConcurrencyStamp", "PasswordHash", "SecurityStamp" },
                values: new object[] { "37a22726-b0ae-47ff-92ce-fa05a0aa9d7b", "AQAAAAIAAYagAAAAEFkKDRAVv79Ox6Z9TuLD9gWYR6ndNnGl3M14Cs/0dO771TEXxAbjtDi9alzm+C/0Hg==", "99aeb0a6-2ccb-4d0e-87ee-22b2feef9ba3" });

            migrationBuilder.UpdateData(
                table: "AspNetUsers",
                keyColumn: "Id",
                keyValue: "3",
                columns: new[] { "ConcurrencyStamp", "PasswordHash", "SecurityStamp" },
                values: new object[] { "2120ac0d-fd8a-419f-a9c3-c762e0689254", "AQAAAAIAAYagAAAAEJLvBt6OHjV6CcTT4BjaIGN0LxoVtDfDRDCP3z7GQiw8q3z5/LZyGpePUpMfxKCx3A==", "8cafb49f-22bc-4882-bbe0-5f69b417038a" });
        }
    }
}
