namespace Sales.Web.Models.Results
{
    public class GetEntityResult<TModel> : ServiceResult
    {
        public TModel data { get; set; }

    }
}
