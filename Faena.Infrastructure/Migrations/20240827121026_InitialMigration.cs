using System;
using Microsoft.EntityFrameworkCore.Migrations;

#nullable disable

namespace Faena.Infrastructure.Migrations
{
    /// <inheritdoc />
    public partial class InitialMigration : Migration
    {
        /// <inheritdoc />
        protected override void Up(MigrationBuilder migrationBuilder)
        {
            migrationBuilder.CreateTable(
                name: "Flights",
                columns: table => new
                {
                    id = table.Column<Guid>(type: "uuid", nullable: false),
                    departurelocation = table.Column<string>(type: "text", nullable: false),
                    arrivallocation = table.Column<string>(type: "text", nullable: false),
                    departuredatetime = table.Column<string>(type: "text", nullable: false),
                    arrivaldatetime = table.Column<string>(type: "text", nullable: false)
                },
                constraints: table =>
                {
                    table.PrimaryKey("PK_Flights", x => x.id);
                });
        }

        /// <inheritdoc />
        protected override void Down(MigrationBuilder migrationBuilder)
        {
            migrationBuilder.DropTable(
                name: "Flights");
        }
    }
}
