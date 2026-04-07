using System;
using System.Collections.Generic;
using System.Text;

using Microsoft.EntityFrameworkCore;
using Microsoft.EntityFrameworkCore.Metadata.Builders;
using Microservicio.Clientes.DataAccess.Entities;

namespace Microservicio.Clientes.DataAccess.Configuration
{
    public class AuditoriaConfiguration : IEntityTypeConfiguration<AuditoriaEntity>
    {
        public void Configure(EntityTypeBuilder<AuditoriaEntity> builder)
        {
            // 🔥 TABLA
            builder.ToTable("Auditoria", "crm");

            // 🔥 PRIMARY KEY
            builder.HasKey(a => a.IdAuditoria);

            // 🔥 PROPIEDADES
            builder.Property(a => a.IdAuditoria)
                   .ValueGeneratedOnAdd();

            builder.Property(a => a.RowVersion)
                   .IsRowVersion();

            // 🔥 CAMPOS PRINCIPALES
            builder.Property(a => a.Tabla)
                   .HasMaxLength(100)
                   .IsRequired();

            builder.Property(a => a.Accion)
                   .HasMaxLength(20)
                   .IsRequired();

            builder.Property(a => a.Usuario)
                   .HasMaxLength(100);

            builder.Property(a => a.Ip)
                   .HasMaxLength(50);

            builder.Property(a => a.Fecha)
                   .HasDefaultValueSql("GETDATE()");

            builder.Property(a => a.IdRegistro)
                   .HasMaxLength(100);

            // 🔥 DATOS JSON (MUY PRO)
            builder.Property(a => a.DatosAntes)
                   .HasColumnType("NVARCHAR(MAX)");

            builder.Property(a => a.DatosDespues)
                   .HasColumnType("NVARCHAR(MAX)");

            // 🔥 ESTADO
            builder.Property(a => a.Estado)
                   .HasMaxLength(20)
                   .HasDefaultValue("ACTIVO");

            // 🔥 BORRADO LÓGICO
            builder.Property(a => a.Eliminado)
                   .HasDefaultValue(false);

            // 🔥 ÍNDICES (MUY PRO 🔥)
            builder.HasIndex(a => a.Tabla);
            builder.HasIndex(a => a.Fecha);
            builder.HasIndex(a => a.Usuario);

            // 🔥 FILTRO GLOBAL
            builder.HasQueryFilter(a => !a.Eliminado);
        }
    }
}