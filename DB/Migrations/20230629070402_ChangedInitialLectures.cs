using System;
using Microsoft.EntityFrameworkCore.Migrations;

#nullable disable

namespace DB.Migrations
{
    /// <inheritdoc />
    public partial class ChangedInitialLectures : Migration
    {
        /// <inheritdoc />
        protected override void Up(MigrationBuilder migrationBuilder)
        {
            migrationBuilder.UpdateData(
                table: "AspNetUsers",
                keyColumn: "Id",
                keyValue: "1",
                columns: new[] { "ConcurrencyStamp", "PasswordHash", "SecurityStamp" },
                values: new object[] { "1d4784be-b310-4534-a52e-bc3a42ff7125", "AQAAAAIAAYagAAAAECWV6P8FDYB+PBB/MNgKkcQNunftcb4eRUELI3KfAwT9/mIRcB2+uUrxXmOObZJWUQ==", "6fde2506-f3c9-402a-8101-2b774112b211" });

            migrationBuilder.UpdateData(
                table: "AspNetUsers",
                keyColumn: "Id",
                keyValue: "2",
                columns: new[] { "ConcurrencyStamp", "PasswordHash", "SecurityStamp" },
                values: new object[] { "be30e0ed-68c4-49a2-aae4-391854230f28", "AQAAAAIAAYagAAAAEO0YSsGR4Lso8M25vLMTNqY5iMgZtHDW+Tnq+dYpdDZ8cJDfu9CUtJEfPpzXys0bDg==", "1c54ecec-caa2-4317-bdea-74663a7dfc0d" });

            migrationBuilder.UpdateData(
                table: "AspNetUsers",
                keyColumn: "Id",
                keyValue: "3",
                columns: new[] { "ConcurrencyStamp", "PasswordHash", "SecurityStamp" },
                values: new object[] { "68133679-a40a-45c6-82a2-05d4e442f711", "AQAAAAIAAYagAAAAENeeMeeXjCGT4HWDLV+fzNccREuuCKqwZE3r8oD9WsrOca6Q6wPKlr5TiChHlMeF1g==", "899d4df2-2da4-4414-828b-39096a3db1ef" });

            migrationBuilder.UpdateData(
                table: "Lectures",
                keyColumn: "Id",
                keyValue: 1,
                column: "Date",
                value: new DateTime(2023, 6, 29, 0, 0, 0, 0, DateTimeKind.Unspecified));

            migrationBuilder.UpdateData(
                table: "Lectures",
                keyColumn: "Id",
                keyValue: 2,
                column: "Date",
                value: new DateTime(2023, 6, 29, 0, 0, 0, 0, DateTimeKind.Unspecified));

            migrationBuilder.UpdateData(
                table: "Lectures",
                keyColumn: "Id",
                keyValue: 3,
                column: "Date",
                value: new DateTime(2023, 6, 30, 0, 0, 0, 0, DateTimeKind.Unspecified));

            migrationBuilder.UpdateData(
                table: "Lectures",
                keyColumn: "Id",
                keyValue: 4,
                column: "Date",
                value: new DateTime(2023, 6, 30, 0, 0, 0, 0, DateTimeKind.Unspecified));
        }

        /// <inheritdoc />
        protected override void Down(MigrationBuilder migrationBuilder)
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

            migrationBuilder.UpdateData(
                table: "Lectures",
                keyColumn: "Id",
                keyValue: 1,
                column: "Date",
                value: new DateTime(2023, 6, 15, 0, 0, 0, 0, DateTimeKind.Unspecified));

            migrationBuilder.UpdateData(
                table: "Lectures",
                keyColumn: "Id",
                keyValue: 2,
                column: "Date",
                value: new DateTime(2023, 6, 15, 0, 0, 0, 0, DateTimeKind.Unspecified));

            migrationBuilder.UpdateData(
                table: "Lectures",
                keyColumn: "Id",
                keyValue: 3,
                column: "Date",
                value: new DateTime(2023, 6, 16, 0, 0, 0, 0, DateTimeKind.Unspecified));

            migrationBuilder.UpdateData(
                table: "Lectures",
                keyColumn: "Id",
                keyValue: 4,
                column: "Date",
                value: new DateTime(2023, 6, 16, 0, 0, 0, 0, DateTimeKind.Unspecified));
        }
    }
}
