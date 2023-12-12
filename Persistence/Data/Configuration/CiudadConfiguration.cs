using Domain.Entities;
using Microsoft.EntityFrameworkCore;
using Microsoft.EntityFrameworkCore.Metadata.Builders;
using Microsoft.Extensions.Configuration;

namespace Persistence.Data.Configurations;
  public class CiudadConfiguration : IEntityTypeConfiguration<Ciudad>
  {
     public void Configure(EntityTypeBuilder<Ciudad> builder)
    {
        builder.ToTable("ciudad");

        builder.Property(p => p.NombreCiu)
        .IsRequired()
        .HasMaxLength(30);

        builder.HasOne(p => p.Departamento)
        .WithMany(p => p.Ciudades)
        .HasForeignKey(p => p.IdDepartamento);

        builder.HasData(
            new Ciudad{Id=1 , NombreCiu = "Bucaramanga", IdDepartamento= 1},
            new Ciudad{Id=2 , NombreCiu = "Giron", IdDepartamento= 1},
            new Ciudad{Id=3 , NombreCiu = "Piedecuesta", IdDepartamento= 1}
        );
  }
  }