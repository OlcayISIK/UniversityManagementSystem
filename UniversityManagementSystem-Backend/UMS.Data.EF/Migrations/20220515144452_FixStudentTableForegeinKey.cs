using Microsoft.EntityFrameworkCore.Migrations;

namespace UMS.Data.EF.Migrations
{
    public partial class FixStudentTableForegeinKey : Migration
    {
        protected override void Up(MigrationBuilder migrationBuilder)
        {
            migrationBuilder.DropColumn(
                name: "StudentsUniversitySocialClubId",
                table: "Students");
        }

        protected override void Down(MigrationBuilder migrationBuilder)
        {
            migrationBuilder.AddColumn<long>(
                name: "StudentsUniversitySocialClubId",
                table: "Students",
                type: "bigint",
                nullable: true);
        }
    }
}
