
using AppMAUI_TP6.Models;

namespace AppMAUI_TP6.Service
{
    public interface IProductoService
    {
        Task<IEnumerable<Producto>> GetProductsAsync();

    }
}


