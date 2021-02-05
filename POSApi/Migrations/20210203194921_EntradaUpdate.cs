using Microsoft.EntityFrameworkCore.Migrations;

namespace POSApi.Migrations
{
    public partial class EntradaUpdate : Migration
    {
        protected override void Up(MigrationBuilder migrationBuilder)
        {
            migrationBuilder.AlterColumn<string>(
                name: "NombreEmpleado",
                table: "EntradasAlmacen",
                type: "nvarchar(max)",
                nullable: true,
                oldClrType: typeof(double),
                oldType: "float");

            migrationBuilder.AddColumn<int>(
                name: "NoEmpleado",
                table: "EntradasAlmacen",
                type: "int",
                nullable: false,
                defaultValue: 0);
        }

        protected override void Down(MigrationBuilder migrationBuilder)
        {
            migrationBuilder.DropColumn(
                name: "NoEmpleado",
                table: "EntradasAlmacen");

            migrationBuilder.AlterColumn<double>(
                name: "NombreEmpleado",
                table: "EntradasAlmacen",
                type: "float",
                nullable: false,
                defaultValue: 0.0,
                oldClrType: typeof(string),
                oldType: "nvarchar(max)",
                oldNullable: true);
        }
    }
}
