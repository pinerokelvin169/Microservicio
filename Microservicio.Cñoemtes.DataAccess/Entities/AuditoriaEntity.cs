using System;
using System.Collections.Generic;
using System.Text;

namespace Microservicio.Clientes.DataAccess.Entities
{
    public class AuditoriaEntity
    {
        // IDENTIFICACIÓN TÉCNICA
        public int IdAuditoria { get; set; }
        public byte[] RowVersion { get; set; }

        // INFORMACIÓN GENERAL
        public string Tabla { get; set; }           // Cliente, Pago, Boleto
        public string Accion { get; set; }          // INSERT, UPDATE, DELETE

        public string Usuario { get; set; }
        public string Ip { get; set; }

        public DateTime Fecha { get; set; }

        // DETALLE DEL CAMBIO 🔥
        public string DatosAntes { get; set; }      // JSON
        public string DatosDespues { get; set; }    // JSON

        // CLAVE AFECTADA
        public string IdRegistro { get; set; }      // Ej: "1" o "1-2-3" (PK compuesta)

        // ESTADO
        public string Estado { get; set; }

        // BORRADO LÓGICO
        public bool Eliminado { get; set; }
    }
}
