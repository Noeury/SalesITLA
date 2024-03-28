namespace Sales.API.Models.Negocio
{
    public class NegocioUpdateModel : NegocioBaseModel
    {

        public int NegocioId { get; set; }
        public DateTime? FechaMod;
        public int? IdUsuarioMod { get; set; }

    }
}
