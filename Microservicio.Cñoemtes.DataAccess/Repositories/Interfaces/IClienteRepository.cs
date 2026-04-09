using System;
using System.Collections.Generic;
using System.Text;

using Microservicio.Clientes.DataAccess.Entities;

namespace Microservicio.Clientes.DataAccess.Repositories.Interfaces
{
    public interface IClienteRepository
    {
        // 🔍 CONSULTAS

        Task<ClienteEntity> GetByIdAsync(int id);

        Task<ClienteEntity> GetByCedulaAsync(string cedula);

        Task<IEnumerable<ClienteEntity>> GetAllAsync();

        // 📄 PAGINACIÓN
        Task<(IEnumerable<ClienteEntity> data, int total)> GetPagedAsync(int page, int pageSize);

        // 🔥 PARA ACTUALIZACIÓN (CONCURRENCIA)
        Task<ClienteEntity> ObtenerParaActualizarAsync(int id);

        // ✏️ OPERACIONES

        Task AddAsync(ClienteEntity cliente);

        void Update(ClienteEntity cliente);

        void Delete(ClienteEntity cliente);

        // 💾 GUARDAR CAMBIOS
        Task SaveChangesAsync();
    }
}