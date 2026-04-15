using System;
using System.Collections.Generic;
using System.Text;

namespace Microservicio.Clientes.Business.DTOs
{
    public class CrearClienteRequest
    {
        // 🔹 DATOS OBLIGATORIOS
        public string Nombre { get; set; }
        public string Apellido { get; set; }
        public string Cedula { get; set; }

        // 🔹 DATOS OPCIONALES
        public string? Correo { get; set; }
        public string? Telefono { get; set; }

        // 🔹 ESTADO (puede venir o no)
        public bool Estado { get; set; } = true;
    }
}
