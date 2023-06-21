using Microsoft.EntityFrameworkCore.Migrations;

#nullable disable

namespace Gurukul.Infrastructure.Migrations
{
    /// <inheritdoc />
    public partial class MagazineListSubscribeMigration : Migration
    {
        /// <inheritdoc />
        protected override void Up(MigrationBuilder migrationBuilder)
        {
            migrationBuilder.AddColumn<int>(
                name: "SubscribeId",
                table: "Magazines",
                type: "int",
                nullable: true);

            migrationBuilder.CreateIndex(
                name: "IX_Magazines_SubscribeId",
                table: "Magazines",
                column: "SubscribeId");

            migrationBuilder.AddForeignKey(
                name: "FK_Magazines_Subscribes_SubscribeId",
                table: "Magazines",
                column: "SubscribeId",
                principalTable: "Subscribes",
                principalColumn: "Id");
        }

        /// <inheritdoc />
        protected override void Down(MigrationBuilder migrationBuilder)
        {
            migrationBuilder.DropForeignKey(
                name: "FK_Magazines_Subscribes_SubscribeId",
                table: "Magazines");

            migrationBuilder.DropIndex(
                name: "IX_Magazines_SubscribeId",
                table: "Magazines");

            migrationBuilder.DropColumn(
                name: "SubscribeId",
                table: "Magazines");
        }
    }
}
