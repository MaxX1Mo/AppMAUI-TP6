using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace AppMAUI_TP6.Utils
{
    public static class EndPoints
    {
        public const string URLApi = "https://9s77np9h-5280.brs.devtunnels.ms/api/";

        //public const string Producto = "Productos";
        //public const string Carrito = "Carrito";
        //public const string Usuario = "Usuario";

        public const string Login = "Login/acceso";
        public const string Registrar = "Usuario/registro";

        public const string ListaProducto = "Productos/lista";
        public const string BuscarProducto = "Productos/buscar/";//{id}
        public const string CrearProducto = "Productos/crear";
        public const string EliminarProducto = "Productos/eliminar";//{id}
        public const string EditarProducto = "Productos/editar";//{id}

        public const string ListaUsuario = "Usuario/lista";
        public const string BuscarUsuario = "Usuario/buscar/";//{id}
        public const string CrearUsuario = "Usuario/crear";
        public const string EliminarUsuario = "Usuario/eliminar/";//{id}
        public const string EditarUsuario = "Usuario/editar/";//{id}

        public const string ListaCarrito = "Carrito/lista";
        public const string BuscarCarrito = "Carrito/buscar/";//{id}
        public const string CrearCarrito = "Carrito/crear";
        public const string EliminarCarrito = "Carrito/eliminar/";//{id}
        public const string EditarCarrito = "Carrito/editar/";//{id}
    
    }
}
