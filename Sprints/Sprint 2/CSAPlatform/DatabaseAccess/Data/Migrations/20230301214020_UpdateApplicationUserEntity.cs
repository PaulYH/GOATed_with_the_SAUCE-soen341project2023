using System;
using Microsoft.EntityFrameworkCore.Migrations;

#nullable disable

namespace CSAPlatform.Data.Migrations
{
    public partial class UpdateApplicationUserEntity : Migration
    {
        protected override void Up(MigrationBuilder migrationBuilder)
        {
            migrationBuilder.AddColumn<byte[]>(
                name: "Attachment",
                table: "AspNetUsers",
                type: "varbinary(max)",
                nullable: true);
        }

        protected override void Down(MigrationBuilder migrationBuilder)
        {
            migrationBuilder.DropColumn(
                name: "Attachment",
                table: "AspNetUsers");
        }
    }
}
