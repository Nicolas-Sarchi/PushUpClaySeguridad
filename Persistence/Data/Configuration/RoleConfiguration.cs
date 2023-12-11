using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;
using Domain.Entities;
using Microsoft.EntityFrameworkCore;
using Microsoft.EntityFrameworkCore.Metadata.Builders;

namespace Persistencia.Data.Configurations
{
    public class RolConfiguration : IEntityTypeConfiguration<Role>
    {
        public void Configure(EntityTypeBuilder<Role> builder)
        {
            builder.ToTable("role");

            builder.Property(p => p.Nombre)
            .HasMaxLength(50)
            .IsRequired();

            builder.HasData(
            new Role
            {
                Id = 1,
                Nombre = "Administrador"
            },
            new Role
            {
                Id = 2,
                Nombre = "Empleado"
            }
            );
        }
    }
}