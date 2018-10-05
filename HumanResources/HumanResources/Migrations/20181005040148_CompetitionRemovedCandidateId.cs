using Microsoft.EntityFrameworkCore.Migrations;
using System;

namespace HumanResources.Migrations
{
    public partial class CompetitionRemovedCandidateId : Migration
    {
        protected override void Up(MigrationBuilder migrationBuilder)
        {
            migrationBuilder.DropForeignKey(
                name: "FK_Competitions_Candidates_CandidateId",
                table: "Competitions");

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
                onDelete: ReferentialAction.Restrict);
        }

        protected override void Down(MigrationBuilder migrationBuilder)
        {
            migrationBuilder.DropForeignKey(
                name: "FK_Competitions_Candidates_CandidateId",
                table: "Competitions");

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
        }
    }
}
