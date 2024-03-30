using Sales.Web.Contracts;
using Sales.Web.Models.Negocio;
using Sales.Web.Models.Results;
using Sales.Web.Models.Venta;
using System.Text;
using System.Text.Json;

namespace Sales.Web.Services
{
    public class VentaApiService : IVentaService
    {
        private readonly IConfiguration configuration;
        private readonly ILogger<VentaApiService> logger;
        private readonly IHttpClientFactory clientFactory;
        private string baseUrl;

        public VentaApiService(IConfiguration configuration,
                                    ILogger<VentaApiService> logger,
                                    IHttpClientFactory clientFactory)
        {
            this.configuration = configuration;
            this.logger = logger;
            this.clientFactory = clientFactory;
            this.baseUrl = this.configuration["apiConfig:baseUrl"];
        }

        public async Task<ServiceResult> CreateVenta(VentaCreateModel venta)
        {
            ServiceResult result = new ServiceResult();
            try
            {
                using (var httpClient = this.clientFactory.CreateClient())
                {
                    var url = $"{this.baseUrl}/Venta/Save";

                    StringContent content = new StringContent(JsonSerializer.Serialize(venta), Encoding.UTF8, "application/json");
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


        public async Task<GetEntityResult<VentaResponseModel>> GetTotalVetaBySellerId(TotalVentaBySellerId sellerI)
        {
            GetEntityResult<VentaResponseModel> result = new GetEntityResult<VentaResponseModel>();

            try
            {
                using (var httpClient = this.clientFactory.CreateClient())
                {
                    var url = $"{this.baseUrl}/Venta/TotalDeVentaBySellerId";

                    StringContent content = new StringContent(JsonSerializer.Serialize(sellerI), Encoding.UTF8, "application/json");

                    using (var response = await httpClient.PostAsync(url, content))
                    {
                        if (response.IsSuccessStatusCode)
                        {
                            string resp = await response.Content.ReadAsStringAsync();
                            result = JsonSerializer.Deserialize<GetEntityResult<VentaResponseModel>>(resp);
                        }
                        else
                        {
                            result.Success = false;
                            result.Message = "Error conectandose al end point de TotalDeVentaBySellerId.";
                        }
                    }
                }
            }
            catch (Exception ex)
            {
                result.Success = false;
                result.Message = "Error obteniendo el TotalDeVentaBySellerId.";
                this.logger.LogError(result.Message, ex.ToString()); ;
            }
            return result;
        }

        public async Task<GetEntityResult<List<VentaResponseModel>>> GetVentas()
        {
            GetEntityResult<List<VentaResponseModel>> result = new GetEntityResult<List<VentaResponseModel>>();

            try
            {
                using (var httpClient = this.clientFactory.CreateClient())
                {
                    var url = $"{this.baseUrl}/Venta/GetVentas";

                    using (var response = await httpClient.GetAsync(url))
                    {
                        if (response.IsSuccessStatusCode)
                        {
                            string resp = await response.Content.ReadAsStringAsync();
                            result = JsonSerializer.Deserialize<GetEntityResult<List<VentaResponseModel>>>(resp);
                        }
                        else
                        {
                            result.Success = false;
                            result.Message = "Error conectandose al end point de GetVentas.";
                        }
                    }
                }
            }
            catch (Exception ex)
            {
                result.Success = false;
                result.Message = "Error obteniendo las ventas.";
                this.logger.LogError(result.Message, ex.ToString()); ;

            }

            return result;
        }
    }
}
