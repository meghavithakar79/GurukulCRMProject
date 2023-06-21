using System;
using Microsoft.EntityFrameworkCore.Migrations;

#nullable disable

namespace Gurukul.Infrastructure.Migrations
{
    /// <inheritdoc />
    public partial class InitialSubscribeMigration : Migration
    {
        /// <inheritdoc />
        protected override void Up(MigrationBuilder migrationBuilder)
        {
            migrationBuilder.CreateTable(
                name: "ContactMagazine",
                columns: table => new
                {
                    ContactsId = table.Column<int>(type: "int", nullable: false),
                    MagazinesId = table.Column<int>(type: "int", nullable: false)
                },
                constraints: table =>
                {
                    table.PrimaryKey("PK_ContactMagazine", x => new { x.ContactsId, x.MagazinesId });
                    table.ForeignKey(
                        name: "FK_ContactMagazine_Contacts_ContactsId",
                        column: x => x.ContactsId,
                        principalTable: "Contacts",
                        principalColumn: "Id",
                        onDelete: ReferentialAction.Cascade);
                    table.ForeignKey(
                        name: "FK_ContactMagazine_Magazines_MagazinesId",
                        column: x => x.MagazinesId,
                        principalTable: "Magazines",
                        principalColumn: "Id",
                        onDelete: ReferentialAction.Cascade);
                });

            migrationBuilder.CreateTable(
                name: "Subscribes",
                columns: table => new
                {
                    Id = table.Column<int>(type: "int", nullable: false)
                        .Annotation("SqlServer:Identity", "1, 1"),
                    Plan = table.Column<string>(type: "nvarchar(max)", nullable: true),
                    StartDate = table.Column<DateTime>(type: "datetime2", nullable: false),
                    EndDate = table.Column<DateTime>(type: "datetime2", nullable: false),
                    IsPaymentConfirmed = table.Column<bool>(type: "bit", nullable: false)
                },
                constraints: table =>
                {
                    table.PrimaryKey("PK_Subscribes", x => x.Id);
                });

            migrationBuilder.CreateIndex(
                name: "IX_ContactMagazine_MagazinesId",
                table: "ContactMagazine",
                column: "MagazinesId");
        }

        /// <inheritdoc />
        protected override void Down(MigrationBuilder migrationBuilder)
        {
            migrationBuilder.DropTable(
                name: "ContactMagazine");

            migrationBuilder.DropTable(
                name: "Subscribes");
        }
    }
}
