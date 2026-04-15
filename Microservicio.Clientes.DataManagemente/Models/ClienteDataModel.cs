using System;
using System.Collections.Generic;
using System.Text;

namespace Microservicio.Clientes.DataManagement.Models
{
    public class ClienteDataModel
    {
        // 🔹 IDENTIFICACIÓN
        public int IdCliente { get; set; }

        // 🔹 DATOS FUNCIONALES
        public string Nombre { get; set; }
        public string Apellido { get; set; }
        public string Cedula { get; set; }
        public string Correo { get; set; }
        public string Telefono { get; set; }

        // 🔹 ESTADO
        public bool Estado { get; set; }

        // 🔹 AUDITORÍA (solo lectura en capa superior)
        public DateTime FechaCreacion { get; set; }
        public string UsuarioCreacion { get; set; }

        public DateTime? FechaModificacion { get; set; }
        public string UsuarioModificacion { get; set; }

        // 🔹 BORRADO LÓGICO
        public bool Eliminado { get; set; }
    }
}