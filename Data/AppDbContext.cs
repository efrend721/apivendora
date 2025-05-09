using Microsoft.EntityFrameworkCore;
using apivendora.Models.Finanzas;
using apivendora.Models.Usuarios;
using apivendora.Models.Ventas;
using apivendora.Models.Productos;
using apivendora.Models.Inventario;

namespace apivendora.Data
{
    public class AppDbContext : DbContext
    {
        public AppDbContext(DbContextOptions<AppDbContext> options) : base(options) { }

        protected override void OnModelCreating(ModelBuilder modelBuilder)
        {
            modelBuilder.Entity<Defactura>().HasNoKey();
            modelBuilder.Entity<Formapago>().HasNoKey();
            modelBuilder.Entity<Impuesto>().HasNoKey();
        }

        public DbSet<Usuario> Usuarios { get; set; }
        public DbSet<Barras> Barras { get; set; }
        public DbSet<Cajera> Cajeras { get; set; }
        public DbSet<Consulta> Consultas { get; set; }
        public DbSet<Defactura> Defacturas { get; set; }
        public DbSet<Factura> Facturas { get; set; }
        public DbSet<Formapago> Formapagos { get; set; }
        public DbSet<Impuesto> Impuestos { get; set; }
        public DbSet<Laboratorio> Laboratorios { get; set; }
        public DbSet<Mformapago> Mformapagos { get; set; }
        public DbSet<Mtransaccion> Mtransacciones { get; set; }
        public DbSet<Producto> Productos { get; set; }
        public DbSet<Proveedor> Proveedores { get; set; }
        public DbSet<Recogida> Recogidas { get; set; }
        public DbSet<Saldos> Saldos { get; set; }
        public DbSet<Tinventario> Tinventarios { get; set; }
    }
}
