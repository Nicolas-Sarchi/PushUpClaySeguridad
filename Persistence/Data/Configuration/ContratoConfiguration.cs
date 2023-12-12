using Domain.Entities;
using Microsoft.EntityFrameworkCore;
using Microsoft.EntityFrameworkCore.Metadata.Builders;
using Microsoft.Extensions.Configuration;

namespace Persistence.Data.Configurations;
  public class ContratoConfiguration : IEntityTypeConfiguration<Contrato>
  {
     public void Configure(EntityTypeBuilder<Contrato> builder)
    {
        builder.ToTable("contrato");

        builder.Property(p => p.FechaContrato)
        .IsRequired()
        .HasColumnType("date");

        builder.Property(p => p.FechaFin)
        .IsRequired()
        .HasColumnType("date");

        builder.HasOne(p => p.Estado)
        .WithMany(p => p.Contratos)
        .HasForeignKey(p => p.IdEstado);

        builder.HasOne(p => p.Empleado)
        .WithMany(p => p.Contratos)
        .HasForeignKey(p => p.IdEmpleado);

        builder.HasOne(p => p.Cliente)
        .WithMany(p => p.Contratos)
        .HasForeignKey(p => p.IdCliente);

        builder.HasData(
            new Contrato{Id =1, FechaContrato = new DateOnly(2023, 06, 12), FechaFin = new DateOnly(2024, 03, 13), IdEstado = 1, IdCliente =1, IdEmpleado = 2 },
            new Contrato{Id =2, FechaContrato = new DateOnly(2023, 02, 22), FechaFin = new DateOnly(2023, 12, 10), IdEstado = 2, IdCliente =2, IdEmpleado = 1 }
        );
  }
  }