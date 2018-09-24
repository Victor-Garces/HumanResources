using Microsoft.EntityFrameworkCore.Migrations;
using System;

namespace HumanResources.Migrations
{
    public partial class CandidateFieldsCompetitionsAndTrainingsNullableFalse : Migration
    {
        protected override void Up(MigrationBuilder migrationBuilder)
        {
            migrationBuilder.DropForeignKey(
                name: "FK_Competitions_Candidates_CandidateId",
                table: "Competitions");

            migrationBuilder.DropForeignKey(
                name: "FK_Trainings_Candidates_CandidateId",
                table: "Trainings");

            migrationBuilder.AlterColumn<Guid>(
                name: "CandidateId",
                table: "Trainings",
                nullable: false,
                oldClrType: typeof(Guid),
                oldNullable: true);

            migrationBuilder.AlterColumn<Guid>(
                name: "CandidateId",
                table: "Competitions",
                nullable: false,
                oldClrType: typeof(Guid),
                oldNullable: true);

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

            migrationBuilder.AlterColumn<Guid>(
                name: "CandidateId",
                table: "Trainings",
                nullable: true,
                oldClrType: typeof(Guid));

            migrationBuilder.AlterColumn<Guid>(
                name: "CandidateId",
                table: "Competitions",
                nullable: true,
                oldClrType: typeof(Guid));

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
    }
}
