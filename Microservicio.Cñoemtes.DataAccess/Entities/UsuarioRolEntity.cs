using System;
using System.Collections.Generic;
using System.Text;

namespace Microservicio.Clientes.DataAccess.Entities
{
    public class UsuarioRolEntity
    {
        // 🔥 CLAVE COMPUESTA
        public int IdUsuario { get; set; }
        public UsuarioAppEntity Usuario { get; set; }

        public int IdRol { get; set; }
        public RolEntity Rol { get; set; }

        // 🔥 OPCIONAL PERO PRO (recomendado)
        public DateTime FechaAsignacion { get; set; }

        // ESTADO
        public string Estado { get; set; }

        // AUDITORÍA
        public DateTime FechaCreacion { get; set; }
        public string UsuarioCreacion { get; set; }
        public string IpCreacion { get; set; }
        public string AccionCreacion { get; set; }

        public DateTime? FechaModificacion { get; set; }
        public string UsuarioModificacion { get; set; }
        public string IpModificacion { get; set; }
        public string AccionModificacion { get; set; }

        // BORRADO LÓGICO
        public bool Eliminado { get; set; }
    }
}