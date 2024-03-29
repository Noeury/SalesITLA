namespace Sales.Infraestructure.Models.Producto
{
    public class ProductByCategoryModel
    {
        public int Id { get; set; }
        public string CodigoBarra { get; set; }
        public string Marca { get; set; }
        public int? Stock { get; set; }
        public string NombreCategoria { get; set; }
    }
}
