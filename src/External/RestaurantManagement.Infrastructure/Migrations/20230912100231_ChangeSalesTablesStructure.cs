using Microsoft.EntityFrameworkCore.Migrations;

#nullable disable

namespace RestaurantManagement.Infrastructure.Migrations
{
    /// <inheritdoc />
    public partial class ChangeSalesTablesStructure : Migration
    {
        /// <inheritdoc />
        protected override void Up(MigrationBuilder migrationBuilder)
        {
            migrationBuilder.DropColumn(
                name: "Addons",
                table: "SalesLines");

            migrationBuilder.DropColumn(
                name: "DiscountApplied",
                table: "SalesLines");

            migrationBuilder.DropColumn(
                name: "SalesPrice",
                table: "SalesLines");

            migrationBuilder.DropColumn(
                name: "Size",
                table: "SalesLines");

            migrationBuilder.AddColumn<int>(
                name: "SizeId",
                table: "SalesLines",
                type: "int",
                nullable: false,
                defaultValue: 0);
        }

        /// <inheritdoc />
        protected override void Down(MigrationBuilder migrationBuilder)
        {
            migrationBuilder.DropColumn(
                name: "SizeId",
                table: "SalesLines");

            migrationBuilder.AddColumn<string>(
                name: "Addons",
                table: "SalesLines",
                type: "nvarchar(max)",
                nullable: false,
                defaultValue: "");

            migrationBuilder.AddColumn<int>(
                name: "DiscountApplied",
                table: "SalesLines",
                type: "int",
                nullable: true);

            migrationBuilder.AddColumn<decimal>(
                name: "SalesPrice",
                table: "SalesLines",
                type: "decimal(18,2)",
                precision: 18,
                scale: 2,
                nullable: false,
                defaultValue: 0m);

            migrationBuilder.AddColumn<string>(
                name: "Size",
                table: "SalesLines",
                type: "nvarchar(max)",
                nullable: false,
                defaultValue: "");
        }
    }
}
