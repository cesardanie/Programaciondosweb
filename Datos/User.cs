using System;
using System.Collections.Generic;

namespace Datos
{
    public partial class User
    {
        public string Username { get; set; } = null!;
        public string Nombre { get; set; } = null!;
        public string Correo { get; set; } = null!;
        public string Contraseña { get; set; } = null!;
        public bool? TipoUsuario { get; set; }
    }
}
