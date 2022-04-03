﻿using Microsoft.EntityFrameworkCore.Migrations;

namespace UMS.Data.EF.Migrations
{
    public partial class NullableSocialClubID : Migration
    {
        protected override void Up(MigrationBuilder migrationBuilder)
        {
            migrationBuilder.DropIndex(
                name: "IX_CourseInstructors_UniversitySocialClubId",
                table: "CourseInstructors");

            migrationBuilder.AlterColumn<long>(
                name: "UniversitySocialClubId",
                table: "Students",
                type: "bigint",
                nullable: true,
                oldClrType: typeof(long),
                oldType: "bigint");

            migrationBuilder.AlterColumn<long>(
                name: "UniversitySocialClubId",
                table: "CourseInstructors",
                type: "bigint",
                nullable: true,
                oldClrType: typeof(long),
                oldType: "bigint");

            migrationBuilder.CreateIndex(
                name: "IX_CourseInstructors_UniversitySocialClubId",
                table: "CourseInstructors",
                column: "UniversitySocialClubId",
                unique: true,
                filter: "[UniversitySocialClubId] IS NOT NULL");
        }

        protected override void Down(MigrationBuilder migrationBuilder)
        {
            migrationBuilder.DropIndex(
                name: "IX_CourseInstructors_UniversitySocialClubId",
                table: "CourseInstructors");

            migrationBuilder.AlterColumn<long>(
                name: "UniversitySocialClubId",
                table: "Students",
                type: "bigint",
                nullable: false,
                defaultValue: 0L,
                oldClrType: typeof(long),
                oldType: "bigint",
                oldNullable: true);

            migrationBuilder.AlterColumn<long>(
                name: "UniversitySocialClubId",
                table: "CourseInstructors",
                type: "bigint",
                nullable: false,
                defaultValue: 0L,
                oldClrType: typeof(long),
                oldType: "bigint",
                oldNullable: true);

            migrationBuilder.CreateIndex(
                name: "IX_CourseInstructors_UniversitySocialClubId",
                table: "CourseInstructors",
                column: "UniversitySocialClubId",
                unique: true);
        }
    }
}
