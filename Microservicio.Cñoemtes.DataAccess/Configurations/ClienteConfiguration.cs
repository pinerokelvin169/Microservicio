using System;
using System.Collections.Generic;
using System.Text;
using Microsoft.EntityFrameworkCore;
using Microsoft.EntityFrameworkCore.Metadata.Builders;
using Microservicio.Clientes.DataAccess.Entities;

namespace Microservicio.Clientes.DataAccess.Configuration
{
    public class ClienteConfiguration : IEntityTypeConfiguration<ClienteEntity>
    {
        public void Configure(EntityTypeBuilder<ClienteEntity> builder)
        {
            // 🔥 TABLA
            builder.ToTable("Cliente", "crm");

            // 🔥 PRIMARY KEY
            builder.HasKey(c => c.IdCliente);

            // 🔥 PROPIEDADES
            builder.Property(c => c.IdCliente)
                   .HasColumnName("IdCliente")
                   .ValueGeneratedOnAdd();

            builder.Property(c => c.RowVersion)
                   .IsRowVersion();

            builder.Property(c => c.Nombre)
                   .HasMaxLength(100)
                   .IsRequired();

            builder.Property(c => c.Apellido)
                   .HasMaxLength(100)
                   .IsRequired();

            builder.Property(c => c.Cedula)
                   .HasMaxLength(20)
                   .IsRequired();

            builder.Property(c => c.Correo)
                   .HasMaxLength(150);

            builder.Property(c => c.Telefono)
                   .HasMaxLength(20);

            builder.Property(c => c.Estado)
                   .IsRequired();

            // 🔥 AUDITORÍA
            builder.Property(c => c.UsuarioCreacion)
                   .HasMaxLength(100);

            builder.Property(c => c.UsuarioModificacion)
                   .HasMaxLength(100);

            // 🔥 BORRADO LÓGICO
            builder.Property(c => c.Eliminado)
                   .HasDefaultValue(false);

            // 🔥 ÍNDICES (MUY PRO)
            builder.HasIndex(c => c.Cedula)
                   .IsUnique();

            builder.HasIndex(c => c.Correo);

            // 🔥 FILTRO GLOBAL (SOFT DELETE)
            builder.HasQueryFilter(c => !c.Eliminado);
        }
    }
}