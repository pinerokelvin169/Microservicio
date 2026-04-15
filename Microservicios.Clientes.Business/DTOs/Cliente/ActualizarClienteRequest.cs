using System;
using System.Collections.Generic;
using System.Text;

namespace Microservicio.Clientes.Business.DTOs
{
    public class ActualizarClienteRequest
    {
        // 🔹 DATOS ACTUALIZABLES
        public string Nombre { get; set; }
        public string Apellido { get; set; }
        public string Cedula { get; set; }
        public string Correo { get; set; }
        public string Telefono { get; set; }

        // 🔹 ESTADO
        public bool Estado { get; set; }
    }
}
