using Domain.Entities;
using Microsoft.EntityFrameworkCore;
using Microsoft.EntityFrameworkCore.Metadata.Builders;
using Microsoft.Extensions.Configuration;

namespace Persistence.Data.Configurations;
  public class TipoContactoConfiguration : IEntityTypeConfiguration<TipoContacto>
  {
     public void Configure(EntityTypeBuilder<TipoContacto> builder)
    {
        builder.ToTable("tipo_contacto");

        builder.Property(p => p.Descripcion)
        .IsRequired()
        .HasMaxLength(25);

        builder.HasData(
            new TipoContacto{Id = 1, Descripcion = "Telefono"},
            new TipoContacto{Id = 2, Descripcion = "Correo Electronico"}
        );
  }
  }