using Microsoft.EntityFrameworkCore.Migrations;

#nullable disable

namespace BakeryApp.Infrastructure.Migrations
{
    /// <inheritdoc />
    public partial class InitialDb : Migration
    {
        /// <inheritdoc />
        protected override void Up(MigrationBuilder migrationBuilder)
        {
            migrationBuilder.CreateTable(
                name: "BakeryOffices",
                columns: table => new
                {
                    Id = table.Column<int>(type: "int", nullable: false)
                        .Annotation("SqlServer:Identity", "1, 1"),
                    Name = table.Column<string>(type: "nvarchar(max)", nullable: false),
                    Address = table.Column<string>(type: "nvarchar(max)", nullable: false),
                    MaxCapacity = table.Column<int>(type: "int", nullable: false)
                },
                constraints: table =>
                {
                    table.PrimaryKey("PK_BakeryOffices", x => x.Id);
                });

            migrationBuilder.CreateTable(
                name: "Preparations",
                columns: table => new
                {
                    Id = table.Column<int>(type: "int", nullable: false)
                        .Annotation("SqlServer:Identity", "1, 1"),
                    CookingTime = table.Column<string>(type: "nvarchar(max)", nullable: false),
                    RestingTime = table.Column<string>(type: "nvarchar(max)", nullable: false),
                    FermentTime = table.Column<string>(type: "nvarchar(max)", nullable: false),
                    CookingTemp = table.Column<string>(type: "nvarchar(max)", nullable: false)
                },
                constraints: table =>
                {
                    table.PrimaryKey("PK_Preparations", x => x.Id);
                });

            migrationBuilder.CreateTable(
                name: "OrderLists",
                columns: table => new
                {
                    Id = table.Column<int>(type: "int", nullable: false)
                        .Annotation("SqlServer:Identity", "1, 1"),
                    CustomerName = table.Column<string>(type: "nvarchar(max)", nullable: false),
                    BakeryOfficeId = table.Column<int>(type: "int", nullable: false),
                    BakeryOfficeEntityId = table.Column<int>(type: "int", nullable: true)
                },
                constraints: table =>
                {
                    table.PrimaryKey("PK_OrderLists", x => x.Id);
                    table.ForeignKey(
                        name: "FK_OrderLists_BakeryOffices_BakeryOfficeEntityId",
                        column: x => x.BakeryOfficeEntityId,
                        principalTable: "BakeryOffices",
                        principalColumn: "Id");
                });

            migrationBuilder.CreateTable(
                name: "Breads",
                columns: table => new
                {
                    Id = table.Column<int>(type: "int", nullable: false)
                        .Annotation("SqlServer:Identity", "1, 1"),
                    Name = table.Column<string>(type: "nvarchar(max)", nullable: false),
                    PreparationId = table.Column<int>(type: "int", nullable: false),
                    BakeryOfficeId = table.Column<int>(type: "int", nullable: false),
                    BakeryOfficeEntityId = table.Column<int>(type: "int", nullable: true)
                },
                constraints: table =>
                {
                    table.PrimaryKey("PK_Breads", x => x.Id);
                    table.ForeignKey(
                        name: "FK_Breads_BakeryOffices_BakeryOfficeEntityId",
                        column: x => x.BakeryOfficeEntityId,
                        principalTable: "BakeryOffices",
                        principalColumn: "Id");
                    table.ForeignKey(
                        name: "FK_Breads_Preparations_PreparationId",
                        column: x => x.PreparationId,
                        principalTable: "Preparations",
                        principalColumn: "Id",
                        onDelete: ReferentialAction.Cascade);
                });

            migrationBuilder.CreateTable(
                name: "Ingredients",
                columns: table => new
                {
                    Id = table.Column<int>(type: "int", nullable: false)
                        .Annotation("SqlServer:Identity", "1, 1"),
                    Name = table.Column<string>(type: "nvarchar(max)", nullable: false),
                    Quantity = table.Column<int>(type: "int", nullable: false),
                    Unit = table.Column<string>(type: "nvarchar(max)", nullable: false),
                    PreparationId = table.Column<int>(type: "int", nullable: false),
                    PreparationEntityId = table.Column<int>(type: "int", nullable: true)
                },
                constraints: table =>
                {
                    table.PrimaryKey("PK_Ingredients", x => x.Id);
                    table.ForeignKey(
                        name: "FK_Ingredients_Preparations_PreparationEntityId",
                        column: x => x.PreparationEntityId,
                        principalTable: "Preparations",
                        principalColumn: "Id");
                });

            migrationBuilder.CreateTable(
                name: "OrderDetails",
                columns: table => new
                {
                    Id = table.Column<int>(type: "int", nullable: false)
                        .Annotation("SqlServer:Identity", "1, 1"),
                    BreadId = table.Column<int>(type: "int", nullable: false),
                    Amount = table.Column<int>(type: "int", nullable: false),
                    OrderListId = table.Column<int>(type: "int", nullable: false),
                    OrderListEntityId = table.Column<int>(type: "int", nullable: true)
                },
                constraints: table =>
                {
                    table.PrimaryKey("PK_OrderDetails", x => x.Id);
                    table.ForeignKey(
                        name: "FK_OrderDetails_Breads_BreadId",
                        column: x => x.BreadId,
                        principalTable: "Breads",
                        principalColumn: "Id",
                        onDelete: ReferentialAction.Cascade);
                    table.ForeignKey(
                        name: "FK_OrderDetails_OrderLists_OrderListEntityId",
                        column: x => x.OrderListEntityId,
                        principalTable: "OrderLists",
                        principalColumn: "Id");
                });

            migrationBuilder.CreateIndex(
                name: "IX_Breads_BakeryOfficeEntityId",
                table: "Breads",
                column: "BakeryOfficeEntityId");

            migrationBuilder.CreateIndex(
                name: "IX_Breads_PreparationId",
                table: "Breads",
                column: "PreparationId");

            migrationBuilder.CreateIndex(
                name: "IX_Ingredients_PreparationEntityId",
                table: "Ingredients",
                column: "PreparationEntityId");

            migrationBuilder.CreateIndex(
                name: "IX_OrderDetails_BreadId",
                table: "OrderDetails",
                column: "BreadId");

            migrationBuilder.CreateIndex(
                name: "IX_OrderDetails_OrderListEntityId",
                table: "OrderDetails",
                column: "OrderListEntityId");

            migrationBuilder.CreateIndex(
                name: "IX_OrderLists_BakeryOfficeEntityId",
                table: "OrderLists",
                column: "BakeryOfficeEntityId");
        }

        /// <inheritdoc />
        protected override void Down(MigrationBuilder migrationBuilder)
        {
            migrationBuilder.DropTable(
                name: "Ingredients");

            migrationBuilder.DropTable(
                name: "OrderDetails");

            migrationBuilder.DropTable(
                name: "Breads");

            migrationBuilder.DropTable(
                name: "OrderLists");

            migrationBuilder.DropTable(
                name: "Preparations");

            migrationBuilder.DropTable(
                name: "BakeryOffices");
        }
    }
}
