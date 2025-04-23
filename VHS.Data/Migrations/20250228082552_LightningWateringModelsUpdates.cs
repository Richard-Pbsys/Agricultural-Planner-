using System;
using Microsoft.EntityFrameworkCore.Migrations;

#nullable disable

namespace VHS.Data.Migrations
{
    /// <inheritdoc />
    public partial class LightningWateringModelsUpdates : Migration
    {
        /// <inheritdoc />
        protected override void Up(MigrationBuilder migrationBuilder)
        {
            migrationBuilder.RenameColumn(
                name: "Value",
                table: "LightZoneSchedules",
                newName: "Intensity");

            migrationBuilder.AddColumn<double>(
                name: "CalculatedDLI",
                table: "LightZoneSchedules",
                type: "float",
                nullable: true);

            migrationBuilder.AddColumn<double>(
                name: "TargetDLI",
                table: "LightZones",
                type: "float",
                nullable: true);

            migrationBuilder.CreateTable(
                name: "RecipeLightSchedule",
                columns: table => new
                {
                    Id = table.Column<Guid>(type: "uniqueidentifier", nullable: false),
                    RecipeId = table.Column<Guid>(type: "uniqueidentifier", nullable: false),
                    LightZoneScheduleId = table.Column<Guid>(type: "uniqueidentifier", nullable: false),
                    TargetDLI = table.Column<double>(type: "float", nullable: true)
                },
                constraints: table =>
                {
                    table.PrimaryKey("PK_RecipeLightSchedule", x => x.Id);
                    table.ForeignKey(
                        name: "FK_RecipeLightSchedule_LightZoneSchedules_LightZoneScheduleId",
                        column: x => x.LightZoneScheduleId,
                        principalTable: "LightZoneSchedules",
                        principalColumn: "Id",
                        onDelete: ReferentialAction.Cascade);
                    table.ForeignKey(
                        name: "FK_RecipeLightSchedule_Recipes_RecipeId",
                        column: x => x.RecipeId,
                        principalTable: "Recipes",
                        principalColumn: "Id",
                        onDelete: ReferentialAction.Cascade);
                });

            migrationBuilder.CreateTable(
                name: "WaterZoneSchedule",
                columns: table => new
                {
                    Id = table.Column<Guid>(type: "uniqueidentifier", nullable: false),
                    WaterZoneId = table.Column<Guid>(type: "uniqueidentifier", nullable: false),
                    StartTime = table.Column<TimeOnly>(type: "time", nullable: false),
                    EndTime = table.Column<TimeOnly>(type: "time", nullable: false),
                    Volume = table.Column<int>(type: "int", nullable: false),
                    AddedDateTime = table.Column<DateTime>(type: "datetime2", nullable: false),
                    ModifiedDateTime = table.Column<DateTime>(type: "datetime2", nullable: false),
                    DeletedDateTime = table.Column<DateTime>(type: "datetime2", nullable: true)
                },
                constraints: table =>
                {
                    table.PrimaryKey("PK_WaterZoneSchedule", x => x.Id);
                    table.ForeignKey(
                        name: "FK_WaterZoneSchedule_WaterZones_WaterZoneId",
                        column: x => x.WaterZoneId,
                        principalTable: "WaterZones",
                        principalColumn: "Id",
                        onDelete: ReferentialAction.Cascade);
                });

            migrationBuilder.CreateTable(
                name: "RecipeWaterSchedule",
                columns: table => new
                {
                    Id = table.Column<Guid>(type: "uniqueidentifier", nullable: false),
                    RecipeId = table.Column<Guid>(type: "uniqueidentifier", nullable: false),
                    WaterZoneScheduleId = table.Column<Guid>(type: "uniqueidentifier", nullable: false)
                },
                constraints: table =>
                {
                    table.PrimaryKey("PK_RecipeWaterSchedule", x => x.Id);
                    table.ForeignKey(
                        name: "FK_RecipeWaterSchedule_Recipes_RecipeId",
                        column: x => x.RecipeId,
                        principalTable: "Recipes",
                        principalColumn: "Id",
                        onDelete: ReferentialAction.Cascade);
                    table.ForeignKey(
                        name: "FK_RecipeWaterSchedule_WaterZoneSchedule_WaterZoneScheduleId",
                        column: x => x.WaterZoneScheduleId,
                        principalTable: "WaterZoneSchedule",
                        principalColumn: "Id",
                        onDelete: ReferentialAction.Cascade);
                });

            migrationBuilder.CreateIndex(
                name: "IX_RecipeLightSchedule_LightZoneScheduleId",
                table: "RecipeLightSchedule",
                column: "LightZoneScheduleId");

            migrationBuilder.CreateIndex(
                name: "IX_RecipeLightSchedule_RecipeId",
                table: "RecipeLightSchedule",
                column: "RecipeId");

            migrationBuilder.CreateIndex(
                name: "IX_RecipeWaterSchedule_RecipeId",
                table: "RecipeWaterSchedule",
                column: "RecipeId");

            migrationBuilder.CreateIndex(
                name: "IX_RecipeWaterSchedule_WaterZoneScheduleId",
                table: "RecipeWaterSchedule",
                column: "WaterZoneScheduleId");

            migrationBuilder.CreateIndex(
                name: "IX_WaterZoneSchedule_WaterZoneId",
                table: "WaterZoneSchedule",
                column: "WaterZoneId");
        }

        /// <inheritdoc />
        protected override void Down(MigrationBuilder migrationBuilder)
        {
            migrationBuilder.DropTable(
                name: "RecipeLightSchedule");

            migrationBuilder.DropTable(
                name: "RecipeWaterSchedule");

            migrationBuilder.DropTable(
                name: "WaterZoneSchedule");

            migrationBuilder.DropColumn(
                name: "CalculatedDLI",
                table: "LightZoneSchedules");

            migrationBuilder.DropColumn(
                name: "TargetDLI",
                table: "LightZones");

            migrationBuilder.RenameColumn(
                name: "Intensity",
                table: "LightZoneSchedules",
                newName: "Value");
        }
    }
}
