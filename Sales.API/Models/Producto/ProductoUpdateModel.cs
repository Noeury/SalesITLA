namespace Sales.API.Models.Producto
{
    public class ProductoUpdateModel : ProductoBaseModel
    {
        public int ProductoId { get; set; }
        public DateTime? FechaMod;
        public int? IdUsuarioMod { get; set; }
    }
}
