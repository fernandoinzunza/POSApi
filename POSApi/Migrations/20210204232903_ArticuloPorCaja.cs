using Microsoft.EntityFrameworkCore.Migrations;

namespace POSApi.Migrations
{
    public partial class ArticuloPorCaja : Migration
    {
        protected override void Up(MigrationBuilder migrationBuilder)
        {
            migrationBuilder.AddColumn<bool>(
                name: "Caja",
                table: "EntradasAlmacen",
                type: "bit",
                nullable: false,
                defaultValue: false);

            migrationBuilder.AddColumn<int>(
                name: "CajasStock",
                table: "EntradasAlmacen",
                type: "int",
                nullable: true);

            migrationBuilder.AddColumn<double>(
                name: "UnidadesXCaja",
                table: "EntradasAlmacen",
                type: "float",
                nullable: true);

            migrationBuilder.AddColumn<bool>(
                name: "Caja",
                table: "Articulos",
                type: "bit",
                nullable: false,
                defaultValue: false);

            migrationBuilder.AddColumn<int>(
                name: "CajasStock",
                table: "Articulos",
                type: "int",
                nullable: true);

            migrationBuilder.AddColumn<double>(
                name: "UnidadesXCaja",
                table: "Articulos",
                type: "float",
                nullable: true);
        }

        protected override void Down(MigrationBuilder migrationBuilder)
        {
            migrationBuilder.DropColumn(
                name: "Caja",
                table: "EntradasAlmacen");

            migrationBuilder.DropColumn(
                name: "CajasStock",
                table: "EntradasAlmacen");

            migrationBuilder.DropColumn(
                name: "UnidadesXCaja",
                table: "EntradasAlmacen");

            migrationBuilder.DropColumn(
                name: "Caja",
                table: "Articulos");

            migrationBuilder.DropColumn(
                name: "CajasStock",
                table: "Articulos");

            migrationBuilder.DropColumn(
                name: "UnidadesXCaja",
                table: "Articulos");
        }
    }
}
