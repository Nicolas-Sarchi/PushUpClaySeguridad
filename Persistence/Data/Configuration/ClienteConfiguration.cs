using Domain.Entities;
using Microsoft.EntityFrameworkCore;
using Microsoft.EntityFrameworkCore.Metadata.Builders;
using Microsoft.Extensions.Configuration;

namespace Persistence.Data.Configurations;
  public class ClienteConfiguration : IEntityTypeConfiguration<Cliente>
  {
     public void Configure(EntityTypeBuilder<Cliente> builder)
    {
        builder.ToTable("Cliente");

        builder.Property(p => p.IdPersona)
        .IsRequired()
        .HasMaxLength(15);

        builder.HasIndex(p => p.IdPersona)
        .IsUnique();

        builder.Property(p => p.Nombre)
        .IsRequired()
        .HasMaxLength(20);

        builder.Property(p => p.FechaReg)
        .IsRequired()
        .HasColumnType("date");
        
        builder.HasOne(p => p.Direccion)
        .WithMany(p => p.Clientes)
        .HasForeignKey(p => p.IdDireccion);

        builder.HasData(
            // new Persona{Id = 1, IdPersona = "1101622982", Nombre = "Juan Perez", FechaReg = new DateOnly(2018, 05, 22), IdTipoPersona = 2, IdCategoria = 1, IdDireccion=  1},
            // new Persona{Id = 2, IdPersona = "45245344", Nombre = "Emiliano Martinez", FechaReg = new DateOnly(2020, 04, 18), IdTipoPersona = 2, IdDireccion=  3, IdCategoria = 2},
            // new Persona{Id = 3, IdPersona = "324232", Nombre = "Julian Lopez", FechaReg = new DateOnly(2023, 12, 2), IdTipoPersona = 1, IdDireccion=  2}
            new Cliente {Id = 1, IdPersona = "1101622982", IdDireccion = 1, FechaReg = new DateOnly(2018 , 05, 21), Nombre = "Lionel Messi"},
            new Cliente {Id = 2, IdPersona = "43622982", IdDireccion = 2, FechaReg = new DateOnly(2010 , 10, 11), Nombre = "James Rodriguez"}

            );
  }
  }