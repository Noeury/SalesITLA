using Sales.Web.Contracts;
using Sales.Web.Models.Negocio;
using Sales.Web.Models.Results;
using System.Text;
using System.Text.Json;

namespace Sales.Web.Services
{
    public class NegocioApiService : INegocioService
    {
        private readonly IConfiguration configuration;
        private readonly ILogger<NegocioApiService> logger;
        private readonly IHttpClientFactory clientFactory;
        private string baseUrl;
        public NegocioApiService(IConfiguration configuration,
                                    ILogger<NegocioApiService> logger,
                                    IHttpClientFactory clientFactory)
        {
            this.configuration = configuration;
            this.logger = logger;
            this.clientFactory = clientFactory;
            this.baseUrl = this.configuration["apiConfig:baseUrl"];
        }

        public async Task<ServiceResult> CreateNegocio(NegocioCreateModel negocio)
        {
            ServiceResult result = new ServiceResult();
            try
            {
                using (var httpClient = this.clientFactory.CreateClient())
                {
                    var url = $"{this.baseUrl}/Negocio/Save";

                    StringContent content = new StringContent(JsonSerializer.Serialize(negocio), Encoding.UTF8, "application/json");
                    string resp = string.Empty;
                    using (var response = await httpClient.PostAsync(url, content))
                    {
                        if (response.IsSuccessStatusCode)
                        {
                            resp = await response.Content.ReadAsStringAsync();
                            result = JsonSerializer.Deserialize<ServiceResult>(resp);
                        }
                        else
                        {
                            if (response.StatusCode == System.Net.HttpStatusCode.BadRequest)
                            {
                                resp = await response.Content.ReadAsStringAsync();
                                result = JsonSerializer.Deserialize<ServiceResult>(resp);
                                return result;
                            }
                            else
                            {
                                result.Success = false;
                                result.Message = "Error conectandose al end point de Save Negocio.";
                            }

                        }
                    }
                }
            }
            catch (Exception ex)
            {

                result.Success = false;
                result.Message = "Error guardando el Negocio.";
                this.logger.LogError(result.Message, ex.ToString()); ;
            }
            return result;
        }

        public async Task<GetEntityResult<NegocioResponseModel>> GetNeocioByName(NegocioSearchModel negocio)
        {
            GetEntityResult<NegocioResponseModel> result = new GetEntityResult<NegocioResponseModel>();

            try
            {
                using (var httpClient = this.clientFactory.CreateClient())
                {
                    var url = $"{this.baseUrl}/Negocio/GetNegocioByName";

                    StringContent content = new StringContent(JsonSerializer.Serialize(negocio), Encoding.UTF8, "application/json");

                    using (var response = await httpClient.PostAsync(url, content))
                    {
                        if (response.IsSuccessStatusCode)
                        {
                            string resp = await response.Content.ReadAsStringAsync();
                            result = JsonSerializer.Deserialize<GetEntityResult<NegocioResponseModel>>(resp);
                        }
                        else
                        {
                            result.Success = false;
                            result.Message = "Error conectandose al end point de GetNegocioByName.";
                        }
                    }
                }
            }
            catch (Exception ex)
            {
                result.Success = false;
                result.Message = "Error obteniendo el neogcio.";
                this.logger.LogError(result.Message, ex.ToString()); ;
            }
            return result;
        }

        public async Task<GetEntityResult<List<NegocioResponseModel>>> GetNeocios()
        {
            GetEntityResult<List<NegocioResponseModel>> result = new GetEntityResult<List<NegocioResponseModel>>();

            try
            {
                using (var httpClient = this.clientFactory.CreateClient())
                {
                    var url = $"{this.baseUrl}/Negocio/GetNegocios";

                    using (var response = await httpClient.GetAsync(url))
                    {
                        if (response.IsSuccessStatusCode)
                        {
                            string resp = await response.Content.ReadAsStringAsync();
                            result = JsonSerializer.Deserialize<GetEntityResult<List<NegocioResponseModel>>>(resp);
                        }
                        else
                        {
                            result.Success = false;
                            result.Message = "Error conectandose al end point de GetNegocios.";
                        }
                    }
                }
            }
            catch (Exception ex)
            {
                result.Success = false;
                result.Message = "Error obteniendo los negocios.";
                this.logger.LogError(result.Message, ex.ToString()); ;

            }

            return result;

        }




        public async Task<ServiceResult> UpdateNeocios(NegocioUpdateModel negocio)
        {
            ServiceResult result = new ServiceResult();
            try
            {
                using (var httpClient = this.clientFactory.CreateClient())
                {
                    var url = $"{this.baseUrl}/Negocio/Update";

                    StringContent content = new(JsonSerializer.Serialize(negocio), Encoding.UTF8, "application/json");
                    string resp = string.Empty;
                    using (var response = await httpClient.PatchAsync(url, content))
                    {
                        if (response.IsSuccessStatusCode)
                        {
                            resp = await response.Content.ReadAsStringAsync();
                            result = JsonSerializer.Deserialize<ServiceResult>(resp);
                        }
                        else
                        {
                            if (response.StatusCode == System.Net.HttpStatusCode.BadRequest)
                            {
                                resp = await response.Content.ReadAsStringAsync();
                                result = JsonSerializer.Deserialize<ServiceResult>(resp);
                                return result;
                            }
                            else
                            {
                                result.Success = false;
                                result.Message = "Error conectandose al end point de Save Negocios.";
                            }

                        }
                    }
                }
            }
            catch (Exception ex)
            {

                result.Success = false;
                result.Message = "Error guardando el negocio.";
                this.logger.LogError(result.Message, ex.ToString()); ;
            }
            return result;
        }
    }
}
