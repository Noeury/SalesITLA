using Sales.Infraestructure.Interfaces;


namespace Sales.Infraestructure.Dao
{
    public class DetalleVentaDb : IDetalleVentaDb
    {
        private List<DetalleVentaDb> detalleVentas;
        public bool Exists(string nombre)
        {
            throw new NotImplementedException();
        }

        public List<Domain.Entities.DetalleVenta> GetAll()
        {
            throw new NotImplementedException();
        }

        public Domain.Entities.DetalleVenta GetById(int detalleVenta)
        {
            throw new NotImplementedException();
        }

        public void Save(Domain.Entities.DetalleVenta detalleVenta)
        {
            throw new NotImplementedException();
        }

        public void Update(Domain.Entities.DetalleVenta detalleVenta)
        {
            throw new NotImplementedException();
        }
    }
}
