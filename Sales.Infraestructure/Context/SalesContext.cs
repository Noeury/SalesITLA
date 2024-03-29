using Microsoft.EntityFrameworkCore;
using Sales.Domain.Entities;


namespace Sales.Infraestructure.Context
{
    public class SalesContext : DbContext
    {
        public SalesContext(DbContextOptions<SalesContext> options) : base(options) { }


        #region DbSet

        public DbSet<Negocio>? Negocio { get; set; }
        public DbSet<Venta>? Venta { get; set; }
        public DbSet<Producto>? Producto { get; set; }
        public DbSet<Categoria>? Categoria { get; set; }
        public DbSet<DetalleVenta>? DetalleVenta { get; set; }
        public DbSet<Usuario>? Usuario { get; set; }

        #endregion

        protected override void OnModelCreating(ModelBuilder modelBuilder)
        {
            base.OnModelCreating(modelBuilder);
        }
    }
}
