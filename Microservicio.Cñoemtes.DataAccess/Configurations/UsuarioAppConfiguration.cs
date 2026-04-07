using System;
using System.Collections.Generic;
using System.Text;
using Microsoft.EntityFrameworkCore;
using Microsoft.EntityFrameworkCore.Metadata.Builders;
using Microservicio.Clientes.DataAccess.Entities;

namespace Microservicio.Clientes.DataAccess.Configuration
{
    public class UsuarioAppConfiguration : IEntityTypeConfiguration<UsuarioAppEntity>
    {
        public void Configure(EntityTypeBuilder<UsuarioAppEntity> builder)
        {
            // 🔥 TABLA
            builder.ToTable("Usuario", "crm");

            // 🔥 PRIMARY KEY
            builder.HasKey(u => u.IdUsuario);

            // 🔥 PROPIEDADES
            builder.Property(u => u.IdUsuario)
                   .ValueGeneratedOnAdd();

            builder.Property(u => u.RowVersion)
                   .IsRowVersion();

            builder.Property(u => u.Username)
                   .HasMaxLength(100)
                   .IsRequired();

            builder.Property(u => u.PasswordHash)
                   .HasMaxLength(255)
                   .IsRequired();

            // 🔥 RELACIÓN CON CLIENTE (OPCIONAL)
            builder.HasOne(u => u.Cliente)
                   .WithMany()
                   .HasForeignKey(u => u.IdCliente)
                   .OnDelete(DeleteBehavior.Restrict);

            // 🔥 SEGURIDAD
            builder.Property(u => u.IntentosFallidos)
                   .HasDefaultValue(0);

            builder.Property(u => u.Bloqueado)
                   .HasDefaultValue(false);

            builder.Property(u => u.Estado)
                   .HasMaxLength(20)
                   .HasDefaultValue("ACTIVO");

            // 🔥 AUDITORÍA
            builder.Property(u => u.UsuarioCreacion)
                   .HasMaxLength(100);

            builder.Property(u => u.UsuarioModificacion)
                   .HasMaxLength(100);

            builder.Property(u => u.IpCreacion)
                   .HasMaxLength(50);

            builder.Property(u => u.IpModificacion)
                   .HasMaxLength(50);

            builder.Property(u => u.AccionCreacion)
                   .HasMaxLength(50);

            builder.Property(u => u.AccionModificacion)
                   .HasMaxLength(50);

            // 🔥 BORRADO LÓGICO
            builder.Property(u => u.Eliminado)
                   .HasDefaultValue(false);

            // 🔥 ÍNDICE ÚNICO 🔐
            builder.HasIndex(u => u.Username)
                   .IsUnique();

            // 🔥 FILTRO GLOBAL (SOFT DELETE)
            builder.HasQueryFilter(u => !u.Eliminado);
        }
    }
}
