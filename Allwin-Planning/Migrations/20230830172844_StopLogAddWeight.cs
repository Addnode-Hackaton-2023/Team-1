using Microsoft.EntityFrameworkCore.Migrations;

#nullable disable

namespace Allwin_Planning.Migrations
{
    /// <inheritdoc />
    public partial class StopLogAddWeight : Migration
    {
        /// <inheritdoc />
        protected override void Up(MigrationBuilder migrationBuilder)
        {
            migrationBuilder.AddColumn<int>(
                name: "Weight",
                table: "StopLog",
                type: "int",
                nullable: true);
        }

        /// <inheritdoc />
        protected override void Down(MigrationBuilder migrationBuilder)
        {
            migrationBuilder.DropColumn(
                name: "Weight",
                table: "StopLog");
        }
    }
}
