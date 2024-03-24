using Sales.Domain.Entities;
using Sales.Infraestructure.Core;

namespace Sales.Infraestructure.Interfaces
{
    public interface IDetalleVentaDb : IDaoBase<DetalleVenta>
    {
        //Logica exclusiva de DetalleVenta
    }
}
