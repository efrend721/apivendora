using Microsoft.EntityFrameworkCore;
using apivendora.Models;

namespace apivendora.Data
{
    public class AppDbContext : DbContext
    {
        public AppDbContext(DbContextOptions<AppDbContext> options) : base(options)
        {
        }
        protected override void OnModelCreating(ModelBuilder modelBuilder)
        {
            modelBuilder.Entity<Defactura>().HasNoKey();
            modelBuilder.Entity<Formapago>().HasNoKey();
            modelBuilder.Entity<Impuesto>().HasNoKey();
            modelBuilder.Entity<Recogida>().HasNoKey();
        } 

        public DbSet<Usuario> Usuarios { get; set; }
        public DbSet<Barras> Barras { get; set; }
        public DbSet<Cajera> Cajera { get; set; }
        public DbSet<Consulta> Consulta { get; set; }
        public DbSet<Defactura> Defactura { get; set; }
        public DbSet<Factura> Factura { get; set; }
        public DbSet<Formapago> Formapago { get; set; }
        public DbSet<Impuesto> Impuesto { get; set; }
        public DbSet<Laboratorio> Laboratorio { get; set; }
        public DbSet<Mformapago> Mformapago { get; set; }
        public DbSet<Mtransaccion> Mtransaccion { get; set; }
        public DbSet<Producto> Producto { get; set; }
        public DbSet<Proveedor> Proveedor { get; set; }
        public DbSet<Recogida> Recogida { get; set; }
        public DbSet<Saldos> Saldos { get; set; }
        public DbSet<Tinventario> Tinventario { get; set; }
    }


}
