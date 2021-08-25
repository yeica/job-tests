using System;
using Microsoft.EntityFrameworkCore.Migrations;

namespace MVCApp.Migrations
{
    public partial class InitialCreate : Migration
    {
        protected override void Up(MigrationBuilder migrationBuilder)
        {
            migrationBuilder.CreateTable(
                name: "TablaEstado",
                columns: table => new
                {
                    Id = table.Column<int>(type: "INTEGER", nullable: false)
                        .Annotation("Sqlite:Autoincrement", true),
                    NombreEstado = table.Column<int>(type: "INTEGER", nullable: false),
                    FechaCreacion = table.Column<DateTime>(type: "TEXT", nullable: false)
                },
                constraints: table =>
                {
                    table.PrimaryKey("PK_TablaEstado", x => x.Id);
                });

            migrationBuilder.CreateTable(
                name: "TablaEquipo",
                columns: table => new
                {
                    Id = table.Column<int>(type: "INTEGER", nullable: false)
                        .Annotation("Sqlite:Autoincrement", true),
                    Nombre = table.Column<string>(type: "TEXT", nullable: true),
                    País = table.Column<string>(type: "TEXT", maxLength: 3, nullable: true),
                    EstadoId = table.Column<int>(type: "INTEGER", nullable: true),
                    FechaCreacion = table.Column<DateTime>(type: "TEXT", nullable: false)
                },
                constraints: table =>
                {
                    table.PrimaryKey("PK_TablaEquipo", x => x.Id);
                    table.ForeignKey(
                        name: "FK_TablaEquipo_TablaEstado_EstadoId",
                        column: x => x.EstadoId,
                        principalTable: "TablaEstado",
                        principalColumn: "Id",
                        onDelete: ReferentialAction.Restrict);
                });

            migrationBuilder.CreateTable(
                name: "TablaJugador",
                columns: table => new
                {
                    Id = table.Column<int>(type: "INTEGER", nullable: false)
                        .Annotation("Sqlite:Autoincrement", true),
                    Nombre = table.Column<string>(type: "TEXT", nullable: true),
                    Apellido = table.Column<string>(type: "TEXT", nullable: true),
                    FechaNacimiento = table.Column<DateTime>(type: "TEXT", nullable: false),
                    Pasaporte = table.Column<string>(type: "TEXT", nullable: true),
                    Direccion = table.Column<string>(type: "TEXT", nullable: true),
                    Sexo = table.Column<string>(type: "TEXT", nullable: true),
                    EquipoId = table.Column<int>(type: "INTEGER", nullable: false),
                    EstadoId = table.Column<int>(type: "INTEGER", nullable: false)
                },
                constraints: table =>
                {
                    table.PrimaryKey("PK_TablaJugador", x => x.Id);
                    table.ForeignKey(
                        name: "FK_TablaJugador_TablaEquipo_EquipoId",
                        column: x => x.EquipoId,
                        principalTable: "TablaEquipo",
                        principalColumn: "Id",
                        onDelete: ReferentialAction.Cascade);
                    table.ForeignKey(
                        name: "FK_TablaJugador_TablaEstado_EstadoId",
                        column: x => x.EstadoId,
                        principalTable: "TablaEstado",
                        principalColumn: "Id",
                        onDelete: ReferentialAction.Cascade);
                });

            migrationBuilder.CreateIndex(
                name: "IX_TablaEquipo_EstadoId",
                table: "TablaEquipo",
                column: "EstadoId");

            migrationBuilder.CreateIndex(
                name: "IX_TablaJugador_EquipoId",
                table: "TablaJugador",
                column: "EquipoId");

            migrationBuilder.CreateIndex(
                name: "IX_TablaJugador_EstadoId",
                table: "TablaJugador",
                column: "EstadoId");
        }

        protected override void Down(MigrationBuilder migrationBuilder)
        {
            migrationBuilder.DropTable(
                name: "TablaJugador");

            migrationBuilder.DropTable(
                name: "TablaEquipo");

            migrationBuilder.DropTable(
                name: "TablaEstado");
        }
    }
}
