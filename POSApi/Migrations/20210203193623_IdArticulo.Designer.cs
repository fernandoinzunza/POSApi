﻿// <auto-generated />
using Microsoft.EntityFrameworkCore;
using Microsoft.EntityFrameworkCore.Infrastructure;
using Microsoft.EntityFrameworkCore.Metadata;
using Microsoft.EntityFrameworkCore.Migrations;
using Microsoft.EntityFrameworkCore.Storage.ValueConversion;
using POSApi.Models;

namespace POSApi.Migrations
{
    [DbContext(typeof(POSContext))]
    [Migration("20210203193623_IdArticulo")]
    partial class IdArticulo
    {
        protected override void BuildTargetModel(ModelBuilder modelBuilder)
        {
#pragma warning disable 612, 618
            modelBuilder
                .UseIdentityColumns()
                .HasAnnotation("Relational:MaxIdentifierLength", 128)
                .HasAnnotation("ProductVersion", "5.0.2");

            modelBuilder.Entity("POSApi.Models.Articulo", b =>
                {
                    b.Property<string>("Clave")
                        .HasColumnType("varchar(100)");

                    b.Property<string>("Departamento")
                        .HasColumnType("varchar(200)");

                    b.Property<string>("Descripcion")
                        .HasColumnType("varchar(200)");

                    b.Property<int>("Id")
                        .ValueGeneratedOnAdd()
                        .HasColumnType("int")
                        .UseIdentityColumn();

                    b.Property<int>("IdDepartamento")
                        .HasColumnType("int");

                    b.Property<int>("IdProveedor")
                        .HasColumnType("int");

                    b.Property<string>("NombreProveedor")
                        .HasColumnType("nvarchar(max)");

                    b.Property<double>("PrecioAlCosto")
                        .HasColumnType("float");

                    b.Property<double>("PrecioMayoreo")
                        .HasColumnType("float");

                    b.Property<double>("PrecioPublico")
                        .HasColumnType("float");

                    b.Property<double>("PrecioSecundario")
                        .HasColumnType("float");

                    b.Property<float>("Stock")
                        .HasColumnType("real");

                    b.Property<double>("StockBajo")
                        .HasColumnType("float");

                    b.Property<string>("TipoUnidad")
                        .HasColumnType("varchar(200)");

                    b.Property<string>("Unidad")
                        .HasColumnType("varchar(200)");

                    b.HasKey("Clave");

                    b.ToTable("Articulos");
                });

            modelBuilder.Entity("POSApi.Models.Departamento", b =>
                {
                    b.Property<int>("Id")
                        .ValueGeneratedOnAdd()
                        .HasColumnType("int")
                        .UseIdentityColumn();

                    b.Property<string>("Nombre")
                        .HasColumnType("nvarchar(max)");

                    b.HasKey("Id");

                    b.ToTable("Departamentos");
                });

            modelBuilder.Entity("POSApi.Models.Descuento", b =>
                {
                    b.Property<int>("NoDescuento")
                        .ValueGeneratedOnAdd()
                        .HasColumnType("int")
                        .UseIdentityColumn();

                    b.Property<string>("Nombre")
                        .HasColumnType("nvarchar(max)");

                    b.Property<double>("Porcentaje")
                        .HasColumnType("float");

                    b.HasKey("NoDescuento");

                    b.ToTable("Descuentos");
                });

            modelBuilder.Entity("POSApi.Models.DescuentoPermitido", b =>
                {
                    b.Property<int>("IdPermiso")
                        .ValueGeneratedOnAdd()
                        .HasColumnType("int")
                        .UseIdentityColumn();

                    b.Property<int>("IdDescuento")
                        .HasColumnType("int");

                    b.Property<int>("NoEmpleado")
                        .HasColumnType("int");

                    b.HasKey("IdPermiso");

                    b.ToTable("DescuentosPermitidos");
                });

            modelBuilder.Entity("POSApi.Models.EntradaAlmacen", b =>
                {
                    b.Property<int>("Id")
                        .ValueGeneratedOnAdd()
                        .HasColumnType("int")
                        .UseIdentityColumn();

                    b.Property<string>("Articulo")
                        .HasColumnType("nvarchar(max)");

                    b.Property<double>("Cantidad")
                        .HasColumnType("float");

                    b.Property<double>("CostoTotal")
                        .HasColumnType("float");

                    b.Property<string>("Departamento")
                        .HasColumnType("nvarchar(max)");

                    b.Property<string>("Fecha")
                        .HasColumnType("nvarchar(max)");

                    b.Property<int>("IdMoneda")
                        .HasColumnType("int");

                    b.Property<int>("IdProveedor")
                        .HasColumnType("int");

                    b.Property<double>("NombreEmpleado")
                        .HasColumnType("float");

                    b.Property<string>("NombreMoneda")
                        .HasColumnType("nvarchar(max)");

                    b.Property<string>("NombreProveedor")
                        .HasColumnType("nvarchar(max)");

                    b.Property<double>("PrecioUnitario")
                        .HasColumnType("float");

                    b.HasKey("Id");

                    b.ToTable("EntradasAlmacen");
                });

            modelBuilder.Entity("POSApi.Models.Moneda", b =>
                {
                    b.Property<int>("Id")
                        .ValueGeneratedOnAdd()
                        .HasColumnType("int")
                        .UseIdentityColumn();

                    b.Property<double>("EquivalenteEnPesosMX")
                        .HasColumnType("float");

                    b.Property<string>("Nombre")
                        .HasColumnType("nvarchar(max)");

                    b.HasKey("Id");

                    b.ToTable("Moneda");
                });

            modelBuilder.Entity("POSApi.Models.Provider", b =>
                {
                    b.Property<int>("Id")
                        .ValueGeneratedOnAdd()
                        .HasColumnType("int")
                        .UseIdentityColumn();

                    b.Property<string>("Contacto")
                        .HasColumnType("nvarchar(max)");

                    b.Property<string>("Correo")
                        .HasColumnType("nvarchar(max)");

                    b.Property<string>("Nombre")
                        .HasColumnType("nvarchar(max)");

                    b.Property<string>("RazonSocial")
                        .HasColumnType("nvarchar(max)");

                    b.Property<string>("Rfc")
                        .HasColumnType("nvarchar(max)");

                    b.Property<string>("Telefono")
                        .HasColumnType("nvarchar(max)");

                    b.HasKey("Id");

                    b.ToTable("Proveedores");
                });

            modelBuilder.Entity("POSApi.Models.Unidad", b =>
                {
                    b.Property<int>("Id")
                        .ValueGeneratedOnAdd()
                        .HasColumnType("int")
                        .UseIdentityColumn();

                    b.Property<string>("Nombre")
                        .HasColumnType("nvarchar(max)");

                    b.Property<string>("Tipo")
                        .HasColumnType("nvarchar(max)");

                    b.HasKey("Id");

                    b.ToTable("Unidades");
                });

            modelBuilder.Entity("POSApi.Models.Usuario", b =>
                {
                    b.Property<int>("NoEmpleado")
                        .ValueGeneratedOnAdd()
                        .HasColumnType("int")
                        .UseIdentityColumn();

                    b.Property<string>("ApMaterno")
                        .HasColumnType("varchar(100)");

                    b.Property<string>("ApPaterno")
                        .HasColumnType("varchar(100)");

                    b.Property<string>("Contrasena")
                        .HasColumnType("varchar(50)");

                    b.Property<string>("NomUsuario")
                        .HasColumnType("varchar(50)");

                    b.Property<string>("Nombre")
                        .HasColumnType("varchar(100)");

                    b.Property<string>("Puesto")
                        .HasColumnType("varchar(100)");

                    b.HasKey("NoEmpleado");

                    b.ToTable("Usuarios");
                });
#pragma warning restore 612, 618
        }
    }
}
