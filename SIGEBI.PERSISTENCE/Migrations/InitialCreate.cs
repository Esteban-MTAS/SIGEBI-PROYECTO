using System;
using Microsoft.EntityFrameworkCore.Migrations;

#nullable disable

namespace SIGEBI.Persistence.Migrations
{
    public partial class InitialCreate : Migration
    {
        protected override void Up(MigrationBuilder migrationBuilder)
        {
            // Tabla Usuario
            migrationBuilder.CreateTable(
                name: "Usuario",
                columns: table => new
                {
                    Id = table.Column<int>(nullable: false)
                              .Annotation("SqlServer:Identity", "1, 1"),
                    Nombre = table.Column<string>(maxLength: 100, nullable: false),
                    Email = table.Column<string>(maxLength: 100, nullable: false),
                    Rol = table.Column<string>(maxLength: 50, nullable: false),
                    Estado = table.Column<string>(maxLength: 50, nullable: false),
                    FechaRegistro = table.Column<DateTime>(nullable: false, defaultValueSql: "GETDATE()")
                },
                constraints: table =>
                {
                    table.PrimaryKey("PK_Usuario", x => x.Id);
                });

            // Tabla Libro
            migrationBuilder.CreateTable(
                name: "Libro",
                columns: table => new
                {
                    Id = table.Column<int>(nullable: false)
                              .Annotation("SqlServer:Identity", "1, 1"),
                    Titulo = table.Column<string>(maxLength: 150, nullable: false),
                    Autor = table.Column<string>(maxLength: 100, nullable: false),
                    ISBN = table.Column<string>(maxLength: 20, nullable: true),
                    Disponible = table.Column<bool>(nullable: false, defaultValue: true),
                    FechaRegistro = table.Column<DateTime>(nullable: false, defaultValueSql: "GETDATE()")
                },
                constraints: table =>
                {
                    table.PrimaryKey("PK_Libro", x => x.Id);
                });

            // Tabla Prestamo
            migrationBuilder.CreateTable(
                name: "Prestamo",
                columns: table => new
                {
                    Id = table.Column<int>(nullable: false)
                              .Annotation("SqlServer:Identity", "1, 1"),
                    LibroId = table.Column<int>(nullable: false),
                    UsuarioId = table.Column<int>(nullable: false),
                    FechaPrestamo = table.Column<DateTime>(nullable: false),
                    FechaDevolucion = table.Column<DateTime>(nullable: true),
                    Estado = table.Column<string>(maxLength: 50, nullable: false),
                    RegistradoPor = table.Column<int>(nullable: false)
                },
                constraints: table =>
                {
                    table.PrimaryKey("PK_Prestamo", x => x.Id);
                    table.ForeignKey(
                        name: "FK_Prestamo_Libro",
                        column: x => x.LibroId,
                        principalTable: "Libro",
                        principalColumn: "Id");
                    table.ForeignKey(
                        name: "FK_Prestamo_Usuario",
                        column: x => x.UsuarioId,
                        principalTable: "Usuario",
                        principalColumn: "Id");
                    table.ForeignKey(
                        name: "FK_Prestamo_Bibliotecario",
                        column: x => x.RegistradoPor,
                        principalTable: "Usuario",
                        principalColumn: "Id",
                        onDelete: ReferentialAction.Restrict);
                });

            // Tabla Penalizacion
            migrationBuilder.CreateTable(
                name: "Penalizacion",
                columns: table => new
                {
                    Id = table.Column<int>(nullable: false)
                              .Annotation("SqlServer:Identity", "1, 1"),
                    UsuarioId = table.Column<int>(nullable: false),
                    PrestamoId = table.Column<int>(nullable: false),
                    Monto = table.Column<decimal>(type: "decimal(10,2)", nullable: false),
                    Motivo = table.Column<string>(maxLength: 200, nullable: true),
                    Estado = table.Column<string>(maxLength: 50, nullable: false),
                    FechaAplicacion = table.Column<DateTime>(nullable: false, defaultValueSql: "GETDATE()")
                },
                constraints: table =>
                {
                    table.PrimaryKey("PK_Penalizacion", x => x.Id);
                    table.ForeignKey(
                        name: "FK_Penalizacion_Usuario",
                        column: x => x.UsuarioId,
                        principalTable: "Usuario",
                        principalColumn: "Id");
                    table.ForeignKey(
                        name: "FK_Penalizacion_Prestamo",
                        column: x => x.PrestamoId,
                        principalTable: "Prestamo",
                        principalColumn: "Id");
                });

            // Tabla Reporte
            migrationBuilder.CreateTable(
                name: "Reporte",
                columns: table => new
                {
                    Id = table.Column<int>(nullable: false)
                              .Annotation("SqlServer:Identity", "1, 1"),
                    Tipo = table.Column<string>(maxLength: 100, nullable: false),
                    FechaGeneracion = table.Column<DateTime>(nullable: false),
                    GeneradoPor = table.Column<int>(nullable: false),
                    Datos = table.Column<string>(type: "nvarchar(max)", nullable: true)
                },
                constraints: table =>
                {
                    table.PrimaryKey("PK_Reporte", x => x.Id);
                    table.ForeignKey(
                        name: "FK_Reporte_Usuario",
                        column: x => x.GeneradoPor,
                        principalTable: "Usuario",
                        principalColumn: "Id");
                });

            // Tabla Notificacion
            migrationBuilder.CreateTable(
                name: "Notificacion",
                columns: table => new
                {
                    Id = table.Column<int>(nullable: false)
                              .Annotation("SqlServer:Identity", "1, 1"),
                    UsuarioId = table.Column<int>(nullable: false),
                    Mensaje = table.Column<string>(maxLength: 300, nullable: false),
                    FechaEnvio = table.Column<DateTime>(nullable: false, defaultValueSql: "GETDATE()"),
                    Leido = table.Column<bool>(nullable: false, defaultValue: false)
                },
                constraints: table =>
                {
                    table.PrimaryKey("PK_Notificacion", x => x.Id);
                    table.ForeignKey(
                        name: "FK_Notificacion_Usuario",
                        column: x => x.UsuarioId,
                        principalTable: "Usuario",
                        principalColumn: "Id");
                });

            // Índices para claves foráneas
            migrationBuilder.CreateIndex("IX_Prestamo_LibroId", "Prestamo", "LibroId");
            migrationBuilder.CreateIndex("IX_Prestamo_UsuarioId", "Prestamo", "UsuarioId");
            migrationBuilder.CreateIndex("IX_Prestamo_RegistradoPor", "Prestamo", "RegistradoPor");
            migrationBuilder.CreateIndex("IX_Penalizacion_UsuarioId", "Penalizacion", "UsuarioId");
            migrationBuilder.CreateIndex("IX_Penalizacion_PrestamoId", "Penalizacion", "PrestamoId");
            migrationBuilder.CreateIndex("IX_Reporte_GeneradoPor", "Reporte", "GeneradoPor");
            migrationBuilder.CreateIndex("IX_Notificacion_UsuarioId", "Notificacion", "UsuarioId");
        }

        protected override void Down(MigrationBuilder migrationBuilder)
        {
            migrationBuilder.DropTable(name: "Notificacion");
            migrationBuilder.DropTable(name: "Penalizacion");
            migrationBuilder.DropTable(name: "Reporte");
            migrationBuilder.DropTable(name: "Prestamo");
            migrationBuilder.DropTable(name: "Libro");
            migrationBuilder.DropTable(name: "Usuario");
        }
    }
}

