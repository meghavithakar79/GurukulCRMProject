using Microsoft.EntityFrameworkCore.Migrations;

#nullable disable

namespace Gurukul.Infrastructure.Migrations
{
    /// <inheritdoc />
    public partial class AttendanceMigrationEmail : Migration
    {
        /// <inheritdoc />
        protected override void Up(MigrationBuilder migrationBuilder)
        {
            migrationBuilder.AddColumn<string>(
                name: "Email",
                table: "EventAttendances",
                type: "nvarchar(max)",
                nullable: true);

            migrationBuilder.AddColumn<string>(
                name: "PhoneNumber",
                table: "EventAttendances",
                type: "nvarchar(max)",
                nullable: true);
        }

        /// <inheritdoc />
        protected override void Down(MigrationBuilder migrationBuilder)
        {
            migrationBuilder.DropColumn(
                name: "Email",
                table: "EventAttendances");

            migrationBuilder.DropColumn(
                name: "PhoneNumber",
                table: "EventAttendances");
        }
    }
}
