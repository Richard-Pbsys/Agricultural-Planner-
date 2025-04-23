using System;
using Microsoft.EntityFrameworkCore.Migrations;

#nullable disable

namespace VHS.Data.Migrations
{
    /// <inheritdoc />
    public partial class AddFarmTypes : Migration
    {
        /// <inheritdoc />
        protected override void Up(MigrationBuilder migrationBuilder)
        {
            migrationBuilder.RenameColumn(
                name: "TypeId",
                table: "Farms",
                newName: "FarmTypeId");

            migrationBuilder.CreateTable(
                name: "FarmTypes",
                columns: table => new
                {
                    Id = table.Column<Guid>(type: "uniqueidentifier", nullable: false),
                    Name = table.Column<string>(type: "nvarchar(50)", maxLength: 50, nullable: false),
                    Description = table.Column<string>(type: "nvarchar(255)", maxLength: 255, nullable: true),
                    AddedDateTime = table.Column<DateTime>(type: "datetime2", nullable: false),
                    ModifiedDateTime = table.Column<DateTime>(type: "datetime2", nullable: false),
                    DeletedDateTime = table.Column<DateTime>(type: "datetime2", nullable: true)
                },
                constraints: table =>
                {
                    table.PrimaryKey("PK_FarmTypes", x => x.Id);
                });

            migrationBuilder.CreateIndex(
                name: "IX_Farms_FarmTypeId",
                table: "Farms",
                column: "FarmTypeId");

            migrationBuilder.AddForeignKey(
                name: "FK_Farms_FarmTypes_FarmTypeId",
                table: "Farms",
                column: "FarmTypeId",
                principalTable: "FarmTypes",
                principalColumn: "Id");
        }

        /// <inheritdoc />
        protected override void Down(MigrationBuilder migrationBuilder)
        {
            migrationBuilder.DropForeignKey(
                name: "FK_Farms_FarmTypes_FarmTypeId",
                table: "Farms");

            migrationBuilder.DropTable(
                name: "FarmTypes");

            migrationBuilder.DropIndex(
                name: "IX_Farms_FarmTypeId",
                table: "Farms");

            migrationBuilder.RenameColumn(
                name: "FarmTypeId",
                table: "Farms",
                newName: "TypeId");
        }
    }
}
