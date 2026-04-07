using System;
using System.Collections.Generic;
using System.Text;

using Microsoft.EntityFrameworkCore;
using Microservicio.Clientes.DataAccess.Entities;
using Microservicio.Clientes.DataAccess.Configuration;

namespace Microservicio.Clientes.DataAccess.Context
{
    public class ClientesDbContext : DbContext
    {
        public ClientesDbContext(DbContextOptions<ClientesDbContext> options)
            : base(options)
        {
        }

        // 🔥 DBSETS (TABLAS)
        public DbSet<ClienteEntity> Clientes { get; set; }
        public DbSet<UsuarioAppEntity> Usuarios { get; set; }
        public DbSet<RolEntity> Roles { get; set; }
        public DbSet<UsuarioRolEntity> UsuarioRoles { get; set; }
        public DbSet<AuditoriaEntity> Auditorias { get; set; }

        // 🔥 CONFIGURACIONES
        protected override void OnModelCreating(ModelBuilder modelBuilder)
        {
            base.OnModelCreating(modelBuilder);

            // Aplicar configuraciones
            modelBuilder.ApplyConfiguration(new ClienteConfiguration());
            modelBuilder.ApplyConfiguration(new UsuarioAppConfiguration());
            modelBuilder.ApplyConfiguration(new RolConfiguration());
            modelBuilder.ApplyConfiguration(new UsuarioRolConfiguration());
            modelBuilder.ApplyConfiguration(new AuditoriaConfiguration());
        }
    }
}