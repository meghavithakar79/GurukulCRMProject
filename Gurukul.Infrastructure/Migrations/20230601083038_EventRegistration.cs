using System;
using Microsoft.EntityFrameworkCore.Migrations;

#nullable disable

namespace Gurukul.Infrastructure.Migrations
{
    /// <inheritdoc />
    public partial class EventRegistration : Migration
    {
        /// <inheritdoc />
        protected override void Up(MigrationBuilder migrationBuilder)
        {
            migrationBuilder.AddColumn<int>(
                name: "EventRegistrationId",
                table: "Events",
                type: "int",
                nullable: true);

            migrationBuilder.CreateTable(
                name: "EventRegistrations",
                columns: table => new
                {
                    Id = table.Column<int>(type: "int", nullable: false)
                        .Annotation("SqlServer:Identity", "1, 1"),
                    FirstName = table.Column<string>(type: "nvarchar(max)", nullable: true),
                    LastName = table.Column<string>(type: "nvarchar(max)", nullable: true),
                    Email = table.Column<string>(type: "nvarchar(max)", nullable: true),
                    PhoneNumber = table.Column<string>(type: "nvarchar(max)", nullable: true),
                    RegistrationDate = table.Column<DateTime>(type: "datetime2", nullable: false)
                },
                constraints: table =>
                {
                    table.PrimaryKey("PK_EventRegistrations", x => x.Id);
                });

            migrationBuilder.CreateIndex(
                name: "IX_Events_EventRegistrationId",
                table: "Events",
                column: "EventRegistrationId");

            migrationBuilder.AddForeignKey(
                name: "FK_Events_EventRegistrations_EventRegistrationId",
                table: "Events",
                column: "EventRegistrationId",
                principalTable: "EventRegistrations",
                principalColumn: "Id");
        }

        /// <inheritdoc />
        protected override void Down(MigrationBuilder migrationBuilder)
        {
            migrationBuilder.DropForeignKey(
                name: "FK_Events_EventRegistrations_EventRegistrationId",
                table: "Events");

            migrationBuilder.DropTable(
                name: "EventRegistrations");

            migrationBuilder.DropIndex(
                name: "IX_Events_EventRegistrationId",
                table: "Events");

            migrationBuilder.DropColumn(
                name: "EventRegistrationId",
                table: "Events");
        }
    }
}
