namespace Sales.Web.Models.Negocio
{
    public class NegocioUpdateModel : NegocioBaseModel
    {
        public DateTime? FechaMod;
        public int? IdUsuarioMod { get; set; }
    }
}
