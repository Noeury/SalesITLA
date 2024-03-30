namespace Sales.Web.Models.Results
{
    public class GetEntityResult<TModel> : ServiceResult
    {
        public TModel? Data { get; set; }

    }
}
