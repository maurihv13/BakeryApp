using Microsoft.EntityFrameworkCore.Migrations;

#nullable disable

namespace BakeryApp.Infrastructure.Migrations
{
    /// <inheritdoc />
    public partial class FixedEntities : Migration
    {
        /// <inheritdoc />
        protected override void Up(MigrationBuilder migrationBuilder)
        {
            migrationBuilder.DropColumn(
                name: "BakeryOfficeId",
                table: "OrderLists");

            migrationBuilder.DropColumn(
                name: "OrderListId",
                table: "OrderDetails");

            migrationBuilder.DropColumn(
                name: "PreparationId",
                table: "Ingredients");

            migrationBuilder.DropColumn(
                name: "BakeryOfficeId",
                table: "Breads");
        }

        /// <inheritdoc />
        protected override void Down(MigrationBuilder migrationBuilder)
        {
            migrationBuilder.AddColumn<int>(
                name: "BakeryOfficeId",
                table: "OrderLists",
                type: "int",
                nullable: false,
                defaultValue: 0);

            migrationBuilder.AddColumn<int>(
                name: "OrderListId",
                table: "OrderDetails",
                type: "int",
                nullable: false,
                defaultValue: 0);

            migrationBuilder.AddColumn<int>(
                name: "PreparationId",
                table: "Ingredients",
                type: "int",
                nullable: false,
                defaultValue: 0);

            migrationBuilder.AddColumn<int>(
                name: "BakeryOfficeId",
                table: "Breads",
                type: "int",
                nullable: false,
                defaultValue: 0);
        }
    }
}
