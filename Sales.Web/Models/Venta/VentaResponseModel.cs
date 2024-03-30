namespace Sales.Web.Models.Venta
{
    public class VentaResponseModel
    {
        public string? numeroVenta { get; set; }
        public int? idTipoDocumentoVenta { get; set; }
        public int? idUsuario { get; set; }
        public string? cocumentoCliente { get; set; }
        public string? nombreCliente { get; set; }
        public decimal? subTotal { get; set; }
        public decimal? impuestoTotal { get; set; }
        public decimal? total { get; set; }
        public DateTime fechaRegistro { get; set; }
        public int idUsuarioCreacion { get; set; }
    }
}
