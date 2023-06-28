using Microsoft.EntityFrameworkCore.Migrations;

#nullable disable

namespace DB.Migrations
{
    /// <inheritdoc />
    public partial class spGetHalls : Migration
    {
        /// <inheritdoc />
        protected override void Up(MigrationBuilder migrationBuilder)
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

        /// <inheritdoc />
        protected override void Down(MigrationBuilder migrationBuilder)
        {
            migrationBuilder.UpdateData(
                table: "AspNetUsers",
                keyColumn: "Id",
                keyValue: "1",
                columns: new[] { "ConcurrencyStamp", "PasswordHash", "SecurityStamp" },
                values: new object[] { "3c0dae68-cd5c-4cba-92e0-9c1a58718491", "AQAAAAIAAYagAAAAEOfzORS/SSH02sPfpzOOlFR4dekvADJX+YUzVKYd0x8vACxMlkmtJXpgGLX9J0k4yw==", "50872bcb-ac59-4d6f-98a2-bf0b5217a838" });

            migrationBuilder.UpdateData(
                table: "AspNetUsers",
                keyColumn: "Id",
                keyValue: "2",
                columns: new[] { "ConcurrencyStamp", "PasswordHash", "SecurityStamp" },
                values: new object[] { "b064206a-b9ac-45dd-a53d-e2cde11b18dd", "AQAAAAIAAYagAAAAEMruDLX1+Q0A2vHun5EPCZryAPDw8RLueL8SbYGOGj3CFv5/Vg19xYx5eRFa1wKhvQ==", "79cf09a4-c559-447e-931a-f971ff6f6cd4" });

            migrationBuilder.UpdateData(
                table: "AspNetUsers",
                keyColumn: "Id",
                keyValue: "3",
                columns: new[] { "ConcurrencyStamp", "PasswordHash", "SecurityStamp" },
                values: new object[] { "57fd8adc-08e1-4fa4-9671-a50bd9b84394", "AQAAAAIAAYagAAAAENHpYWaNz/ugztWp1LxVpMkshbObHg6WnDIkEjgOBw1xVK8XsXdWGwyUtLBEN5ueFQ==", "b0c3ee89-0d6b-45d8-a7df-388a68b0a761" });
        }
    }
}
