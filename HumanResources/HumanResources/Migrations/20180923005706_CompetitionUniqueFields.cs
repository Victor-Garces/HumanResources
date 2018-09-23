using Microsoft.EntityFrameworkCore.Migrations;

namespace HumanResources.Migrations
{
    public partial class CompetitionUniqueFields : Migration
    {
        protected override void Up(MigrationBuilder migrationBuilder)
        {
            migrationBuilder.AlterColumn<string>(
                name: "Description",
                table: "Competitions",
                nullable: false,
                oldClrType: typeof(string));

            migrationBuilder.CreateIndex(
                name: "IX_Competitions_Description_Status",
                table: "Competitions",
                columns: new[] { "Description", "Status" },
                unique: true);
        }

        protected override void Down(MigrationBuilder migrationBuilder)
        {
            migrationBuilder.DropIndex(
                name: "IX_Competitions_Description_Status",
                table: "Competitions");

            migrationBuilder.AlterColumn<string>(
                name: "Description",
                table: "Competitions",
                nullable: false,
                oldClrType: typeof(string));
        }
    }
}
