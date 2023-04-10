using Microsoft.EntityFrameworkCore.Migrations;

#nullable disable

namespace CSAPlatform.Data.Migrations
{
    public partial class DataSeeding : Migration
    {
        protected override void Up(MigrationBuilder migrationBuilder)
        {
            migrationBuilder.InsertData(
                table: "AspNetUsers",
                columns: new[] { "Id", "AccessFailedCount", "Attachment", "CompanyName", "ConcurrencyStamp", "Email", "EmailConfirmed", "FirstName", "LastName", "LockoutEnabled", "LockoutEnd", "NormalizedEmail", "NormalizedUserName", "PasswordHash", "PhoneNumber", "PhoneNumberConfirmed", "Program", "Role", "SecurityStamp", "StudentNum", "TwoFactorEnabled", "University", "UserName" },
                values: new object[] { "e7985cd6-96b2-498e-83c9-a7eb99bf071b", 0, null, "", "6eb4d182-2b1b-4a37-a320-2296f18638cd", "admin@localhost", true, "admin", "admin", false, null, "ADMIN@LOCALHOST", null, "AQAAAAEAACcQAAAAEAzPz5+yzhFdAyYnsuxDYsM7YyohSaAGpjfaciu+eXfY4BTunhfeFx/mi8JGAzNPgQ==", null, false, "", 2, "fb64389b-57a7-4514-9ba3-a0f4aedc71c7", "", false, "", "admin@localhost" });
        }

        protected override void Down(MigrationBuilder migrationBuilder)
        {
            migrationBuilder.DeleteData(
                table: "AspNetUsers",
                keyColumn: "Id",
                keyValue: "e7985cd6-96b2-498e-83c9-a7eb99bf071b");
        }
    }
}
