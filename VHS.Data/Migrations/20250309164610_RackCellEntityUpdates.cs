using System;
using Microsoft.EntityFrameworkCore.Migrations;

#nullable disable

namespace VHS.Data.Migrations
{
    /// <inheritdoc />
    public partial class RackCellEntityUpdates : Migration
    {
        /// <inheritdoc />
        protected override void Up(MigrationBuilder migrationBuilder)
        {
            migrationBuilder.AddColumn<Guid>(
                name: "RackId",
                table: "RackCells",
                type: "uniqueidentifier",
                nullable: false,
                defaultValue: new Guid("00000000-0000-0000-0000-000000000000"));

            migrationBuilder.CreateIndex(
                name: "IX_RackCells_RackId",
                table: "RackCells",
                column: "RackId");

            migrationBuilder.AddForeignKey(
                name: "FK_RackCells_Racks_RackId",
                table: "RackCells",
                column: "RackId",
                principalTable: "Racks",
                principalColumn: "Id");
        }

        /// <inheritdoc />
        protected override void Down(MigrationBuilder migrationBuilder)
        {
            migrationBuilder.DropForeignKey(
                name: "FK_RackCells_Racks_RackId",
                table: "RackCells");

            migrationBuilder.DropIndex(
                name: "IX_RackCells_RackId",
                table: "RackCells");

            migrationBuilder.DropColumn(
                name: "RackId",
                table: "RackCells");
        }
    }
}
