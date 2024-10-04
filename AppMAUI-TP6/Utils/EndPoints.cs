using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace AppMAUI_TP6.Utils
{
    public static class EndPoints
    {
        public const string URLApi = "http://localhost:5280/api/";

        public const string Producto = "Productos";
        public const string Carrito = "Carrito";
        public const string Usuario = "Usuario";
        public const string Login = "Login/acceso";
        //Acciones
        public const string Lista = "lista";
        public const string Buscar = "buscar/{id}";
        public const string Crear = "crear";
        public const string Eliminar = "eliminar/{id}";
        public const string Editar= "editar/{id}";
    }
}
