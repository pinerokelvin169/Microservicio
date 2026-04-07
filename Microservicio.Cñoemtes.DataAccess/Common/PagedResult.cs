using System;
using System.Collections.Generic;
using System.Text;

namespace Microservicio.Clientes.DataAccess.Common
{
    public class PagedResult<T>
    {
        // 🔥 DATOS
        public IEnumerable<T> Data { get; set; }

        // 🔥 TOTAL DE REGISTROS
        public int Total { get; set; }

        // 🔥 PAGINACIÓN
        public int Page { get; set; }
        public int PageSize { get; set; }

        // 🔥 TOTAL DE PÁGINAS
        public int TotalPages
            => (int)Math.Ceiling((double)Total / PageSize);
    }
}