using Microsoft.EntityFrameworkCore.Migrations;

namespace UMS.Data.EF.Migrations
{
    public partial class FixStudentSocialClubTable : Migration
    {
        protected override void Up(MigrationBuilder migrationBuilder)
        {
            migrationBuilder.DropForeignKey(
                name: "FK_UniversitySocialClubs_Students_StudentId",
                table: "UniversitySocialClubs");

            migrationBuilder.DropIndex(
                name: "IX_UniversitySocialClubs_StudentId",
                table: "UniversitySocialClubs");

            migrationBuilder.DropColumn(
                name: "ClubLeaderId",
                table: "UniversitySocialClubs");

            migrationBuilder.RenameColumn(
                name: "StudentId",
                table: "UniversitySocialClubs",
                newName: "StudentsUniversitySocialClubId");

            migrationBuilder.RenameColumn(
                name: "UniversitySocialClubId",
                table: "Students",
                newName: "StudentsUniversitySocialClubId");

            migrationBuilder.CreateTable(
                name: "StudentsUniversitySocialClubs",
                columns: table => new
                {
                    StudentId = table.Column<long>(type: "bigint", nullable: false),
                    UniversitySocialClubId = table.Column<long>(type: "bigint", nullable: false)
                },
                constraints: table =>
                {
                    table.PrimaryKey("PK_StudentsUniversitySocialClubs", x => new { x.StudentId, x.UniversitySocialClubId });
                    table.ForeignKey(
                        name: "FK_StudentsUniversitySocialClubs_Students_StudentId",
                        column: x => x.StudentId,
                        principalTable: "Students",
                        principalColumn: "Id",
                        onDelete: ReferentialAction.Restrict);
                    table.ForeignKey(
                        name: "FK_StudentsUniversitySocialClubs_UniversitySocialClubs_UniversitySocialClubId",
                        column: x => x.UniversitySocialClubId,
                        principalTable: "UniversitySocialClubs",
                        principalColumn: "Id",
                        onDelete: ReferentialAction.Restrict);
                });

            migrationBuilder.CreateIndex(
                name: "IX_StudentsUniversitySocialClubs_UniversitySocialClubId",
                table: "StudentsUniversitySocialClubs",
                column: "UniversitySocialClubId");
        }

        protected override void Down(MigrationBuilder migrationBuilder)
        {
            migrationBuilder.DropTable(
                name: "StudentsUniversitySocialClubs");

            migrationBuilder.RenameColumn(
                name: "StudentsUniversitySocialClubId",
                table: "UniversitySocialClubs",
                newName: "StudentId");

            migrationBuilder.RenameColumn(
                name: "StudentsUniversitySocialClubId",
                table: "Students",
                newName: "UniversitySocialClubId");

            migrationBuilder.AddColumn<long>(
                name: "ClubLeaderId",
                table: "UniversitySocialClubs",
                type: "bigint",
                nullable: false,
                defaultValue: 0L);

            migrationBuilder.CreateIndex(
                name: "IX_UniversitySocialClubs_StudentId",
                table: "UniversitySocialClubs",
                column: "StudentId");

            migrationBuilder.AddForeignKey(
                name: "FK_UniversitySocialClubs_Students_StudentId",
                table: "UniversitySocialClubs",
                column: "StudentId",
                principalTable: "Students",
                principalColumn: "Id",
                onDelete: ReferentialAction.Restrict);
        }
    }
}
