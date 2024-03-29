namespace Sales.Infraestructure.Models.Venta
{
    public class VentaBySellerModel
    {
        public int SellerId { get; set; } 
        public string? Seller { get; set; }
        public decimal? TotalVentas { get; set; }

    }
}
