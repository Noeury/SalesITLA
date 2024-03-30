namespace Sales.Web.Models.Producto
{
    public class ProductoBaseModel
    {
        public string? CodigoBarra { get; set; }
        public string? Marca { get; set; }
        public string? Descripcion;
        public int? IdCategoria { get; set; }
        public int? Stock { get; set; }
        public string? UrlImagen { get; set; }
        public string? NombreImagen { get; set; }
        public decimal? Precio { get; set; }
    }
}
