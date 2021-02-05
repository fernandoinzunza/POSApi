using Microsoft.EntityFrameworkCore.Migrations;

namespace POSApi.Migrations
{
    public partial class StockBajo : Migration
    {
        protected override void Up(MigrationBuilder migrationBuilder)
        {
            migrationBuilder.AddColumn<double>(
                name: "StockBajo",
                table: "Articulos",
                type: "float",
                nullable: false,
                defaultValue: 0.0);
        }

        protected override void Down(MigrationBuilder migrationBuilder)
        {
            migrationBuilder.DropColumn(
                name: "StockBajo",
                table: "Articulos");
        }
    }
}
