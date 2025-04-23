using System;
using Microsoft.EntityFrameworkCore.Migrations;

#nullable disable

namespace VHS.Data.Migrations
{
    /// <inheritdoc />
    public partial class LightWaterSystemsUpdate : Migration
    {
        /// <inheritdoc />
        protected override void Up(MigrationBuilder migrationBuilder)
        {
            migrationBuilder.AddColumn<string>(
                name: "VolumeUnit",
                table: "WaterZoneSchedules",
                type: "nvarchar(20)",
                maxLength: 20,
                nullable: false,
                defaultValue: "");

            migrationBuilder.AddColumn<DateTime>(
                name: "AddedDateTime",
                table: "RecipeWaterSchedules",
                type: "datetime2",
                nullable: false,
                defaultValue: new DateTime(1, 1, 1, 0, 0, 0, 0, DateTimeKind.Unspecified));

            migrationBuilder.AddColumn<DateTime>(
                name: "DeletedDateTime",
                table: "RecipeWaterSchedules",
                type: "datetime2",
                nullable: true);

            migrationBuilder.AddColumn<DateTime>(
                name: "ModifiedDateTime",
                table: "RecipeWaterSchedules",
                type: "datetime2",
                nullable: false,
                defaultValue: new DateTime(1, 1, 1, 0, 0, 0, 0, DateTimeKind.Unspecified));

            migrationBuilder.AddColumn<DateTime>(
                name: "AddedDateTime",
                table: "RecipeLightSchedules",
                type: "datetime2",
                nullable: false,
                defaultValue: new DateTime(1, 1, 1, 0, 0, 0, 0, DateTimeKind.Unspecified));

            migrationBuilder.AddColumn<DateTime>(
                name: "DeletedDateTime",
                table: "RecipeLightSchedules",
                type: "datetime2",
                nullable: true);

            migrationBuilder.AddColumn<DateTime>(
                name: "ModifiedDateTime",
                table: "RecipeLightSchedules",
                type: "datetime2",
                nullable: false,
                defaultValue: new DateTime(1, 1, 1, 0, 0, 0, 0, DateTimeKind.Unspecified));
        }

        /// <inheritdoc />
        protected override void Down(MigrationBuilder migrationBuilder)
        {
            migrationBuilder.DropColumn(
                name: "VolumeUnit",
                table: "WaterZoneSchedules");

            migrationBuilder.DropColumn(
                name: "AddedDateTime",
                table: "RecipeWaterSchedules");

            migrationBuilder.DropColumn(
                name: "DeletedDateTime",
                table: "RecipeWaterSchedules");

            migrationBuilder.DropColumn(
                name: "ModifiedDateTime",
                table: "RecipeWaterSchedules");

            migrationBuilder.DropColumn(
                name: "AddedDateTime",
                table: "RecipeLightSchedules");

            migrationBuilder.DropColumn(
                name: "DeletedDateTime",
                table: "RecipeLightSchedules");

            migrationBuilder.DropColumn(
                name: "ModifiedDateTime",
                table: "RecipeLightSchedules");
        }
    }
}
