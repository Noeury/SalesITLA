using Sales.Domain.Entities;
using Sales.Infraestructure.Core;

namespace Sales.Infraestructure.Interfaces
{
    public interface IDetalleVentaDb : IDaoBase<DetalleVenta>
    {

        public List<DetalleVenta> GetDetallesVentas(int idVenta);

        //Logica exclusiva de DetalleVenta
    }
}
