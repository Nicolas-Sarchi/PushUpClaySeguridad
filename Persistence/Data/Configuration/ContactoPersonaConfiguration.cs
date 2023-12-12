using Domain.Entities;
using Microsoft.EntityFrameworkCore;
using Microsoft.EntityFrameworkCore.Metadata.Builders;
using Microsoft.Extensions.Configuration;

namespace Persistence.Data.Configurations;
  public class ContactoPersonaConfiguration : IEntityTypeConfiguration<ContactoPersona>
  {
     public void Configure(EntityTypeBuilder<ContactoPersona> builder)
    {
        builder.ToTable("contacto");

        builder.Property(p => p.Descripcion)
        .IsRequired()
        .HasMaxLength(30);

        builder.HasIndex(c => c.Descripcion)
        .IsUnique();

        builder.HasOne(p => p.Persona)
        .WithMany(p => p.ContactoPersonas)
        .HasForeignKey(p => p.IdPersona);

        builder.HasOne(p => p.TipoContacto)
        .WithMany(p => p.ContactoPersonas)
        .HasForeignKey(p => p.IdTipoContacto);

        builder.HasData(
            new ContactoPersona {Id =1, Descripcion = "3177520056", IdPersona= 1, IdTipoContacto = 1},
            new ContactoPersona {Id = 2, Descripcion = "12312313", IdTipoContacto = 1, IdPersona = 2},
            new ContactoPersona {Id = 3, Descripcion = "3123459094", IdPersona = 1, IdTipoContacto = 1}
        );
  }
  }