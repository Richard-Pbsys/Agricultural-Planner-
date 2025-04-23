using Microsoft.EntityFrameworkCore.Migrations;

#nullable disable

namespace VHS.Data.Migrations
{
    /// <inheritdoc />
    public partial class AddFarmTypesValues : Migration
    {
        /// <inheritdoc />
        protected override void Up(MigrationBuilder migrationBuilder)
        {
            var now = DateTime.UtcNow;
            migrationBuilder.InsertData(
                table: "FarmTypes",
                columns: new[] { "Id", "Name", "Description", "AddedDateTime", "ModifiedDateTime", "DeletedDateTime" },
                values: new object[,]
                {
                    { Guid.NewGuid(), "Vertical", "Vertical farm", now, now, null },
                    { Guid.NewGuid(), "Single", "Single farm", now, now, null },
                    { Guid.NewGuid(), "Multi", "Multi farm", now, now, null },
                    { Guid.NewGuid(), "Container", "Container farm", now, now, null }
                });
        }

        /// <inheritdoc />
        protected override void Down(MigrationBuilder migrationBuilder)
        {
            migrationBuilder.Sql("DELETE FROM [FarmTypes];");
        }
    }
}
