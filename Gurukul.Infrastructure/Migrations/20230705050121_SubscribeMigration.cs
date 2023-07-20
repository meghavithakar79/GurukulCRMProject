using Microsoft.EntityFrameworkCore.Migrations;

#nullable disable

namespace Gurukul.Infrastructure.Migrations
{
    /// <inheritdoc />
    public partial class SubscribeMigration : Migration
    {
        /// <inheritdoc />
        protected override void Up(MigrationBuilder migrationBuilder)
        {
            migrationBuilder.AddColumn<string>(
                name: "Email",
                table: "Subscribes",
                type: "nvarchar(max)",
                nullable: true);

            migrationBuilder.AddColumn<string>(
                name: "FirstName",
                table: "Subscribes",
                type: "nvarchar(max)",
                nullable: true);

            migrationBuilder.AddColumn<string>(
                name: "LastName",
                table: "Subscribes",
                type: "nvarchar(max)",
                nullable: true);

            migrationBuilder.AddColumn<string>(
                name: "PhoneNumber",
                table: "Subscribes",
                type: "nvarchar(max)",
                nullable: true);
        }

        /// <inheritdoc />
        protected override void Down(MigrationBuilder migrationBuilder)
        {
            migrationBuilder.DropColumn(
                name: "Email",
                table: "Subscribes");

            migrationBuilder.DropColumn(
                name: "FirstName",
                table: "Subscribes");

            migrationBuilder.DropColumn(
                name: "LastName",
                table: "Subscribes");

            migrationBuilder.DropColumn(
                name: "PhoneNumber",
                table: "Subscribes");
        }
    }
}
