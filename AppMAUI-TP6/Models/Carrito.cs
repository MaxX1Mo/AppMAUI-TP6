using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace AppMAUI_TP6.Models
{
    public class Carrito
    {   
        public int idCarrito { get; set; }
        public DateTime fecha { get; set; }
        public int idUsuario { get; set; }
        //public ICollection<DetalleCarrito> Productos { get; set; }

    }
}
