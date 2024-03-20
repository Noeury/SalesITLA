
namespace Sales.Domain.Core
{
    public abstract class BaseEntity
    {

        public BaseEntity()
        {
            this.FechaRegistro = DateTime.Now;
            this.Eliminado = false;
        }

        public int Id { get; set; }

        public bool? EsActivo { get; set; }
        public DateTime FechaRegistro { get; set; }

        public int IdUsuarioCreacion { get; set; }

        public DateTime? FechaMod;
        public int? IdUsuarioMod { get; set; }
        public int? IdUsuarioElimino { get; set; }
        public DateTime? FechaElimino { get; set; }
        public Boolean Eliminado { get; set; }

    }
}
