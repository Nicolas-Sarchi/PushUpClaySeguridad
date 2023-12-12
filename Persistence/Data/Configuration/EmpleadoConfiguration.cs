using Domain.Entities;
using Microsoft.EntityFrameworkCore;
using Microsoft.EntityFrameworkCore.Metadata.Builders;
using Microsoft.Extensions.Configuration;

namespace Persistence.Data.Configurations;
  public class EmpleadoConfiguration : IEntityTypeConfiguration<Empleado>
  {
     public void Configure(EntityTypeBuilder<Empleado> builder)
    {
        builder.ToTable("empleado");

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
        .WithMany(p => p.Empleados)
        .HasForeignKey(p => p.IdDireccion);

        builder.HasOne(p => p.Categoria)
        .WithMany(p => p.Empleados)
        .HasForeignKey(p => p.IdCategoria);


  builder.HasData(

            new Empleado {Id = 1, IdPersona = "53054583", IdDireccion = 3, FechaReg = new DateOnly(2021 , 01, 21), Nombre = "Linda Caicedo", IdCategoria=  1},
            new Empleado {Id = 2, IdPersona = "54267888", IdDireccion = 1, FechaReg = new DateOnly(2023 , 12, 18), Nombre = "Julian Lopez", IdCategoria = 1},
            new Empleado {Id = 3, IdPersona = "555564", IdDireccion = 4, FechaReg = new DateOnly(2023 , 12, 18), Nombre = "Paco Web", IdCategoria = 1}

            );
  }
  }