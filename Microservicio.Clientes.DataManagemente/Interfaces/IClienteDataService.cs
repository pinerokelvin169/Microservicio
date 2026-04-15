using System;
using System.Collections.Generic;
using System.Text;

using Microservicio.Clientes.DataManagement.Models;

namespace Microservicio.Clientes.DataManagement.Interfaces
{
    public interface IClienteDataService
    {
        // 🔍 CONSULTAS

        Task<ClienteDataModel?> GetByIdAsync(int id);

        Task<ClienteDataModel?> GetByCedulaAsync(string cedula);

        Task<IEnumerable<ClienteDataModel>> GetAllAsync();

        // 🔥 CONSULTA CON FILTRO + PAGINACIÓN
        Task<DataPagedResult<ClienteDataModel>> GetPagedAsync(ClienteFiltroDataModel filtro);

        // ✏️ OPERACIONES

        Task<ClienteDataModel> CreateAsync(ClienteDataModel model);

        Task<bool> UpdateAsync(int id, ClienteDataModel model);

        Task<bool> DeleteAsync(int id); // borrado lógico
    }
}