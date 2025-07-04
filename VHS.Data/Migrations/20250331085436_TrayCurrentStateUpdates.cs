﻿using Microsoft.EntityFrameworkCore.Migrations;

#nullable disable

namespace VHS.Data.Migrations
{
    /// <inheritdoc />
    public partial class TrayCurrentStateUpdates : Migration
    {
        /// <inheritdoc />
        protected override void Up(MigrationBuilder migrationBuilder)
        {
            migrationBuilder.AlterColumn<int>(
                name: "OrderOnLayer",
                table: "TrayCurrentStates",
                type: "int",
                nullable: false,
                defaultValue: 0,
                oldClrType: typeof(int),
                oldType: "int");
        }

        /// <inheritdoc />
        protected override void Down(MigrationBuilder migrationBuilder)
        {
            migrationBuilder.AlterColumn<int>(
                name: "OrderOnLayer",
                table: "TrayCurrentStates",
                type: "int",
                nullable: false,
                oldClrType: typeof(int),
                oldType: "int",
                oldDefaultValue: 0);
        }
    }
}
