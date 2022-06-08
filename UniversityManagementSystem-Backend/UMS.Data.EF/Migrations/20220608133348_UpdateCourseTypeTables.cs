using System;
using Microsoft.EntityFrameworkCore.Migrations;

namespace UMS.Data.EF.Migrations
{
    public partial class UpdateCourseTypeTables : Migration
    {
        protected override void Up(MigrationBuilder migrationBuilder)
        {
            migrationBuilder.AddColumn<string>(
                name: "Days",
                table: "OnlineCourses",
                type: "nvarchar(max)",
                nullable: true);

            migrationBuilder.AddColumn<DateTime>(
                name: "Time",
                table: "OnlineCourses",
                type: "datetime2",
                nullable: false,
                defaultValue: new DateTime(1, 1, 1, 0, 0, 0, 0, DateTimeKind.Unspecified));
        }

        protected override void Down(MigrationBuilder migrationBuilder)
        {
            migrationBuilder.DropColumn(
                name: "Days",
                table: "OnlineCourses");

            migrationBuilder.DropColumn(
                name: "Time",
                table: "OnlineCourses");
        }
    }
}
