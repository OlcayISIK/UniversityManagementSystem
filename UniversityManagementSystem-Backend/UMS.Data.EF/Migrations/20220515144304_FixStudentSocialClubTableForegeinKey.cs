using Microsoft.EntityFrameworkCore.Migrations;

namespace UMS.Data.EF.Migrations
{
    public partial class FixStudentSocialClubTableForegeinKey : Migration
    {
        protected override void Up(MigrationBuilder migrationBuilder)
        {
            migrationBuilder.DropColumn(
                name: "StudentsUniversitySocialClubId",
                table: "UniversitySocialClubs");
        }

        protected override void Down(MigrationBuilder migrationBuilder)
        {
            migrationBuilder.AddColumn<long>(
                name: "StudentsUniversitySocialClubId",
                table: "UniversitySocialClubs",
                type: "bigint",
                nullable: true);
        }
    }
}
