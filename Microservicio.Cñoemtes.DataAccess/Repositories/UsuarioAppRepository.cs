using System;
using System.Collections.Generic;
using System.Text;

using Microsoft.EntityFrameworkCore;
using Microservicio.Clientes.DataAccess.Context;
using Microservicio.Clientes.DataAccess.Entities;
using Microservicio.Clientes.DataAccess.Repositories.Interfaces;

namespace Microservicio.Clientes.DataAccess.Repositories
{
    public class UsuarioAppRepository : IUsuarioAppRepository
    {
        private readonly ClientesDbContext _context;

        public UsuarioAppRepository(ClientesDbContext context)
        {
            _context = context;
        }

        // 🔍 CONSULTAS

        public async Task<UsuarioAppEntity?> GetByIdAsync(int id)
        {
            return await _context.Usuarios
                .FirstOrDefaultAsync(u => u.IdUsuario == id);
        }

        public async Task<UsuarioAppEntity?> GetByUsernameAsync(string username)
        {
            return await _context.Usuarios
                .FirstOrDefaultAsync(u => u.Username == username);
        }

        // 🔥 TRAER USUARIO + ROLES
        public async Task<UsuarioAppEntity?> GetWithRolesAsync(string username)
        {
            return await _context.Usuarios
                .Include(u => u.UsuarioRoles)
                    .ThenInclude(ur => ur.Rol)
                .FirstOrDefaultAsync(u => u.Username == username);
        }

        public async Task<IEnumerable<UsuarioAppEntity>> GetAllAsync()
        {
            return await _context.Usuarios.ToListAsync();
        }

        // ✏️ OPERACIONES

        public async Task AddAsync(UsuarioAppEntity usuario)
        {
            await _context.Usuarios.AddAsync(usuario);
        }

        public void Update(UsuarioAppEntity usuario)
        {
            _context.Usuarios.Update(usuario);
        }

        public void Delete(UsuarioAppEntity usuario)
        {
            // 🔥 BORRADO LÓGICO
            usuario.Eliminado = true;
            _context.Usuarios.Update(usuario);
        }

        // 🔐 SEGURIDAD

        public async Task IncrementarIntentosFallidosAsync(int id)
        {
            var usuario = await GetByIdAsync(id);
            if (usuario != null)
            {
                usuario.IntentosFallidos++;

                if (usuario.IntentosFallidos >= 3)
                {
                    usuario.Bloqueado = true;
                }

                _context.Usuarios.Update(usuario);
            }
        }

        public async Task ResetIntentosFallidosAsync(int id)
        {
            var usuario = await GetByIdAsync(id);
            if (usuario != null)
            {
                usuario.IntentosFallidos = 0;
                _context.Usuarios.Update(usuario);
            }
        }

        public async Task BloquearUsuarioAsync(int id)
        {
            var usuario = await GetByIdAsync(id);
            if (usuario != null)
            {
                usuario.Bloqueado = true;
                _context.Usuarios.Update(usuario);
            }
        }

        // 💾 SAVE

        public async Task SaveChangesAsync()
        {
            await _context.SaveChangesAsync();
        }
    }
}
