using Microsoft.EntityFrameworkCore.Migrations;

#nullable disable

namespace VHS.Data.Migrations
{
    /// <inheritdoc />
    public partial class ProduceRacksUpdates : Migration
    {
        /// <inheritdoc />
        protected override void Up(MigrationBuilder migrationBuilder)
        {
            migrationBuilder.DropForeignKey(
                name: "FK_ProductCategoryRack_ProductCategories_ProductCategoryId",
                table: "ProductCategoryRack");

            migrationBuilder.DropForeignKey(
                name: "FK_ProductCategoryRack_Racks_RackId",
                table: "ProductCategoryRack");

            migrationBuilder.DropPrimaryKey(
                name: "PK_ProductCategoryRack",
                table: "ProductCategoryRack");

            migrationBuilder.RenameTable(
                name: "ProductCategoryRack",
                newName: "ProductCategoryRacks");

            migrationBuilder.RenameIndex(
                name: "IX_ProductCategoryRack_RackId",
                table: "ProductCategoryRacks",
                newName: "IX_ProductCategoryRacks_RackId");

            migrationBuilder.RenameIndex(
                name: "IX_ProductCategoryRack_ProductCategoryId",
                table: "ProductCategoryRacks",
                newName: "IX_ProductCategoryRacks_ProductCategoryId");

            migrationBuilder.AddPrimaryKey(
                name: "PK_ProductCategoryRacks",
                table: "ProductCategoryRacks",
                column: "Id");

            migrationBuilder.AddForeignKey(
                name: "FK_ProductCategoryRacks_ProductCategories_ProductCategoryId",
                table: "ProductCategoryRacks",
                column: "ProductCategoryId",
                principalTable: "ProductCategories",
                principalColumn: "Id");

            migrationBuilder.AddForeignKey(
                name: "FK_ProductCategoryRacks_Racks_RackId",
                table: "ProductCategoryRacks",
                column: "RackId",
                principalTable: "Racks",
                principalColumn: "Id");
        }

        /// <inheritdoc />
        protected override void Down(MigrationBuilder migrationBuilder)
        {
            migrationBuilder.DropForeignKey(
                name: "FK_ProductCategoryRacks_ProductCategories_ProductCategoryId",
                table: "ProductCategoryRacks");

            migrationBuilder.DropForeignKey(
                name: "FK_ProductCategoryRacks_Racks_RackId",
                table: "ProductCategoryRacks");

            migrationBuilder.DropPrimaryKey(
                name: "PK_ProductCategoryRacks",
                table: "ProductCategoryRacks");

            migrationBuilder.RenameTable(
                name: "ProductCategoryRacks",
                newName: "ProductCategoryRack");

            migrationBuilder.RenameIndex(
                name: "IX_ProductCategoryRacks_RackId",
                table: "ProductCategoryRack",
                newName: "IX_ProductCategoryRack_RackId");

            migrationBuilder.RenameIndex(
                name: "IX_ProductCategoryRacks_ProductCategoryId",
                table: "ProductCategoryRack",
                newName: "IX_ProductCategoryRack_ProductCategoryId");

            migrationBuilder.AddPrimaryKey(
                name: "PK_ProductCategoryRack",
                table: "ProductCategoryRack",
                column: "Id");

            migrationBuilder.AddForeignKey(
                name: "FK_ProductCategoryRack_ProductCategories_ProductCategoryId",
                table: "ProductCategoryRack",
                column: "ProductCategoryId",
                principalTable: "ProductCategories",
                principalColumn: "Id",
                onDelete: ReferentialAction.Cascade);

            migrationBuilder.AddForeignKey(
                name: "FK_ProductCategoryRack_Racks_RackId",
                table: "ProductCategoryRack",
                column: "RackId",
                principalTable: "Racks",
                principalColumn: "Id",
                onDelete: ReferentialAction.Cascade);
        }
    }
}
