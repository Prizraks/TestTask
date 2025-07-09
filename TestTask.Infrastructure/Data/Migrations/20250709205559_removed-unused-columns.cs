using Microsoft.EntityFrameworkCore.Migrations;

#nullable disable

namespace TestTask.Infrastructure.Data.Application.Migrations
{
    /// <inheritdoc />
    public partial class removedunusedcolumns : Migration
    {
        /// <inheritdoc />
        protected override void Up(MigrationBuilder migrationBuilder)
        {
            migrationBuilder.DropColumn(
                name: "Fall",
                table: "Meteorites");

            migrationBuilder.DropColumn(
                name: "Latitude",
                table: "Meteorites");

            migrationBuilder.DropColumn(
                name: "Longitude",
                table: "Meteorites");

            migrationBuilder.DropColumn(
                name: "NameType",
                table: "Meteorites");
        }

        /// <inheritdoc />
        protected override void Down(MigrationBuilder migrationBuilder)
        {
            migrationBuilder.AddColumn<bool>(
                name: "Fall",
                table: "Meteorites",
                type: "INTEGER",
                nullable: false,
                defaultValue: false);

            migrationBuilder.AddColumn<double>(
                name: "Latitude",
                table: "Meteorites",
                type: "REAL",
                nullable: false,
                defaultValue: 0.0);

            migrationBuilder.AddColumn<double>(
                name: "Longitude",
                table: "Meteorites",
                type: "REAL",
                nullable: false,
                defaultValue: 0.0);

            migrationBuilder.AddColumn<int>(
                name: "NameType",
                table: "Meteorites",
                type: "INTEGER",
                nullable: false,
                defaultValue: 0);
        }
    }
}
