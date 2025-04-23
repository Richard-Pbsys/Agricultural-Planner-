using System;
using Microsoft.EntityFrameworkCore.Migrations;

#nullable disable

namespace VHS.Data.Migrations
{
    /// <inheritdoc />
    public partial class BatchesUpdates : Migration
    {
        /// <inheritdoc />
        protected override void Up(MigrationBuilder migrationBuilder)
        {
            migrationBuilder.DropForeignKey(
                name: "FK_Batches_BatchConfigurations_BatchConfigId",
                table: "Batches");

            migrationBuilder.RenameColumn(
                name: "GrowthDays",
                table: "Recipes",
                newName: "PropagationDays");

            migrationBuilder.RenameColumn(
                name: "BatchConfigId",
                table: "Batches",
                newName: "BatchConfigurationId");

            migrationBuilder.RenameIndex(
                name: "IX_Batches_BatchConfigId",
                table: "Batches",
                newName: "IX_Batches_BatchConfigurationId");

            migrationBuilder.AddColumn<Guid>(
                name: "BatchId",
                table: "Trays",
                type: "uniqueidentifier",
                nullable: true);

            migrationBuilder.AddColumn<Guid>(
                name: "LayerId",
                table: "Trays",
                type: "uniqueidentifier",
                nullable: false,
                defaultValue: new Guid("00000000-0000-0000-0000-000000000000"));

            migrationBuilder.AddColumn<int>(
                name: "GrowDays",
                table: "Recipes",
                type: "int",
                nullable: false,
                defaultValue: 0);

            migrationBuilder.AddColumn<DateTime>(
                name: "HarvestDate",
                table: "Batches",
                type: "datetime2",
                nullable: true);

            migrationBuilder.AddColumn<DateTime>(
                name: "SeededDate",
                table: "Batches",
                type: "datetime2",
                nullable: false,
                defaultValue: new DateTime(1, 1, 1, 0, 0, 0, 0, DateTimeKind.Unspecified));

            migrationBuilder.AddColumn<string>(
                name: "Status",
                table: "Batches",
                type: "nvarchar(50)",
                maxLength: 50,
                nullable: false,
                defaultValue: "");

            migrationBuilder.AddColumn<Guid>(
                name: "RecipeId",
                table: "BatchConfigurations",
                type: "uniqueidentifier",
                nullable: false,
                defaultValue: new Guid("00000000-0000-0000-0000-000000000000"));

            migrationBuilder.AddColumn<int>(
                name: "TotalTrays",
                table: "BatchConfigurations",
                type: "int",
                nullable: false,
                defaultValue: 0);

            migrationBuilder.CreateIndex(
                name: "IX_Trays_BatchId",
                table: "Trays",
                column: "BatchId");

            migrationBuilder.CreateIndex(
                name: "IX_Trays_LayerId",
                table: "Trays",
                column: "LayerId");

            migrationBuilder.CreateIndex(
                name: "IX_BatchConfigurations_RecipeId",
                table: "BatchConfigurations",
                column: "RecipeId");

            migrationBuilder.AddForeignKey(
                name: "FK_BatchConfigurations_Recipes_RecipeId",
                table: "BatchConfigurations",
                column: "RecipeId",
                principalTable: "Recipes",
                principalColumn: "Id");

            migrationBuilder.AddForeignKey(
                name: "FK_Batches_BatchConfigurations_BatchConfigurationId",
                table: "Batches",
                column: "BatchConfigurationId",
                principalTable: "BatchConfigurations",
                principalColumn: "Id");

            migrationBuilder.AddForeignKey(
                name: "FK_Trays_Batches_BatchId",
                table: "Trays",
                column: "BatchId",
                principalTable: "Batches",
                principalColumn: "Id");

            migrationBuilder.AddForeignKey(
                name: "FK_Trays_Layers_LayerId",
                table: "Trays",
                column: "LayerId",
                principalTable: "Layers",
                principalColumn: "Id");
        }

        /// <inheritdoc />
        protected override void Down(MigrationBuilder migrationBuilder)
        {
            migrationBuilder.DropForeignKey(
                name: "FK_BatchConfigurations_Recipes_RecipeId",
                table: "BatchConfigurations");

            migrationBuilder.DropForeignKey(
                name: "FK_Batches_BatchConfigurations_BatchConfigurationId",
                table: "Batches");

            migrationBuilder.DropForeignKey(
                name: "FK_Trays_Batches_BatchId",
                table: "Trays");

            migrationBuilder.DropForeignKey(
                name: "FK_Trays_Layers_LayerId",
                table: "Trays");

            migrationBuilder.DropIndex(
                name: "IX_Trays_BatchId",
                table: "Trays");

            migrationBuilder.DropIndex(
                name: "IX_Trays_LayerId",
                table: "Trays");

            migrationBuilder.DropIndex(
                name: "IX_BatchConfigurations_RecipeId",
                table: "BatchConfigurations");

            migrationBuilder.DropColumn(
                name: "BatchId",
                table: "Trays");

            migrationBuilder.DropColumn(
                name: "LayerId",
                table: "Trays");

            migrationBuilder.DropColumn(
                name: "GrowDays",
                table: "Recipes");

            migrationBuilder.DropColumn(
                name: "HarvestDate",
                table: "Batches");

            migrationBuilder.DropColumn(
                name: "SeededDate",
                table: "Batches");

            migrationBuilder.DropColumn(
                name: "Status",
                table: "Batches");

            migrationBuilder.DropColumn(
                name: "RecipeId",
                table: "BatchConfigurations");

            migrationBuilder.DropColumn(
                name: "TotalTrays",
                table: "BatchConfigurations");

            migrationBuilder.RenameColumn(
                name: "PropagationDays",
                table: "Recipes",
                newName: "GrowthDays");

            migrationBuilder.RenameColumn(
                name: "BatchConfigurationId",
                table: "Batches",
                newName: "BatchConfigId");

            migrationBuilder.RenameIndex(
                name: "IX_Batches_BatchConfigurationId",
                table: "Batches",
                newName: "IX_Batches_BatchConfigId");

            migrationBuilder.AddForeignKey(
                name: "FK_Batches_BatchConfigurations_BatchConfigId",
                table: "Batches",
                column: "BatchConfigId",
                principalTable: "BatchConfigurations",
                principalColumn: "Id");
        }
    }
}
