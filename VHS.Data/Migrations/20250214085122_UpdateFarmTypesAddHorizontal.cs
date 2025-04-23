using Microsoft.EntityFrameworkCore.Migrations;

#nullable disable

namespace VHS.Data.Migrations
{
    /// <inheritdoc />
    public partial class UpdateFarmTypesAddHorizontal : Migration
    {
        /// <inheritdoc />
        protected override void Up(MigrationBuilder migrationBuilder)
        {
            migrationBuilder.Sql("DELETE FROM FarmTypes WHERE Name IN ('Multi', 'Single')");

            migrationBuilder.Sql(@"
            INSERT INTO FarmTypes (Id, Name, Description, AddedDateTime, ModifiedDateTime) 
            VALUES 
            (NEWID(), 'Horizontal', 'Horizontal farm', GETDATE(), GETDATE())");
        }

        /// <inheritdoc />
        protected override void Down(MigrationBuilder migrationBuilder)
        {
            migrationBuilder.Sql("DELETE FROM FarmTypes WHERE Name = 'Horizontal'");

            migrationBuilder.Sql(@"
            INSERT INTO FarmTypes (Id, Name, Description, AddedDateTime, ModifiedDateTime) 
            VALUES 
            (NEWID(), 'Multi', 'Multi farm', GETDATE(), GETDATE()),
            (NEWID(), 'Single', 'Single farm', GETDATE(), GETDATE())");
        }
    }
}
