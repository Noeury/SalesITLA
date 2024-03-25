using Sales.Domain.Entities;
using Sales.Infraestructure.Context;
using Sales.Infraestructure.Core;
using Sales.Infraestructure.Interfaces;


namespace Sales.Infraestructure.Dao
{
    public class NegocioDb : DaoBase<Negocio>, INegocioDb
    {

        private readonly SalesContext context;

        public NegocioDb(SalesContext context) : base(context)
        {
            this.context = context;
        }

        public List<Negocio> GetNegocioByUserId(int userId)
        {
            return this.context.Negocios.Where(ng => ng.IdUsuarioCreacion == userId).ToList();
        }

        public override DataResult Save(Negocio entity)
        {
            return base.Save(entity);
        }
    }
}
