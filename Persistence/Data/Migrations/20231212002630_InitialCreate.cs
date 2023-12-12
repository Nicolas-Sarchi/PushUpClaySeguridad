using System;
using Microsoft.EntityFrameworkCore.Metadata;
using Microsoft.EntityFrameworkCore.Migrations;

#nullable disable

#pragma warning disable CA1814 // Prefer jagged arrays over multidimensional

namespace Persistence.Data.Migrations
{
    /// <inheritdoc />
    public partial class InitialCreate : Migration
    {
        /// <inheritdoc />
        protected override void Up(MigrationBuilder migrationBuilder)
        {
            migrationBuilder.AlterDatabase()
                .Annotation("MySql:CharSet", "utf8mb4");

            migrationBuilder.CreateTable(
                name: "categoria",
                columns: table => new
                {
                    Id = table.Column<int>(type: "int", nullable: false)
                        .Annotation("MySql:ValueGenerationStrategy", MySqlValueGenerationStrategy.IdentityColumn),
                    NombreCategoria = table.Column<string>(type: "varchar(15)", maxLength: 15, nullable: false)
                        .Annotation("MySql:CharSet", "utf8mb4")
                },
                constraints: table =>
                {
                    table.PrimaryKey("PK_categoria", x => x.Id);
                })
                .Annotation("MySql:CharSet", "utf8mb4");

            migrationBuilder.CreateTable(
                name: "estado",
                columns: table => new
                {
                    Id = table.Column<int>(type: "int", nullable: false)
                        .Annotation("MySql:ValueGenerationStrategy", MySqlValueGenerationStrategy.IdentityColumn),
                    Descripcion = table.Column<string>(type: "varchar(15)", maxLength: 15, nullable: false)
                        .Annotation("MySql:CharSet", "utf8mb4")
                },
                constraints: table =>
                {
                    table.PrimaryKey("PK_estado", x => x.Id);
                })
                .Annotation("MySql:CharSet", "utf8mb4");

            migrationBuilder.CreateTable(
                name: "pais",
                columns: table => new
                {
                    Id = table.Column<int>(type: "int", nullable: false)
                        .Annotation("MySql:ValueGenerationStrategy", MySqlValueGenerationStrategy.IdentityColumn),
                    NombrePais = table.Column<string>(type: "varchar(25)", maxLength: 25, nullable: false)
                        .Annotation("MySql:CharSet", "utf8mb4")
                },
                constraints: table =>
                {
                    table.PrimaryKey("PK_pais", x => x.Id);
                })
                .Annotation("MySql:CharSet", "utf8mb4");

            migrationBuilder.CreateTable(
                name: "role",
                columns: table => new
                {
                    Id = table.Column<int>(type: "int", nullable: false)
                        .Annotation("MySql:ValueGenerationStrategy", MySqlValueGenerationStrategy.IdentityColumn),
                    Nombre = table.Column<string>(type: "varchar(50)", maxLength: 50, nullable: false)
                        .Annotation("MySql:CharSet", "utf8mb4")
                },
                constraints: table =>
                {
                    table.PrimaryKey("PK_role", x => x.Id);
                })
                .Annotation("MySql:CharSet", "utf8mb4");

            migrationBuilder.CreateTable(
                name: "tipo_contacto",
                columns: table => new
                {
                    Id = table.Column<int>(type: "int", nullable: false)
                        .Annotation("MySql:ValueGenerationStrategy", MySqlValueGenerationStrategy.IdentityColumn),
                    Descripcion = table.Column<string>(type: "varchar(25)", maxLength: 25, nullable: false)
                        .Annotation("MySql:CharSet", "utf8mb4")
                },
                constraints: table =>
                {
                    table.PrimaryKey("PK_tipo_contacto", x => x.Id);
                })
                .Annotation("MySql:CharSet", "utf8mb4");

            migrationBuilder.CreateTable(
                name: "tipo_direccion",
                columns: table => new
                {
                    Id = table.Column<int>(type: "int", nullable: false)
                        .Annotation("MySql:ValueGenerationStrategy", MySqlValueGenerationStrategy.IdentityColumn),
                    Descripcion = table.Column<string>(type: "varchar(50)", maxLength: 50, nullable: false)
                        .Annotation("MySql:CharSet", "utf8mb4")
                },
                constraints: table =>
                {
                    table.PrimaryKey("PK_tipo_direccion", x => x.Id);
                })
                .Annotation("MySql:CharSet", "utf8mb4");

            migrationBuilder.CreateTable(
                name: "tipo_via",
                columns: table => new
                {
                    Id = table.Column<int>(type: "int", nullable: false)
                        .Annotation("MySql:ValueGenerationStrategy", MySqlValueGenerationStrategy.IdentityColumn),
                    Descripcion = table.Column<string>(type: "varchar(20)", maxLength: 20, nullable: false)
                        .Annotation("MySql:CharSet", "utf8mb4")
                },
                constraints: table =>
                {
                    table.PrimaryKey("PK_tipo_via", x => x.Id);
                })
                .Annotation("MySql:CharSet", "utf8mb4");

            migrationBuilder.CreateTable(
                name: "turno",
                columns: table => new
                {
                    Id = table.Column<int>(type: "int", nullable: false)
                        .Annotation("MySql:ValueGenerationStrategy", MySqlValueGenerationStrategy.IdentityColumn),
                    NombreTurno = table.Column<string>(type: "varchar(15)", maxLength: 15, nullable: false)
                        .Annotation("MySql:CharSet", "utf8mb4"),
                    HoraInicio = table.Column<TimeOnly>(type: "time(6)", nullable: false),
                    HoraFin = table.Column<TimeOnly>(type: "time(6)", nullable: false)
                },
                constraints: table =>
                {
                    table.PrimaryKey("PK_turno", x => x.Id);
                })
                .Annotation("MySql:CharSet", "utf8mb4");

            migrationBuilder.CreateTable(
                name: "user",
                columns: table => new
                {
                    Id = table.Column<int>(type: "int", nullable: false)
                        .Annotation("MySql:ValueGenerationStrategy", MySqlValueGenerationStrategy.IdentityColumn),
                    username = table.Column<string>(type: "varchar(50)", maxLength: 50, nullable: true)
                        .Annotation("MySql:CharSet", "utf8mb4"),
                    email = table.Column<string>(type: "varchar(100)", maxLength: 100, nullable: false)
                        .Annotation("MySql:CharSet", "utf8mb4"),
                    password = table.Column<string>(type: "varchar(255)", maxLength: 255, nullable: false)
                        .Annotation("MySql:CharSet", "utf8mb4")
                },
                constraints: table =>
                {
                    table.PrimaryKey("PK_user", x => x.Id);
                })
                .Annotation("MySql:CharSet", "utf8mb4");

            migrationBuilder.CreateTable(
                name: "departamento",
                columns: table => new
                {
                    Id = table.Column<int>(type: "int", nullable: false)
                        .Annotation("MySql:ValueGenerationStrategy", MySqlValueGenerationStrategy.IdentityColumn),
                    NombreDep = table.Column<string>(type: "varchar(25)", maxLength: 25, nullable: false)
                        .Annotation("MySql:CharSet", "utf8mb4"),
                    IdPais = table.Column<int>(type: "int", nullable: false)
                },
                constraints: table =>
                {
                    table.PrimaryKey("PK_departamento", x => x.Id);
                    table.ForeignKey(
                        name: "FK_departamento_pais_IdPais",
                        column: x => x.IdPais,
                        principalTable: "pais",
                        principalColumn: "Id",
                        onDelete: ReferentialAction.Cascade);
                })
                .Annotation("MySql:CharSet", "utf8mb4");

            migrationBuilder.CreateTable(
                name: "RefreshToken",
                columns: table => new
                {
                    Id = table.Column<int>(type: "int", nullable: false)
                        .Annotation("MySql:ValueGenerationStrategy", MySqlValueGenerationStrategy.IdentityColumn),
                    UserId = table.Column<int>(type: "int", nullable: false),
                    Token = table.Column<string>(type: "longtext", nullable: true)
                        .Annotation("MySql:CharSet", "utf8mb4"),
                    Expires = table.Column<DateTime>(type: "datetime(6)", nullable: false),
                    Created = table.Column<DateTime>(type: "datetime(6)", nullable: false),
                    Revoked = table.Column<DateTime>(type: "datetime(6)", nullable: true)
                },
                constraints: table =>
                {
                    table.PrimaryKey("PK_RefreshToken", x => x.Id);
                    table.ForeignKey(
                        name: "FK_RefreshToken_user_UserId",
                        column: x => x.UserId,
                        principalTable: "user",
                        principalColumn: "Id",
                        onDelete: ReferentialAction.Cascade);
                })
                .Annotation("MySql:CharSet", "utf8mb4");

            migrationBuilder.CreateTable(
                name: "userRol",
                columns: table => new
                {
                    UserId = table.Column<int>(type: "int", nullable: false),
                    RoleId = table.Column<int>(type: "int", nullable: false)
                },
                constraints: table =>
                {
                    table.PrimaryKey("PK_userRol", x => new { x.UserId, x.RoleId });
                    table.ForeignKey(
                        name: "FK_userRol_role_RoleId",
                        column: x => x.RoleId,
                        principalTable: "role",
                        principalColumn: "Id",
                        onDelete: ReferentialAction.Cascade);
                    table.ForeignKey(
                        name: "FK_userRol_user_UserId",
                        column: x => x.UserId,
                        principalTable: "user",
                        principalColumn: "Id",
                        onDelete: ReferentialAction.Cascade);
                })
                .Annotation("MySql:CharSet", "utf8mb4");

            migrationBuilder.CreateTable(
                name: "ciudad",
                columns: table => new
                {
                    Id = table.Column<int>(type: "int", nullable: false)
                        .Annotation("MySql:ValueGenerationStrategy", MySqlValueGenerationStrategy.IdentityColumn),
                    NombreCiu = table.Column<string>(type: "varchar(30)", maxLength: 30, nullable: false)
                        .Annotation("MySql:CharSet", "utf8mb4"),
                    IdDepartamento = table.Column<int>(type: "int", nullable: false)
                },
                constraints: table =>
                {
                    table.PrimaryKey("PK_ciudad", x => x.Id);
                    table.ForeignKey(
                        name: "FK_ciudad_departamento_IdDepartamento",
                        column: x => x.IdDepartamento,
                        principalTable: "departamento",
                        principalColumn: "Id",
                        onDelete: ReferentialAction.Cascade);
                })
                .Annotation("MySql:CharSet", "utf8mb4");

            migrationBuilder.CreateTable(
                name: "direccion",
                columns: table => new
                {
                    Id = table.Column<int>(type: "int", nullable: false)
                        .Annotation("MySql:ValueGenerationStrategy", MySqlValueGenerationStrategy.IdentityColumn),
                    NroPrincipal = table.Column<string>(type: "varchar(10)", maxLength: 10, nullable: false)
                        .Annotation("MySql:CharSet", "utf8mb4"),
                    NroSecundario = table.Column<string>(type: "varchar(10)", maxLength: 10, nullable: false)
                        .Annotation("MySql:CharSet", "utf8mb4"),
                    Complemento = table.Column<string>(type: "varchar(5)", maxLength: 5, nullable: false)
                        .Annotation("MySql:CharSet", "utf8mb4"),
                    InfoAdicional = table.Column<string>(type: "varchar(25)", maxLength: 25, nullable: true)
                        .Annotation("MySql:CharSet", "utf8mb4"),
                    IdTipoVia = table.Column<int>(type: "int", nullable: false),
                    IdTipoDireccion = table.Column<int>(type: "int", nullable: false),
                    IdCiudad = table.Column<int>(type: "int", nullable: false)
                },
                constraints: table =>
                {
                    table.PrimaryKey("PK_direccion", x => x.Id);
                    table.ForeignKey(
                        name: "FK_direccion_ciudad_IdCiudad",
                        column: x => x.IdCiudad,
                        principalTable: "ciudad",
                        principalColumn: "Id",
                        onDelete: ReferentialAction.Cascade);
                    table.ForeignKey(
                        name: "FK_direccion_tipo_direccion_IdTipoDireccion",
                        column: x => x.IdTipoDireccion,
                        principalTable: "tipo_direccion",
                        principalColumn: "Id",
                        onDelete: ReferentialAction.Cascade);
                    table.ForeignKey(
                        name: "FK_direccion_tipo_via_IdTipoVia",
                        column: x => x.IdTipoVia,
                        principalTable: "tipo_via",
                        principalColumn: "Id",
                        onDelete: ReferentialAction.Cascade);
                })
                .Annotation("MySql:CharSet", "utf8mb4");

            migrationBuilder.CreateTable(
                name: "Cliente",
                columns: table => new
                {
                    Id = table.Column<int>(type: "int", nullable: false)
                        .Annotation("MySql:ValueGenerationStrategy", MySqlValueGenerationStrategy.IdentityColumn),
                    IdPersona = table.Column<string>(type: "varchar(15)", maxLength: 15, nullable: false)
                        .Annotation("MySql:CharSet", "utf8mb4"),
                    Nombre = table.Column<string>(type: "varchar(20)", maxLength: 20, nullable: false)
                        .Annotation("MySql:CharSet", "utf8mb4"),
                    FechaReg = table.Column<DateOnly>(type: "date", nullable: false),
                    IdDireccion = table.Column<int>(type: "int", nullable: false)
                },
                constraints: table =>
                {
                    table.PrimaryKey("PK_Cliente", x => x.Id);
                    table.ForeignKey(
                        name: "FK_Cliente_direccion_IdDireccion",
                        column: x => x.IdDireccion,
                        principalTable: "direccion",
                        principalColumn: "Id",
                        onDelete: ReferentialAction.Cascade);
                })
                .Annotation("MySql:CharSet", "utf8mb4");

            migrationBuilder.CreateTable(
                name: "empleado",
                columns: table => new
                {
                    Id = table.Column<int>(type: "int", nullable: false)
                        .Annotation("MySql:ValueGenerationStrategy", MySqlValueGenerationStrategy.IdentityColumn),
                    IdPersona = table.Column<string>(type: "varchar(15)", maxLength: 15, nullable: false)
                        .Annotation("MySql:CharSet", "utf8mb4"),
                    Nombre = table.Column<string>(type: "varchar(20)", maxLength: 20, nullable: false)
                        .Annotation("MySql:CharSet", "utf8mb4"),
                    FechaReg = table.Column<DateOnly>(type: "date", nullable: false),
                    IdDireccion = table.Column<int>(type: "int", nullable: false),
                    IdCategoria = table.Column<int>(type: "int", nullable: false)
                },
                constraints: table =>
                {
                    table.PrimaryKey("PK_empleado", x => x.Id);
                    table.ForeignKey(
                        name: "FK_empleado_categoria_IdCategoria",
                        column: x => x.IdCategoria,
                        principalTable: "categoria",
                        principalColumn: "Id",
                        onDelete: ReferentialAction.Cascade);
                    table.ForeignKey(
                        name: "FK_empleado_direccion_IdDireccion",
                        column: x => x.IdDireccion,
                        principalTable: "direccion",
                        principalColumn: "Id",
                        onDelete: ReferentialAction.Cascade);
                })
                .Annotation("MySql:CharSet", "utf8mb4");

            migrationBuilder.CreateTable(
                name: "contacto",
                columns: table => new
                {
                    Id = table.Column<int>(type: "int", nullable: false)
                        .Annotation("MySql:ValueGenerationStrategy", MySqlValueGenerationStrategy.IdentityColumn),
                    Descripcion = table.Column<string>(type: "varchar(30)", maxLength: 30, nullable: false)
                        .Annotation("MySql:CharSet", "utf8mb4"),
                    IdPersona = table.Column<int>(type: "int", nullable: false),
                    IdTipoContacto = table.Column<int>(type: "int", nullable: false),
                    ClienteId = table.Column<int>(type: "int", nullable: true)
                },
                constraints: table =>
                {
                    table.PrimaryKey("PK_contacto", x => x.Id);
                    table.ForeignKey(
                        name: "FK_contacto_Cliente_ClienteId",
                        column: x => x.ClienteId,
                        principalTable: "Cliente",
                        principalColumn: "Id");
                    table.ForeignKey(
                        name: "FK_contacto_empleado_IdPersona",
                        column: x => x.IdPersona,
                        principalTable: "empleado",
                        principalColumn: "Id",
                        onDelete: ReferentialAction.Cascade);
                    table.ForeignKey(
                        name: "FK_contacto_tipo_contacto_IdTipoContacto",
                        column: x => x.IdTipoContacto,
                        principalTable: "tipo_contacto",
                        principalColumn: "Id",
                        onDelete: ReferentialAction.Cascade);
                })
                .Annotation("MySql:CharSet", "utf8mb4");

            migrationBuilder.CreateTable(
                name: "contrato",
                columns: table => new
                {
                    Id = table.Column<int>(type: "int", nullable: false)
                        .Annotation("MySql:ValueGenerationStrategy", MySqlValueGenerationStrategy.IdentityColumn),
                    IdCliente = table.Column<int>(type: "int", nullable: false),
                    FechaContrato = table.Column<DateOnly>(type: "date", nullable: false),
                    FechaFin = table.Column<DateOnly>(type: "date", nullable: false),
                    IdEmpleado = table.Column<int>(type: "int", nullable: false),
                    IdEstado = table.Column<int>(type: "int", nullable: false)
                },
                constraints: table =>
                {
                    table.PrimaryKey("PK_contrato", x => x.Id);
                    table.ForeignKey(
                        name: "FK_contrato_Cliente_IdCliente",
                        column: x => x.IdCliente,
                        principalTable: "Cliente",
                        principalColumn: "Id",
                        onDelete: ReferentialAction.Cascade);
                    table.ForeignKey(
                        name: "FK_contrato_empleado_IdEmpleado",
                        column: x => x.IdEmpleado,
                        principalTable: "empleado",
                        principalColumn: "Id",
                        onDelete: ReferentialAction.Cascade);
                    table.ForeignKey(
                        name: "FK_contrato_estado_IdEstado",
                        column: x => x.IdEstado,
                        principalTable: "estado",
                        principalColumn: "Id",
                        onDelete: ReferentialAction.Cascade);
                })
                .Annotation("MySql:CharSet", "utf8mb4");

            migrationBuilder.CreateTable(
                name: "programacion",
                columns: table => new
                {
                    Id = table.Column<int>(type: "int", nullable: false)
                        .Annotation("MySql:ValueGenerationStrategy", MySqlValueGenerationStrategy.IdentityColumn),
                    IdContrato = table.Column<int>(type: "int", nullable: false),
                    IdTurno = table.Column<int>(type: "int", nullable: false),
                    IdEmpleado = table.Column<int>(type: "int", nullable: false)
                },
                constraints: table =>
                {
                    table.PrimaryKey("PK_programacion", x => x.Id);
                    table.ForeignKey(
                        name: "FK_programacion_contrato_IdContrato",
                        column: x => x.IdContrato,
                        principalTable: "contrato",
                        principalColumn: "Id",
                        onDelete: ReferentialAction.Cascade);
                    table.ForeignKey(
                        name: "FK_programacion_empleado_IdEmpleado",
                        column: x => x.IdEmpleado,
                        principalTable: "empleado",
                        principalColumn: "Id",
                        onDelete: ReferentialAction.Cascade);
                    table.ForeignKey(
                        name: "FK_programacion_turno_IdTurno",
                        column: x => x.IdTurno,
                        principalTable: "turno",
                        principalColumn: "Id",
                        onDelete: ReferentialAction.Cascade);
                })
                .Annotation("MySql:CharSet", "utf8mb4");

            migrationBuilder.InsertData(
                table: "categoria",
                columns: new[] { "Id", "NombreCategoria" },
                values: new object[] { 1, "Vigilante" });

            migrationBuilder.InsertData(
                table: "estado",
                columns: new[] { "Id", "Descripcion" },
                values: new object[,]
                {
                    { 1, "Activo" },
                    { 2, "Inactivo" }
                });

            migrationBuilder.InsertData(
                table: "pais",
                columns: new[] { "Id", "NombrePais" },
                values: new object[] { 1, "Colombia" });

            migrationBuilder.InsertData(
                table: "role",
                columns: new[] { "Id", "Nombre" },
                values: new object[,]
                {
                    { 1, "Administrador" },
                    { 2, "Empleado" }
                });

            migrationBuilder.InsertData(
                table: "tipo_contacto",
                columns: new[] { "Id", "Descripcion" },
                values: new object[,]
                {
                    { 1, "Telefono" },
                    { 2, "Correo Electronico" }
                });

            migrationBuilder.InsertData(
                table: "tipo_direccion",
                columns: new[] { "Id", "Descripcion" },
                values: new object[,]
                {
                    { 1, "Casa" },
                    { 2, "Oficina" }
                });

            migrationBuilder.InsertData(
                table: "tipo_via",
                columns: new[] { "Id", "Descripcion" },
                values: new object[,]
                {
                    { 1, "Calle" },
                    { 2, "Carrera" }
                });

            migrationBuilder.InsertData(
                table: "turno",
                columns: new[] { "Id", "HoraFin", "HoraInicio", "NombreTurno" },
                values: new object[,]
                {
                    { 1, new TimeOnly(13, 0, 0), new TimeOnly(7, 0, 0), "Turno 1" },
                    { 2, new TimeOnly(18, 0, 0), new TimeOnly(14, 0, 0), "Turno 2" }
                });

            migrationBuilder.InsertData(
                table: "departamento",
                columns: new[] { "Id", "IdPais", "NombreDep" },
                values: new object[] { 1, 1, "Santander" });

            migrationBuilder.InsertData(
                table: "ciudad",
                columns: new[] { "Id", "IdDepartamento", "NombreCiu" },
                values: new object[,]
                {
                    { 1, 1, "Bucaramanga" },
                    { 2, 1, "Giron" },
                    { 3, 1, "Piedecuesta" }
                });

            migrationBuilder.InsertData(
                table: "direccion",
                columns: new[] { "Id", "Complemento", "IdCiudad", "IdTipoDireccion", "IdTipoVia", "InfoAdicional", "NroPrincipal", "NroSecundario" },
                values: new object[,]
                {
                    { 1, "32", 1, 1, 2, null, "25", "27" },
                    { 2, "42", 2, 1, 1, null, "25B", "24A" },
                    { 3, "32", 2, 1, 2, null, "25", "27" },
                    { 4, "32", 3, 1, 2, null, "25", "27" }
                });

            migrationBuilder.InsertData(
                table: "Cliente",
                columns: new[] { "Id", "FechaReg", "IdDireccion", "IdPersona", "Nombre" },
                values: new object[,]
                {
                    { 1, new DateOnly(2018, 5, 21), 1, "1101622982", "Lionel Messi" },
                    { 2, new DateOnly(2010, 10, 11), 2, "43622982", "James Rodriguez" }
                });

            migrationBuilder.InsertData(
                table: "empleado",
                columns: new[] { "Id", "FechaReg", "IdCategoria", "IdDireccion", "IdPersona", "Nombre" },
                values: new object[,]
                {
                    { 1, new DateOnly(2021, 1, 21), 1, 3, "53054583", "Linda Caicedo" },
                    { 2, new DateOnly(2023, 12, 18), 1, 1, "54267888", "Julian Lopez" },
                    { 3, new DateOnly(2023, 12, 18), 1, 4, "555564", "Paco Web" }
                });

            migrationBuilder.InsertData(
                table: "contacto",
                columns: new[] { "Id", "ClienteId", "Descripcion", "IdPersona", "IdTipoContacto" },
                values: new object[,]
                {
                    { 1, null, "3177520056", 1, 1 },
                    { 2, null, "12312313", 2, 1 },
                    { 3, null, "3123459094", 1, 1 }
                });

            migrationBuilder.InsertData(
                table: "contrato",
                columns: new[] { "Id", "FechaContrato", "FechaFin", "IdCliente", "IdEmpleado", "IdEstado" },
                values: new object[,]
                {
                    { 1, new DateOnly(2023, 6, 12), new DateOnly(2024, 3, 13), 1, 2, 1 },
                    { 2, new DateOnly(2023, 2, 22), new DateOnly(2023, 12, 10), 2, 1, 2 }
                });

            migrationBuilder.InsertData(
                table: "programacion",
                columns: new[] { "Id", "IdContrato", "IdEmpleado", "IdTurno" },
                values: new object[,]
                {
                    { 1, 1, 2, 1 },
                    { 2, 1, 1, 2 }
                });

            migrationBuilder.CreateIndex(
                name: "IX_ciudad_IdDepartamento",
                table: "ciudad",
                column: "IdDepartamento");

            migrationBuilder.CreateIndex(
                name: "IX_Cliente_IdDireccion",
                table: "Cliente",
                column: "IdDireccion");

            migrationBuilder.CreateIndex(
                name: "IX_Cliente_IdPersona",
                table: "Cliente",
                column: "IdPersona",
                unique: true);

            migrationBuilder.CreateIndex(
                name: "IX_contacto_ClienteId",
                table: "contacto",
                column: "ClienteId");

            migrationBuilder.CreateIndex(
                name: "IX_contacto_Descripcion",
                table: "contacto",
                column: "Descripcion",
                unique: true);

            migrationBuilder.CreateIndex(
                name: "IX_contacto_IdPersona",
                table: "contacto",
                column: "IdPersona");

            migrationBuilder.CreateIndex(
                name: "IX_contacto_IdTipoContacto",
                table: "contacto",
                column: "IdTipoContacto");

            migrationBuilder.CreateIndex(
                name: "IX_contrato_IdCliente",
                table: "contrato",
                column: "IdCliente");

            migrationBuilder.CreateIndex(
                name: "IX_contrato_IdEmpleado",
                table: "contrato",
                column: "IdEmpleado");

            migrationBuilder.CreateIndex(
                name: "IX_contrato_IdEstado",
                table: "contrato",
                column: "IdEstado");

            migrationBuilder.CreateIndex(
                name: "IX_departamento_IdPais",
                table: "departamento",
                column: "IdPais");

            migrationBuilder.CreateIndex(
                name: "IX_direccion_IdCiudad",
                table: "direccion",
                column: "IdCiudad");

            migrationBuilder.CreateIndex(
                name: "IX_direccion_IdTipoDireccion",
                table: "direccion",
                column: "IdTipoDireccion");

            migrationBuilder.CreateIndex(
                name: "IX_direccion_IdTipoVia",
                table: "direccion",
                column: "IdTipoVia");

            migrationBuilder.CreateIndex(
                name: "IX_empleado_IdCategoria",
                table: "empleado",
                column: "IdCategoria");

            migrationBuilder.CreateIndex(
                name: "IX_empleado_IdDireccion",
                table: "empleado",
                column: "IdDireccion");

            migrationBuilder.CreateIndex(
                name: "IX_empleado_IdPersona",
                table: "empleado",
                column: "IdPersona",
                unique: true);

            migrationBuilder.CreateIndex(
                name: "IX_programacion_IdContrato",
                table: "programacion",
                column: "IdContrato");

            migrationBuilder.CreateIndex(
                name: "IX_programacion_IdEmpleado",
                table: "programacion",
                column: "IdEmpleado");

            migrationBuilder.CreateIndex(
                name: "IX_programacion_IdTurno",
                table: "programacion",
                column: "IdTurno");

            migrationBuilder.CreateIndex(
                name: "IX_RefreshToken_UserId",
                table: "RefreshToken",
                column: "UserId");

            migrationBuilder.CreateIndex(
                name: "IX_userRol_RoleId",
                table: "userRol",
                column: "RoleId");
        }

        /// <inheritdoc />
        protected override void Down(MigrationBuilder migrationBuilder)
        {
            migrationBuilder.DropTable(
                name: "contacto");

            migrationBuilder.DropTable(
                name: "programacion");

            migrationBuilder.DropTable(
                name: "RefreshToken");

            migrationBuilder.DropTable(
                name: "userRol");

            migrationBuilder.DropTable(
                name: "tipo_contacto");

            migrationBuilder.DropTable(
                name: "contrato");

            migrationBuilder.DropTable(
                name: "turno");

            migrationBuilder.DropTable(
                name: "role");

            migrationBuilder.DropTable(
                name: "user");

            migrationBuilder.DropTable(
                name: "Cliente");

            migrationBuilder.DropTable(
                name: "empleado");

            migrationBuilder.DropTable(
                name: "estado");

            migrationBuilder.DropTable(
                name: "categoria");

            migrationBuilder.DropTable(
                name: "direccion");

            migrationBuilder.DropTable(
                name: "ciudad");

            migrationBuilder.DropTable(
                name: "tipo_direccion");

            migrationBuilder.DropTable(
                name: "tipo_via");

            migrationBuilder.DropTable(
                name: "departamento");

            migrationBuilder.DropTable(
                name: "pais");
        }
    }
}
