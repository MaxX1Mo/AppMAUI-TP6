
using AppMAUI_TP6.Models;
using AppMAUI_TP6.Utils;
using Microsoft.Maui.ApplicationModel.Communication;
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

       
        #region Crud 
        public async Task EditarProducto(int idProducto, string nombreProducto, string descripcion, decimal precio, string imagen, int stock)
        {
            var producto = new { nombre = nombreProducto, Descripcion = descripcion, Precio = precio, Img = imagen, Stock = stock };
            var jsonContent = JsonConvert.SerializeObject(producto);
            var content = new StringContent(jsonContent, Encoding.UTF8, "application/json");

            #region autenticacion
            var token = await SecureStorage.GetAsync("auth_token");
            if (string.IsNullOrEmpty(token)) { throw new Exception("No se encontró el token de autenticación."); }
            _httpClient.DefaultRequestHeaders.Authorization = new AuthenticationHeaderValue("Bearer", token);
            #endregion

            var response = await _httpClient.PutAsync($"{EndPoints.EditarProducto}/{idProducto}", content);

           // var response = await _httpClient.PutAsync(EndPoints.EditarProducto, content);

            if (!response.IsSuccessStatusCode)
            {
                throw new Exception("Algo fallo en la edicion del producto");
            }

        }

        public async Task EliminarProducto(int idProducto)
        {
            var id = new { Id = idProducto };
            var jsonContent = JsonConvert.SerializeObject(id);
            var content = new StringContent(jsonContent, Encoding.UTF8, "application/json");            
            
            #region autenticacion
            var token = await SecureStorage.GetAsync("auth_token");
            if (string.IsNullOrEmpty(token)) { throw new Exception("No se encontró el token de autenticación."); }
            _httpClient.DefaultRequestHeaders.Authorization = new AuthenticationHeaderValue("Bearer", token);
            #endregion

            var response = await _httpClient.DeleteAsync($"{EndPoints.EliminarProducto}/{idProducto}");

            if (!response.IsSuccessStatusCode)
            {
                throw new Exception("Algo fallo en la eliminacion del producto");
            }
        }

        public async Task CrearProducto(string nombreProducto, string descripcion, decimal precio, string imagen, int stock)
        {
            var producto = new { nombre = nombreProducto, Descripcion = descripcion, Precio = precio, Img = imagen, Stock = stock };
            var jsonContent = JsonConvert.SerializeObject(producto);
            var content = new StringContent(jsonContent, Encoding.UTF8, "application/json");

            #region autenticacion
            var token = await SecureStorage.GetAsync("auth_token");
            if (string.IsNullOrEmpty(token)) { throw new Exception("No se encontró el token de autenticación."); }
            _httpClient.DefaultRequestHeaders.Authorization = new AuthenticationHeaderValue("Bearer", token);
            #endregion

            var response = await _httpClient.PostAsync(EndPoints.CrearProducto, content);

            if (!response.IsSuccessStatusCode)
            {
                throw new Exception("Error en la creacion del producto");
            }
        }


        #endregion

    }



}
