using Domain.Entities;
using Microsoft.EntityFrameworkCore;
using Microsoft.EntityFrameworkCore.Metadata.Builders;
using Microsoft.Extensions.Configuration;

namespace Persistence.Data.Configurations;
  public class DireccionConfiguration : IEntityTypeConfiguration<Direccion>
  {
     public void Configure(EntityTypeBuilder<Direccion> builder)
    {
        builder.ToTable("direccion");

        builder.Property(p => p.NroPrincipal)
        .IsRequired()
        .HasMaxLength(10);

        builder.Property(p => p.NroSecundario)
        .IsRequired()
        .HasMaxLength(10);

        builder.Property(p => p.Complemento)
        .IsRequired()
        .HasMaxLength(5);

        builder.Property(p => p.InfoAdicional)
        .HasMaxLength(25);

        builder.HasOne(p => p.Ciudad)
        .WithMany(p => p.Direcciones)
        .HasForeignKey(p => p.IdCiudad);

        builder.HasOne(p => p.TipoVia)
        .WithMany(p => p.Direcciones)
        .HasForeignKey(p => p.IdTipoVia);

        builder.HasOne(p => p.TipoDireccion)
        .WithMany(p => p.Direcciones)
        .HasForeignKey(p => p.IdTipoDireccion);


        builder.HasData(
            new Direccion{Id = 1, NroPrincipal = "25" , NroSecundario = "27", Complemento = "32", IdCiudad = 1, IdTipoDireccion = 1, IdTipoVia = 2},
            new Direccion{Id = 2, NroPrincipal = "25B" , NroSecundario = "24A", Complemento = "42", IdCiudad = 2, IdTipoDireccion = 1, IdTipoVia = 1},
            new Direccion{Id = 3, NroPrincipal = "25" , NroSecundario = "27", Complemento = "32", IdCiudad = 2, IdTipoDireccion = 1, IdTipoVia = 2},
            new Direccion{Id = 4, NroPrincipal = "25" , NroSecundario = "27", Complemento = "32", IdCiudad = 3, IdTipoDireccion = 1, IdTipoVia = 2}
        );
  }
  }