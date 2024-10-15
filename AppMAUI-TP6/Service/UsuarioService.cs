using AppMAUI_TP6.Models;
using System.Net.Http.Headers;
using System.Text.Json;
using AppMAUI_TP6.Utils;
using System.Net.Http.Json;
using System.Text;

using AppMAUI_TP6.Models;
using AppMAUI_TP6.Utils;
using Newtonsoft.Json;
using System.Net.Http.Headers;

namespace AppMAUI_TP6.Service
{
    
    public class UsuarioService
    {
        private readonly HttpClient _httpClient;

        public UsuarioService()
        {
            _httpClient = new HttpClient();
            // Configura la base URL de la API
            _httpClient.BaseAddress = new Uri(EndPoints.URLApi);
        }

        public async Task<List<Usuario>> GetListaUsuario()
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
            var response = await _httpClient.GetAsync(EndPoints.ListaUsuario);

            if (response.IsSuccessStatusCode)
            {
                var json = await response.Content.ReadAsStringAsync();
                var usuario = JsonConvert.DeserializeObject<List<Usuario>>(json);
                return usuario;
            }
            else
            {
                throw new Exception("Fallo en la solicitud de datos");
            }
        }


        #region Crud 
        public async Task EditarUsuario(int idUsuario, string email, string username, string password, int idPersona, string nombre, string apellido, string nroCelular, string rol)
        {
            var user = new { id = idUsuario, em = email, usern = username, pass = password, personaid = idPersona, nomb = nombre, ape = apellido, nro = nroCelular, Rol = rol };
            var jsonContent = JsonConvert.SerializeObject(user);
            var content = new StringContent(jsonContent, Encoding.UTF8, "application/json");


            #region autenticacion
            var token = await SecureStorage.GetAsync("auth_token");
            if (string.IsNullOrEmpty(token)) { throw new Exception("No se encontró el token de autenticación."); }
            _httpClient.DefaultRequestHeaders.Authorization = new AuthenticationHeaderValue("Bearer", token);
            #endregion

            var response = await _httpClient.PutAsync(EndPoints.EditarUsuario, content);

            if (!response.IsSuccessStatusCode)
            {
                throw new Exception("Algo fallo en la edicion del usuario");
            }
        }

        public async Task EliminarUsuario(int idUsuario)
        {
            var id = new { Id = idUsuario };
            var jsonContent = JsonConvert.SerializeObject(id);
            var content = new StringContent(jsonContent, Encoding.UTF8, "application/json");

            #region autenticacion
            var token = await SecureStorage.GetAsync("auth_token");
            if (string.IsNullOrEmpty(token)) { throw new Exception("No se encontró el token de autenticación."); }
            _httpClient.DefaultRequestHeaders.Authorization = new AuthenticationHeaderValue("Bearer", token);
            #endregion

            var response = await _httpClient.DeleteAsync($"Usuario/eliminar/{content}");
            
            if (!response.IsSuccessStatusCode)
            {
                throw new Exception("Algo fallo en la eliminacion del usuario");
            }
        }

        public async Task CrearUsuario(string email, string username, string password, string nombre, string apellido, string nroCelular, string rol)
        {
            var user = new { em = email, usern = username, pass = password, nomb = nombre, ape = apellido, nro = nroCelular, Rol = rol };
            var jsonContent = JsonConvert.SerializeObject(user);
            var content = new StringContent(jsonContent, Encoding.UTF8, "application/json");

            #region autenticacion
            var token = await SecureStorage.GetAsync("auth_token");
            if (string.IsNullOrEmpty(token)) { throw new Exception("No se encontró el token de autenticación."); }
            _httpClient.DefaultRequestHeaders.Authorization = new AuthenticationHeaderValue("Bearer", token);
            #endregion

            var response = await _httpClient.PostAsync(EndPoints.CrearUsuario, content);

            if (!response.IsSuccessStatusCode)
            {
                throw new Exception("Error en la creacion del usuario");
            }
        }


        #endregion
    }
}
