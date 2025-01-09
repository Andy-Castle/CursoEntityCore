using System;
using Microsoft.EntityFrameworkCore.Migrations;

#nullable disable

#pragma warning disable CA1814 // Prefer jagged arrays over multidimensional

namespace CursoEntityCore.Migrations
{
    /// <inheritdoc />
    public partial class SiembraDatosCategoriaBD : Migration
    {
        /// <inheritdoc />
        protected override void Up(MigrationBuilder migrationBuilder)
        {
            migrationBuilder.InsertData(
                table: "Categoria",
                columns: new[] { "Categoria_Id", "Activo", "FechaCreacion", "Nombre" },
                values: new object[,]
                {
                    { 33, true, new DateTime(2024, 11, 28, 0, 0, 0, 0, DateTimeKind.Unspecified), "Categoria 5" },
                    { 34, false, new DateTime(2024, 12, 29, 0, 0, 0, 0, DateTimeKind.Unspecified), "Categoria 6" }
                });
        }

        /// <inheritdoc />
        protected override void Down(MigrationBuilder migrationBuilder)
        {
            migrationBuilder.DeleteData(
                table: "Categoria",
                keyColumn: "Categoria_Id",
                keyValue: 33);

            migrationBuilder.DeleteData(
                table: "Categoria",
                keyColumn: "Categoria_Id",
                keyValue: 34);
        }
    }
}
