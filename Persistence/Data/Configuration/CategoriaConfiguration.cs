using Domain.Entities;
using Microsoft.EntityFrameworkCore;
using Microsoft.EntityFrameworkCore.Metadata.Builders;
using Microsoft.Extensions.Configuration;

namespace Persistence.Data.Configurations;
public class CategoriaConfiguration : IEntityTypeConfiguration<Categoria>
{
    public void Configure(EntityTypeBuilder<Categoria> builder)
    {
        builder.ToTable("categoria");

        builder.Property(p => p.NombreCategoria)
        .IsRequired()
        .HasMaxLength(15);
        

        builder.HasData(
            new Categoria{Id = 1, NombreCategoria="Vigilante"}
        );
    }
}