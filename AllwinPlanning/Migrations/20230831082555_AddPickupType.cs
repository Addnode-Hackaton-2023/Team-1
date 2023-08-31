using Microsoft.EntityFrameworkCore.Migrations;

#nullable disable

namespace AllwinPlanning.Migrations
{
    /// <inheritdoc />
    public partial class AddPickupType : Migration
    {
        /// <inheritdoc />
        protected override void Up(MigrationBuilder migrationBuilder)
        {
            migrationBuilder.AddColumn<int>(
                name: "PickupType",
                table: "Pickup",
                type: "int",
                nullable: false,
                defaultValue: 0);

            migrationBuilder.AddForeignKey(
                name: "FK_DeliveryDay_Delivery_Gid",
                table: "DeliveryDay",
                column: "Gid",
                principalTable: "Delivery",
                principalColumn: "Gid",
                onDelete: ReferentialAction.Cascade);
        }

        /// <inheritdoc />
        protected override void Down(MigrationBuilder migrationBuilder)
        {
            migrationBuilder.DropForeignKey(
                name: "FK_DeliveryDay_Delivery_Gid",
                table: "DeliveryDay");

            migrationBuilder.DropColumn(
                name: "PickupType",
                table: "Pickup");
        }
    }
}
