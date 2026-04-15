using System;
using System.Collections.Generic;
using System.Text;

namespace Microservicio.Clientes.DataManagement.Models
{
    public class DataPagedResult<T>
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

        // 🔥 PRO EXTRA
        public bool HasNextPage => Page < TotalPages;
        public bool HasPreviousPage => Page > 1;
    }
}