using Microservicio.Clientes.Business.DTOs;
using Microservicio.Clientes.DataManagement.Models;
using System;
using System.Collections.Generic;
using System.Text;

namespace Microservicio.Clientes.Business.Interfaces
{
    public interface IClienteService
    {
        // 🔍 CONSULTAS

        Task<ClienteResponse?> GetByIdAsync(int id);

        Task<IEnumerable<ClienteResponse>> GetAllAsync();

        Task<DataPagedResult<ClienteResponse>> GetPagedAsync(ClienteFiltroRequest request);

        // ✏️ OPERACIONES

        Task<ClienteResponse> CreateAsync(CrearClienteRequest request);

        Task<bool> UpdateAsync(int id, ActualizarClienteRequest request);

        Task<bool> DeleteAsync(int id);
    }
}