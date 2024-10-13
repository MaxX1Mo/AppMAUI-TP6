﻿using System;
using System.Collections.Generic;
using System.Data;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using AppMAUI_TP6.Utils;

namespace AppMAUI_TP6.Models
{
    public class Usuario
    {
        public int IDUsuario { get; set; }
        public string? Email { get; set; }
        public string? Username { get; set; }
        public string? Password { get; set; }
        public int IDPersona { get; set; }
        public string? Nombre { get; set; }
        public string? Apellido { get; set; }
        public string? NroCelular { get; set; }
        public string Rol { get; set; }

    }
}
