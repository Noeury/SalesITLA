using Microsoft.EntityFrameworkCore;
using Sales.Domain.Entities;


namespace Sales.Infraestructure.Context
{
    public class SalesContext : DbContext
    {
        public SalesContext(DbContextOptions<SalesContext> options) : base(options) { }


        #region DbSet

        public DbSet<Negocio>? Negocio { get; set; }

        #endregion
    }
}
