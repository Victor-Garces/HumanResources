using Microsoft.EntityFrameworkCore.Migrations;
using System;

namespace HumanResources.Migrations
{
    public partial class WorkExperienceTable : Migration
    {
        protected override void Up(MigrationBuilder migrationBuilder)
        {
            migrationBuilder.DropColumn(
                name: "WorkExperience",
                table: "Candidates");

            migrationBuilder.AlterColumn<double>(
                name: "AspiratedSalary",
                table: "Candidates",
                nullable: false,
                oldClrType: typeof(int));

            migrationBuilder.AddColumn<Guid>(
                name: "WorkExperienceId",
                table: "Candidates",
                nullable: false,
                defaultValue: new Guid("00000000-0000-0000-0000-000000000000"));

            migrationBuilder.CreateTable(
                name: "WorkExperiences",
                columns: table => new
                {
                    Id = table.Column<Guid>(nullable: false, defaultValueSql: "newsequentialid()"),
                    Company = table.Column<string>(nullable: false),
                    OccupiedPosition = table.Column<string>(nullable: false),
                    DateFrom = table.Column<DateTime>(nullable: false),
                    DateTo = table.Column<DateTime>(nullable: false),
                    Salary = table.Column<double>(nullable: false)
                },
                constraints: table =>
                {
                    table.PrimaryKey("PK_WorkExperiences", x => x.Id);
                });

            migrationBuilder.CreateIndex(
                name: "IX_Candidates_WorkExperienceId",
                table: "Candidates",
                column: "WorkExperienceId");

            migrationBuilder.AddForeignKey(
                name: "FK_Candidates_WorkExperiences_WorkExperienceId",
                table: "Candidates",
                column: "WorkExperienceId",
                principalTable: "WorkExperiences",
                principalColumn: "Id",
                onDelete: ReferentialAction.NoAction);
        }

        protected override void Down(MigrationBuilder migrationBuilder)
        {
            migrationBuilder.DropForeignKey(
                name: "FK_Candidates_WorkExperiences_WorkExperienceId",
                table: "Candidates");

            migrationBuilder.DropTable(
                name: "WorkExperiences");

            migrationBuilder.DropIndex(
                name: "IX_Candidates_WorkExperienceId",
                table: "Candidates");

            migrationBuilder.DropColumn(
                name: "WorkExperienceId",
                table: "Candidates");

            migrationBuilder.AlterColumn<int>(
                name: "AspiratedSalary",
                table: "Candidates",
                nullable: false,
                oldClrType: typeof(double));

            migrationBuilder.AddColumn<string>(
                name: "WorkExperience",
                table: "Candidates",
                nullable: false,
                defaultValue: "");
        }
    }
}
