using Microsoft.EntityFrameworkCore.Migrations;

#nullable disable

namespace VHS.Data.Migrations
{
    /// <inheritdoc />
    public partial class removecolumnes_addenabled : Migration
    {
        /// <inheritdoc />
        protected override void Up(MigrationBuilder migrationBuilder)
        {
            migrationBuilder.DropColumn(
                name: "GerminationDays",
                table: "BatchConfigurations");

            migrationBuilder.DropColumn(
                name: "GrowDays",
                table: "BatchConfigurations");

            migrationBuilder.DropColumn(
                name: "PropagationDays",
                table: "BatchConfigurations");

            migrationBuilder.AddColumn<bool>(
                name: "Enabled",
                table: "Racks",
                type: "bit",
                nullable: false,
                defaultValue: false);

            migrationBuilder.AddColumn<bool>(
                name: "Enabled",
                table: "Layers",
                type: "bit",
                nullable: false,
                defaultValue: false);

            migrationBuilder.AddColumn<bool>(
                name: "Enabled",
                table: "Floors",
                type: "bit",
                nullable: false,
                defaultValue: false);
        }

        /// <inheritdoc />
        protected override void Down(MigrationBuilder migrationBuilder)
        {
            migrationBuilder.DropColumn(
                name: "Enabled",
                table: "Racks");

            migrationBuilder.DropColumn(
                name: "Enabled",
                table: "Layers");

            migrationBuilder.DropColumn(
                name: "Enabled",
                table: "Floors");

            migrationBuilder.AddColumn<int>(
                name: "GerminationDays",
                table: "BatchConfigurations",
                type: "int",
                nullable: false,
                defaultValue: 0);

            migrationBuilder.AddColumn<int>(
                name: "GrowDays",
                table: "BatchConfigurations",
                type: "int",
                nullable: false,
                defaultValue: 0);

            migrationBuilder.AddColumn<int>(
                name: "PropagationDays",
                table: "BatchConfigurations",
                type: "int",
                nullable: false,
                defaultValue: 0);
        }
    }
}
