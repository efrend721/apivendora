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
        } 

        public DbSet<Usuario> Usuarios { get; set; }
        public DbSet<Barras> Barras { get; set; }
        public DbSet<Cajera> Cajera { get; set; }
        public DbSet<Consulta> Consulta { get; set; }
        public DbSet<Defactura> Defactura { get; set; }
        public DbSet<Factura> Factura { get; set; }
        public DbSet<Formapago> Formapago { get; set; }

    }


}
