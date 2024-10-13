
using AppMAUI_TP6.Models;
using AppMAUI_TP6.Utils;
using Newtonsoft.Json;
using System.Net.Http.Headers;
using System.Text;

namespace AppMAUI_TP6.Service
{
    public class ProductoService
    {
        private readonly HttpClient _httpClient;

        public ProductoService() {
            _httpClient = new HttpClient();
            // Configura la base URL de la API
            _httpClient.BaseAddress = new Uri(EndPoints.URLApi);           

        }

        public async Task<List<Producto>> GetListaProductos()
        {

            // Recupera el token JWT almacenado en SecureStorage
            var token = await SecureStorage.GetAsync("auth_token");

            if (string.IsNullOrEmpty(token))
            {
                throw new Exception("No se encontró el token de autenticación.");
            }

            // Añade el token al encabezado de autorizacion
            _httpClient.DefaultRequestHeaders.Authorization = new AuthenticationHeaderValue("Bearer", token);


            // Enviar la solicitud al endpoint de Lista Producto
            var response = await _httpClient.GetAsync(EndPoints.ListaProducto);

            if (response.IsSuccessStatusCode)
            {
                var json = await response.Content.ReadAsStringAsync();
                var productos = JsonConvert.DeserializeObject<List<Producto>>(json);
                return productos;
            }
            else
            {
                throw new Exception("Fallo en la solicitud de datos (o puedes que no estes autorizado)");
            }
        }


    }

}
