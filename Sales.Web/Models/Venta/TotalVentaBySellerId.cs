namespace Sales.Web.Models.Venta
{
    public class TotalVentaBySellerId
    {
        public int Seller { get; set; }
        public int SellerId { get; set; }
        public decimal TotalVentas { get; set; }
    }
}
