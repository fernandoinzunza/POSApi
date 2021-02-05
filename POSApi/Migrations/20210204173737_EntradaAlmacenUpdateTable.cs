using Microsoft.EntityFrameworkCore.Migrations;

namespace POSApi.Migrations
{
    public partial class EntradaAlmacenUpdateTable : Migration
    {
        protected override void Up(MigrationBuilder migrationBuilder)
        {
            migrationBuilder.AddColumn<string>(
                name: "ClaveArticulo",
                table: "EntradasAlmacen",
                type: "nvarchar(max)",
                nullable: true);

            migrationBuilder.AddColumn<int>(
                name: "IdDepartamento",
                table: "EntradasAlmacen",
                type: "int",
                nullable: false,
                defaultValue: 0);
        }

        protected override void Down(MigrationBuilder migrationBuilder)
        {
            migrationBuilder.DropColumn(
                name: "ClaveArticulo",
                table: "EntradasAlmacen");

            migrationBuilder.DropColumn(
                name: "IdDepartamento",
                table: "EntradasAlmacen");
        }
    }
}
