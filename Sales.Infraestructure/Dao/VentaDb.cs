using Sales.Domain.Entities;
using Sales.Infraestructure.Interfaces;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Sales.Infraestructure.Dao
{
    public class VentaDb : IVentaDb
    {
        private List<Venta> ventas;
        public bool Exists(string nombre)
        {
            throw new NotImplementedException();
        }

        public List<Venta> GetAll()
        {
            throw new NotImplementedException();
        }

        public Venta GetById(int ventaId)
        {
            throw new NotImplementedException();
        }

        public void Save(Venta venta)
        {
            throw new NotImplementedException();
        }

        public void Update(Venta venta)
        {
            throw new NotImplementedException();
        }
    }
}
