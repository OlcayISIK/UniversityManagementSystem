using Microsoft.EntityFrameworkCore.Migrations;

namespace UMS.Data.EF.Migrations
{
    public partial class FileDataUpdate : Migration
    {
        protected override void Up(MigrationBuilder migrationBuilder)
        {
            migrationBuilder.AddColumn<long>(
                name: "FileId",
                table: "Students",
                type: "bigint",
                nullable: true);

            migrationBuilder.AddColumn<long>(
                name: "CourseId",
                table: "Files",
                type: "bigint",
                nullable: true);

            migrationBuilder.AddColumn<bool>(
                name: "IsPrivate",
                table: "Files",
                type: "bit",
                nullable: false,
                defaultValue: false);

            migrationBuilder.AddColumn<long>(
                name: "StudentId",
                table: "Files",
                type: "bigint",
                nullable: true);

            migrationBuilder.AddColumn<long>(
                name: "FileId",
                table: "Courses",
                type: "bigint",
                nullable: true);

            migrationBuilder.CreateIndex(
                name: "IX_Files_CourseId",
                table: "Files",
                column: "CourseId");

            migrationBuilder.CreateIndex(
                name: "IX_Files_StudentId",
                table: "Files",
                column: "StudentId");

            migrationBuilder.AddForeignKey(
                name: "FK_Files_Courses_CourseId",
                table: "Files",
                column: "CourseId",
                principalTable: "Courses",
                principalColumn: "Id",
                onDelete: ReferentialAction.Restrict);

            migrationBuilder.AddForeignKey(
                name: "FK_Files_Students_StudentId",
                table: "Files",
                column: "StudentId",
                principalTable: "Students",
                principalColumn: "Id",
                onDelete: ReferentialAction.Restrict);
        }

        protected override void Down(MigrationBuilder migrationBuilder)
        {
            migrationBuilder.DropForeignKey(
                name: "FK_Files_Courses_CourseId",
                table: "Files");

            migrationBuilder.DropForeignKey(
                name: "FK_Files_Students_StudentId",
                table: "Files");

            migrationBuilder.DropIndex(
                name: "IX_Files_CourseId",
                table: "Files");

            migrationBuilder.DropIndex(
                name: "IX_Files_StudentId",
                table: "Files");

            migrationBuilder.DropColumn(
                name: "FileId",
                table: "Students");

            migrationBuilder.DropColumn(
                name: "CourseId",
                table: "Files");

            migrationBuilder.DropColumn(
                name: "IsPrivate",
                table: "Files");

            migrationBuilder.DropColumn(
                name: "StudentId",
                table: "Files");

            migrationBuilder.DropColumn(
                name: "FileId",
                table: "Courses");
        }
    }
}
