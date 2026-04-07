using System;
using System.Collections.Generic;
using System.Text;

using Microsoft.EntityFrameworkCore;
using Microservicio.Clientes.DataAccess.Context;
using Microservicio.Clientes.DataAccess.Entities;
using Microservicio.Clientes.DataAccess.Repositories.Interfaces;

namespace Microservicio.Clientes.DataAccess.Repositories
{
    public class ClienteRepository : IClienteRepository
    {
        private readonly ClientesDbContext _context;

        public ClienteRepository(ClientesDbContext context)
        {
            _context = context;
        }

        // 🔍 CONSULTAS

        public async Task<ClienteEntity> GetByIdAsync(int id)
        {
            return await _context.Clientes
                .FirstOrDefaultAsync(c => c.IdCliente == id);
        }

        public async Task<ClienteEntity> GetByCedulaAsync(string cedula)
        {
            return await _context.Clientes
                .FirstOrDefaultAsync(c => c.Cedula == cedula);
        }

        public async Task<IEnumerable<ClienteEntity>> GetAllAsync()
        {
            return await _context.Clientes
                .ToListAsync();
        }

        public async Task<(IEnumerable<ClienteEntity> data, int total)> GetPagedAsync(int page, int pageSize)
        {
            var query = _context.Clientes.AsQueryable();

            var total = await query.CountAsync();

            var data = await query
                .Skip((page - 1) * pageSize)
                .Take(pageSize)
                .ToListAsync();

            return (data, total);
        }

        // ✏️ OPERACIONES

        public async Task AddAsync(ClienteEntity cliente)
        {
            await _context.Clientes.AddAsync(cliente);
        }

        public void Update(ClienteEntity cliente)
        {
            _context.Clientes.Update(cliente);
        }

        public void Delete(ClienteEntity cliente)
        {
            // 🔥 BORRADO LÓGICO
            cliente.Eliminado = true;
            _context.Clientes.Update(cliente);
        }

        // 💾 GUARDAR CAMBIOS
        public async Task SaveChangesAsync()
        {
            await _context.SaveChangesAsync();
        }
    }
}
