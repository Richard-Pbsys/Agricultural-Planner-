using Microsoft.EntityFrameworkCore.Migrations;

#nullable disable

namespace VHS.Data.Migrations
{
    /// <inheritdoc />
    public partial class LightningWateringModelsOnDelete : Migration
    {
        /// <inheritdoc />
        protected override void Up(MigrationBuilder migrationBuilder)
        {
            migrationBuilder.DropForeignKey(
                name: "FK_RecipeLightSchedules_Recipes_RecipeId",
                table: "RecipeLightSchedules");

            migrationBuilder.DropForeignKey(
                name: "FK_RecipeWaterSchedules_Recipes_RecipeId",
                table: "RecipeWaterSchedules");

            migrationBuilder.AddForeignKey(
                name: "FK_RecipeLightSchedules_Recipes_RecipeId",
                table: "RecipeLightSchedules",
                column: "RecipeId",
                principalTable: "Recipes",
                principalColumn: "Id");

            migrationBuilder.AddForeignKey(
                name: "FK_RecipeWaterSchedules_Recipes_RecipeId",
                table: "RecipeWaterSchedules",
                column: "RecipeId",
                principalTable: "Recipes",
                principalColumn: "Id");
        }

        /// <inheritdoc />
        protected override void Down(MigrationBuilder migrationBuilder)
        {
            migrationBuilder.DropForeignKey(
                name: "FK_RecipeLightSchedules_Recipes_RecipeId",
                table: "RecipeLightSchedules");

            migrationBuilder.DropForeignKey(
                name: "FK_RecipeWaterSchedules_Recipes_RecipeId",
                table: "RecipeWaterSchedules");

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
        }
    }
}
