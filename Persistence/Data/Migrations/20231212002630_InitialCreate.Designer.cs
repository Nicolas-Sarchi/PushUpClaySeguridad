﻿// <auto-generated />
using System;
using Microsoft.EntityFrameworkCore;
using Microsoft.EntityFrameworkCore.Infrastructure;
using Microsoft.EntityFrameworkCore.Migrations;
using Microsoft.EntityFrameworkCore.Storage.ValueConversion;
using Persistence.Data;

#nullable disable

namespace Persistence.Data.Migrations
{
    [DbContext(typeof(DBContext))]
    [Migration("20231212002630_InitialCreate")]
    partial class InitialCreate
    {
        /// <inheritdoc />
        protected override void BuildTargetModel(ModelBuilder modelBuilder)
        {
#pragma warning disable 612, 618
            modelBuilder
                .HasAnnotation("ProductVersion", "7.0.14")
                .HasAnnotation("Relational:MaxIdentifierLength", 64);

            modelBuilder.Entity("Domain.Entities.Categoria", b =>
                {
                    b.Property<int>("Id")
                        .ValueGeneratedOnAdd()
                        .HasColumnType("int");

                    b.Property<string>("NombreCategoria")
                        .IsRequired()
                        .HasMaxLength(15)
                        .HasColumnType("varchar(15)");

                    b.HasKey("Id");

                    b.ToTable("categoria", (string)null);

                    b.HasData(
                        new
                        {
                            Id = 1,
                            NombreCategoria = "Vigilante"
                        });
                });

            modelBuilder.Entity("Domain.Entities.Ciudad", b =>
                {
                    b.Property<int>("Id")
                        .ValueGeneratedOnAdd()
                        .HasColumnType("int");

                    b.Property<int>("IdDepartamento")
                        .HasColumnType("int");

                    b.Property<string>("NombreCiu")
                        .IsRequired()
                        .HasMaxLength(30)
                        .HasColumnType("varchar(30)");

                    b.HasKey("Id");

                    b.HasIndex("IdDepartamento");

                    b.ToTable("ciudad", (string)null);

                    b.HasData(
                        new
                        {
                            Id = 1,
                            IdDepartamento = 1,
                            NombreCiu = "Bucaramanga"
                        },
                        new
                        {
                            Id = 2,
                            IdDepartamento = 1,
                            NombreCiu = "Giron"
                        },
                        new
                        {
                            Id = 3,
                            IdDepartamento = 1,
                            NombreCiu = "Piedecuesta"
                        });
                });

            modelBuilder.Entity("Domain.Entities.Cliente", b =>
                {
                    b.Property<int>("Id")
                        .ValueGeneratedOnAdd()
                        .HasColumnType("int");

                    b.Property<DateOnly>("FechaReg")
                        .HasColumnType("date");

                    b.Property<int>("IdDireccion")
                        .HasColumnType("int");

                    b.Property<string>("IdPersona")
                        .IsRequired()
                        .HasMaxLength(15)
                        .HasColumnType("varchar(15)");

                    b.Property<string>("Nombre")
                        .IsRequired()
                        .HasMaxLength(20)
                        .HasColumnType("varchar(20)");

                    b.HasKey("Id");

                    b.HasIndex("IdDireccion");

                    b.HasIndex("IdPersona")
                        .IsUnique();

                    b.ToTable("Cliente", (string)null);

                    b.HasData(
                        new
                        {
                            Id = 1,
                            FechaReg = new DateOnly(2018, 5, 21),
                            IdDireccion = 1,
                            IdPersona = "1101622982",
                            Nombre = "Lionel Messi"
                        },
                        new
                        {
                            Id = 2,
                            FechaReg = new DateOnly(2010, 10, 11),
                            IdDireccion = 2,
                            IdPersona = "43622982",
                            Nombre = "James Rodriguez"
                        });
                });

            modelBuilder.Entity("Domain.Entities.ContactoPersona", b =>
                {
                    b.Property<int>("Id")
                        .ValueGeneratedOnAdd()
                        .HasColumnType("int");

                    b.Property<int?>("ClienteId")
                        .HasColumnType("int");

                    b.Property<string>("Descripcion")
                        .IsRequired()
                        .HasMaxLength(30)
                        .HasColumnType("varchar(30)");

                    b.Property<int>("IdPersona")
                        .HasColumnType("int");

                    b.Property<int>("IdTipoContacto")
                        .HasColumnType("int");

                    b.HasKey("Id");

                    b.HasIndex("ClienteId");

                    b.HasIndex("Descripcion")
                        .IsUnique();

                    b.HasIndex("IdPersona");

                    b.HasIndex("IdTipoContacto");

                    b.ToTable("contacto", (string)null);

                    b.HasData(
                        new
                        {
                            Id = 1,
                            Descripcion = "3177520056",
                            IdPersona = 1,
                            IdTipoContacto = 1
                        },
                        new
                        {
                            Id = 2,
                            Descripcion = "12312313",
                            IdPersona = 2,
                            IdTipoContacto = 1
                        },
                        new
                        {
                            Id = 3,
                            Descripcion = "3123459094",
                            IdPersona = 1,
                            IdTipoContacto = 1
                        });
                });

            modelBuilder.Entity("Domain.Entities.Contrato", b =>
                {
                    b.Property<int>("Id")
                        .ValueGeneratedOnAdd()
                        .HasColumnType("int");

                    b.Property<DateOnly>("FechaContrato")
                        .HasColumnType("date");

                    b.Property<DateOnly>("FechaFin")
                        .HasColumnType("date");

                    b.Property<int>("IdCliente")
                        .HasColumnType("int");

                    b.Property<int>("IdEmpleado")
                        .HasColumnType("int");

                    b.Property<int>("IdEstado")
                        .HasColumnType("int");

                    b.HasKey("Id");

                    b.HasIndex("IdCliente");

                    b.HasIndex("IdEmpleado");

                    b.HasIndex("IdEstado");

                    b.ToTable("contrato", (string)null);

                    b.HasData(
                        new
                        {
                            Id = 1,
                            FechaContrato = new DateOnly(2023, 6, 12),
                            FechaFin = new DateOnly(2024, 3, 13),
                            IdCliente = 1,
                            IdEmpleado = 2,
                            IdEstado = 1
                        },
                        new
                        {
                            Id = 2,
                            FechaContrato = new DateOnly(2023, 2, 22),
                            FechaFin = new DateOnly(2023, 12, 10),
                            IdCliente = 2,
                            IdEmpleado = 1,
                            IdEstado = 2
                        });
                });

            modelBuilder.Entity("Domain.Entities.Departamento", b =>
                {
                    b.Property<int>("Id")
                        .ValueGeneratedOnAdd()
                        .HasColumnType("int");

                    b.Property<int>("IdPais")
                        .HasColumnType("int");

                    b.Property<string>("NombreDep")
                        .IsRequired()
                        .HasMaxLength(25)
                        .HasColumnType("varchar(25)");

                    b.HasKey("Id");

                    b.HasIndex("IdPais");

                    b.ToTable("departamento", (string)null);

                    b.HasData(
                        new
                        {
                            Id = 1,
                            IdPais = 1,
                            NombreDep = "Santander"
                        });
                });

            modelBuilder.Entity("Domain.Entities.Direccion", b =>
                {
                    b.Property<int>("Id")
                        .ValueGeneratedOnAdd()
                        .HasColumnType("int");

                    b.Property<string>("Complemento")
                        .IsRequired()
                        .HasMaxLength(5)
                        .HasColumnType("varchar(5)");

                    b.Property<int>("IdCiudad")
                        .HasColumnType("int");

                    b.Property<int>("IdTipoDireccion")
                        .HasColumnType("int");

                    b.Property<int>("IdTipoVia")
                        .HasColumnType("int");

                    b.Property<string>("InfoAdicional")
                        .HasMaxLength(25)
                        .HasColumnType("varchar(25)");

                    b.Property<string>("NroPrincipal")
                        .IsRequired()
                        .HasMaxLength(10)
                        .HasColumnType("varchar(10)");

                    b.Property<string>("NroSecundario")
                        .IsRequired()
                        .HasMaxLength(10)
                        .HasColumnType("varchar(10)");

                    b.HasKey("Id");

                    b.HasIndex("IdCiudad");

                    b.HasIndex("IdTipoDireccion");

                    b.HasIndex("IdTipoVia");

                    b.ToTable("direccion", (string)null);

                    b.HasData(
                        new
                        {
                            Id = 1,
                            Complemento = "32",
                            IdCiudad = 1,
                            IdTipoDireccion = 1,
                            IdTipoVia = 2,
                            NroPrincipal = "25",
                            NroSecundario = "27"
                        },
                        new
                        {
                            Id = 2,
                            Complemento = "42",
                            IdCiudad = 2,
                            IdTipoDireccion = 1,
                            IdTipoVia = 1,
                            NroPrincipal = "25B",
                            NroSecundario = "24A"
                        },
                        new
                        {
                            Id = 3,
                            Complemento = "32",
                            IdCiudad = 2,
                            IdTipoDireccion = 1,
                            IdTipoVia = 2,
                            NroPrincipal = "25",
                            NroSecundario = "27"
                        },
                        new
                        {
                            Id = 4,
                            Complemento = "32",
                            IdCiudad = 3,
                            IdTipoDireccion = 1,
                            IdTipoVia = 2,
                            NroPrincipal = "25",
                            NroSecundario = "27"
                        });
                });

            modelBuilder.Entity("Domain.Entities.Empleado", b =>
                {
                    b.Property<int>("Id")
                        .ValueGeneratedOnAdd()
                        .HasColumnType("int");

                    b.Property<DateOnly>("FechaReg")
                        .HasColumnType("date");

                    b.Property<int>("IdCategoria")
                        .HasColumnType("int");

                    b.Property<int>("IdDireccion")
                        .HasColumnType("int");

                    b.Property<string>("IdPersona")
                        .IsRequired()
                        .HasMaxLength(15)
                        .HasColumnType("varchar(15)");

                    b.Property<string>("Nombre")
                        .IsRequired()
                        .HasMaxLength(20)
                        .HasColumnType("varchar(20)");

                    b.HasKey("Id");

                    b.HasIndex("IdCategoria");

                    b.HasIndex("IdDireccion");

                    b.HasIndex("IdPersona")
                        .IsUnique();

                    b.ToTable("empleado", (string)null);

                    b.HasData(
                        new
                        {
                            Id = 1,
                            FechaReg = new DateOnly(2021, 1, 21),
                            IdCategoria = 1,
                            IdDireccion = 3,
                            IdPersona = "53054583",
                            Nombre = "Linda Caicedo"
                        },
                        new
                        {
                            Id = 2,
                            FechaReg = new DateOnly(2023, 12, 18),
                            IdCategoria = 1,
                            IdDireccion = 1,
                            IdPersona = "54267888",
                            Nombre = "Julian Lopez"
                        },
                        new
                        {
                            Id = 3,
                            FechaReg = new DateOnly(2023, 12, 18),
                            IdCategoria = 1,
                            IdDireccion = 4,
                            IdPersona = "555564",
                            Nombre = "Paco Web"
                        });
                });

            modelBuilder.Entity("Domain.Entities.Estado", b =>
                {
                    b.Property<int>("Id")
                        .ValueGeneratedOnAdd()
                        .HasColumnType("int");

                    b.Property<string>("Descripcion")
                        .IsRequired()
                        .HasMaxLength(15)
                        .HasColumnType("varchar(15)");

                    b.HasKey("Id");

                    b.ToTable("estado", (string)null);

                    b.HasData(
                        new
                        {
                            Id = 1,
                            Descripcion = "Activo"
                        },
                        new
                        {
                            Id = 2,
                            Descripcion = "Inactivo"
                        });
                });

            modelBuilder.Entity("Domain.Entities.Pais", b =>
                {
                    b.Property<int>("Id")
                        .ValueGeneratedOnAdd()
                        .HasColumnType("int");

                    b.Property<string>("NombrePais")
                        .IsRequired()
                        .HasMaxLength(25)
                        .HasColumnType("varchar(25)");

                    b.HasKey("Id");

                    b.ToTable("pais", (string)null);

                    b.HasData(
                        new
                        {
                            Id = 1,
                            NombrePais = "Colombia"
                        });
                });

            modelBuilder.Entity("Domain.Entities.Programacion", b =>
                {
                    b.Property<int>("Id")
                        .ValueGeneratedOnAdd()
                        .HasColumnType("int");

                    b.Property<int>("IdContrato")
                        .HasColumnType("int");

                    b.Property<int>("IdEmpleado")
                        .HasColumnType("int");

                    b.Property<int>("IdTurno")
                        .HasColumnType("int");

                    b.HasKey("Id");

                    b.HasIndex("IdContrato");

                    b.HasIndex("IdEmpleado");

                    b.HasIndex("IdTurno");

                    b.ToTable("programacion", (string)null);

                    b.HasData(
                        new
                        {
                            Id = 1,
                            IdContrato = 1,
                            IdEmpleado = 2,
                            IdTurno = 1
                        },
                        new
                        {
                            Id = 2,
                            IdContrato = 1,
                            IdEmpleado = 1,
                            IdTurno = 2
                        });
                });

            modelBuilder.Entity("Domain.Entities.RefreshToken", b =>
                {
                    b.Property<int>("Id")
                        .ValueGeneratedOnAdd()
                        .HasColumnType("int");

                    b.Property<DateTime>("Created")
                        .HasColumnType("datetime(6)");

                    b.Property<DateTime>("Expires")
                        .HasColumnType("datetime(6)");

                    b.Property<DateTime?>("Revoked")
                        .HasColumnType("datetime(6)");

                    b.Property<string>("Token")
                        .HasColumnType("longtext");

                    b.Property<int>("UserId")
                        .HasColumnType("int");

                    b.HasKey("Id");

                    b.HasIndex("UserId");

                    b.ToTable("RefreshToken", (string)null);
                });

            modelBuilder.Entity("Domain.Entities.Role", b =>
                {
                    b.Property<int>("Id")
                        .ValueGeneratedOnAdd()
                        .HasColumnType("int");

                    b.Property<string>("Nombre")
                        .IsRequired()
                        .HasMaxLength(50)
                        .HasColumnType("varchar(50)");

                    b.HasKey("Id");

                    b.ToTable("role", (string)null);

                    b.HasData(
                        new
                        {
                            Id = 1,
                            Nombre = "Administrador"
                        },
                        new
                        {
                            Id = 2,
                            Nombre = "Empleado"
                        });
                });

            modelBuilder.Entity("Domain.Entities.TipoContacto", b =>
                {
                    b.Property<int>("Id")
                        .ValueGeneratedOnAdd()
                        .HasColumnType("int");

                    b.Property<string>("Descripcion")
                        .IsRequired()
                        .HasMaxLength(25)
                        .HasColumnType("varchar(25)");

                    b.HasKey("Id");

                    b.ToTable("tipo_contacto", (string)null);

                    b.HasData(
                        new
                        {
                            Id = 1,
                            Descripcion = "Telefono"
                        },
                        new
                        {
                            Id = 2,
                            Descripcion = "Correo Electronico"
                        });
                });

            modelBuilder.Entity("Domain.Entities.TipoDireccion", b =>
                {
                    b.Property<int>("Id")
                        .ValueGeneratedOnAdd()
                        .HasColumnType("int");

                    b.Property<string>("Descripcion")
                        .IsRequired()
                        .HasMaxLength(50)
                        .HasColumnType("varchar(50)");

                    b.HasKey("Id");

                    b.ToTable("tipo_direccion", (string)null);

                    b.HasData(
                        new
                        {
                            Id = 1,
                            Descripcion = "Casa"
                        },
                        new
                        {
                            Id = 2,
                            Descripcion = "Oficina"
                        });
                });

            modelBuilder.Entity("Domain.Entities.TipoVia", b =>
                {
                    b.Property<int>("Id")
                        .ValueGeneratedOnAdd()
                        .HasColumnType("int");

                    b.Property<string>("Descripcion")
                        .IsRequired()
                        .HasMaxLength(20)
                        .HasColumnType("varchar(20)");

                    b.HasKey("Id");

                    b.ToTable("tipo_via", (string)null);

                    b.HasData(
                        new
                        {
                            Id = 1,
                            Descripcion = "Calle"
                        },
                        new
                        {
                            Id = 2,
                            Descripcion = "Carrera"
                        });
                });

            modelBuilder.Entity("Domain.Entities.Turno", b =>
                {
                    b.Property<int>("Id")
                        .ValueGeneratedOnAdd()
                        .HasColumnType("int");

                    b.Property<TimeOnly>("HoraFin")
                        .HasColumnType("time(6)");

                    b.Property<TimeOnly>("HoraInicio")
                        .HasColumnType("time(6)");

                    b.Property<string>("NombreTurno")
                        .IsRequired()
                        .HasMaxLength(15)
                        .HasColumnType("varchar(15)");

                    b.HasKey("Id");

                    b.ToTable("turno", (string)null);

                    b.HasData(
                        new
                        {
                            Id = 1,
                            HoraFin = new TimeOnly(13, 0, 0),
                            HoraInicio = new TimeOnly(7, 0, 0),
                            NombreTurno = "Turno 1"
                        },
                        new
                        {
                            Id = 2,
                            HoraFin = new TimeOnly(18, 0, 0),
                            HoraInicio = new TimeOnly(14, 0, 0),
                            NombreTurno = "Turno 2"
                        });
                });

            modelBuilder.Entity("Domain.Entities.User", b =>
                {
                    b.Property<int>("Id")
                        .ValueGeneratedOnAdd()
                        .HasColumnType("int");

                    b.Property<string>("Email")
                        .IsRequired()
                        .HasMaxLength(100)
                        .HasColumnType("varchar")
                        .HasColumnName("email");

                    b.Property<string>("Password")
                        .IsRequired()
                        .HasMaxLength(255)
                        .HasColumnType("varchar")
                        .HasColumnName("password");

                    b.Property<string>("Username")
                        .HasMaxLength(50)
                        .HasColumnType("varchar")
                        .HasColumnName("username");

                    b.HasKey("Id");

                    b.ToTable("user", (string)null);
                });

            modelBuilder.Entity("Domain.Entities.UserRole", b =>
                {
                    b.Property<int>("UserId")
                        .HasColumnType("int");

                    b.Property<int>("RoleId")
                        .HasColumnType("int");

                    b.HasKey("UserId", "RoleId");

                    b.HasIndex("RoleId");

                    b.ToTable("userRol", (string)null);
                });

            modelBuilder.Entity("Domain.Entities.Ciudad", b =>
                {
                    b.HasOne("Domain.Entities.Departamento", "Departamento")
                        .WithMany("Ciudades")
                        .HasForeignKey("IdDepartamento")
                        .OnDelete(DeleteBehavior.Cascade)
                        .IsRequired();

                    b.Navigation("Departamento");
                });

            modelBuilder.Entity("Domain.Entities.Cliente", b =>
                {
                    b.HasOne("Domain.Entities.Direccion", "Direccion")
                        .WithMany("Clientes")
                        .HasForeignKey("IdDireccion")
                        .OnDelete(DeleteBehavior.Cascade)
                        .IsRequired();

                    b.Navigation("Direccion");
                });

            modelBuilder.Entity("Domain.Entities.ContactoPersona", b =>
                {
                    b.HasOne("Domain.Entities.Cliente", null)
                        .WithMany("ContactoPersonas")
                        .HasForeignKey("ClienteId");

                    b.HasOne("Domain.Entities.Empleado", "Persona")
                        .WithMany("ContactoPersonas")
                        .HasForeignKey("IdPersona")
                        .OnDelete(DeleteBehavior.Cascade)
                        .IsRequired();

                    b.HasOne("Domain.Entities.TipoContacto", "TipoContacto")
                        .WithMany("ContactoPersonas")
                        .HasForeignKey("IdTipoContacto")
                        .OnDelete(DeleteBehavior.Cascade)
                        .IsRequired();

                    b.Navigation("Persona");

                    b.Navigation("TipoContacto");
                });

            modelBuilder.Entity("Domain.Entities.Contrato", b =>
                {
                    b.HasOne("Domain.Entities.Cliente", "Cliente")
                        .WithMany("Contratos")
                        .HasForeignKey("IdCliente")
                        .OnDelete(DeleteBehavior.Cascade)
                        .IsRequired();

                    b.HasOne("Domain.Entities.Empleado", "Empleado")
                        .WithMany("Contratos")
                        .HasForeignKey("IdEmpleado")
                        .OnDelete(DeleteBehavior.Cascade)
                        .IsRequired();

                    b.HasOne("Domain.Entities.Estado", "Estado")
                        .WithMany("Contratos")
                        .HasForeignKey("IdEstado")
                        .OnDelete(DeleteBehavior.Cascade)
                        .IsRequired();

                    b.Navigation("Cliente");

                    b.Navigation("Empleado");

                    b.Navigation("Estado");
                });

            modelBuilder.Entity("Domain.Entities.Departamento", b =>
                {
                    b.HasOne("Domain.Entities.Pais", "Pais")
                        .WithMany("Departamentos")
                        .HasForeignKey("IdPais")
                        .OnDelete(DeleteBehavior.Cascade)
                        .IsRequired();

                    b.Navigation("Pais");
                });

            modelBuilder.Entity("Domain.Entities.Direccion", b =>
                {
                    b.HasOne("Domain.Entities.Ciudad", "Ciudad")
                        .WithMany("Direcciones")
                        .HasForeignKey("IdCiudad")
                        .OnDelete(DeleteBehavior.Cascade)
                        .IsRequired();

                    b.HasOne("Domain.Entities.TipoDireccion", "TipoDireccion")
                        .WithMany("Direcciones")
                        .HasForeignKey("IdTipoDireccion")
                        .OnDelete(DeleteBehavior.Cascade)
                        .IsRequired();

                    b.HasOne("Domain.Entities.TipoVia", "TipoVia")
                        .WithMany("Direcciones")
                        .HasForeignKey("IdTipoVia")
                        .OnDelete(DeleteBehavior.Cascade)
                        .IsRequired();

                    b.Navigation("Ciudad");

                    b.Navigation("TipoDireccion");

                    b.Navigation("TipoVia");
                });

            modelBuilder.Entity("Domain.Entities.Empleado", b =>
                {
                    b.HasOne("Domain.Entities.Categoria", "Categoria")
                        .WithMany("Empleados")
                        .HasForeignKey("IdCategoria")
                        .OnDelete(DeleteBehavior.Cascade)
                        .IsRequired();

                    b.HasOne("Domain.Entities.Direccion", "Direccion")
                        .WithMany("Empleados")
                        .HasForeignKey("IdDireccion")
                        .OnDelete(DeleteBehavior.Cascade)
                        .IsRequired();

                    b.Navigation("Categoria");

                    b.Navigation("Direccion");
                });

            modelBuilder.Entity("Domain.Entities.Programacion", b =>
                {
                    b.HasOne("Domain.Entities.Contrato", "Contrato")
                        .WithMany("Programaciones")
                        .HasForeignKey("IdContrato")
                        .OnDelete(DeleteBehavior.Cascade)
                        .IsRequired();

                    b.HasOne("Domain.Entities.Empleado", "Empleado")
                        .WithMany("Programaciones")
                        .HasForeignKey("IdEmpleado")
                        .OnDelete(DeleteBehavior.Cascade)
                        .IsRequired();

                    b.HasOne("Domain.Entities.Turno", "Turno")
                        .WithMany("Programaciones")
                        .HasForeignKey("IdTurno")
                        .OnDelete(DeleteBehavior.Cascade)
                        .IsRequired();

                    b.Navigation("Contrato");

                    b.Navigation("Empleado");

                    b.Navigation("Turno");
                });

            modelBuilder.Entity("Domain.Entities.RefreshToken", b =>
                {
                    b.HasOne("Domain.Entities.User", "User")
                        .WithMany("RefreshTokens")
                        .HasForeignKey("UserId")
                        .OnDelete(DeleteBehavior.Cascade)
                        .IsRequired();

                    b.Navigation("User");
                });

            modelBuilder.Entity("Domain.Entities.UserRole", b =>
                {
                    b.HasOne("Domain.Entities.Role", "Role")
                        .WithMany("UsersRoles")
                        .HasForeignKey("RoleId")
                        .OnDelete(DeleteBehavior.Cascade)
                        .IsRequired();

                    b.HasOne("Domain.Entities.User", "User")
                        .WithMany("UsersRoles")
                        .HasForeignKey("UserId")
                        .OnDelete(DeleteBehavior.Cascade)
                        .IsRequired();

                    b.Navigation("Role");

                    b.Navigation("User");
                });

            modelBuilder.Entity("Domain.Entities.Categoria", b =>
                {
                    b.Navigation("Empleados");
                });

            modelBuilder.Entity("Domain.Entities.Ciudad", b =>
                {
                    b.Navigation("Direcciones");
                });

            modelBuilder.Entity("Domain.Entities.Cliente", b =>
                {
                    b.Navigation("ContactoPersonas");

                    b.Navigation("Contratos");
                });

            modelBuilder.Entity("Domain.Entities.Contrato", b =>
                {
                    b.Navigation("Programaciones");
                });

            modelBuilder.Entity("Domain.Entities.Departamento", b =>
                {
                    b.Navigation("Ciudades");
                });

            modelBuilder.Entity("Domain.Entities.Direccion", b =>
                {
                    b.Navigation("Clientes");

                    b.Navigation("Empleados");
                });

            modelBuilder.Entity("Domain.Entities.Empleado", b =>
                {
                    b.Navigation("ContactoPersonas");

                    b.Navigation("Contratos");

                    b.Navigation("Programaciones");
                });

            modelBuilder.Entity("Domain.Entities.Estado", b =>
                {
                    b.Navigation("Contratos");
                });

            modelBuilder.Entity("Domain.Entities.Pais", b =>
                {
                    b.Navigation("Departamentos");
                });

            modelBuilder.Entity("Domain.Entities.Role", b =>
                {
                    b.Navigation("UsersRoles");
                });

            modelBuilder.Entity("Domain.Entities.TipoContacto", b =>
                {
                    b.Navigation("ContactoPersonas");
                });

            modelBuilder.Entity("Domain.Entities.TipoDireccion", b =>
                {
                    b.Navigation("Direcciones");
                });

            modelBuilder.Entity("Domain.Entities.TipoVia", b =>
                {
                    b.Navigation("Direcciones");
                });

            modelBuilder.Entity("Domain.Entities.Turno", b =>
                {
                    b.Navigation("Programaciones");
                });

            modelBuilder.Entity("Domain.Entities.User", b =>
                {
                    b.Navigation("RefreshTokens");

                    b.Navigation("UsersRoles");
                });
#pragma warning restore 612, 618
        }
    }
}
