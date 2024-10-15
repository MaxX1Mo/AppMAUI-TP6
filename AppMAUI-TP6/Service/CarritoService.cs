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

        public async Task<List<Carrito>> GetListaCarritos()
        {
            #region autenticacion
            var token = await SecureStorage.GetAsync("auth_token");
            if (string.IsNullOrEmpty(token)) { throw new Exception("No se encontró el token de autenticación."); }
            _httpClient.DefaultRequestHeaders.Authorization = new AuthenticationHeaderValue("Bearer", token);
            #endregion
            
            var response = await _httpClient.GetAsync(EndPoints.ListaCarrito);

            if (response.IsSuccessStatusCode)
            {
                var json = await response.Content.ReadAsStringAsync();
                var carritos = JsonConvert.DeserializeObject<List<Carrito>>(json);
                return carritos;
            }
            else
            {
                throw new Exception("Fallo en la solicitud de datos ");
            }
        }

        #region no funciona lo dejo a futuro
        // Método para crear un nuevo carrito
        public async Task CrearCarrito(int productoId, int cantidad)
        {
            #region logica para autenticacion y extraer dato idusuario
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
            #endregion

            var carritoData = new
            {
                IDUsuario = usuarioId,
                DetallesCarrito = new[]
                {
                new { ProductoId = productoId, Cantidad = cantidad }
            }
            };

            var content = new StringContent(JsonConvert.SerializeObject(carritoData), Encoding.UTF8, "application/json");
            var response = await _httpClient.PostAsync(EndPoints.CrearCarrito, content);

            if (!response.IsSuccessStatusCode)
            {
                throw new Exception("Error al crear el carrito.");
            }
        }
        #endregion

        
        public async Task EliminarCarrito(int idCarrito)
        {

            #region autenticacion
            var token = await SecureStorage.GetAsync("auth_token");
            if (string.IsNullOrEmpty(token)) { throw new Exception("No se encontró el token de autenticación."); }
            _httpClient.DefaultRequestHeaders.Authorization = new AuthenticationHeaderValue("Bearer", token);
            #endregion

            var response = await _httpClient.DeleteAsync($"Carrito/eliminar/{idCarrito}");

            if (!response.IsSuccessStatusCode)
            {
                throw new Exception("Algo fallo en la eliminacion del carrito");
            }
        }
        



    }
}
