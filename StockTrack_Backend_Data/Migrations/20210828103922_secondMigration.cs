using Microsoft.EntityFrameworkCore.Migrations;

namespace StockTrack_Backend_Data.Migrations
{
    public partial class secondMigration : Migration
    {
        protected override void Up(MigrationBuilder migrationBuilder)
        {
            migrationBuilder.DropForeignKey(
                name: "FK_Orders_Plants_PlantId",
                table: "Orders");

            migrationBuilder.AddColumn<int>(
                name: "PlantId",
                table: "Plants",
                type: "int",
                nullable: false,
                defaultValue: 0);

            migrationBuilder.AddUniqueConstraint(
                name: "AK_Plants_PlantId",
                table: "Plants",
                column: "PlantId");

            migrationBuilder.AddForeignKey(
                name: "FK_Orders_Plants_PlantId",
                table: "Orders",
                column: "PlantId",
                principalTable: "Plants",
                principalColumn: "PlantId",
                onDelete: ReferentialAction.Cascade);
        }

        protected override void Down(MigrationBuilder migrationBuilder)
        {
            migrationBuilder.DropForeignKey(
                name: "FK_Orders_Plants_PlantId",
                table: "Orders");

            migrationBuilder.DropUniqueConstraint(
                name: "AK_Plants_PlantId",
                table: "Plants");

            migrationBuilder.DropColumn(
                name: "PlantId",
                table: "Plants");

            migrationBuilder.AddForeignKey(
                name: "FK_Orders_Plants_PlantId",
                table: "Orders",
                column: "PlantId",
                principalTable: "Plants",
                principalColumn: "ID",
                onDelete: ReferentialAction.Cascade);
        }
    }
}
