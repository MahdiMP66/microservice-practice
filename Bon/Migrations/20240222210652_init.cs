using System;
using Microsoft.EntityFrameworkCore.Migrations;

#nullable disable

#pragma warning disable CA1814 // Prefer jagged arrays over multidimensional

namespace BonAPI.Migrations
{
    /// <inheritdoc />
    public partial class init : Migration
    {
        /// <inheritdoc />
        protected override void Up(MigrationBuilder migrationBuilder)
        {
            migrationBuilder.CreateTable(
                name: "Bons",
                columns: table => new
                {
                    Id = table.Column<int>(type: "int", nullable: false)
                        .Annotation("SqlServer:Identity", "1, 1"),
                    Code = table.Column<int>(type: "int", nullable: false),
                    Off = table.Column<double>(type: "float", nullable: false),
                    Created = table.Column<DateTime>(type: "datetime2", nullable: false)
                },
                constraints: table =>
                {
                    table.PrimaryKey("PK_Bons", x => x.Id);
                });

            migrationBuilder.InsertData(
                table: "Bons",
                columns: new[] { "Id", "Code", "Created", "Off" },
                values: new object[,]
                {
                    { 1, 1001, new DateTime(2024, 2, 23, 0, 36, 49, 722, DateTimeKind.Local).AddTicks(3488), 10.0 },
                    { 2, 1002, new DateTime(2024, 2, 23, 0, 36, 49, 722, DateTimeKind.Local).AddTicks(3537), 20.0 }
                });
        }

        /// <inheritdoc />
        protected override void Down(MigrationBuilder migrationBuilder)
        {
            migrationBuilder.DropTable(
                name: "Bons");
        }
    }
}
