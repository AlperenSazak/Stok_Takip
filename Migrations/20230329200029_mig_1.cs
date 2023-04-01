using Microsoft.EntityFrameworkCore.Migrations;

#nullable disable

namespace StokTakip.Migrations
{
    /// <inheritdoc />
    public partial class mig1 : Migration
    {
        /// <inheritdoc />
        protected override void Up(MigrationBuilder migrationBuilder)
        {
            migrationBuilder.CreateTable(
                name: "Currencies_Tbl",
                columns: table => new
                {
                    Id = table.Column<int>(type: "int", nullable: false)
                        .Annotation("SqlServer:Identity", "1, 1"),
                    Name = table.Column<string>(type: "nvarchar(10)", maxLength: 10, nullable: false)
                },
                constraints: table =>
                {
                    table.PrimaryKey("PK_Currencies_Tbl", x => x.Id);
                });

            migrationBuilder.CreateTable(
                name: "QuantityUnits_Tbl",
                columns: table => new
                {
                    Id = table.Column<int>(type: "int", nullable: false)
                        .Annotation("SqlServer:Identity", "1, 1"),
                    Name = table.Column<string>(type: "nvarchar(15)", maxLength: 15, nullable: false)
                },
                constraints: table =>
                {
                    table.PrimaryKey("PK_QuantityUnits_Tbl", x => x.Id);
                });

            migrationBuilder.CreateTable(
                name: "StockClasses_Tbl",
                columns: table => new
                {
                    Id = table.Column<int>(type: "int", nullable: false)
                        .Annotation("SqlServer:Identity", "1, 1"),
                    Name = table.Column<string>(type: "nvarchar(max)", nullable: false)
                },
                constraints: table =>
                {
                    table.PrimaryKey("PK_StockClasses_Tbl", x => x.Id);
                });

            migrationBuilder.CreateTable(
                name: "StockTypes_Tbl",
                columns: table => new
                {
                    Id = table.Column<int>(type: "int", nullable: false)
                        .Annotation("SqlServer:Identity", "1, 1"),
                    Name = table.Column<string>(type: "nvarchar(20)", maxLength: 20, nullable: false),
                    Status = table.Column<bool>(type: "bit", nullable: true)
                },
                constraints: table =>
                {
                    table.PrimaryKey("PK_StockTypes_Tbl", x => x.Id);
                });

            migrationBuilder.CreateTable(
                name: "StockUnits_Tbl",
                columns: table => new
                {
                    Id = table.Column<int>(type: "int", nullable: false)
                        .Annotation("SqlServer:Identity", "1, 1"),
                    UnitCode = table.Column<string>(type: "nvarchar(450)", nullable: false),
                    Description = table.Column<string>(type: "nvarchar(max)", nullable: false),
                    PurchasePrice = table.Column<decimal>(type: "decimal(18,2)", nullable: false),
                    SalePrice = table.Column<decimal>(type: "decimal(18,2)", nullable: false),
                    PaperWeight = table.Column<decimal>(type: "decimal(18,2)", nullable: false),
                    StockTypeId = table.Column<int>(type: "int", nullable: false),
                    QuantityUnitId = table.Column<int>(type: "int", nullable: false),
                    PurchaseCurrencyId = table.Column<int>(type: "int", nullable: false),
                    SalesCurrencyId = table.Column<int>(type: "int", nullable: false)
                },
                constraints: table =>
                {
                    table.PrimaryKey("PK_StockUnits_Tbl", x => x.Id);
                    table.ForeignKey(
                        name: "FK_StockUnits_Tbl_Currencies_Tbl_PurchaseCurrencyId",
                        column: x => x.PurchaseCurrencyId,
                        principalTable: "Currencies_Tbl",
                        principalColumn: "Id",
                        onDelete: ReferentialAction.Cascade);
                    table.ForeignKey(
                        name: "FK_StockUnits_Tbl_QuantityUnits_Tbl_QuantityUnitId",
                        column: x => x.QuantityUnitId,
                        principalTable: "QuantityUnits_Tbl",
                        principalColumn: "Id",
                        onDelete: ReferentialAction.Cascade);
                    table.ForeignKey(
                        name: "FK_StockUnits_Tbl_StockTypes_Tbl_StockTypeId",
                        column: x => x.StockTypeId,
                        principalTable: "StockTypes_Tbl",
                        principalColumn: "Id",
                        onDelete: ReferentialAction.Cascade);
                });

            migrationBuilder.CreateTable(
                name: "Stocks_Tbl",
                columns: table => new
                {
                    Id = table.Column<int>(type: "int", nullable: false)
                        .Annotation("SqlServer:Identity", "1, 1"),
                    StockClassId = table.Column<int>(type: "int", nullable: false),
                    StockTypeId = table.Column<int>(type: "int", nullable: false),
                    StockUnitId = table.Column<int>(type: "int", nullable: false),
                    Amount = table.Column<int>(type: "int", nullable: false),
                    ShelfInfo = table.Column<string>(type: "nvarchar(max)", nullable: false),
                    CupBoardInfo = table.Column<string>(type: "nvarchar(max)", nullable: false),
                    CriticalAmount = table.Column<int>(type: "int", nullable: false)
                },
                constraints: table =>
                {
                    table.PrimaryKey("PK_Stocks_Tbl", x => x.Id);
                    table.ForeignKey(
                        name: "FK_Stocks_Tbl_StockClasses_Tbl_StockClassId",
                        column: x => x.StockClassId,
                        principalTable: "StockClasses_Tbl",
                        principalColumn: "Id",
                        onDelete: ReferentialAction.Cascade);
                    table.ForeignKey(
                        name: "FK_Stocks_Tbl_StockUnits_Tbl_StockUnitId",
                        column: x => x.StockUnitId,
                        principalTable: "StockUnits_Tbl",
                        principalColumn: "Id",
                        onDelete: ReferentialAction.Cascade);
                });

            migrationBuilder.CreateIndex(
                name: "IX_Stocks_Tbl_StockClassId",
                table: "Stocks_Tbl",
                column: "StockClassId");

            migrationBuilder.CreateIndex(
                name: "IX_Stocks_Tbl_StockUnitId",
                table: "Stocks_Tbl",
                column: "StockUnitId");

            migrationBuilder.CreateIndex(
                name: "IX_StockTypes_Tbl_Name",
                table: "StockTypes_Tbl",
                column: "Name",
                unique: true);

            migrationBuilder.CreateIndex(
                name: "IX_StockUnits_Tbl_PurchaseCurrencyId",
                table: "StockUnits_Tbl",
                column: "PurchaseCurrencyId");

            migrationBuilder.CreateIndex(
                name: "IX_StockUnits_Tbl_QuantityUnitId",
                table: "StockUnits_Tbl",
                column: "QuantityUnitId");

            migrationBuilder.CreateIndex(
                name: "IX_StockUnits_Tbl_StockTypeId",
                table: "StockUnits_Tbl",
                column: "StockTypeId");

            migrationBuilder.CreateIndex(
                name: "IX_StockUnits_Tbl_UnitCode",
                table: "StockUnits_Tbl",
                column: "UnitCode");
        }

        /// <inheritdoc />
        protected override void Down(MigrationBuilder migrationBuilder)
        {
            migrationBuilder.DropTable(
                name: "Stocks_Tbl");

            migrationBuilder.DropTable(
                name: "StockClasses_Tbl");

            migrationBuilder.DropTable(
                name: "StockUnits_Tbl");

            migrationBuilder.DropTable(
                name: "Currencies_Tbl");

            migrationBuilder.DropTable(
                name: "QuantityUnits_Tbl");

            migrationBuilder.DropTable(
                name: "StockTypes_Tbl");
        }
    }
}
