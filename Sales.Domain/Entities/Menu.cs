

using Sales.Domain.Core;

namespace Sales.Domain.Entities
{
    public class Menu : BaseEntity
    {
        public string? Descripcion { get; set; }
        public string? IdMenuPadre { get; set; }
        public string? Icono { get; set; }
        public string? Controlador { get; set; }
        public string? PaginaAccion { get; set; }
    }
}
