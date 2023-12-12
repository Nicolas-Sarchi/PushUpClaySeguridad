using Domain.Entities;
using Microsoft.EntityFrameworkCore;
using Microsoft.EntityFrameworkCore.Metadata.Builders;
using Microsoft.Extensions.Configuration;

namespace Persistence.Data.Configurations;
  public class PaisConfiguration : IEntityTypeConfiguration<Pais>
  {
     public void Configure(EntityTypeBuilder<Pais> builder)
    {
        builder.ToTable("pais");

        builder.Property(p => p.NombrePais)
        .IsRequired()
        .HasMaxLength(25);

        builder.HasData(
            new Pais {Id = 1, NombrePais = "Colombia"}
        );
  }
  }