namespace Sales.Web.Models.Producto
{
    public class ProductoResponseModel
    {
        public string? codigoBarra { get; set; }
        public string? marca { get; set; }
        public string? descripcion;
        public int? idCategoria { get; set; }
        public int? stock { get; set; }
        public string? urlImagen { get; set; }
        public string? nombreImagen { get; set; }
        public decimal? precio { get; set; }
    }
}