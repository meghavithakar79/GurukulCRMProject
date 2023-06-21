using Microsoft.EntityFrameworkCore.Migrations;

#nullable disable

namespace Gurukul.Infrastructure.Migrations
{
    /// <inheritdoc />
    public partial class AttendanceMigration : Migration
    {
        /// <inheritdoc />
        protected override void Up(MigrationBuilder migrationBuilder)
        {
            migrationBuilder.AddColumn<int>(
                name: "EventAttendanceId",
                table: "EventRegistrations",
                type: "int",
                nullable: true);

            migrationBuilder.CreateTable(
                name: "EventAttendances",
                columns: table => new
                {
                    Id = table.Column<int>(type: "int", nullable: false)
                        .Annotation("SqlServer:Identity", "1, 1"),
                    FirstName = table.Column<string>(type: "nvarchar(max)", nullable: true),
                    LastName = table.Column<string>(type: "nvarchar(max)", nullable: true),
                    EventId = table.Column<string>(type: "nvarchar(max)", nullable: true),
                    EventTitle = table.Column<string>(type: "nvarchar(max)", nullable: true),
                    EventStartDate = table.Column<string>(type: "nvarchar(max)", nullable: true),
                    EventEndDate = table.Column<string>(type: "nvarchar(max)", nullable: true)
                },
                constraints: table =>
                {
                    table.PrimaryKey("PK_EventAttendances", x => x.Id);
                });

            migrationBuilder.CreateIndex(
                name: "IX_EventRegistrations_EventAttendanceId",
                table: "EventRegistrations",
                column: "EventAttendanceId");

            migrationBuilder.AddForeignKey(
                name: "FK_EventRegistrations_EventAttendances_EventAttendanceId",
                table: "EventRegistrations",
                column: "EventAttendanceId",
                principalTable: "EventAttendances",
                principalColumn: "Id");
        }

        /// <inheritdoc />
        protected override void Down(MigrationBuilder migrationBuilder)
        {
            migrationBuilder.DropForeignKey(
                name: "FK_EventRegistrations_EventAttendances_EventAttendanceId",
                table: "EventRegistrations");

            migrationBuilder.DropTable(
                name: "EventAttendances");

            migrationBuilder.DropIndex(
                name: "IX_EventRegistrations_EventAttendanceId",
                table: "EventRegistrations");

            migrationBuilder.DropColumn(
                name: "EventAttendanceId",
                table: "EventRegistrations");
        }
    }
}
