using Microsoft.EntityFrameworkCore;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;
using POSApi.Models;

namespace POSApi.Models
{
    public class POSContext : DbContext
    {
        public POSContext(DbContextOptions<POSContext> options): base(options)
        { }

        public DbSet<Articulo> Articulos { get; set; }
        public DbSet<Departamento> Departamentos { get; set; }
        public DbSet<Unidad> Unidades { get; set; }
        public DbSet<Descuento> Descuentos { get; set; }
        public DbSet<DescuentoPermitido> DescuentosPermitidos { get; set; }
        public DbSet<Usuario> Usuarios { get; set; }
        public DbSet<EntradaAlmacen> EntradasAlmacen { get; set; }
        public DbSet<Provider> Proveedores { get; set; }
        public DbSet<UnidadMedida> UnidadesMedida { get; set; }

        protected override void OnConfiguring(DbContextOptionsBuilder optionsBuilder)
        {
            optionsBuilder.UseSqlServer("Server=.;Database=POSDb;Trusted_Connection=True;");
        }

        protected override void OnModelCreating(ModelBuilder modelBuilder)
        {
        }

        public DbSet<POSApi.Models.Moneda> Moneda { get; set; }
    }
}
