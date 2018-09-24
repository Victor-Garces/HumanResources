using System;
using Microsoft.EntityFrameworkCore.Migrations;

namespace HumanResources.Migrations
{
    public partial class EmployeeTable : Migration
    {
        protected override void Up(MigrationBuilder migrationBuilder)
        {
            migrationBuilder.CreateTable(
                name: "Employees",
                columns: table => new
                {
                    Id = table.Column<Guid>(nullable: false, defaultValueSql: "newsequentialid()"),
                    Identification = table.Column<string>(nullable: false),
                    Name = table.Column<string>(nullable: true),
                    AdmissionDate = table.Column<DateTime>(nullable: false, defaultValueSql: "GetDate()"),
                    Department = table.Column<string>(nullable: false),
                    PositionId = table.Column<Guid>(nullable: false),
                    MonthlySalary = table.Column<double>(nullable: false),
                    IsActive = table.Column<bool>(nullable: false)
                },
                constraints: table =>
                {
                    table.PrimaryKey("PK_Employees", x => x.Id);
                    table.ForeignKey(
                        name: "FK_Employees_Positions_PositionId",
                        column: x => x.PositionId,
                        principalTable: "Positions",
                        principalColumn: "Id",
                        onDelete: ReferentialAction.NoAction);
                });

            migrationBuilder.CreateIndex(
                name: "IX_Employees_PositionId",
                table: "Employees",
                column: "PositionId");
        }

        protected override void Down(MigrationBuilder migrationBuilder)
        {
            migrationBuilder.DropTable(
                name: "Employees");
        }
    }
}
