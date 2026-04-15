using System;
using System.Collections.Generic;
using System.Text;

using Microservicio.Clientes.DataManagement.Interfaces;
using Microservicio.Clientes.DataManagement.Models;
using Microservicio.Clientes.DataManagement.Mappers;
using Microservicio.Clientes.DataAccess.Repositories.Interfaces;

namespace Microservicio.Clientes.DataManagement.Services
{
    public class ClienteDataService : IClienteDataService
    {
        private readonly IUnitOfWork _unitOfWork;

        public ClienteDataService(IUnitOfWork unitOfWork)
        {
            _unitOfWork = unitOfWork;
        }

        // 🔍 CONSULTAS

        public async Task<ClienteDataModel?> GetByIdAsync(int id)
        {
            var entity = await _unitOfWork.Clientes.GetByIdAsync(id);
            return ClienteDataMapper.ToDataModel(entity);
        }

        public async Task<ClienteDataModel?> GetByCedulaAsync(string cedula)
        {
            var entity = await _unitOfWork.Clientes.GetByCedulaAsync(cedula);
            return ClienteDataMapper.ToDataModel(entity);
        }

        public async Task<IEnumerable<ClienteDataModel>> GetAllAsync()
        {
            var entities = await _unitOfWork.Clientes.GetAllAsync();
            return entities.Select(ClienteDataMapper.ToDataModel);
        }

        public async Task<DataPagedResult<ClienteDataModel>> GetPagedAsync(ClienteFiltroDataModel filtro)
        {
            var (data, total) = await _unitOfWork.Clientes.GetPagedAsync(filtro.Page, filtro.PageSize);

            return new DataPagedResult<ClienteDataModel>
            {
                Data = data.Select(ClienteDataMapper.ToDataModel),
                Total = total,
                Page = filtro.Page,
                PageSize = filtro.PageSize
            };
        }

        // ✏️ OPERACIONES

        public async Task<ClienteDataModel> CreateAsync(ClienteDataModel model)
        {
            var entity = ClienteDataMapper.ToEntity(model);

            await _unitOfWork.Clientes.AddAsync(entity);
            await _unitOfWork.SaveChangesAsync();

            return ClienteDataMapper.ToDataModel(entity);
        }

        public async Task<bool> UpdateAsync(int id, ClienteDataModel model)
        {
            var entity = await _unitOfWork.Clientes.ObtenerParaActualizarAsync(id);

            if (entity == null)
                return false;

            ClienteDataMapper.UpdateEntity(entity, model);

            _unitOfWork.Clientes.Update(entity);
            await _unitOfWork.SaveChangesAsync();

            return true;
        }

        public async Task<bool> DeleteAsync(int id)
        {
            var entity = await _unitOfWork.Clientes.ObtenerParaActualizarAsync(id);

            if (entity == null)
                return false;

            _unitOfWork.Clientes.Delete(entity);
            await _unitOfWork.SaveChangesAsync();

            return true;
        }
    }
}
