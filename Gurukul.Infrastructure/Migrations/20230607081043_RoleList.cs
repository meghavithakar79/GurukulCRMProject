using Microsoft.EntityFrameworkCore.Migrations;

#nullable disable

namespace Gurukul.Infrastructure.Migrations
{
    /// <inheritdoc />
    public partial class RoleList : Migration
    {
        /// <inheritdoc />
        protected override void Up(MigrationBuilder migrationBuilder)
        {
            migrationBuilder.AddColumn<int>(
                name: "AddRoleViewModelId",
                table: "AspNetRoles",
                type: "int",
                nullable: true);

            migrationBuilder.CreateTable(
                name: "RoleViewModels",
                columns: table => new
                {
                    Id = table.Column<int>(type: "int", nullable: false)
                        .Annotation("SqlServer:Identity", "1, 1"),
                    SelectedRole = table.Column<string>(type: "nvarchar(max)", nullable: true)
                },
                constraints: table =>
                {
                    table.PrimaryKey("PK_RoleViewModels", x => x.Id);
                });

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

        /// <inheritdoc />
        protected override void Down(MigrationBuilder migrationBuilder)
        {
            migrationBuilder.DropForeignKey(
                name: "FK_AspNetRoles_RoleViewModels_AddRoleViewModelId",
                table: "AspNetRoles");

            migrationBuilder.DropTable(
                name: "RoleViewModels");

            migrationBuilder.DropIndex(
                name: "IX_AspNetRoles_AddRoleViewModelId",
                table: "AspNetRoles");

            migrationBuilder.DropColumn(
                name: "AddRoleViewModelId",
                table: "AspNetRoles");
        }
    }
}
