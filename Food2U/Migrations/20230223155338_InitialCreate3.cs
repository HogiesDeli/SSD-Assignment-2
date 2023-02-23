using Microsoft.EntityFrameworkCore.Migrations;

#nullable disable

namespace Food2U.Migrations
{
    /// <inheritdoc />
    public partial class InitialCreate3 : Migration
    {
        /// <inheritdoc />
        protected override void Up(MigrationBuilder migrationBuilder)
        {
            migrationBuilder.RenameColumn(
                name: "Vehichle",
                table: "DeliveryPerson",
                newName: "Vehicle");

            migrationBuilder.AddColumn<int>(
                name: "localrestaurantsID",
                table: "Items",
                type: "INTEGER",
                nullable: false,
                defaultValue: 0);

            migrationBuilder.CreateIndex(
                name: "IX_Items_localrestaurantsID",
                table: "Items",
                column: "localrestaurantsID");

            migrationBuilder.AddForeignKey(
                name: "FK_Items_LocalRestaurants_localrestaurantsID",
                table: "Items",
                column: "localrestaurantsID",
                principalTable: "LocalRestaurants",
                principalColumn: "localrestaurantsID",
                onDelete: ReferentialAction.Cascade);
        }

        /// <inheritdoc />
        protected override void Down(MigrationBuilder migrationBuilder)
        {
            migrationBuilder.DropForeignKey(
                name: "FK_Items_LocalRestaurants_localrestaurantsID",
                table: "Items");

            migrationBuilder.DropIndex(
                name: "IX_Items_localrestaurantsID",
                table: "Items");

            migrationBuilder.DropColumn(
                name: "localrestaurantsID",
                table: "Items");

            migrationBuilder.RenameColumn(
                name: "Vehicle",
                table: "DeliveryPerson",
                newName: "Vehichle");
        }
    }
}
