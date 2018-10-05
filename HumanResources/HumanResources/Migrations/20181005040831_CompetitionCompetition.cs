using System;
using Microsoft.EntityFrameworkCore.Migrations;

namespace HumanResources.Migrations
{
    public partial class CompetitionCompetition : Migration
    {
        protected override void Up(MigrationBuilder migrationBuilder)
        {
            migrationBuilder.DropForeignKey(
                name: "FK_Competitions_Candidates_CandidateId",
                table: "Competitions");

            migrationBuilder.DropIndex(
                name: "IX_Competitions_CandidateId",
                table: "Competitions");

            migrationBuilder.DropColumn(
                name: "CandidateId",
                table: "Competitions");

            migrationBuilder.CreateTable(
                name: "CandidateCompetition",
                columns: table => new
                {
                    Id = table.Column<Guid>(nullable: false),
                    CandidateId = table.Column<Guid>(nullable: false),
                    CompetitionId = table.Column<Guid>(nullable: false)
                },
                constraints: table =>
                {
                    table.PrimaryKey("PK_CandidateCompetition", x => x.Id);
                    table.ForeignKey(
                        name: "FK_CandidateCompetition_Candidates_CandidateId",
                        column: x => x.CandidateId,
                        principalTable: "Candidates",
                        principalColumn: "Id",
                        onDelete: ReferentialAction.NoAction);
                    table.ForeignKey(
                        name: "FK_CandidateCompetition_Competitions_CompetitionId",
                        column: x => x.CompetitionId,
                        principalTable: "Competitions",
                        principalColumn: "Id",
                        onDelete: ReferentialAction.NoAction);
                });

            migrationBuilder.CreateIndex(
                name: "IX_CandidateCompetition_CandidateId",
                table: "CandidateCompetition",
                column: "CandidateId");

            migrationBuilder.CreateIndex(
                name: "IX_CandidateCompetition_CompetitionId",
                table: "CandidateCompetition",
                column: "CompetitionId");
        }

        protected override void Down(MigrationBuilder migrationBuilder)
        {
            migrationBuilder.DropTable(
                name: "CandidateCompetition");

            migrationBuilder.AddColumn<Guid>(
                name: "CandidateId",
                table: "Competitions",
                nullable: true);

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
                onDelete: ReferentialAction.Restrict);
        }
    }
}
