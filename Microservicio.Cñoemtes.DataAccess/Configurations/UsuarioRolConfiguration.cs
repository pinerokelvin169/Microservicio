using System;
using System.Collections.Generic;
using System.Text;

using Microsoft.EntityFrameworkCore;
using Microsoft.EntityFrameworkCore.Metadata.Builders;
using Microservicio.Clientes.DataAccess.Entities;

namespace Microservicio.Clientes.DataAccess.Configuration
{
    public class UsuarioRolConfiguration : IEntityTypeConfiguration<UsuarioRolEntity>
    {
        public void Configure(EntityTypeBuilder<UsuarioRolEntity> builder)
        {
            // 🔥 TABLA
            builder.ToTable("UsuarioRol", "crm");

            // 💣 CLAVE COMPUESTA (LO MÁS IMPORTANTE)
            builder.HasKey(ur => new { ur.IdUsuario, ur.IdRol });

            // 🔥 RELACIÓN CON USUARIO
            builder.HasOne(ur => ur.Usuario)
                   .WithMany(u => u.UsuarioRoles)
                   .HasForeignKey(ur => ur.IdUsuario)
                   .OnDelete(DeleteBehavior.Restrict);

            // 🔥 RELACIÓN CON ROL
            builder.HasOne(ur => ur.Rol)
                   .WithMany(r => r.UsuarioRoles)
                   .HasForeignKey(ur => ur.IdRol)
                   .OnDelete(DeleteBehavior.Restrict);

            // 🔥 PROPIEDADES
            builder.Property(ur => ur.Estado)
                   .HasMaxLength(20)
                   .HasDefaultValue("ACTIVO");

            builder.Property(ur => ur.FechaAsignacion)
                   .HasDefaultValueSql("GETDATE()");

            // 🔥 AUDITORÍA
            builder.Property(ur => ur.UsuarioCreacion)
                   .HasMaxLength(100);

            builder.Property(ur => ur.UsuarioModificacion)
                   .HasMaxLength(100);

            builder.Property(ur => ur.IpCreacion)
                   .HasMaxLength(50);

            builder.Property(ur => ur.IpModificacion)
                   .HasMaxLength(50);

            builder.Property(ur => ur.AccionCreacion)
                   .HasMaxLength(50);

            builder.Property(ur => ur.AccionModificacion)
                   .HasMaxLength(50);

            // 🔥 BORRADO LÓGICO
            builder.Property(ur => ur.Eliminado)
                   .HasDefaultValue(false);

            // 🔥 FILTRO GLOBAL (SOFT DELETE)
            builder.HasQueryFilter(ur => !ur.Eliminado);
        }
    }
}