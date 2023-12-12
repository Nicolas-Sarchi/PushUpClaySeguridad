using Domain.Entities;
using Microsoft.EntityFrameworkCore;
using Microsoft.EntityFrameworkCore.Metadata.Builders;
using Microsoft.Extensions.Configuration;

namespace Persistence.Data.Configurations;
  public class TurnoConfiguration : IEntityTypeConfiguration<Turno>
  {
     public void Configure(EntityTypeBuilder<Turno> builder)
    {
        builder.ToTable("turno");

        builder.Property(p => p.NombreTurno)
        .IsRequired()
        .HasMaxLength(15);

        builder.Property(p => p.HoraInicio)
        .IsRequired();

        builder.Property(p => p.HoraFin)
        .IsRequired();

        builder.HasData(
            new Turno{Id = 1, NombreTurno = "Turno 1", HoraInicio = new TimeOnly(7, 00), HoraFin = new TimeOnly(13, 00)},
            new Turno{Id = 2, NombreTurno = "Turno 2", HoraInicio = new TimeOnly(14, 00), HoraFin = new TimeOnly(18, 00)}
        );
  }
  }