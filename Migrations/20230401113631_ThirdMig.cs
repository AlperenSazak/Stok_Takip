using Microsoft.EntityFrameworkCore.Migrations;

#nullable disable

namespace StokTakip.Migrations
{
    /// <inheritdoc />
    public partial class ThirdMig : Migration
    {
        /// <inheritdoc />
        protected override void Up(MigrationBuilder migrationBuilder)
        {
            migrationBuilder.AlterColumn<string>(
                name: "UnitCode",
                table: "StockUnits_Tbl",
                type: "nvarchar(450)",
                nullable: false,
                oldClrType: typeof(string),
                oldType: "nvarchar(max)");

            migrationBuilder.AlterColumn<string>(
                name: "Name",
                table: "StockClasses_Tbl",
                type: "nvarchar(450)",
                nullable: false,
                oldClrType: typeof(string),
                oldType: "nvarchar(max)");

            migrationBuilder.CreateIndex(
                name: "IX_StockUnits_Tbl_UnitCode",
                table: "StockUnits_Tbl",
                column: "UnitCode",
                unique: true);

            migrationBuilder.CreateIndex(
                name: "IX_StockClasses_Tbl_Name",
                table: "StockClasses_Tbl",
                column: "Name",
                unique: true);

            migrationBuilder.CreateIndex(
                name: "IX_QuantityUnits_Tbl_Name",
                table: "QuantityUnits_Tbl",
                column: "Name",
                unique: true);

            migrationBuilder.CreateIndex(
                name: "IX_Currencies_Tbl_Name",
                table: "Currencies_Tbl",
                column: "Name",
                unique: true);
        }

        /// <inheritdoc />
        protected override void Down(MigrationBuilder migrationBuilder)
        {
            migrationBuilder.DropIndex(
                name: "IX_StockUnits_Tbl_UnitCode",
                table: "StockUnits_Tbl");

            migrationBuilder.DropIndex(
                name: "IX_StockClasses_Tbl_Name",
                table: "StockClasses_Tbl");

            migrationBuilder.DropIndex(
                name: "IX_QuantityUnits_Tbl_Name",
                table: "QuantityUnits_Tbl");

            migrationBuilder.DropIndex(
                name: "IX_Currencies_Tbl_Name",
                table: "Currencies_Tbl");

            migrationBuilder.AlterColumn<string>(
                name: "UnitCode",
                table: "StockUnits_Tbl",
                type: "nvarchar(max)",
                nullable: false,
                oldClrType: typeof(string),
                oldType: "nvarchar(450)");

            migrationBuilder.AlterColumn<string>(
                name: "Name",
                table: "StockClasses_Tbl",
                type: "nvarchar(max)",
                nullable: false,
                oldClrType: typeof(string),
                oldType: "nvarchar(450)");
        }
    }
}
