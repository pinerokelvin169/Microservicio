using System;
using System.Collections.Generic;
using System.Text;

using Microsoft.EntityFrameworkCore.Storage;
using Microservicio.Clientes.DataAccess.Context;
using Microservicio.Clientes.DataAccess.Repositories.Interfaces;
using Microservicio.Clientes.DataManagement.Interfaces;

namespace Microservicio.Clientes.DataManagement.Services
{
    public class UnitOfWork : IUnitOfWork
    {
        private readonly ClientesDbContext _context;

        private IDbContextTransaction? _transaction;

        // 🔥 REPOSITORIOS
        public IClienteRepository Clientes { get; }
        public IUsuarioAppRepository Usuarios { get; }

        public UnitOfWork(
            ClientesDbContext context,
            IClienteRepository clienteRepository,
            IUsuarioAppRepository usuarioRepository)
        {
            _context = context;
            Clientes = clienteRepository;
            Usuarios = usuarioRepository;
        }

        // 💾 SAVE
        public async Task<int> SaveChangesAsync()
        {
            return await _context.SaveChangesAsync();
        }

        // 🔥 TRANSACCIONES

        public async Task BeginTransactionAsync()
        {
            _transaction = await _context.Database.BeginTransactionAsync();
        }

        public async Task CommitAsync()
        {
            if (_transaction != null)
            {
                await _transaction.CommitAsync();
                await _transaction.DisposeAsync();
            }
        }

        public async Task RollbackAsync()
        {
            if (_transaction != null)
            {
                await _transaction.RollbackAsync();
                await _transaction.DisposeAsync();
            }
        }
    }
}