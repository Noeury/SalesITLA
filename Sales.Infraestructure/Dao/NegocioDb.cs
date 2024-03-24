using Sales.Domain.Entities;
using Sales.Infraestructure.Interfaces;


namespace Sales.Infraestructure.Dao
{
    public class NegocioDb : INegocioDb
    {
        private readonly List<Negocio> negocios;

        public bool Exists(string nombre)
        {
            return negocios.Any(ng => ng.Nombre == nombre);
        }

        public List<Negocio> GetAll()
        {
            return negocios.Where(ng => !ng.Eliminado).ToList();
        }

        public Negocio GetById(int negocioId)
        {
            return negocios.Single(ng => ng.Id == negocioId);
        }

        public void Save(Negocio negocio)
        {
            negocios.Add(negocio);
        }

        public void Update(Negocio negocio)
        {
            negocios.Add(negocio);
        }
    }
}
