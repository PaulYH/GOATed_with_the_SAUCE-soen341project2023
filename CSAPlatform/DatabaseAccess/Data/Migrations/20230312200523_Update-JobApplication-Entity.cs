using System;
using Microsoft.EntityFrameworkCore.Migrations;

#nullable disable

namespace CSAPlatform.Data.Migrations
{
    public partial class UpdateJobApplicationEntity : Migration
    {
        protected override void Up(MigrationBuilder migrationBuilder)
        {
            migrationBuilder.AddColumn<byte[]>(
                name: "CoverLetterAttachment",
                table: "JobApplications",
                type: "varbinary(max)",
                nullable: true);

            migrationBuilder.AddColumn<byte[]>(
                name: "ResumeAttachment",
                table: "JobApplications",
                type: "varbinary(max)",
                nullable: true);
        }

        protected override void Down(MigrationBuilder migrationBuilder)
        {
            migrationBuilder.DropColumn(
                name: "CoverLetterAttachment",
                table: "JobApplications");

            migrationBuilder.DropColumn(
                name: "ResumeAttachment",
                table: "JobApplications");
        }
    }
}
