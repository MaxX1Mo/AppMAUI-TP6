
using AppMAUI_TP6.Models;
using System.Net.Http.Headers;
using System.Text.Json;
using AppMAUI_TP6.Utils;
using System.Net.Http.Json;
using System.Net;

namespace AppMAUI_TP6.Service
{
    public class ProductoService : IProductoService
    {
        HttpClient client;

        private static JsonSerializerOptions options = new()
        {
            PropertyNameCaseInsensitive = true
        };

        public ProductoService()
        {
            client = new HttpClient();

            client.BaseAddress = new Uri(EndPoints.);
            client.DefaultRequestHeaders.Accept.Add(
                new MediaTypeWithQualityHeaderValue("application/json"));
        }

        public async Task<IEnumerable<Producto>> GetProductsAsync()
        {
            var response = await client.GetAsync(EndPoints.Producto);

            if (response.IsSuccessStatusCode)
                return await response.Content.ReadFromJsonAsync<IEnumerable<Producto>>(options);

            return default;
        }

    }
}
