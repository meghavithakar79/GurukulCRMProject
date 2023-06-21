using Microsoft.EntityFrameworkCore.Migrations;

#nullable disable

namespace Gurukul.Infrastructure.Migrations
{
    /// <inheritdoc />
    public partial class RoleIdUserIdStoringDb : Migration
    {
        /// <inheritdoc />
        protected override void Up(MigrationBuilder migrationBuilder)
        {
            migrationBuilder.DropForeignKey(
                name: "FK_AspNetRoles_RoleViewModels_AddRoleViewModelId",
                table: "AspNetRoles");

            migrationBuilder.DropIndex(
                name: "IX_AspNetRoles_AddRoleViewModelId",
                table: "AspNetRoles");

            migrationBuilder.DropColumn(
                name: "AddRoleViewModelId",
                table: "AspNetRoles");

            migrationBuilder.AddColumn<string>(
                name: "RoleId",
                table: "RoleViewModels",
                type: "nvarchar(max)",
                nullable: true);

            migrationBuilder.AddColumn<string>(
                name: "SelectedUser",
                table: "RoleViewModels",
                type: "nvarchar(max)",
                nullable: true);

            migrationBuilder.AddColumn<string>(
                name: "UserId",
                table: "RoleViewModels",
                type: "nvarchar(max)",
                nullable: true);
        }

        /// <inheritdoc />
        protected override void Down(MigrationBuilder migrationBuilder)
        {
            migrationBuilder.DropColumn(
                name: "RoleId",
                table: "RoleViewModels");

            migrationBuilder.DropColumn(
                name: "SelectedUser",
                table: "RoleViewModels");

            migrationBuilder.DropColumn(
                name: "UserId",
                table: "RoleViewModels");

            migrationBuilder.AddColumn<int>(
                name: "AddRoleViewModelId",
                table: "AspNetRoles",
                type: "int",
                nullable: true);

            migrationBuilder.UpdateData(
                table: "AspNetRoles",
                keyColumn: "Id",
                keyValue: 1,
                column: "AddRoleViewModelId",
                value: null);

            migrationBuilder.UpdateData(
                table: "AspNetRoles",
                keyColumn: "Id",
                keyValue: 2,
                column: "AddRoleViewModelId",
                value: null);

            migrationBuilder.CreateIndex(
                name: "IX_AspNetRoles_AddRoleViewModelId",
                table: "AspNetRoles",
                column: "AddRoleViewModelId");

            migrationBuilder.AddForeignKey(
                name: "FK_AspNetRoles_RoleViewModels_AddRoleViewModelId",
                table: "AspNetRoles",
                column: "AddRoleViewModelId",
                principalTable: "RoleViewModels",
                principalColumn: "Id");
        }
    }
}
