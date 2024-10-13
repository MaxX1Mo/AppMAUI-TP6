using Newtonsoft.Json;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Net.Http.Headers;
using System.Text;
using System.Threading.Tasks;
using AppMAUI_TP6.Service;
using AppMAUI_TP6.Models;
using AppMAUI_TP6.Utils;
using System.IdentityModel.Tokens.Jwt;

namespace AppMAUI_TP6.Service
{

    public class CarritoService
    {
        private readonly HttpClient _httpClient;

        public CarritoService()
        {
            _httpClient = new HttpClient();
            _httpClient.BaseAddress = new Uri(EndPoints.URLApi);
        }

        // Método para crear un nuevo carrito
        public async Task<int> CrearCarrito(int productoId, int cantidad)
        {
            var token = await SecureStorage.GetAsync("auth_token");
            if (string.IsNullOrEmpty(token))
                throw new Exception("No se encontró el token de autenticación.");
            _httpClient.DefaultRequestHeaders.Authorization = new AuthenticationHeaderValue("Bearer", token);

            ///// obtener id usuario de token jtw ///////////
            // Decodificar el token JWT para obtener el UsuarioId
            var handler = new JwtSecurityTokenHandler();
            var jwtToken = handler.ReadJwtToken(token);

            // El UsuarioId está almacenado en el claim "userId" (una linea de codigo en mi api asi: new Claim(ClaimTypes.NameIdentifier, usuario.IDUsuario.ToString()),)
            // Obtener el UsuarioId del claim "nameidentifier"
            var usuarioIdClaim = jwtToken.Claims.FirstOrDefault(claim => claim.Type == "http://schemas.xmlsoap.org/ws/2005/05/identity/claims/nameidentifier");

            if (usuarioIdClaim == null)
                throw new Exception("No se encontró el claim 'nameidentifier' en el token.");

            int usuarioId = int.Parse(usuarioIdClaim.Value); // Convertir el valor de string a int

            // Obtener la fecha actual 
            var fechaActual = DateTime.UtcNow;

            var carritoData = new
            {
                IDUsuario = usuarioId,
                Fecha = fechaActual,
                DetallesCarrito = new[]
                {
                new { ProductoId = productoId, Cantidad = cantidad }
            }
            };

            var content = new StringContent(JsonConvert.SerializeObject(carritoData), Encoding.UTF8, "application/json");
            var response = await _httpClient.PostAsync(EndPoints.CrearCarrito, content);

            if (response.IsSuccessStatusCode)
            {
                var result = await response.Content.ReadAsStringAsync();
                var carritoId = JsonConvert.DeserializeObject<int>(result); // Asume que el API devuelve el ID del carrito
                return carritoId;
            }
            else
            {
                throw new Exception("Error al crear el carrito.");
            }
        }

        // Método para editar un carrito existente
        public async Task EditarCarrito(int carritoId, int productoId, int cantidad)
        {
            var token = await SecureStorage.GetAsync("auth_token");
            if (string.IsNullOrEmpty(token))
                throw new Exception("No se encontró el token de autenticación.");

            _httpClient.DefaultRequestHeaders.Authorization = new AuthenticationHeaderValue("Bearer", token);
            
            var fechaActual = DateTime.UtcNow;
            var carritoData = new
            {
                ProductoId = productoId,
                FechaActual = fechaActual,
                Cantidad = cantidad
            };

            var content = new StringContent(JsonConvert.SerializeObject(carritoData), Encoding.UTF8, "application/json");
            var response = await _httpClient.PutAsync($"Carrito/editar/{carritoId}", content);

            if (!response.IsSuccessStatusCode)
            {
                throw new Exception("Error al editar el carrito.");
            }
        }

        public async Task<List<DetalleCarrito>> ObtenerDetallesCarrito(int carritoId)
        {
            var token = await SecureStorage.GetAsync("auth_token");
            if (string.IsNullOrEmpty(token))
                throw new Exception("No se encontró el token de autenticación.");

            _httpClient.DefaultRequestHeaders.Authorization = new AuthenticationHeaderValue("Bearer", token);

            var response = await _httpClient.GetAsync($"Carrito/buscar/{carritoId}");

            if (response.IsSuccessStatusCode)
            {
                var json = await response.Content.ReadAsStringAsync();
                var detalles = JsonConvert.DeserializeObject<List<DetalleCarrito>>(json);
                return detalles;
            }
            else
            {
                throw new Exception("Error al obtener detalles del carrito.");
            }
        }

    }
}
