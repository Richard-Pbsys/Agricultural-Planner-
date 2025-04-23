using System;
using Microsoft.EntityFrameworkCore.Migrations;

#nullable disable

namespace VHS.Data.Migrations
{
    /// <inheritdoc />
    public partial class AddFarmIdToProductCategory : Migration
    {
        /// <inheritdoc />
        protected override void Up(MigrationBuilder migrationBuilder)
        {
            // Step 1: Add the FarmId column (temporarily nullable to allow updates)
            migrationBuilder.AddColumn<Guid>(
                name: "FarmId",
                table: "ProductCategories",
                type: "uniqueidentifier",
                nullable: true);

            // Step 2: Assign FarmId using SQL (get first non-deleted farm)
            migrationBuilder.Sql(@"
                DECLARE @FarmId UNIQUEIDENTIFIER;
                SET @FarmId = (SELECT TOP 1 Id FROM Farms WHERE DeletedDateTime IS NULL ORDER BY AddedDateTime ASC);

                -- If no farm exists, create a default one
                IF @FarmId IS NULL
                BEGIN
                    SET @FarmId = NEWID();
                    INSERT INTO Farms (Id, Name, Description, FarmTypeId, AddedDateTime, ModifiedDateTime) 
                    VALUES (
                        @FarmId, 
                        'Default Farm', 
                        'Auto-generated farm', 
                        ISNULL((SELECT TOP 1 Id FROM FarmTypes WHERE Name = 'Vertical'), NEWID()), -- Ensures FarmTypeId is always valid
                        GETDATE(), 
                        GETDATE()
                    );
                END;

                -- Assign the found/created farm to all ProductCategories where FarmId is NULL
                UPDATE ProductCategories 
                SET FarmId = @FarmId 
                WHERE FarmId IS NULL; -- Fix: Only update rows where FarmId is actually NULL
            ");

            // Step 3: Make the FarmId column non-nullable in a separate SQL statement
            migrationBuilder.Sql(@"
                ALTER TABLE ProductCategories 
                ALTER COLUMN FarmId UNIQUEIDENTIFIER NOT NULL;
            ");

            // Step 4: Create index & foreign key constraint
            migrationBuilder.CreateIndex(
                name: "IX_ProductCategories_FarmId",
                table: "ProductCategories",
                column: "FarmId");

            migrationBuilder.AddForeignKey(
                name: "FK_ProductCategories_Farms_FarmId",
                table: "ProductCategories",
                column: "FarmId",
                principalTable: "Farms",
                principalColumn: "Id",
                onDelete: ReferentialAction.NoAction);
        }

        /// <inheritdoc />
        protected override void Down(MigrationBuilder migrationBuilder)
        {
            migrationBuilder.DropForeignKey(
                name: "FK_ProductCategories_Farms_FarmId",
                table: "ProductCategories");

            migrationBuilder.DropIndex(
                name: "IX_ProductCategories_FarmId",
                table: "ProductCategories");

            migrationBuilder.DropColumn(
                name: "FarmId",
                table: "ProductCategories");
        }
    }
}
