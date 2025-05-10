using Microsoft.EntityFrameworkCore.Migrations;

#nullable disable

#pragma warning disable CA1814 // Prefer jagged arrays over multidimensional

namespace BakeryApp.Infrastructure.Migrations
{
    /// <inheritdoc />
    public partial class ChangeBreadEntity : Migration
    {
        /// <inheritdoc />
        protected override void Up(MigrationBuilder migrationBuilder)
        {
            migrationBuilder.DropForeignKey(
                name: "FK_BakeryOfficeBread_Breads_MenuId",
                table: "BakeryOfficeBread");

            migrationBuilder.DropForeignKey(
                name: "FK_OrderDetails_Breads_BreadId",
                table: "OrderDetails");

            migrationBuilder.DropIndex(
                name: "IX_OrderDetails_BreadId",
                table: "OrderDetails");

            migrationBuilder.DropPrimaryKey(
                name: "PK_Breads",
                table: "Breads");

            migrationBuilder.DropPrimaryKey(
                name: "PK_BakeryOfficeBread",
                table: "BakeryOfficeBread");

            migrationBuilder.DropIndex(
                name: "IX_BakeryOfficeBread_MenuId",
                table: "BakeryOfficeBread");

            migrationBuilder.DeleteData(
                table: "BakeryOfficeBread",
                keyColumns: new[] { "BakeryOfficesId", "MenuId" },
                keyColumnTypes: new[] { "int", "int" },
                keyValues: new object[] { 1, 1 });

            migrationBuilder.DeleteData(
                table: "BakeryOfficeBread",
                keyColumns: new[] { "BakeryOfficesId", "MenuId" },
                keyColumnTypes: new[] { "int", "int" },
                keyValues: new object[] { 1, 2 });

            migrationBuilder.DeleteData(
                table: "BakeryOfficeBread",
                keyColumns: new[] { "BakeryOfficesId", "MenuId" },
                keyColumnTypes: new[] { "int", "int" },
                keyValues: new object[] { 1, 3 });

            migrationBuilder.DeleteData(
                table: "BakeryOfficeBread",
                keyColumns: new[] { "BakeryOfficesId", "MenuId" },
                keyColumnTypes: new[] { "int", "int" },
                keyValues: new object[] { 2, 1 });

            migrationBuilder.DeleteData(
                table: "BakeryOfficeBread",
                keyColumns: new[] { "BakeryOfficesId", "MenuId" },
                keyColumnTypes: new[] { "int", "int" },
                keyValues: new object[] { 2, 2 });

            migrationBuilder.DeleteData(
                table: "BakeryOfficeBread",
                keyColumns: new[] { "BakeryOfficesId", "MenuId" },
                keyColumnTypes: new[] { "int", "int" },
                keyValues: new object[] { 2, 6 });

            migrationBuilder.DeleteData(
                table: "Breads",
                keyColumn: "Id",
                keyColumnType: "int",
                keyValue: 1);

            migrationBuilder.DeleteData(
                table: "Breads",
                keyColumn: "Id",
                keyColumnType: "int",
                keyValue: 2);

            migrationBuilder.DeleteData(
                table: "Breads",
                keyColumn: "Id",
                keyColumnType: "int",
                keyValue: 3);

            migrationBuilder.DeleteData(
                table: "Breads",
                keyColumn: "Id",
                keyColumnType: "int",
                keyValue: 6);

            migrationBuilder.DropColumn(
                name: "Id",
                table: "Breads");

            migrationBuilder.DropColumn(
                name: "MenuId",
                table: "BakeryOfficeBread");

            migrationBuilder.AddColumn<string>(
                name: "BreadName",
                table: "OrderDetails",
                type: "nvarchar(450)",
                nullable: false,
                defaultValue: "");

            migrationBuilder.AlterColumn<string>(
                name: "Name",
                table: "Breads",
                type: "nvarchar(450)",
                nullable: false,
                oldClrType: typeof(string),
                oldType: "nvarchar(max)");

            migrationBuilder.AddColumn<string>(
                name: "MenuName",
                table: "BakeryOfficeBread",
                type: "nvarchar(450)",
                nullable: false,
                defaultValue: "");

            migrationBuilder.AddPrimaryKey(
                name: "PK_Breads",
                table: "Breads",
                column: "Name");

            migrationBuilder.AddPrimaryKey(
                name: "PK_BakeryOfficeBread",
                table: "BakeryOfficeBread",
                columns: new[] { "BakeryOfficesId", "MenuName" });

            migrationBuilder.InsertData(
                table: "Breads",
                columns: new[] { "Name", "PreparationId", "Price" },
                values: new object[,]
                {
                    { "Baguette", 1, 2.0 },
                    { "Hamburguer Bun", 6, 1.0 },
                    { "Milk Bread", 3, 1.5 },
                    { "White Bread", 2, 2.5 }
                });

            migrationBuilder.InsertData(
                table: "BakeryOfficeBread",
                columns: new[] { "BakeryOfficesId", "MenuName" },
                values: new object[,]
                {
                    { 1, "Baguette" },
                    { 1, "Milk Bread" },
                    { 1, "White Bread" },
                    { 2, "Baguette" },
                    { 2, "Hamburguer Bun" },
                    { 2, "White Bread" }
                });

            migrationBuilder.CreateIndex(
                name: "IX_OrderDetails_BreadName",
                table: "OrderDetails",
                column: "BreadName");

            migrationBuilder.CreateIndex(
                name: "IX_BakeryOfficeBread_MenuName",
                table: "BakeryOfficeBread",
                column: "MenuName");

            migrationBuilder.AddForeignKey(
                name: "FK_BakeryOfficeBread_Breads_MenuName",
                table: "BakeryOfficeBread",
                column: "MenuName",
                principalTable: "Breads",
                principalColumn: "Name",
                onDelete: ReferentialAction.Cascade);

            migrationBuilder.AddForeignKey(
                name: "FK_OrderDetails_Breads_BreadName",
                table: "OrderDetails",
                column: "BreadName",
                principalTable: "Breads",
                principalColumn: "Name",
                onDelete: ReferentialAction.Cascade);
        }

        /// <inheritdoc />
        protected override void Down(MigrationBuilder migrationBuilder)
        {
            migrationBuilder.DropForeignKey(
                name: "FK_BakeryOfficeBread_Breads_MenuName",
                table: "BakeryOfficeBread");

            migrationBuilder.DropForeignKey(
                name: "FK_OrderDetails_Breads_BreadName",
                table: "OrderDetails");

            migrationBuilder.DropIndex(
                name: "IX_OrderDetails_BreadName",
                table: "OrderDetails");

            migrationBuilder.DropPrimaryKey(
                name: "PK_Breads",
                table: "Breads");

            migrationBuilder.DropPrimaryKey(
                name: "PK_BakeryOfficeBread",
                table: "BakeryOfficeBread");

            migrationBuilder.DropIndex(
                name: "IX_BakeryOfficeBread_MenuName",
                table: "BakeryOfficeBread");

            migrationBuilder.DeleteData(
                table: "BakeryOfficeBread",
                keyColumns: new[] { "BakeryOfficesId", "MenuName" },
                keyColumnTypes: new[] { "int", "nvarchar(450)" },
                keyValues: new object[] { 1, "Baguette" });

            migrationBuilder.DeleteData(
                table: "BakeryOfficeBread",
                keyColumns: new[] { "BakeryOfficesId", "MenuName" },
                keyColumnTypes: new[] { "int", "nvarchar(450)" },
                keyValues: new object[] { 1, "Milk Bread" });

            migrationBuilder.DeleteData(
                table: "BakeryOfficeBread",
                keyColumns: new[] { "BakeryOfficesId", "MenuName" },
                keyColumnTypes: new[] { "int", "nvarchar(450)" },
                keyValues: new object[] { 1, "White Bread" });

            migrationBuilder.DeleteData(
                table: "BakeryOfficeBread",
                keyColumns: new[] { "BakeryOfficesId", "MenuName" },
                keyColumnTypes: new[] { "int", "nvarchar(450)" },
                keyValues: new object[] { 2, "Baguette" });

            migrationBuilder.DeleteData(
                table: "BakeryOfficeBread",
                keyColumns: new[] { "BakeryOfficesId", "MenuName" },
                keyColumnTypes: new[] { "int", "nvarchar(450)" },
                keyValues: new object[] { 2, "Hamburguer Bun" });

            migrationBuilder.DeleteData(
                table: "BakeryOfficeBread",
                keyColumns: new[] { "BakeryOfficesId", "MenuName" },
                keyColumnTypes: new[] { "int", "nvarchar(450)" },
                keyValues: new object[] { 2, "White Bread" });

            migrationBuilder.DeleteData(
                table: "Breads",
                keyColumn: "Name",
                keyValue: "Baguette");

            migrationBuilder.DeleteData(
                table: "Breads",
                keyColumn: "Name",
                keyValue: "Hamburguer Bun");

            migrationBuilder.DeleteData(
                table: "Breads",
                keyColumn: "Name",
                keyValue: "Milk Bread");

            migrationBuilder.DeleteData(
                table: "Breads",
                keyColumn: "Name",
                keyValue: "White Bread");

            migrationBuilder.DropColumn(
                name: "BreadName",
                table: "OrderDetails");

            migrationBuilder.DropColumn(
                name: "MenuName",
                table: "BakeryOfficeBread");

            migrationBuilder.AlterColumn<string>(
                name: "Name",
                table: "Breads",
                type: "nvarchar(max)",
                nullable: false,
                oldClrType: typeof(string),
                oldType: "nvarchar(450)");

            migrationBuilder.AddColumn<int>(
                name: "Id",
                table: "Breads",
                type: "int",
                nullable: false,
                defaultValue: 0)
                .Annotation("SqlServer:Identity", "1, 1");

            migrationBuilder.AddColumn<int>(
                name: "MenuId",
                table: "BakeryOfficeBread",
                type: "int",
                nullable: false,
                defaultValue: 0);

            migrationBuilder.AddPrimaryKey(
                name: "PK_Breads",
                table: "Breads",
                column: "Id");

            migrationBuilder.AddPrimaryKey(
                name: "PK_BakeryOfficeBread",
                table: "BakeryOfficeBread",
                columns: new[] { "BakeryOfficesId", "MenuId" });

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
                name: "IX_OrderDetails_BreadId",
                table: "OrderDetails",
                column: "BreadId");

            migrationBuilder.CreateIndex(
                name: "IX_BakeryOfficeBread_MenuId",
                table: "BakeryOfficeBread",
                column: "MenuId");

            migrationBuilder.AddForeignKey(
                name: "FK_BakeryOfficeBread_Breads_MenuId",
                table: "BakeryOfficeBread",
                column: "MenuId",
                principalTable: "Breads",
                principalColumn: "Id",
                onDelete: ReferentialAction.Cascade);

            migrationBuilder.AddForeignKey(
                name: "FK_OrderDetails_Breads_BreadId",
                table: "OrderDetails",
                column: "BreadId",
                principalTable: "Breads",
                principalColumn: "Id",
                onDelete: ReferentialAction.Cascade);
        }
    }
}
