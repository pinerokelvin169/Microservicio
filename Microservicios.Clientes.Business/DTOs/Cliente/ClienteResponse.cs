using System;
using System.Collections.Generic;
using System.Text;

namespace Microservicio.Clientes.Business.DTOs
{
    public class ClienteResponse
    {
        // 🔹 IDENTIFICACIÓN
        public int IdCliente { get; set; }

        // 🔹 DATOS FUNCIONALES
        public string NombreCompleto { get; set; }
        public string Cedula { get; set; }
        public string Correo { get; set; }
        public string Telefono { get; set; }

        // 🔹 ESTADO
        public bool Estado { get; set; }
    }
}