using Microsoft.EntityFrameworkCore.Migrations;

#nullable disable

namespace Food2U.Migrations
{
    /// <inheritdoc />
    public partial class AddShopperCart : Migration
    {
        /// <inheritdoc />
        protected override void Up(MigrationBuilder migrationBuilder)
        {
            migrationBuilder.AddColumn<int>(
                name: "shoppersID",
                table: "Items",
                type: "INTEGER",
                nullable: true);

            migrationBuilder.CreateIndex(
                name: "IX_Items_shoppersID",
                table: "Items",
                column: "shoppersID");

            migrationBuilder.AddForeignKey(
                name: "FK_Items_Shoppers_shoppersID",
                table: "Items",
                column: "shoppersID",
                principalTable: "Shoppers",
                principalColumn: "shoppersID");
        }

        /// <inheritdoc />
        protected override void Down(MigrationBuilder migrationBuilder)
        {
            migrationBuilder.DropForeignKey(
                name: "FK_Items_Shoppers_shoppersID",
                table: "Items");

            migrationBuilder.DropIndex(
                name: "IX_Items_shoppersID",
                table: "Items");

            migrationBuilder.DropColumn(
                name: "shoppersID",
                table: "Items");
        }
    }
}
