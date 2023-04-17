using Microsoft.EntityFrameworkCore.Migrations;

#nullable disable

namespace CSAPlatform.Data.Migrations
{
    public partial class Update_DataSeed_1 : Migration
    {
        protected override void Up(MigrationBuilder migrationBuilder)
        {
            migrationBuilder.UpdateData(
                table: "AspNetUsers",
                keyColumn: "Id",
                keyValue: "e7985cd6-96b2-498e-83c9-a7eb99bf071b",
                columns: new[] { "ConcurrencyStamp", "NormalizedUserName", "PasswordHash", "SecurityStamp" },
                values: new object[] { "e6ef69de-3aef-445b-932c-52e836179f08", "ADMIN@LOCALHOST", "AQAAAAEAACcQAAAAEFeBC6iG3FxHD9FGMWDb8f74WRwER5QlwZtf2ThgWsL5Pl07259C0j5O9QQkonyatQ==", "a46112f1-d48e-436a-8510-9c56217c5647" });
        }

        protected override void Down(MigrationBuilder migrationBuilder)
        {
            migrationBuilder.UpdateData(
                table: "AspNetUsers",
                keyColumn: "Id",
                keyValue: "e7985cd6-96b2-498e-83c9-a7eb99bf071b",
                columns: new[] { "ConcurrencyStamp", "NormalizedUserName", "PasswordHash", "SecurityStamp" },
                values: new object[] { "6eb4d182-2b1b-4a37-a320-2296f18638cd", null, "AQAAAAEAACcQAAAAEAzPz5+yzhFdAyYnsuxDYsM7YyohSaAGpjfaciu+eXfY4BTunhfeFx/mi8JGAzNPgQ==", "fb64389b-57a7-4514-9ba3-a0f4aedc71c7" });
        }
    }
}
