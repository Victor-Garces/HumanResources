using System;
using Microsoft.EntityFrameworkCore.Migrations;

namespace HumanResources.Migrations
{
    public partial class AddedWorkExperiencesRelationToCandidateTable : Migration
    {
        protected override void Up(MigrationBuilder migrationBuilder)
        {
            migrationBuilder.DropForeignKey(
                name: "FK_Candidates_WorkExperiences_WorkExperienceId",
                table: "Candidates");

            migrationBuilder.DropIndex(
                name: "IX_Candidates_WorkExperienceId",
                table: "Candidates");

            migrationBuilder.DropColumn(
                name: "WorkExperienceId",
                table: "Candidates");

            migrationBuilder.AddColumn<Guid>(
                name: "CandidateId",
                table: "WorkExperiences",
                nullable: true);

            migrationBuilder.CreateIndex(
                name: "IX_WorkExperiences_CandidateId",
                table: "WorkExperiences",
                column: "CandidateId");

            migrationBuilder.AddForeignKey(
                name: "FK_WorkExperiences_Candidates_CandidateId",
                table: "WorkExperiences",
                column: "CandidateId",
                principalTable: "Candidates",
                principalColumn: "Id",
                onDelete: ReferentialAction.Restrict);
        }

        protected override void Down(MigrationBuilder migrationBuilder)
        {
            migrationBuilder.DropForeignKey(
                name: "FK_WorkExperiences_Candidates_CandidateId",
                table: "WorkExperiences");

            migrationBuilder.DropIndex(
                name: "IX_WorkExperiences_CandidateId",
                table: "WorkExperiences");

            migrationBuilder.DropColumn(
                name: "CandidateId",
                table: "WorkExperiences");

            migrationBuilder.AddColumn<Guid>(
                name: "WorkExperienceId",
                table: "Candidates",
                nullable: false,
                defaultValue: new Guid("00000000-0000-0000-0000-000000000000"));

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
                onDelete: ReferentialAction.Cascade);
        }
    }
}
