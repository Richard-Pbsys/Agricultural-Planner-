using Microsoft.EntityFrameworkCore.Migrations;

#nullable disable

namespace VHS.Data.Migrations
{
    /// <inheritdoc />
    public partial class LightningWateringModels : Migration
    {
        /// <inheritdoc />
        protected override void Up(MigrationBuilder migrationBuilder)
        {
            migrationBuilder.DropForeignKey(
                name: "FK_RecipeLightSchedule_LightZoneSchedules_LightZoneScheduleId",
                table: "RecipeLightSchedule");

            migrationBuilder.DropForeignKey(
                name: "FK_RecipeLightSchedule_Recipes_RecipeId",
                table: "RecipeLightSchedule");

            migrationBuilder.DropForeignKey(
                name: "FK_RecipeWaterSchedule_Recipes_RecipeId",
                table: "RecipeWaterSchedule");

            migrationBuilder.DropForeignKey(
                name: "FK_RecipeWaterSchedule_WaterZoneSchedule_WaterZoneScheduleId",
                table: "RecipeWaterSchedule");

            migrationBuilder.DropForeignKey(
                name: "FK_WaterZoneSchedule_WaterZones_WaterZoneId",
                table: "WaterZoneSchedule");

            migrationBuilder.DropPrimaryKey(
                name: "PK_WaterZoneSchedule",
                table: "WaterZoneSchedule");

            migrationBuilder.DropPrimaryKey(
                name: "PK_RecipeWaterSchedule",
                table: "RecipeWaterSchedule");

            migrationBuilder.DropPrimaryKey(
                name: "PK_RecipeLightSchedule",
                table: "RecipeLightSchedule");

            migrationBuilder.RenameTable(
                name: "WaterZoneSchedule",
                newName: "WaterZoneSchedules");

            migrationBuilder.RenameTable(
                name: "RecipeWaterSchedule",
                newName: "RecipeWaterSchedules");

            migrationBuilder.RenameTable(
                name: "RecipeLightSchedule",
                newName: "RecipeLightSchedules");

            migrationBuilder.RenameIndex(
                name: "IX_WaterZoneSchedule_WaterZoneId",
                table: "WaterZoneSchedules",
                newName: "IX_WaterZoneSchedules_WaterZoneId");

            migrationBuilder.RenameIndex(
                name: "IX_RecipeWaterSchedule_WaterZoneScheduleId",
                table: "RecipeWaterSchedules",
                newName: "IX_RecipeWaterSchedules_WaterZoneScheduleId");

            migrationBuilder.RenameIndex(
                name: "IX_RecipeWaterSchedule_RecipeId",
                table: "RecipeWaterSchedules",
                newName: "IX_RecipeWaterSchedules_RecipeId");

            migrationBuilder.RenameIndex(
                name: "IX_RecipeLightSchedule_RecipeId",
                table: "RecipeLightSchedules",
                newName: "IX_RecipeLightSchedules_RecipeId");

            migrationBuilder.RenameIndex(
                name: "IX_RecipeLightSchedule_LightZoneScheduleId",
                table: "RecipeLightSchedules",
                newName: "IX_RecipeLightSchedules_LightZoneScheduleId");

            migrationBuilder.AddPrimaryKey(
                name: "PK_WaterZoneSchedules",
                table: "WaterZoneSchedules",
                column: "Id");

            migrationBuilder.AddPrimaryKey(
                name: "PK_RecipeWaterSchedules",
                table: "RecipeWaterSchedules",
                column: "Id");

            migrationBuilder.AddPrimaryKey(
                name: "PK_RecipeLightSchedules",
                table: "RecipeLightSchedules",
                column: "Id");

            migrationBuilder.AddForeignKey(
                name: "FK_RecipeLightSchedules_LightZoneSchedules_LightZoneScheduleId",
                table: "RecipeLightSchedules",
                column: "LightZoneScheduleId",
                principalTable: "LightZoneSchedules",
                principalColumn: "Id");

            migrationBuilder.AddForeignKey(
                name: "FK_RecipeLightSchedules_Recipes_RecipeId",
                table: "RecipeLightSchedules",
                column: "RecipeId",
                principalTable: "Recipes",
                principalColumn: "Id",
                onDelete: ReferentialAction.Cascade);

            migrationBuilder.AddForeignKey(
                name: "FK_RecipeWaterSchedules_Recipes_RecipeId",
                table: "RecipeWaterSchedules",
                column: "RecipeId",
                principalTable: "Recipes",
                principalColumn: "Id",
                onDelete: ReferentialAction.Cascade);

            migrationBuilder.AddForeignKey(
                name: "FK_RecipeWaterSchedules_WaterZoneSchedules_WaterZoneScheduleId",
                table: "RecipeWaterSchedules",
                column: "WaterZoneScheduleId",
                principalTable: "WaterZoneSchedules",
                principalColumn: "Id");

            migrationBuilder.AddForeignKey(
                name: "FK_WaterZoneSchedules_WaterZones_WaterZoneId",
                table: "WaterZoneSchedules",
                column: "WaterZoneId",
                principalTable: "WaterZones",
                principalColumn: "Id");
        }

        /// <inheritdoc />
        protected override void Down(MigrationBuilder migrationBuilder)
        {
            migrationBuilder.DropForeignKey(
                name: "FK_RecipeLightSchedules_LightZoneSchedules_LightZoneScheduleId",
                table: "RecipeLightSchedules");

            migrationBuilder.DropForeignKey(
                name: "FK_RecipeLightSchedules_Recipes_RecipeId",
                table: "RecipeLightSchedules");

            migrationBuilder.DropForeignKey(
                name: "FK_RecipeWaterSchedules_Recipes_RecipeId",
                table: "RecipeWaterSchedules");

            migrationBuilder.DropForeignKey(
                name: "FK_RecipeWaterSchedules_WaterZoneSchedules_WaterZoneScheduleId",
                table: "RecipeWaterSchedules");

            migrationBuilder.DropForeignKey(
                name: "FK_WaterZoneSchedules_WaterZones_WaterZoneId",
                table: "WaterZoneSchedules");

            migrationBuilder.DropPrimaryKey(
                name: "PK_WaterZoneSchedules",
                table: "WaterZoneSchedules");

            migrationBuilder.DropPrimaryKey(
                name: "PK_RecipeWaterSchedules",
                table: "RecipeWaterSchedules");

            migrationBuilder.DropPrimaryKey(
                name: "PK_RecipeLightSchedules",
                table: "RecipeLightSchedules");

            migrationBuilder.RenameTable(
                name: "WaterZoneSchedules",
                newName: "WaterZoneSchedule");

            migrationBuilder.RenameTable(
                name: "RecipeWaterSchedules",
                newName: "RecipeWaterSchedule");

            migrationBuilder.RenameTable(
                name: "RecipeLightSchedules",
                newName: "RecipeLightSchedule");

            migrationBuilder.RenameIndex(
                name: "IX_WaterZoneSchedules_WaterZoneId",
                table: "WaterZoneSchedule",
                newName: "IX_WaterZoneSchedule_WaterZoneId");

            migrationBuilder.RenameIndex(
                name: "IX_RecipeWaterSchedules_WaterZoneScheduleId",
                table: "RecipeWaterSchedule",
                newName: "IX_RecipeWaterSchedule_WaterZoneScheduleId");

            migrationBuilder.RenameIndex(
                name: "IX_RecipeWaterSchedules_RecipeId",
                table: "RecipeWaterSchedule",
                newName: "IX_RecipeWaterSchedule_RecipeId");

            migrationBuilder.RenameIndex(
                name: "IX_RecipeLightSchedules_RecipeId",
                table: "RecipeLightSchedule",
                newName: "IX_RecipeLightSchedule_RecipeId");

            migrationBuilder.RenameIndex(
                name: "IX_RecipeLightSchedules_LightZoneScheduleId",
                table: "RecipeLightSchedule",
                newName: "IX_RecipeLightSchedule_LightZoneScheduleId");

            migrationBuilder.AddPrimaryKey(
                name: "PK_WaterZoneSchedule",
                table: "WaterZoneSchedule",
                column: "Id");

            migrationBuilder.AddPrimaryKey(
                name: "PK_RecipeWaterSchedule",
                table: "RecipeWaterSchedule",
                column: "Id");

            migrationBuilder.AddPrimaryKey(
                name: "PK_RecipeLightSchedule",
                table: "RecipeLightSchedule",
                column: "Id");

            migrationBuilder.AddForeignKey(
                name: "FK_RecipeLightSchedule_LightZoneSchedules_LightZoneScheduleId",
                table: "RecipeLightSchedule",
                column: "LightZoneScheduleId",
                principalTable: "LightZoneSchedules",
                principalColumn: "Id",
                onDelete: ReferentialAction.Cascade);

            migrationBuilder.AddForeignKey(
                name: "FK_RecipeLightSchedule_Recipes_RecipeId",
                table: "RecipeLightSchedule",
                column: "RecipeId",
                principalTable: "Recipes",
                principalColumn: "Id",
                onDelete: ReferentialAction.Cascade);

            migrationBuilder.AddForeignKey(
                name: "FK_RecipeWaterSchedule_Recipes_RecipeId",
                table: "RecipeWaterSchedule",
                column: "RecipeId",
                principalTable: "Recipes",
                principalColumn: "Id",
                onDelete: ReferentialAction.Cascade);

            migrationBuilder.AddForeignKey(
                name: "FK_RecipeWaterSchedule_WaterZoneSchedule_WaterZoneScheduleId",
                table: "RecipeWaterSchedule",
                column: "WaterZoneScheduleId",
                principalTable: "WaterZoneSchedule",
                principalColumn: "Id",
                onDelete: ReferentialAction.Cascade);

            migrationBuilder.AddForeignKey(
                name: "FK_WaterZoneSchedule_WaterZones_WaterZoneId",
                table: "WaterZoneSchedule",
                column: "WaterZoneId",
                principalTable: "WaterZones",
                principalColumn: "Id",
                onDelete: ReferentialAction.Cascade);
        }
    }
}
