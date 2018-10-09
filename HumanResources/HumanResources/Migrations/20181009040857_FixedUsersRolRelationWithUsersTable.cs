using System;
using Microsoft.EntityFrameworkCore.Migrations;

namespace HumanResources.Migrations
{
    public partial class FixedUsersRolRelationWithUsersTable : Migration
    {
        protected override void Up(MigrationBuilder migrationBuilder)
        {
            migrationBuilder.DropIndex(
                name: "IX_UsersRol_RolId",
                table: "UsersRol");

            migrationBuilder.DropIndex(
                name: "IX_UsersRol_UserId",
                table: "UsersRol");

            migrationBuilder.DropColumn(
                name: "UsersRolId",
                table: "Users");

            migrationBuilder.DropColumn(
                name: "UsersRolId",
                table: "Rol");

            migrationBuilder.CreateIndex(
                name: "IX_UsersRol_RolId",
                table: "UsersRol",
                column: "RolId");
        }

        protected override void Down(MigrationBuilder migrationBuilder)
        {
            migrationBuilder.DropIndex(
                name: "IX_UsersRol_RolId",
                table: "UsersRol");

            migrationBuilder.AddColumn<Guid>(
                name: "UsersRolId",
                table: "Users",
                nullable: false,
                defaultValue: new Guid("00000000-0000-0000-0000-000000000000"));

            migrationBuilder.AddColumn<Guid>(
                name: "UsersRolId",
                table: "Rol",
                nullable: false,
                defaultValue: new Guid("00000000-0000-0000-0000-000000000000"));

            migrationBuilder.CreateIndex(
                name: "IX_UsersRol_RolId",
                table: "UsersRol",
                column: "RolId",
                unique: true);

            migrationBuilder.CreateIndex(
                name: "IX_UsersRol_UserId",
                table: "UsersRol",
                column: "UserId",
                unique: true);
        }
    }
}
