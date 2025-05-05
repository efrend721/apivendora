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
        } 

        public DbSet<Usuario> Usuarios { get; set; }
        public DbSet<Barras> Barras { get; set; }
        public DbSet<Cajera> Cajera { get; set; }
        public DbSet<Consulta> Consulta { get; set; }
        public DbSet<Defactura> Defactura { get; set; }

    }


}
