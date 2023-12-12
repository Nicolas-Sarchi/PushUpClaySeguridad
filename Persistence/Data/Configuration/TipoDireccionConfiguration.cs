using Domain.Entities;
using Microsoft.EntityFrameworkCore;
using Microsoft.EntityFrameworkCore.Metadata.Builders;
using Microsoft.Extensions.Configuration;

namespace Persistence.Data.Configurations;
  public class TipoDireccionConfiguration : IEntityTypeConfiguration<TipoDireccion>
  {
     public void Configure(EntityTypeBuilder<TipoDireccion> builder)
    {
        builder.ToTable("tipo_direccion");

        builder.Property(p => p.Descripcion)
        .IsRequired()
        .HasMaxLength(50);

        builder.HasData(
            new TipoDireccion{Id= 1, Descripcion= "Casa"},
            new TipoDireccion{Id= 2, Descripcion= "Oficina"}
        );
  }
  }