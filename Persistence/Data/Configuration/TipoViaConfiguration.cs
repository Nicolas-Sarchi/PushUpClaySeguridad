using Domain.Entities;
using Microsoft.EntityFrameworkCore;
using Microsoft.EntityFrameworkCore.Metadata.Builders;
using Microsoft.Extensions.Configuration;

namespace Persistence.Data.Configurations;
  public class TipoViaConfiguration : IEntityTypeConfiguration<TipoVia>
  {
     public void Configure(EntityTypeBuilder<TipoVia> builder)
    {
        builder.ToTable("tipo_via");

        builder.Property(p => p.Descripcion)
        .IsRequired()
        .HasMaxLength(20);

        builder.HasData(
            new TipoVia {Id = 1, Descripcion= "Calle"},
            new TipoVia {Id = 2, Descripcion = "Carrera"}
        );
  }
  }