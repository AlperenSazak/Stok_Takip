using Microsoft.EntityFrameworkCore.Migrations;

#nullable disable

namespace StokTakip.Migrations
{
    /// <inheritdoc />
    public partial class Second : Migration
    {
        /// <inheritdoc />
        protected override void Up(MigrationBuilder migrationBuilder)
        {
            migrationBuilder.DropForeignKey(
                name: "FK_Stocks_Tbl_StockClasses_Tbl_StockClassId",
                table: "Stocks_Tbl");

            migrationBuilder.DropForeignKey(
                name: "FK_Stocks_Tbl_StockUnits_Tbl_StockUnitId",
                table: "Stocks_Tbl");

            migrationBuilder.DropForeignKey(
                name: "FK_StockUnits_Tbl_Currencies_Tbl_PurchaseCurrencyId",
                table: "StockUnits_Tbl");

            migrationBuilder.DropForeignKey(
                name: "FK_StockUnits_Tbl_QuantityUnits_Tbl_QuantityUnitId",
                table: "StockUnits_Tbl");

            migrationBuilder.DropForeignKey(
                name: "FK_StockUnits_Tbl_StockTypes_Tbl_StockTypeId",
                table: "StockUnits_Tbl");

            migrationBuilder.DropIndex(
                name: "IX_StockUnits_Tbl_PurchaseCurrencyId",
                table: "StockUnits_Tbl");

            migrationBuilder.DropIndex(
                name: "IX_StockUnits_Tbl_QuantityUnitId",
                table: "StockUnits_Tbl");

            migrationBuilder.DropIndex(
                name: "IX_StockUnits_Tbl_StockTypeId",
                table: "StockUnits_Tbl");

            migrationBuilder.DropIndex(
                name: "IX_StockUnits_Tbl_UnitCode",
                table: "StockUnits_Tbl");

            migrationBuilder.DropIndex(
                name: "IX_Stocks_Tbl_StockClassId",
                table: "Stocks_Tbl");

            migrationBuilder.DropIndex(
                name: "IX_Stocks_Tbl_StockUnitId",
                table: "Stocks_Tbl");

            migrationBuilder.AlterColumn<string>(
                name: "UnitCode",
                table: "StockUnits_Tbl",
                type: "nvarchar(max)",
                nullable: false,
                oldClrType: typeof(string),
                oldType: "nvarchar(450)");

            migrationBuilder.AlterColumn<bool>(
                name: "Status",
                table: "StockTypes_Tbl",
                type: "bit",
                nullable: false,
                defaultValue: false,
                oldClrType: typeof(bool),
                oldType: "bit",
                oldNullable: true);
        }

        /// <inheritdoc />
        protected override void Down(MigrationBuilder migrationBuilder)
        {
            migrationBuilder.AlterColumn<string>(
                name: "UnitCode",
                table: "StockUnits_Tbl",
                type: "nvarchar(450)",
                nullable: false,
                oldClrType: typeof(string),
                oldType: "nvarchar(max)");

            migrationBuilder.AlterColumn<bool>(
                name: "Status",
                table: "StockTypes_Tbl",
                type: "bit",
                nullable: true,
                oldClrType: typeof(bool),
                oldType: "bit");

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

            migrationBuilder.CreateIndex(
                name: "IX_Stocks_Tbl_StockClassId",
                table: "Stocks_Tbl",
                column: "StockClassId");

            migrationBuilder.CreateIndex(
                name: "IX_Stocks_Tbl_StockUnitId",
                table: "Stocks_Tbl",
                column: "StockUnitId");

            migrationBuilder.AddForeignKey(
                name: "FK_Stocks_Tbl_StockClasses_Tbl_StockClassId",
                table: "Stocks_Tbl",
                column: "StockClassId",
                principalTable: "StockClasses_Tbl",
                principalColumn: "Id",
                onDelete: ReferentialAction.Cascade);

            migrationBuilder.AddForeignKey(
                name: "FK_Stocks_Tbl_StockUnits_Tbl_StockUnitId",
                table: "Stocks_Tbl",
                column: "StockUnitId",
                principalTable: "StockUnits_Tbl",
                principalColumn: "Id",
                onDelete: ReferentialAction.Cascade);

            migrationBuilder.AddForeignKey(
                name: "FK_StockUnits_Tbl_Currencies_Tbl_PurchaseCurrencyId",
                table: "StockUnits_Tbl",
                column: "PurchaseCurrencyId",
                principalTable: "Currencies_Tbl",
                principalColumn: "Id",
                onDelete: ReferentialAction.Cascade);

            migrationBuilder.AddForeignKey(
                name: "FK_StockUnits_Tbl_QuantityUnits_Tbl_QuantityUnitId",
                table: "StockUnits_Tbl",
                column: "QuantityUnitId",
                principalTable: "QuantityUnits_Tbl",
                principalColumn: "Id",
                onDelete: ReferentialAction.Cascade);

            migrationBuilder.AddForeignKey(
                name: "FK_StockUnits_Tbl_StockTypes_Tbl_StockTypeId",
                table: "StockUnits_Tbl",
                column: "StockTypeId",
                principalTable: "StockTypes_Tbl",
                principalColumn: "Id",
                onDelete: ReferentialAction.Cascade);
        }
    }
}
