using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace AppMAUI_TP6.Models
{
    public class Carrito
    {
        public int IdCarrito { get; set; }
        public DateTime Fecha { get; set; }
        public int IdUsuario { get; set; }
        public List<DetallesCarrito> Productos { get; set; }

    }
}
