using System.Text;
using AppMAUI_TP6.Models;
using AppMAUI_TP6.Utils;
using Newtonsoft.Json;

namespace AppMAUI_TP6.Service
{
    public class Login
    {
        private readonly HttpClient _httpClient;

        public Login()
        {
            _httpClient = new HttpClient();
            // Configura la base URL de la API
            _httpClient.BaseAddress = new Uri(EndPoints.URLApi);
        }

        public async Task<string> LoginAsync(string email, string password)
        {
            var loginData = new { Email = email, Password = password };
            var jsonContent = JsonConvert.SerializeObject(loginData);
            var content = new StringContent(jsonContent, Encoding.UTF8, "application/json");

            // Enviar la solicitud al endpoint de login
            var response = await _httpClient.PostAsync(EndPoints.Login, content);

            if (response.IsSuccessStatusCode)
            {
                var jsonResponse = await response.Content.ReadAsStringAsync();

                // Deserializar la respuesta JSON en tu modelo LoginM
                var tokenResponse = JsonConvert.DeserializeObject<LoginM>(jsonResponse);

                if (tokenResponse != null && !string.IsNullOrEmpty(tokenResponse.Token))
                {
                    // Guardar solo el token en SecureStorage
                    await SecureStorage.SetAsync("auth_token", tokenResponse.Token);

                    return tokenResponse.Token;
                }
                else
                {
                    throw new Exception("Token no valido en la respuesta del servidor.");
                }
            }
            else
            {
                throw new Exception("Login failed");
            }
        }

        public async Task<bool> RegistrarAsync(string email, string username, string password, string nombre, string apellido, string nrocelular)
        {
            var usuario = new
            {
                Email = email,
                Username = username,
                Password = password,
                Nombre = nombre,
                Apellido = apellido,
                Nrocelular = nrocelular,
            };

            var jsonContent = JsonConvert.SerializeObject(usuario);
            var content = new StringContent(jsonContent, Encoding.UTF8, "application/json");

            // Enviar la solicitud al endpoint de login
            var response = await _httpClient.PostAsync(EndPoints.Registrar, content);

            return response.IsSuccessStatusCode;
        }
    }
}

