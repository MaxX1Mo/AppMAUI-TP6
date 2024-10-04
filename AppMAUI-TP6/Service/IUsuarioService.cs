using AppMAUI_TP6.Models;

namespace AppMAUI_TP6.Service
{
    public interface IUsuarioService
    {
        Task<IEnumerable<Usuario>> GetUsersAsync();
        
        Task<string> AuthenticateUserAsync(string username, string password);

    }
}
