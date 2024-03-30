using Sales.Web.Contracts;
using Sales.Web.Models.Negocio;
using Sales.Web.Models.Producto;
using Sales.Web.Models.Results;
using System.Text;
using System.Text.Json;

namespace Sales.Web.Services
{
    public class ProductoApiService : IProductoService
    {
        private readonly IConfiguration configuration;
        private readonly ILogger<ProductoApiService> logger;
        private readonly IHttpClientFactory clientFactory;
        private string baseUrl;

        public ProductoApiService(IConfiguration configuration,
                                    ILogger<ProductoApiService> logger,
                                    IHttpClientFactory clientFactory)
        {
            this.configuration = configuration;
            this.logger = logger;
            this.clientFactory = clientFactory;
            this.baseUrl = this.configuration["apiConfig:baseUrl"];
        }

        public async Task<ServiceResult> CreateProducto(ProductoCreateModel producto)
        {
            ServiceResult result = new ServiceResult();
            try
            {
                using (var httpClient = this.clientFactory.CreateClient())
                {
                    var url = $"{this.baseUrl}/Producto/Save";

                    StringContent content = new StringContent(JsonSerializer.Serialize(producto), Encoding.UTF8, "application/json");
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
                                result.Message = "Error conectandose al end point de Save Producto.";
                            }

                        }
                    }
                }
            }
            catch (Exception ex)
            {

                result.Success = false;
                result.Message = "Error guardando el producto.";
                this.logger.LogError(result.Message, ex.ToString()); ;
            }
            return result;
        }

        public async Task<GetEntityResult<ProductoResponseModel>> GetProductoByDescripcion(ProductoSearchModel producto)
        {
            GetEntityResult<ProductoResponseModel> result = new GetEntityResult<ProductoResponseModel>();

            try
            {
                using (var httpClient = this.clientFactory.CreateClient())
                {
                    var url = $"{this.baseUrl}/Producto/GetProductoByDescipcion";

                    StringContent content = new StringContent(JsonSerializer.Serialize(producto), Encoding.UTF8, "application/json");

                    using (var response = await httpClient.PostAsync(url, content))
                    {
                        if (response.IsSuccessStatusCode)
                        {
                            string resp = await response.Content.ReadAsStringAsync();
                            result = JsonSerializer.Deserialize<GetEntityResult<ProductoResponseModel>>(resp);
                        }
                        else
                        {
                            result.Success = false;
                            result.Message = "Error conectandose al end point de GetProdcutoByDescripcion.";
                        }
                    }
                }
            }
            catch (Exception ex)
            {
                result.Success = false;
                result.Message = "Error obteniendo el producto.";
                this.logger.LogError(result.Message, ex.ToString()); ;
            }
            return result;
        }

        public async Task<GetEntityResult<List<ProductoResponseModel>>> GetProductos()
        {
            GetEntityResult<List<ProductoResponseModel>> result = new GetEntityResult<List<ProductoResponseModel>>();

            try
            {
                using (var httpClient = this.clientFactory.CreateClient())
                {
                    var url = $"{this.baseUrl}/Producto/GetProductos";

                    using (var response = await httpClient.GetAsync(url))
                    {
                        if (response.IsSuccessStatusCode)
                        {
                            string resp = await response.Content.ReadAsStringAsync();
                            result = JsonSerializer.Deserialize<GetEntityResult<List<ProductoResponseModel>>>(resp);
                        }
                        else
                        {
                            result.Success = false;
                            result.Message = "Error conectandose al end point de GetProductos.";
                        }
                    }
                }
            }
            catch (Exception ex)
            {
                result.Success = false;
                result.Message = "Error obteniendo los productos.";
                this.logger.LogError(result.Message, ex.ToString()); ;

            }

            return result;
        }

        public async Task<ServiceResult> UpdateProducto(ProductoUpdateModel producto)
        {
            ServiceResult result = new ServiceResult();
            try
            {
                using (var httpClient = this.clientFactory.CreateClient())
                {
                    var url = $"{this.baseUrl}/Producto/Update";

                    StringContent content = new(JsonSerializer.Serialize(producto), Encoding.UTF8, "application/json");
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
                                result.Message = "Error conectandose al end point de Save Producto.";
                            }

                        }
                    }
                }
            }
            catch (Exception ex)
            {

                result.Success = false;
                result.Message = "Error guardando el producto.";
                this.logger.LogError(result.Message, ex.ToString()); ;
            }
            return result;
        }
    }
}
