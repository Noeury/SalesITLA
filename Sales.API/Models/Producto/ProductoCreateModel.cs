namespace Sales.API.Models.Producto
{
    public class ProductoCreateModel : ProductoBaseModel
    {
        public int IdUsuarioCreacion { get; set; }
        public DateTime FechaRegistro { get; set; }
    }
}
