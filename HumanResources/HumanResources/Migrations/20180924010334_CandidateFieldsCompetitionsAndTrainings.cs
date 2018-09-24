using Microsoft.EntityFrameworkCore.Migrations;
using System;

namespace HumanResources.Migrations
{
    public partial class CandidateFieldsCompetitionsAndTrainings : Migration
    {
        protected override void Up(MigrationBuilder migrationBuilder)
        {
            migrationBuilder.DropColumn(
                name: "MainCompetences",
                table: "Candidates");

            migrationBuilder.DropColumn(
                name: "MainTrainings",
                table: "Candidates");

            migrationBuilder.AddColumn<Guid>(
                name: "CandidateId",
                table: "Trainings",
                nullable: true);

            migrationBuilder.AddColumn<Guid>(
                name: "CandidateId",
                table: "Competitions",
                nullable: true);

            migrationBuilder.CreateIndex(
                name: "IX_Trainings_CandidateId",
                table: "Trainings",
                column: "CandidateId");

            migrationBuilder.CreateIndex(
                name: "IX_Competitions_CandidateId",
                table: "Competitions",
                column: "CandidateId");

            migrationBuilder.AddForeignKey(
                name: "FK_Competitions_Candidates_CandidateId",
                table: "Competitions",
                column: "CandidateId",
                principalTable: "Candidates",
                principalColumn: "Id",
                onDelete: ReferentialAction.NoAction);

            migrationBuilder.AddForeignKey(
                name: "FK_Trainings_Candidates_CandidateId",
                table: "Trainings",
                column: "CandidateId",
                principalTable: "Candidates",
                principalColumn: "Id",
                onDelete: ReferentialAction.NoAction);
        }

        protected override void Down(MigrationBuilder migrationBuilder)
        {
            migrationBuilder.DropForeignKey(
                name: "FK_Competitions_Candidates_CandidateId",
                table: "Competitions");

            migrationBuilder.DropForeignKey(
                name: "FK_Trainings_Candidates_CandidateId",
                table: "Trainings");

            migrationBuilder.DropIndex(
                name: "IX_Trainings_CandidateId",
                table: "Trainings");

            migrationBuilder.DropIndex(
                name: "IX_Competitions_CandidateId",
                table: "Competitions");

            migrationBuilder.DropColumn(
                name: "CandidateId",
                table: "Trainings");

            migrationBuilder.DropColumn(
                name: "CandidateId",
                table: "Competitions");

            migrationBuilder.AddColumn<string>(
                name: "MainCompetences",
                table: "Candidates",
                nullable: false,
                defaultValue: "");

            migrationBuilder.AddColumn<string>(
                name: "MainTrainings",
                table: "Candidates",
                nullable: false,
                defaultValue: "");
        }
    }
}
