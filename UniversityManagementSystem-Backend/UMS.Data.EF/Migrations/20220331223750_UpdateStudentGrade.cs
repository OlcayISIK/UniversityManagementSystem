using Microsoft.EntityFrameworkCore.Migrations;

namespace UMS.Data.EF.Migrations
{
    public partial class UpdateStudentGrade : Migration
    {
        protected override void Up(MigrationBuilder migrationBuilder)
        {
            migrationBuilder.DropForeignKey(
                name: "FK_StudentGrades_Courses_CourseId1",
                table: "StudentGrades");

            migrationBuilder.DropForeignKey(
                name: "FK_StudentGrades_Students_StudentId1",
                table: "StudentGrades");

            migrationBuilder.DropIndex(
                name: "IX_StudentGrades_CourseId1",
                table: "StudentGrades");

            migrationBuilder.DropIndex(
                name: "IX_StudentGrades_StudentId1",
                table: "StudentGrades");

            migrationBuilder.DropColumn(
                name: "CourseId1",
                table: "StudentGrades");

            migrationBuilder.DropColumn(
                name: "StudentId1",
                table: "StudentGrades");

            migrationBuilder.AlterColumn<long>(
                name: "StudentId",
                table: "StudentGrades",
                type: "bigint",
                nullable: false,
                oldClrType: typeof(int),
                oldType: "int");

            migrationBuilder.AlterColumn<long>(
                name: "CourseId",
                table: "StudentGrades",
                type: "bigint",
                nullable: false,
                oldClrType: typeof(int),
                oldType: "int");

            migrationBuilder.CreateIndex(
                name: "IX_StudentGrades_CourseId",
                table: "StudentGrades",
                column: "CourseId");

            migrationBuilder.CreateIndex(
                name: "IX_StudentGrades_StudentId",
                table: "StudentGrades",
                column: "StudentId");

            migrationBuilder.AddForeignKey(
                name: "FK_StudentGrades_Courses_CourseId",
                table: "StudentGrades",
                column: "CourseId",
                principalTable: "Courses",
                principalColumn: "Id",
                onDelete: ReferentialAction.Restrict);

            migrationBuilder.AddForeignKey(
                name: "FK_StudentGrades_Students_StudentId",
                table: "StudentGrades",
                column: "StudentId",
                principalTable: "Students",
                principalColumn: "Id",
                onDelete: ReferentialAction.Restrict);
        }

        protected override void Down(MigrationBuilder migrationBuilder)
        {
            migrationBuilder.DropForeignKey(
                name: "FK_StudentGrades_Courses_CourseId",
                table: "StudentGrades");

            migrationBuilder.DropForeignKey(
                name: "FK_StudentGrades_Students_StudentId",
                table: "StudentGrades");

            migrationBuilder.DropIndex(
                name: "IX_StudentGrades_CourseId",
                table: "StudentGrades");

            migrationBuilder.DropIndex(
                name: "IX_StudentGrades_StudentId",
                table: "StudentGrades");

            migrationBuilder.AlterColumn<int>(
                name: "StudentId",
                table: "StudentGrades",
                type: "int",
                nullable: false,
                oldClrType: typeof(long),
                oldType: "bigint");

            migrationBuilder.AlterColumn<int>(
                name: "CourseId",
                table: "StudentGrades",
                type: "int",
                nullable: false,
                oldClrType: typeof(long),
                oldType: "bigint");

            migrationBuilder.AddColumn<long>(
                name: "CourseId1",
                table: "StudentGrades",
                type: "bigint",
                nullable: true);

            migrationBuilder.AddColumn<long>(
                name: "StudentId1",
                table: "StudentGrades",
                type: "bigint",
                nullable: true);

            migrationBuilder.CreateIndex(
                name: "IX_StudentGrades_CourseId1",
                table: "StudentGrades",
                column: "CourseId1");

            migrationBuilder.CreateIndex(
                name: "IX_StudentGrades_StudentId1",
                table: "StudentGrades",
                column: "StudentId1");

            migrationBuilder.AddForeignKey(
                name: "FK_StudentGrades_Courses_CourseId1",
                table: "StudentGrades",
                column: "CourseId1",
                principalTable: "Courses",
                principalColumn: "Id",
                onDelete: ReferentialAction.Restrict);

            migrationBuilder.AddForeignKey(
                name: "FK_StudentGrades_Students_StudentId1",
                table: "StudentGrades",
                column: "StudentId1",
                principalTable: "Students",
                principalColumn: "Id",
                onDelete: ReferentialAction.Restrict);
        }
    }
}
