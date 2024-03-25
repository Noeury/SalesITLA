

using Sales.Domain.Entities;
using Sales.Infraestructure.Core;

namespace Sales.Infraestructure.Interfaces
{
    public interface INegocioDb : IDaoBase<Negocio>
    {

        public List<Negocio> GetNegocioByUserId(int userId);

        //Logica exclusva de los negocios
    }
}
