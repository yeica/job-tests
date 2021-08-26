using System;
using Microsoft.EntityFrameworkCore.Migrations;

namespace MVCApp.Migrations
{
    public partial class ModelChangesAndSeedData : Migration
    {
        protected override void Up(MigrationBuilder migrationBuilder)
        {
            migrationBuilder.DropForeignKey(
                name: "FK_TablaEquipo_TablaEstado_EstadoId",
                table: "TablaEquipo");

            migrationBuilder.RenameColumn(
                name: "País",
                table: "TablaEquipo",
                newName: "Pais");

            migrationBuilder.AlterColumn<string>(
                name: "NombreEstado",
                table: "TablaEstado",
                type: "TEXT",
                nullable: false,
                oldClrType: typeof(int),
                oldType: "INTEGER");

            migrationBuilder.AlterColumn<int>(
                name: "EstadoId",
                table: "TablaEquipo",
                type: "INTEGER",
                nullable: false,
                defaultValue: 0,
                oldClrType: typeof(int),
                oldType: "INTEGER",
                oldNullable: true);

            migrationBuilder.InsertData(
                table: "TablaEstado",
                columns: new[] { "Id", "FechaCreacion", "NombreEstado" },
                values: new object[] { 1, new DateTime(2021, 8, 25, 20, 21, 12, 793, DateTimeKind.Local).AddTicks(3089), "Activo" });

            migrationBuilder.InsertData(
                table: "TablaEstado",
                columns: new[] { "Id", "FechaCreacion", "NombreEstado" },
                values: new object[] { 2, new DateTime(2021, 8, 25, 20, 21, 12, 795, DateTimeKind.Local).AddTicks(9988), "Cancelado" });

            migrationBuilder.InsertData(
                table: "TablaEstado",
                columns: new[] { "Id", "FechaCreacion", "NombreEstado" },
                values: new object[] { 3, new DateTime(2021, 8, 25, 20, 21, 12, 796, DateTimeKind.Local).AddTicks(78), "AgenteLibre" });

            migrationBuilder.AddForeignKey(
                name: "FK_TablaEquipo_TablaEstado_EstadoId",
                table: "TablaEquipo",
                column: "EstadoId",
                principalTable: "TablaEstado",
                principalColumn: "Id",
                onDelete: ReferentialAction.Cascade);
        }

        protected override void Down(MigrationBuilder migrationBuilder)
        {
            migrationBuilder.DropForeignKey(
                name: "FK_TablaEquipo_TablaEstado_EstadoId",
                table: "TablaEquipo");

            migrationBuilder.DeleteData(
                table: "TablaEstado",
                keyColumn: "Id",
                keyValue: 1);

            migrationBuilder.DeleteData(
                table: "TablaEstado",
                keyColumn: "Id",
                keyValue: 2);

            migrationBuilder.DeleteData(
                table: "TablaEstado",
                keyColumn: "Id",
                keyValue: 3);

            migrationBuilder.RenameColumn(
                name: "Pais",
                table: "TablaEquipo",
                newName: "País");

            migrationBuilder.AlterColumn<int>(
                name: "NombreEstado",
                table: "TablaEstado",
                type: "INTEGER",
                nullable: false,
                oldClrType: typeof(string),
                oldType: "TEXT");

            migrationBuilder.AlterColumn<int>(
                name: "EstadoId",
                table: "TablaEquipo",
                type: "INTEGER",
                nullable: true,
                oldClrType: typeof(int),
                oldType: "INTEGER");

            migrationBuilder.AddForeignKey(
                name: "FK_TablaEquipo_TablaEstado_EstadoId",
                table: "TablaEquipo",
                column: "EstadoId",
                principalTable: "TablaEstado",
                principalColumn: "Id",
                onDelete: ReferentialAction.Restrict);
        }
    }
}
