using Sales.Domain.Entities;
using Sales.Infraestructure.Context;
using Sales.Infraestructure.Core;
using Sales.Infraestructure.Interfaces;

namespace Sales.Infraestructure.Dao
{
    public class VentaDb : DaoBase<Venta>, IVentaDb
    {
        private readonly SalesContext context;


        public VentaDb(SalesContext context) : base(context)
        {
            this.context = context;
        }

        public override DataResult Save(Venta entity)
        {
            return base.Save(entity);
        }
    }
}
