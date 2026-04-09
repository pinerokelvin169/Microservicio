using System;
using System.Collections.Generic;
using System.Text;

using Microservicio.Clientes.DataAccess.Entities;

namespace Microservicio.Clientes.DataAccess.Repositories.Interfaces
{
    public interface IUsuarioAppRepository
    {
        // 🔍 CONSULTAS

        Task<UsuarioAppEntity?> GetByIdAsync(int id);

        Task<UsuarioAppEntity?> GetByUsernameAsync(string username);

        Task<UsuarioAppEntity?> GetWithRolesAsync(string username);

        Task<IEnumerable<UsuarioAppEntity>> GetAllAsync();

        // ✏️ OPERACIONES

        Task AddAsync(UsuarioAppEntity usuario);

        void Update(UsuarioAppEntity usuario);

        void Delete(UsuarioAppEntity usuario); // lógico

        // 🔐 SEGURIDAD

        Task IncrementarIntentosFallidosAsync(int id);

        Task ResetIntentosFallidosAsync(int id);

        Task BloquearUsuarioAsync(int id);

        // 💾 GUARDAR
        Task SaveChangesAsync();
    }
}
