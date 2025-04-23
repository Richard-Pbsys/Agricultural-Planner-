using System;
using Microsoft.EntityFrameworkCore.Migrations;

#nullable disable

namespace VHS.Data.Migrations
{
    /// <inheritdoc />
    public partial class FarmRefactoredUpdates4 : Migration
    {
        /// <inheritdoc />
        protected override void Up(MigrationBuilder migrationBuilder)
        {
            migrationBuilder.AddColumn<Guid>(
                name: "LayerId",
                table: "TrayCurrentStates",
                type: "uniqueidentifier",
                nullable: true);

            migrationBuilder.AddColumn<DateTime>(
                name: "SeededDateTimeUTC",
                table: "TrayCurrentStates",
                type: "datetime2",
                nullable: true);

            migrationBuilder.CreateIndex(
                name: "IX_TrayCurrentStates_LayerId",
                table: "TrayCurrentStates",
                column: "LayerId");

            migrationBuilder.AddForeignKey(
                name: "FK_TrayCurrentStates_Layers_LayerId",
                table: "TrayCurrentStates",
                column: "LayerId",
                principalTable: "Layers",
                principalColumn: "Id");
        }

        /// <inheritdoc />
        protected override void Down(MigrationBuilder migrationBuilder)
        {
            migrationBuilder.DropForeignKey(
                name: "FK_TrayCurrentStates_Layers_LayerId",
                table: "TrayCurrentStates");

            migrationBuilder.DropIndex(
                name: "IX_TrayCurrentStates_LayerId",
                table: "TrayCurrentStates");

            migrationBuilder.DropColumn(
                name: "LayerId",
                table: "TrayCurrentStates");

            migrationBuilder.DropColumn(
                name: "SeededDateTimeUTC",
                table: "TrayCurrentStates");
        }
    }
}
