using Microsoft.EntityFrameworkCore.Migrations;

#nullable disable

namespace VHS.Data.Migrations
{
    /// <inheritdoc />
    public partial class WaterSchedulesDWRUpdates : Migration
    {
        /// <inheritdoc />
        protected override void Up(MigrationBuilder migrationBuilder)
        {
            migrationBuilder.AlterColumn<decimal>(
                name: "Volume",
                table: "WaterZoneSchedules",
                type: "decimal(10,2)",
                precision: 10,
                scale: 2,
                nullable: false,
                oldClrType: typeof(int),
                oldType: "int");

            migrationBuilder.AddColumn<double>(
                name: "CalculatedDWR",
                table: "WaterZoneSchedules",
                type: "float",
                nullable: true);

            migrationBuilder.AddColumn<double>(
                name: "TargetDWR",
                table: "WaterZones",
                type: "float",
                nullable: true);

            migrationBuilder.AlterColumn<decimal>(
                name: "Intensity",
                table: "LightZoneSchedules",
                type: "decimal(5,2)",
                precision: 5,
                scale: 2,
                nullable: false,
                oldClrType: typeof(int),
                oldType: "int");
        }

        /// <inheritdoc />
        protected override void Down(MigrationBuilder migrationBuilder)
        {
            migrationBuilder.DropColumn(
                name: "CalculatedDWR",
                table: "WaterZoneSchedules");

            migrationBuilder.DropColumn(
                name: "TargetDWR",
                table: "WaterZones");

            migrationBuilder.AlterColumn<int>(
                name: "Volume",
                table: "WaterZoneSchedules",
                type: "int",
                nullable: false,
                oldClrType: typeof(decimal),
                oldType: "decimal(10,2)",
                oldPrecision: 10,
                oldScale: 2);

            migrationBuilder.AlterColumn<int>(
                name: "Intensity",
                table: "LightZoneSchedules",
                type: "int",
                nullable: false,
                oldClrType: typeof(decimal),
                oldType: "decimal(5,2)",
                oldPrecision: 5,
                oldScale: 2);
        }
    }
}
