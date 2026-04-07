using System;
using System.Collections.Generic;
using System.Text;

using Microsoft.EntityFrameworkCore;
using Microsoft.EntityFrameworkCore.Metadata.Builders;
using Microservicio.Clientes.DataAccess.Entities;

namespace Microservicio.Clientes.DataAccess.Configuration
{
    public class RolConfiguration : IEntityTypeConfiguration<RolEntity>
    {
        public void Configure(EntityTypeBuilder<RolEntity> builder)
        {
            // 🔥 TABLA
            builder.ToTable("Rol", "crm");

            // 🔥 PRIMARY KEY
            builder.HasKey(r => r.IdRol);

            // 🔥 PROPIEDADES
            builder.Property(r => r.IdRol)
                   .ValueGeneratedOnAdd();

            builder.Property(r => r.RowVersion)
                   .IsRowVersion();

            builder.Property(r => r.Nombre)
                   .HasMaxLength(50)
                   .IsRequired();

            builder.Property(r => r.Descripcion)
                   .HasMaxLength(255);

            builder.Property(r => r.Estado)
                   .HasMaxLength(20)
                   .HasDefaultValue("ACTIVO");

            // 🔥 AUDITORÍA
            builder.Property(r => r.UsuarioCreacion)
                   .HasMaxLength(100);

            builder.Property(r => r.UsuarioModificacion)
                   .HasMaxLength(100);

            builder.Property(r => r.IpCreacion)
                   .HasMaxLength(50);

            builder.Property(r => r.IpModificacion)
                   .HasMaxLength(50);

            builder.Property(r => r.AccionCreacion)
                   .HasMaxLength(50);

            builder.Property(r => r.AccionModificacion)
                   .HasMaxLength(50);

            // 🔥 BORRADO LÓGICO
            builder.Property(r => r.Eliminado)
                   .HasDefaultValue(false);

            // 🔥 ÍNDICE ÚNICO (MUY IMPORTANTE 🔥)
            builder.HasIndex(r => r.Nombre)
                   .IsUnique();

            // 🔥 FILTRO GLOBAL (SOFT DELETE)
            builder.HasQueryFilter(r => !r.Eliminado);
        }
    }
}