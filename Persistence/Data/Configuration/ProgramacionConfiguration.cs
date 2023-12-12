using Domain.Entities;
using Microsoft.EntityFrameworkCore;
using Microsoft.EntityFrameworkCore.Metadata.Builders;
using Microsoft.Extensions.Configuration;

namespace Persistence.Data.Configurations;
  public class ProgramacionConfiguration : IEntityTypeConfiguration<Programacion>
  {
     public void Configure(EntityTypeBuilder<Programacion> builder)
    {
        builder.ToTable("programacion");

        builder.HasOne(p => p.Turno)
        .WithMany(p => p.Programaciones)
        .HasForeignKey(p => p.IdTurno);

        builder.HasOne(p => p.Contrato)
        .WithMany(p => p.Programaciones)
        .HasForeignKey(p => p.IdContrato);

        builder.HasOne(p => p.Empleado)
        .WithMany(p => p.Programaciones)
        .HasForeignKey(p => p.IdEmpleado);

        builder.HasData(
            new Programacion{Id =1, IdTurno = 1, IdContrato = 1, IdEmpleado = 2},
            new Programacion{Id =2, IdTurno = 2, IdContrato = 1, IdEmpleado = 1}

        );
  }
  }