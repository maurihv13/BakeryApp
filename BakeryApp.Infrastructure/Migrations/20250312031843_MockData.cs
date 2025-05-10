using Microsoft.EntityFrameworkCore.Migrations;

#nullable disable

#pragma warning disable CA1814 // Prefer jagged arrays over multidimensional

namespace BakeryApp.Infrastructure.Migrations
{
    /// <inheritdoc />
    public partial class MockData : Migration
    {
        /// <inheritdoc />
        protected override void Up(MigrationBuilder migrationBuilder)
        {
            migrationBuilder.DropForeignKey(
                name: "FK_Breads_BakeryOffices_BakeryOfficeEntityId",
                table: "Breads");

            migrationBuilder.DropIndex(
                name: "IX_Breads_BakeryOfficeEntityId",
                table: "Breads");

            migrationBuilder.DropColumn(
                name: "BakeryOfficeEntityId",
                table: "Breads");

            migrationBuilder.AddColumn<double>(
                name: "Price",
                table: "Breads",
                type: "float",
                nullable: false,
                defaultValue: 0.0);

            migrationBuilder.CreateTable(
                name: "BakeryOfficeBread",
                columns: table => new
                {
                    BakeryOfficesId = table.Column<int>(type: "int", nullable: false),
                    MenuId = table.Column<int>(type: "int", nullable: false)
                },
                constraints: table =>
                {
                    table.PrimaryKey("PK_BakeryOfficeBread", x => new { x.BakeryOfficesId, x.MenuId });
                    table.ForeignKey(
                        name: "FK_BakeryOfficeBread_BakeryOffices_BakeryOfficesId",
                        column: x => x.BakeryOfficesId,
                        principalTable: "BakeryOffices",
                        principalColumn: "Id",
                        onDelete: ReferentialAction.Cascade);
                    table.ForeignKey(
                        name: "FK_BakeryOfficeBread_Breads_MenuId",
                        column: x => x.MenuId,
                        principalTable: "Breads",
                        principalColumn: "Id",
                        onDelete: ReferentialAction.Cascade);
                });

            migrationBuilder.InsertData(
                table: "BakeryOffices",
                columns: new[] { "Id", "Address", "MaxCapacity", "Name" },
                values: new object[,]
                {
                    { 1, "742 Evergreen Terrace", 150, "Main Office" },
                    { 2, "P. Sherman, 42 Wallaby, Sydney", 100, "Second Office" }
                });

            migrationBuilder.InsertData(
                table: "Preparations",
                columns: new[] { "Id", "CookingTemp", "CookingTime", "FermentTime", "RestingTime" },
                values: new object[,]
                {
                    { 1, "270°C", "15 minutes", "1 day", "0.5 hours" },
                    { 2, "180°C", "30 minutes", "4 hours", "1 hour" },
                    { 3, "180°C", "15 minutes", "4 hours", "10 minutes" },
                    { 6, "180°C", "15 minutes", "4 hours", "0.5 hour" }
                });

            migrationBuilder.InsertData(
                table: "Breads",
                columns: new[] { "Id", "Name", "PreparationId", "Price" },
                values: new object[,]
                {
                    { 1, "Baguette", 1, 2.0 },
                    { 2, "White Bread", 2, 2.5 },
                    { 3, "Milk Bread", 3, 1.5 },
                    { 6, "Hamburguer Bun", 6, 1.0 }
                });

            migrationBuilder.InsertData(
                table: "BakeryOfficeBread",
                columns: new[] { "BakeryOfficesId", "MenuId" },
                values: new object[,]
                {
                    { 1, 1 },
                    { 1, 2 },
                    { 1, 3 },
                    { 2, 1 },
                    { 2, 2 },
                    { 2, 6 }
                });

            migrationBuilder.CreateIndex(
                name: "IX_BakeryOfficeBread_MenuId",
                table: "BakeryOfficeBread",
                column: "MenuId");
        }

        /// <inheritdoc />
        protected override void Down(MigrationBuilder migrationBuilder)
        {
            migrationBuilder.DropTable(
                name: "BakeryOfficeBread");

            migrationBuilder.DeleteData(
                table: "BakeryOffices",
                keyColumn: "Id",
                keyValue: 1);

            migrationBuilder.DeleteData(
                table: "BakeryOffices",
                keyColumn: "Id",
                keyValue: 2);

            migrationBuilder.DeleteData(
                table: "Breads",
                keyColumn: "Id",
                keyValue: 1);

            migrationBuilder.DeleteData(
                table: "Breads",
                keyColumn: "Id",
                keyValue: 2);

            migrationBuilder.DeleteData(
                table: "Breads",
                keyColumn: "Id",
                keyValue: 3);

            migrationBuilder.DeleteData(
                table: "Breads",
                keyColumn: "Id",
                keyValue: 6);

            migrationBuilder.DeleteData(
                table: "Preparations",
                keyColumn: "Id",
                keyValue: 1);

            migrationBuilder.DeleteData(
                table: "Preparations",
                keyColumn: "Id",
                keyValue: 2);

            migrationBuilder.DeleteData(
                table: "Preparations",
                keyColumn: "Id",
                keyValue: 3);

            migrationBuilder.DeleteData(
                table: "Preparations",
                keyColumn: "Id",
                keyValue: 6);

            migrationBuilder.DropColumn(
                name: "Price",
                table: "Breads");

            migrationBuilder.AddColumn<int>(
                name: "BakeryOfficeEntityId",
                table: "Breads",
                type: "int",
                nullable: true);

            migrationBuilder.CreateIndex(
                name: "IX_Breads_BakeryOfficeEntityId",
                table: "Breads",
                column: "BakeryOfficeEntityId");

            migrationBuilder.AddForeignKey(
                name: "FK_Breads_BakeryOffices_BakeryOfficeEntityId",
                table: "Breads",
                column: "BakeryOfficeEntityId",
                principalTable: "BakeryOffices",
                principalColumn: "Id");
        }
    }
}
