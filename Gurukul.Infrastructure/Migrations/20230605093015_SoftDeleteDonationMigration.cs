using Microsoft.EntityFrameworkCore.Migrations;

#nullable disable

namespace Gurukul.Infrastructure.Migrations
{
    /// <inheritdoc />
    public partial class SoftDeleteDonationMigration : Migration
    {
        /// <inheritdoc />
        protected override void Up(MigrationBuilder migrationBuilder)
        {
            migrationBuilder.AddColumn<bool>(
                name: "IsDeleted",
                table: "Donations",
                type: "bit",
                nullable: false,
                defaultValue: false);
        }

        /// <inheritdoc />
        protected override void Down(MigrationBuilder migrationBuilder)
        {
            migrationBuilder.DropColumn(
                name: "IsDeleted",
                table: "Donations");
        }
    }
}
