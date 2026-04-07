using System;
using System.Collections.Generic;
using System.Text;

using Microsoft.EntityFrameworkCore;
using Microservicio.Clientes.DataAccess.Common;
using Microservicio.Clientes.DataAccess.Context;
using Microservicio.Clientes.DataAccess.Entities;

namespace Microservicio.Clientes.DataAccess.Queries
{
    public class ClienteQueryRepository
    {
        private readonly ClientesDbContext _context;

        public ClienteQueryRepository(ClientesDbContext context)
        {
            _context = context;
        }

        // 🔍 BÚSQUEDA CON FILTRO + PAGINACIÓN 🔥
        public async Task<PagedResult<ClienteEntity>> GetClientesAsync(
            string? search,
            int page,
            int pageSize)
        {
            var query = _context.Clientes.AsQueryable();

            // 🔥 FILTRO DINÁMICO
            if (!string.IsNullOrEmpty(search))
            {
                query = query.Where(c =>
                    c.Nombre.Contains(search) ||
                    c.Apellido.Contains(search) ||
                    c.Cedula.Contains(search));
            }

            // 🔥 TOTAL
            var total = await query.CountAsync();

            // 🔥 PAGINACIÓN
            var data = await query
                .OrderBy(c => c.Nombre)
                .Skip((page - 1) * pageSize)
                .Take(pageSize)
                .ToListAsync();

            return new PagedResult<ClienteEntity>
            {
                Data = data,
                Total = total,
                Page = page,
                PageSize = pageSize
            };
        }

        // 🔍 CONSULTA DETALLADA 🔥
        public async Task<ClienteEntity?> GetClienteDetalleAsync(int id)
        {
            return await _context.Clientes
                .FirstOrDefaultAsync(c => c.IdCliente == id);
        }

        // 🔍 EXISTE CLIENTE 🔥
        public async Task<bool> ExistsByCedulaAsync(string cedula)
        {
            return await _context.Clientes
                .AnyAsync(c => c.Cedula == cedula);
        }
    }
}