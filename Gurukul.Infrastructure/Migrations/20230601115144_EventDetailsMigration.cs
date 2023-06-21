using Microsoft.EntityFrameworkCore.Migrations;

#nullable disable

namespace Gurukul.Infrastructure.Migrations
{
    /// <inheritdoc />
    public partial class EventDetailsMigration : Migration
    {
        /// <inheritdoc />
        protected override void Up(MigrationBuilder migrationBuilder)
        {
            migrationBuilder.AddColumn<string>(
                name: "EventDescription",
                table: "EventRegistrations",
                type: "nvarchar(max)",
                nullable: true);

            migrationBuilder.AddColumn<string>(
                name: "EventEndDate",
                table: "EventRegistrations",
                type: "nvarchar(max)",
                nullable: true);

            migrationBuilder.AddColumn<string>(
                name: "EventId",
                table: "EventRegistrations",
                type: "nvarchar(max)",
                nullable: true);

            migrationBuilder.AddColumn<string>(
                name: "EventStartDate",
                table: "EventRegistrations",
                type: "nvarchar(max)",
                nullable: true);

            migrationBuilder.AddColumn<string>(
                name: "EventTitle",
                table: "EventRegistrations",
                type: "nvarchar(max)",
                nullable: true);

            migrationBuilder.AddColumn<string>(
                name: "EventType",
                table: "EventRegistrations",
                type: "nvarchar(max)",
                nullable: true);

            migrationBuilder.AddColumn<string>(
                name: "EventVenue",
                table: "EventRegistrations",
                type: "nvarchar(max)",
                nullable: true);
        }

        /// <inheritdoc />
        protected override void Down(MigrationBuilder migrationBuilder)
        {
            migrationBuilder.DropColumn(
                name: "EventDescription",
                table: "EventRegistrations");

            migrationBuilder.DropColumn(
                name: "EventEndDate",
                table: "EventRegistrations");

            migrationBuilder.DropColumn(
                name: "EventId",
                table: "EventRegistrations");

            migrationBuilder.DropColumn(
                name: "EventStartDate",
                table: "EventRegistrations");

            migrationBuilder.DropColumn(
                name: "EventTitle",
                table: "EventRegistrations");

            migrationBuilder.DropColumn(
                name: "EventType",
                table: "EventRegistrations");

            migrationBuilder.DropColumn(
                name: "EventVenue",
                table: "EventRegistrations");
        }
    }
}
