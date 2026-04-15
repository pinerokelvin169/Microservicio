using System;
using System.Collections.Generic;
using System.Text;

namespace Microservicio.Clientes.Business.DTOs
{
    public class ClienteFiltroRequest
    {
        // 🔍 FILTROS
        public string? Nombre { get; set; }
        public string? Apellido { get; set; }
        public string? Cedula { get; set; }
        public string? Correo { get; set; }

        // 🔹 ESTADO
        public bool? Estado { get; set; }

        // 📄 PAGINACIÓN
        public int Page { get; set; } = 1;
        public int PageSize { get; set; } = 10;

        // 🔹 ORDENAMIENTO (PRO 🔥)
        public string? OrderBy { get; set; } = "Nombre";
        public bool Descending { get; set; } = false;
    }
}
