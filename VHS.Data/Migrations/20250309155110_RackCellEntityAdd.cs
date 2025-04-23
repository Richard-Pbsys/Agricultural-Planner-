using System;
using Microsoft.EntityFrameworkCore.Migrations;

#nullable disable

namespace VHS.Data.Migrations
{
    /// <inheritdoc />
    public partial class RackCellEntityAdd : Migration
    {
        /// <inheritdoc />
        protected override void Up(MigrationBuilder migrationBuilder)
        {
            migrationBuilder.DropForeignKey(
                name: "FK_Trays_Layers_LayerId",
                table: "Trays");

            migrationBuilder.DropColumn(
                name: "Code",
                table: "Layers");

            migrationBuilder.RenameColumn(
                name: "LayerId",
                table: "Trays",
                newName: "RackCellId");

            migrationBuilder.RenameIndex(
                name: "IX_Trays_LayerId",
                table: "Trays",
                newName: "IX_Trays_RackCellId");

            migrationBuilder.AddColumn<int>(
                name: "LayerNumber",
                table: "Layers",
                type: "int",
                nullable: false,
                defaultValue: 0);

            migrationBuilder.CreateTable(
                name: "RackCells",
                columns: table => new
                {
                    Id = table.Column<Guid>(type: "uniqueidentifier", nullable: false),
                    LayerId = table.Column<Guid>(type: "uniqueidentifier", nullable: false),
                    ColumnNumber = table.Column<int>(type: "int", nullable: false),
                    Code = table.Column<string>(type: "nvarchar(max)", nullable: false),
                    AddedDateTime = table.Column<DateTime>(type: "datetime2", nullable: false),
                    ModifiedDateTime = table.Column<DateTime>(type: "datetime2", nullable: false),
                    DeletedDateTime = table.Column<DateTime>(type: "datetime2", nullable: true)
                },
                constraints: table =>
                {
                    table.PrimaryKey("PK_RackCells", x => x.Id);
                    table.ForeignKey(
                        name: "FK_RackCells_Layers_LayerId",
                        column: x => x.LayerId,
                        principalTable: "Layers",
                        principalColumn: "Id");
                });

            migrationBuilder.CreateIndex(
                name: "IX_RackCells_LayerId",
                table: "RackCells",
                column: "LayerId");

            migrationBuilder.AddForeignKey(
                name: "FK_Trays_RackCells_RackCellId",
                table: "Trays",
                column: "RackCellId",
                principalTable: "RackCells",
                principalColumn: "Id");
        }

        /// <inheritdoc />
        protected override void Down(MigrationBuilder migrationBuilder)
        {
            migrationBuilder.DropForeignKey(
                name: "FK_Trays_RackCells_RackCellId",
                table: "Trays");

            migrationBuilder.DropTable(
                name: "RackCells");

            migrationBuilder.DropColumn(
                name: "LayerNumber",
                table: "Layers");

            migrationBuilder.RenameColumn(
                name: "RackCellId",
                table: "Trays",
                newName: "LayerId");

            migrationBuilder.RenameIndex(
                name: "IX_Trays_RackCellId",
                table: "Trays",
                newName: "IX_Trays_LayerId");

            migrationBuilder.AddColumn<string>(
                name: "Code",
                table: "Layers",
                type: "nvarchar(50)",
                maxLength: 50,
                nullable: false,
                defaultValue: "");

            migrationBuilder.AddForeignKey(
                name: "FK_Trays_Layers_LayerId",
                table: "Trays",
                column: "LayerId",
                principalTable: "Layers",
                principalColumn: "Id");
        }
    }
}
