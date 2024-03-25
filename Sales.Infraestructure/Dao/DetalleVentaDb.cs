using Sales.Domain.Entities;
using Sales.Infraestructure.Context;
using Sales.Infraestructure.Interfaces;
using System.Reflection.Metadata.Ecma335;

namespace Sales.Infraestructure.Dao
{
    public class DetalleVentaDb : DaoBase<DetalleVenta>, IDetalleVentaDb
    {
        private readonly SalesContext context;
        public DetalleVentaDb(SalesContext context) : base(context)
        {
            this.context = context;
        }


        public List<DetalleVenta> GetDetallesVentas(int idVenta)
        {
            return base.GetEntitiesWithFilters(dtv => dtv.IdVenta == idVenta);
        }


    }
}
