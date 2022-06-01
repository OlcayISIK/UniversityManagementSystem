using Microsoft.EntityFrameworkCore.Migrations;

namespace UMS.Data.EF.Migrations
{
    public partial class CourseTableUpdateRelations : Migration
    {
        protected override void Up(MigrationBuilder migrationBuilder)
        {
            migrationBuilder.DropIndex(
                name: "IX_Courses_OnlineCourseId",
                table: "Courses");

            migrationBuilder.DropIndex(
                name: "IX_Courses_OnsiteCourseId",
                table: "Courses");

            migrationBuilder.AlterColumn<long>(
                name: "StudentGradeId",
                table: "Courses",
                type: "bigint",
                nullable: true,
                oldClrType: typeof(long),
                oldType: "bigint");

            migrationBuilder.AlterColumn<long>(
                name: "OnsiteCourseId",
                table: "Courses",
                type: "bigint",
                nullable: true,
                oldClrType: typeof(long),
                oldType: "bigint");

            migrationBuilder.AlterColumn<long>(
                name: "OnlineCourseId",
                table: "Courses",
                type: "bigint",
                nullable: true,
                oldClrType: typeof(long),
                oldType: "bigint");

            migrationBuilder.CreateIndex(
                name: "IX_Courses_OnlineCourseId",
                table: "Courses",
                column: "OnlineCourseId",
                unique: true,
                filter: "[OnlineCourseId] IS NOT NULL");

            migrationBuilder.CreateIndex(
                name: "IX_Courses_OnsiteCourseId",
                table: "Courses",
                column: "OnsiteCourseId",
                unique: true,
                filter: "[OnsiteCourseId] IS NOT NULL");
        }

        protected override void Down(MigrationBuilder migrationBuilder)
        {
            migrationBuilder.DropIndex(
                name: "IX_Courses_OnlineCourseId",
                table: "Courses");

            migrationBuilder.DropIndex(
                name: "IX_Courses_OnsiteCourseId",
                table: "Courses");

            migrationBuilder.AlterColumn<long>(
                name: "StudentGradeId",
                table: "Courses",
                type: "bigint",
                nullable: false,
                defaultValue: 0L,
                oldClrType: typeof(long),
                oldType: "bigint",
                oldNullable: true);

            migrationBuilder.AlterColumn<long>(
                name: "OnsiteCourseId",
                table: "Courses",
                type: "bigint",
                nullable: false,
                defaultValue: 0L,
                oldClrType: typeof(long),
                oldType: "bigint",
                oldNullable: true);

            migrationBuilder.AlterColumn<long>(
                name: "OnlineCourseId",
                table: "Courses",
                type: "bigint",
                nullable: false,
                defaultValue: 0L,
                oldClrType: typeof(long),
                oldType: "bigint",
                oldNullable: true);

            migrationBuilder.CreateIndex(
                name: "IX_Courses_OnlineCourseId",
                table: "Courses",
                column: "OnlineCourseId",
                unique: true);

            migrationBuilder.CreateIndex(
                name: "IX_Courses_OnsiteCourseId",
                table: "Courses",
                column: "OnsiteCourseId",
                unique: true);
        }
    }
}
