using System;
using System.Collections.Generic;
using System.Text;

using Microservicio.Clientes.DataAccess.Repositories.Interfaces;

namespace Microservicio.Clientes.DataManagement.Interfaces
{
    public interface IUnitOfWork
    {
        // 🔥 REPOSITORIOS
        IClienteRepository Clientes { get; }
        IUsuarioAppRepository Usuarios { get; }

        // 💾 GUARDAR CAMBIOS
        Task<int> SaveChangesAsync();

        // 🔥 TRANSACCIONES (PRO)
        Task BeginTransactionAsync();
        Task CommitAsync();
        Task RollbackAsync();
    }
}