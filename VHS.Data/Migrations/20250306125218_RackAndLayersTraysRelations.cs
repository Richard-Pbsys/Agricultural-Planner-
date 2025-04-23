using System;
using Microsoft.EntityFrameworkCore.Migrations;

#nullable disable

namespace VHS.Data.Migrations
{
    /// <inheritdoc />
    public partial class RackAndLayersTraysRelations : Migration
    {
        /// <inheritdoc />
        protected override void Up(MigrationBuilder migrationBuilder)
        {
            migrationBuilder.AddColumn<Guid>(
                name: "LayerId",
                table: "Trays",
                type: "uniqueidentifier",
                nullable: false,
                defaultValue: new Guid("00000000-0000-0000-0000-000000000000"));

            migrationBuilder.AddColumn<Guid>(
                name: "RackId",
                table: "Trays",
                type: "uniqueidentifier",
                nullable: false,
                defaultValue: new Guid("00000000-0000-0000-0000-000000000000"));

            migrationBuilder.CreateIndex(
                name: "IX_Trays_LayerId",
                table: "Trays",
                column: "LayerId");

            migrationBuilder.CreateIndex(
                name: "IX_Trays_RackId",
                table: "Trays",
                column: "RackId");

            migrationBuilder.AddForeignKey(
                name: "FK_Trays_Layers_LayerId",
                table: "Trays",
                column: "LayerId",
                principalTable: "Layers",
                principalColumn: "Id");

            migrationBuilder.AddForeignKey(
                name: "FK_Trays_Racks_RackId",
                table: "Trays",
                column: "RackId",
                principalTable: "Racks",
                principalColumn: "Id");
        }

        /// <inheritdoc />
        protected override void Down(MigrationBuilder migrationBuilder)
        {
            migrationBuilder.DropForeignKey(
                name: "FK_Trays_Layers_LayerId",
                table: "Trays");

            migrationBuilder.DropForeignKey(
                name: "FK_Trays_Racks_RackId",
                table: "Trays");

            migrationBuilder.DropIndex(
                name: "IX_Trays_LayerId",
                table: "Trays");

            migrationBuilder.DropIndex(
                name: "IX_Trays_RackId",
                table: "Trays");

            migrationBuilder.DropColumn(
                name: "LayerId",
                table: "Trays");

            migrationBuilder.DropColumn(
                name: "RackId",
                table: "Trays");
        }
    }
}
