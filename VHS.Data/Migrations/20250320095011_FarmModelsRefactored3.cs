using System;
using Microsoft.EntityFrameworkCore.Migrations;

#nullable disable

namespace VHS.Data.Migrations
{
    /// <inheritdoc />
    public partial class FarmModelsRefactored3 : Migration
    {
        /// <inheritdoc />
        protected override void Up(MigrationBuilder migrationBuilder)
        {
            migrationBuilder.DropForeignKey(
                name: "FK_BatchConfigurations_ProductCategories_ProductCategoryId",
                table: "BatchConfigurations");

            migrationBuilder.DropForeignKey(
                name: "FK_Products_ProductCategories_ProductCategoryId",
                table: "Products");

            migrationBuilder.DropForeignKey(
                name: "FK_Racks_Farms_FarmId",
                table: "Racks");

            migrationBuilder.DropForeignKey(
                name: "FK_Recipes_ProductCategories_ProductCategoryId",
                table: "Recipes");

            migrationBuilder.DropForeignKey(
                name: "FK_Trays_Batches_BatchId",
                table: "Trays");

            migrationBuilder.DropForeignKey(
                name: "FK_Trays_Layers_LayerId",
                table: "Trays");

            migrationBuilder.DropForeignKey(
                name: "FK_Trays_RackCells_RackCellId",
                table: "Trays");

            migrationBuilder.DropForeignKey(
                name: "FK_Trays_Racks_RackId",
                table: "Trays");

            migrationBuilder.DropTable(
                name: "ProductCategoryRacks");

            migrationBuilder.DropTable(
                name: "RackCells");

            migrationBuilder.DropTable(
                name: "ProductCategories");

            migrationBuilder.DropIndex(
                name: "IX_Users_Auth0Id",
                table: "Users");

            migrationBuilder.DropIndex(
                name: "IX_Trays_BatchId",
                table: "Trays");

            migrationBuilder.DropIndex(
                name: "IX_Trays_LayerId",
                table: "Trays");

            migrationBuilder.DropIndex(
                name: "IX_Trays_RackCellId",
                table: "Trays");

            migrationBuilder.DropIndex(
                name: "IX_Trays_RackId",
                table: "Trays");

            migrationBuilder.DropIndex(
                name: "IX_Recipes_ProductCategoryId",
                table: "Recipes");

            migrationBuilder.DropIndex(
                name: "IX_Racks_FarmId",
                table: "Racks");

            migrationBuilder.DropIndex(
                name: "IX_Products_ProductCategoryId",
                table: "Products");

            migrationBuilder.DropIndex(
                name: "IX_BatchConfigurations_ProductCategoryId",
                table: "BatchConfigurations");

            migrationBuilder.DropColumn(
                name: "BatchId",
                table: "Trays");

            migrationBuilder.DropColumn(
                name: "LayerId",
                table: "Trays");

            migrationBuilder.DropColumn(
                name: "ModifiedDateTime",
                table: "Trays");

            migrationBuilder.DropColumn(
                name: "RackCellId",
                table: "Trays");

            migrationBuilder.DropColumn(
                name: "GerminateOnFloor",
                table: "Recipes");

            migrationBuilder.DropColumn(
                name: "ProductCategoryId",
                table: "Recipes");

            migrationBuilder.DropColumn(
                name: "Columns",
                table: "Racks");

            migrationBuilder.DropColumn(
                name: "ModifiedDateTime",
                table: "Racks");

            migrationBuilder.DropColumn(
                name: "TypeName",
                table: "Racks");

            migrationBuilder.DropColumn(
                name: "ModifiedDateTime",
                table: "Layers");

            migrationBuilder.DropColumn(
                name: "ModifiedDateTime",
                table: "Floors");

            migrationBuilder.DropColumn(
                name: "ModifiedDateTime",
                table: "FarmTypes");

            migrationBuilder.DropColumn(
                name: "ModifiedDateTime",
                table: "Farms");

            migrationBuilder.DropColumn(
                name: "Status",
                table: "Batches");

            migrationBuilder.DropColumn(
                name: "ProductCategoryId",
                table: "BatchConfigurations");

            migrationBuilder.RenameColumn(
                name: "RackId",
                table: "Trays",
                newName: "StatusId");

            migrationBuilder.RenameColumn(
                name: "Layers",
                table: "Racks",
                newName: "TrayCountPerLayer");

            migrationBuilder.RenameColumn(
                name: "FarmId",
                table: "Racks",
                newName: "TypeId");

            migrationBuilder.RenameColumn(
                name: "Depth",
                table: "Racks",
                newName: "LayerCount");

            migrationBuilder.RenameColumn(
                name: "SeededDate",
                table: "Batches",
                newName: "SeedDate");

            migrationBuilder.AlterColumn<string>(
                name: "Auth0Id",
                table: "Users",
                type: "nvarchar(255)",
                maxLength: 255,
                nullable: false,
                defaultValue: "",
                oldClrType: typeof(string),
                oldType: "nvarchar(255)",
                oldMaxLength: 255,
                oldNullable: true);

            migrationBuilder.AlterColumn<string>(
                name: "RFIDTag",
                table: "Trays",
                type: "nvarchar(255)",
                maxLength: 255,
                nullable: false,
                oldClrType: typeof(string),
                oldType: "nvarchar(100)",
                oldMaxLength: 100);

            migrationBuilder.AlterColumn<Guid>(
                name: "ProductId",
                table: "Recipes",
                type: "uniqueidentifier",
                nullable: false,
                defaultValue: new Guid("00000000-0000-0000-0000-000000000000"),
                oldClrType: typeof(Guid),
                oldType: "uniqueidentifier",
                oldNullable: true);

            migrationBuilder.AddColumn<Guid>(
                name: "FarmId",
                table: "Products",
                type: "uniqueidentifier",
                nullable: false,
                defaultValue: new Guid("00000000-0000-0000-0000-000000000000"));

            migrationBuilder.AddColumn<string>(
                name: "SeedSupplier",
                table: "Products",
                type: "nvarchar(255)",
                maxLength: 255,
                nullable: true);

            migrationBuilder.AlterColumn<string>(
                name: "Name",
                table: "Floors",
                type: "nvarchar(50)",
                maxLength: 50,
                nullable: false,
                oldClrType: typeof(string),
                oldType: "nvarchar(255)",
                oldMaxLength: 255);

            migrationBuilder.AlterColumn<string>(
                name: "Name",
                table: "Farms",
                type: "nvarchar(50)",
                maxLength: 50,
                nullable: false,
                oldClrType: typeof(string),
                oldType: "nvarchar(255)",
                oldMaxLength: 255);

            migrationBuilder.AlterColumn<string>(
                name: "Description",
                table: "Farms",
                type: "nvarchar(255)",
                maxLength: 255,
                nullable: false,
                oldClrType: typeof(string),
                oldType: "nvarchar(500)",
                oldMaxLength: 500);

            migrationBuilder.AddColumn<Guid>(
                name: "StatusId",
                table: "Batches",
                type: "uniqueidentifier",
                nullable: false,
                defaultValue: new Guid("00000000-0000-0000-0000-000000000000"));

            migrationBuilder.CreateTable(
                name: "BatchJournals",
                columns: table => new
                {
                    Id = table.Column<Guid>(type: "uniqueidentifier", nullable: false),
                    BatchId = table.Column<Guid>(type: "uniqueidentifier", nullable: false),
                    SeedSupplier = table.Column<string>(type: "nvarchar(255)", maxLength: 255, nullable: false),
                    SeedLotNumber = table.Column<string>(type: "nvarchar(255)", maxLength: 255, nullable: false),
                    PeatSupplier = table.Column<string>(type: "nvarchar(255)", maxLength: 255, nullable: true),
                    PeatPrescription = table.Column<string>(type: "nvarchar(255)", maxLength: 255, nullable: true),
                    PeatLotNumber = table.Column<string>(type: "nvarchar(255)", maxLength: 255, nullable: true),
                    RemarksGermination = table.Column<string>(type: "nvarchar(1000)", maxLength: 1000, nullable: false),
                    RemarksYoungPlants = table.Column<string>(type: "nvarchar(1000)", maxLength: 1000, nullable: false),
                    RemarksIntermediatePlants = table.Column<string>(type: "nvarchar(1000)", maxLength: 1000, nullable: false),
                    RemarksHarvestPlants = table.Column<string>(type: "nvarchar(1000)", maxLength: 1000, nullable: false),
                    PrognosisGermination = table.Column<double>(type: "float", nullable: false),
                    PrognosisDays = table.Column<int>(type: "int", nullable: false),
                    PrognosisHeight = table.Column<double>(type: "float", nullable: false),
                    PrognosisWeight = table.Column<double>(type: "float", nullable: false),
                    PrognosisRootLength = table.Column<double>(type: "float", nullable: false),
                    PrognosisRootNeckDiameter = table.Column<double>(type: "float", nullable: false),
                    YieldLettuceCount = table.Column<int>(type: "int", nullable: false),
                    YieldLettuceWeight = table.Column<double>(type: "float", nullable: false),
                    YieldLettuceHeight = table.Column<double>(type: "float", nullable: false),
                    YieldPetiteCount = table.Column<int>(type: "int", nullable: false),
                    YieldPetiteWeight = table.Column<double>(type: "float", nullable: false),
                    YieldPetiteHeight = table.Column<double>(type: "float", nullable: false),
                    YieldMicroCount = table.Column<int>(type: "int", nullable: false),
                    YieldMicroWeight = table.Column<double>(type: "float", nullable: false),
                    YieldMicroHeight = table.Column<double>(type: "float", nullable: false),
                    YieldComparison = table.Column<string>(type: "nvarchar(255)", maxLength: 255, nullable: false),
                    MiscellaneousComments = table.Column<string>(type: "nvarchar(1000)", maxLength: 1000, nullable: false),
                    AddedDateTime = table.Column<DateTime>(type: "datetime2", nullable: false),
                    ModifiedDateTime = table.Column<DateTime>(type: "datetime2", nullable: false),
                    DeletedDateTime = table.Column<DateTime>(type: "datetime2", nullable: true)
                },
                constraints: table =>
                {
                    table.PrimaryKey("PK_BatchJournals", x => x.Id);
                });

            migrationBuilder.CreateTable(
                name: "TrayCurrentStates",
                columns: table => new
                {
                    TrayId = table.Column<Guid>(type: "uniqueidentifier", nullable: false),
                    DestinationLayerId = table.Column<Guid>(type: "uniqueidentifier", nullable: true),
                    OrderOnLayer = table.Column<int>(type: "int", nullable: false),
                    BatchId = table.Column<Guid>(type: "uniqueidentifier", nullable: true),
                    CurrentPhaseId = table.Column<Guid>(type: "uniqueidentifier", nullable: false),
                    AddedDateTime = table.Column<DateTime>(type: "datetime2", nullable: false),
                    ModifiedDateTime = table.Column<DateTime>(type: "datetime2", nullable: false)
                },
                constraints: table =>
                {
                    table.PrimaryKey("PK_TrayCurrentStates", x => x.TrayId);
                    table.ForeignKey(
                        name: "FK_TrayCurrentStates_Batches_BatchId",
                        column: x => x.BatchId,
                        principalTable: "Batches",
                        principalColumn: "Id");
                    table.ForeignKey(
                        name: "FK_TrayCurrentStates_Layers_DestinationLayerId",
                        column: x => x.DestinationLayerId,
                        principalTable: "Layers",
                        principalColumn: "Id");
                    table.ForeignKey(
                        name: "FK_TrayCurrentStates_Trays_TrayId",
                        column: x => x.TrayId,
                        principalTable: "Trays",
                        principalColumn: "Id");
                });

            migrationBuilder.CreateTable(
                name: "TrayTransactions",
                columns: table => new
                {
                    Id = table.Column<Guid>(type: "uniqueidentifier", nullable: false),
                    TrayId = table.Column<Guid>(type: "uniqueidentifier", nullable: false),
                    FromPhaseId = table.Column<Guid>(type: "uniqueidentifier", nullable: false),
                    ToPhaseId = table.Column<Guid>(type: "uniqueidentifier", nullable: false),
                    AddedDateTime = table.Column<DateTime>(type: "datetime2", nullable: false)
                },
                constraints: table =>
                {
                    table.PrimaryKey("PK_TrayTransactions", x => x.Id);
                    table.ForeignKey(
                        name: "FK_TrayTransactions_Trays_TrayId",
                        column: x => x.TrayId,
                        principalTable: "Trays",
                        principalColumn: "Id");
                });

            migrationBuilder.CreateIndex(
                name: "IX_Users_Auth0Id",
                table: "Users",
                column: "Auth0Id",
                unique: true);

            migrationBuilder.CreateIndex(
                name: "IX_Products_FarmId",
                table: "Products",
                column: "FarmId");

            migrationBuilder.CreateIndex(
                name: "IX_TrayCurrentStates_BatchId",
                table: "TrayCurrentStates",
                column: "BatchId");

            migrationBuilder.CreateIndex(
                name: "IX_TrayCurrentStates_DestinationLayerId",
                table: "TrayCurrentStates",
                column: "DestinationLayerId");

            migrationBuilder.CreateIndex(
                name: "IX_TrayTransactions_TrayId",
                table: "TrayTransactions",
                column: "TrayId");

            migrationBuilder.AddForeignKey(
                name: "FK_Products_Farms_FarmId",
                table: "Products",
                column: "FarmId",
                principalTable: "Farms",
                principalColumn: "Id");
        }

        /// <inheritdoc />
        protected override void Down(MigrationBuilder migrationBuilder)
        {
            migrationBuilder.DropForeignKey(
                name: "FK_Products_Farms_FarmId",
                table: "Products");

            migrationBuilder.DropTable(
                name: "BatchJournals");

            migrationBuilder.DropTable(
                name: "TrayCurrentStates");

            migrationBuilder.DropTable(
                name: "TrayTransactions");

            migrationBuilder.DropIndex(
                name: "IX_Users_Auth0Id",
                table: "Users");

            migrationBuilder.DropIndex(
                name: "IX_Products_FarmId",
                table: "Products");

            migrationBuilder.DropColumn(
                name: "FarmId",
                table: "Products");

            migrationBuilder.DropColumn(
                name: "SeedSupplier",
                table: "Products");

            migrationBuilder.DropColumn(
                name: "StatusId",
                table: "Batches");

            migrationBuilder.RenameColumn(
                name: "StatusId",
                table: "Trays",
                newName: "RackId");

            migrationBuilder.RenameColumn(
                name: "TypeId",
                table: "Racks",
                newName: "FarmId");

            migrationBuilder.RenameColumn(
                name: "TrayCountPerLayer",
                table: "Racks",
                newName: "Layers");

            migrationBuilder.RenameColumn(
                name: "LayerCount",
                table: "Racks",
                newName: "Depth");

            migrationBuilder.RenameColumn(
                name: "SeedDate",
                table: "Batches",
                newName: "SeededDate");

            migrationBuilder.AlterColumn<string>(
                name: "Auth0Id",
                table: "Users",
                type: "nvarchar(255)",
                maxLength: 255,
                nullable: true,
                oldClrType: typeof(string),
                oldType: "nvarchar(255)",
                oldMaxLength: 255);

            migrationBuilder.AlterColumn<string>(
                name: "RFIDTag",
                table: "Trays",
                type: "nvarchar(100)",
                maxLength: 100,
                nullable: false,
                oldClrType: typeof(string),
                oldType: "nvarchar(255)",
                oldMaxLength: 255);

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

            migrationBuilder.AddColumn<DateTime>(
                name: "ModifiedDateTime",
                table: "Trays",
                type: "datetime2",
                nullable: false,
                defaultValue: new DateTime(1, 1, 1, 0, 0, 0, 0, DateTimeKind.Unspecified));

            migrationBuilder.AddColumn<Guid>(
                name: "RackCellId",
                table: "Trays",
                type: "uniqueidentifier",
                nullable: false,
                defaultValue: new Guid("00000000-0000-0000-0000-000000000000"));

            migrationBuilder.AlterColumn<Guid>(
                name: "ProductId",
                table: "Recipes",
                type: "uniqueidentifier",
                nullable: true,
                oldClrType: typeof(Guid),
                oldType: "uniqueidentifier");

            migrationBuilder.AddColumn<bool>(
                name: "GerminateOnFloor",
                table: "Recipes",
                type: "bit",
                nullable: false,
                defaultValue: false);

            migrationBuilder.AddColumn<Guid>(
                name: "ProductCategoryId",
                table: "Recipes",
                type: "uniqueidentifier",
                nullable: false,
                defaultValue: new Guid("00000000-0000-0000-0000-000000000000"));

            migrationBuilder.AddColumn<int>(
                name: "Columns",
                table: "Racks",
                type: "int",
                nullable: false,
                defaultValue: 0);

            migrationBuilder.AddColumn<DateTime>(
                name: "ModifiedDateTime",
                table: "Racks",
                type: "datetime2",
                nullable: false,
                defaultValue: new DateTime(1, 1, 1, 0, 0, 0, 0, DateTimeKind.Unspecified));

            migrationBuilder.AddColumn<string>(
                name: "TypeName",
                table: "Racks",
                type: "nvarchar(50)",
                maxLength: 50,
                nullable: false,
                defaultValue: "");

            migrationBuilder.AddColumn<DateTime>(
                name: "ModifiedDateTime",
                table: "Layers",
                type: "datetime2",
                nullable: false,
                defaultValue: new DateTime(1, 1, 1, 0, 0, 0, 0, DateTimeKind.Unspecified));

            migrationBuilder.AlterColumn<string>(
                name: "Name",
                table: "Floors",
                type: "nvarchar(255)",
                maxLength: 255,
                nullable: false,
                oldClrType: typeof(string),
                oldType: "nvarchar(50)",
                oldMaxLength: 50);

            migrationBuilder.AddColumn<DateTime>(
                name: "ModifiedDateTime",
                table: "Floors",
                type: "datetime2",
                nullable: false,
                defaultValue: new DateTime(1, 1, 1, 0, 0, 0, 0, DateTimeKind.Unspecified));

            migrationBuilder.AddColumn<DateTime>(
                name: "ModifiedDateTime",
                table: "FarmTypes",
                type: "datetime2",
                nullable: false,
                defaultValue: new DateTime(1, 1, 1, 0, 0, 0, 0, DateTimeKind.Unspecified));

            migrationBuilder.AlterColumn<string>(
                name: "Name",
                table: "Farms",
                type: "nvarchar(255)",
                maxLength: 255,
                nullable: false,
                oldClrType: typeof(string),
                oldType: "nvarchar(50)",
                oldMaxLength: 50);

            migrationBuilder.AlterColumn<string>(
                name: "Description",
                table: "Farms",
                type: "nvarchar(500)",
                maxLength: 500,
                nullable: false,
                oldClrType: typeof(string),
                oldType: "nvarchar(255)",
                oldMaxLength: 255);

            migrationBuilder.AddColumn<DateTime>(
                name: "ModifiedDateTime",
                table: "Farms",
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
                name: "ProductCategoryId",
                table: "BatchConfigurations",
                type: "uniqueidentifier",
                nullable: false,
                defaultValue: new Guid("00000000-0000-0000-0000-000000000000"));

            migrationBuilder.CreateTable(
                name: "ProductCategories",
                columns: table => new
                {
                    Id = table.Column<Guid>(type: "uniqueidentifier", nullable: false),
                    FarmId = table.Column<Guid>(type: "uniqueidentifier", nullable: false),
                    AddedDateTime = table.Column<DateTime>(type: "datetime2", nullable: false),
                    DeletedDateTime = table.Column<DateTime>(type: "datetime2", nullable: true),
                    ImageData = table.Column<string>(type: "nvarchar(max)", nullable: true),
                    ModifiedDateTime = table.Column<DateTime>(type: "datetime2", nullable: false),
                    Name = table.Column<string>(type: "nvarchar(255)", maxLength: 255, nullable: false)
                },
                constraints: table =>
                {
                    table.PrimaryKey("PK_ProductCategories", x => x.Id);
                    table.ForeignKey(
                        name: "FK_ProductCategories_Farms_FarmId",
                        column: x => x.FarmId,
                        principalTable: "Farms",
                        principalColumn: "Id");
                });

            migrationBuilder.CreateTable(
                name: "RackCells",
                columns: table => new
                {
                    Id = table.Column<Guid>(type: "uniqueidentifier", nullable: false),
                    LayerId = table.Column<Guid>(type: "uniqueidentifier", nullable: false),
                    RackId = table.Column<Guid>(type: "uniqueidentifier", nullable: false),
                    AddedDateTime = table.Column<DateTime>(type: "datetime2", nullable: false),
                    Code = table.Column<string>(type: "nvarchar(max)", nullable: false),
                    ColumnNumber = table.Column<int>(type: "int", nullable: false),
                    DeletedDateTime = table.Column<DateTime>(type: "datetime2", nullable: true),
                    ModifiedDateTime = table.Column<DateTime>(type: "datetime2", nullable: false)
                },
                constraints: table =>
                {
                    table.PrimaryKey("PK_RackCells", x => x.Id);
                    table.ForeignKey(
                        name: "FK_RackCells_Layers_LayerId",
                        column: x => x.LayerId,
                        principalTable: "Layers",
                        principalColumn: "Id");
                    table.ForeignKey(
                        name: "FK_RackCells_Racks_RackId",
                        column: x => x.RackId,
                        principalTable: "Racks",
                        principalColumn: "Id");
                });

            migrationBuilder.CreateTable(
                name: "ProductCategoryRacks",
                columns: table => new
                {
                    Id = table.Column<Guid>(type: "uniqueidentifier", nullable: false),
                    ProductCategoryId = table.Column<Guid>(type: "uniqueidentifier", nullable: false),
                    RackId = table.Column<Guid>(type: "uniqueidentifier", nullable: false),
                    AddedDateTime = table.Column<DateTime>(type: "datetime2", nullable: false),
                    DeletedDateTime = table.Column<DateTime>(type: "datetime2", nullable: true),
                    ModifiedDateTime = table.Column<DateTime>(type: "datetime2", nullable: false)
                },
                constraints: table =>
                {
                    table.PrimaryKey("PK_ProductCategoryRacks", x => x.Id);
                    table.ForeignKey(
                        name: "FK_ProductCategoryRacks_ProductCategories_ProductCategoryId",
                        column: x => x.ProductCategoryId,
                        principalTable: "ProductCategories",
                        principalColumn: "Id");
                    table.ForeignKey(
                        name: "FK_ProductCategoryRacks_Racks_RackId",
                        column: x => x.RackId,
                        principalTable: "Racks",
                        principalColumn: "Id");
                });

            migrationBuilder.CreateIndex(
                name: "IX_Users_Auth0Id",
                table: "Users",
                column: "Auth0Id",
                unique: true,
                filter: "[Auth0Id] IS NOT NULL");

            migrationBuilder.CreateIndex(
                name: "IX_Trays_BatchId",
                table: "Trays",
                column: "BatchId");

            migrationBuilder.CreateIndex(
                name: "IX_Trays_LayerId",
                table: "Trays",
                column: "LayerId");

            migrationBuilder.CreateIndex(
                name: "IX_Trays_RackCellId",
                table: "Trays",
                column: "RackCellId");

            migrationBuilder.CreateIndex(
                name: "IX_Trays_RackId",
                table: "Trays",
                column: "RackId");

            migrationBuilder.CreateIndex(
                name: "IX_Recipes_ProductCategoryId",
                table: "Recipes",
                column: "ProductCategoryId");

            migrationBuilder.CreateIndex(
                name: "IX_Racks_FarmId",
                table: "Racks",
                column: "FarmId");

            migrationBuilder.CreateIndex(
                name: "IX_Products_ProductCategoryId",
                table: "Products",
                column: "ProductCategoryId");

            migrationBuilder.CreateIndex(
                name: "IX_BatchConfigurations_ProductCategoryId",
                table: "BatchConfigurations",
                column: "ProductCategoryId");

            migrationBuilder.CreateIndex(
                name: "IX_ProductCategories_FarmId",
                table: "ProductCategories",
                column: "FarmId");

            migrationBuilder.CreateIndex(
                name: "IX_ProductCategoryRacks_ProductCategoryId",
                table: "ProductCategoryRacks",
                column: "ProductCategoryId");

            migrationBuilder.CreateIndex(
                name: "IX_ProductCategoryRacks_RackId",
                table: "ProductCategoryRacks",
                column: "RackId");

            migrationBuilder.CreateIndex(
                name: "IX_RackCells_LayerId",
                table: "RackCells",
                column: "LayerId");

            migrationBuilder.CreateIndex(
                name: "IX_RackCells_RackId",
                table: "RackCells",
                column: "RackId");

            migrationBuilder.AddForeignKey(
                name: "FK_BatchConfigurations_ProductCategories_ProductCategoryId",
                table: "BatchConfigurations",
                column: "ProductCategoryId",
                principalTable: "ProductCategories",
                principalColumn: "Id");

            migrationBuilder.AddForeignKey(
                name: "FK_Products_ProductCategories_ProductCategoryId",
                table: "Products",
                column: "ProductCategoryId",
                principalTable: "ProductCategories",
                principalColumn: "Id");

            migrationBuilder.AddForeignKey(
                name: "FK_Racks_Farms_FarmId",
                table: "Racks",
                column: "FarmId",
                principalTable: "Farms",
                principalColumn: "Id");

            migrationBuilder.AddForeignKey(
                name: "FK_Recipes_ProductCategories_ProductCategoryId",
                table: "Recipes",
                column: "ProductCategoryId",
                principalTable: "ProductCategories",
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

            migrationBuilder.AddForeignKey(
                name: "FK_Trays_RackCells_RackCellId",
                table: "Trays",
                column: "RackCellId",
                principalTable: "RackCells",
                principalColumn: "Id");

            migrationBuilder.AddForeignKey(
                name: "FK_Trays_Racks_RackId",
                table: "Trays",
                column: "RackId",
                principalTable: "Racks",
                principalColumn: "Id");
        }
    }
}
