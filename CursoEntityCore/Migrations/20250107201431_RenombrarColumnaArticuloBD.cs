using Microsoft.EntityFrameworkCore.Migrations;

#nullable disable

namespace CursoEntityCore.Migrations
{
    /// <inheritdoc />
    public partial class RenombrarColumnaArticuloBD : Migration
    {
        /// <inheritdoc />
        protected override void Up(MigrationBuilder migrationBuilder)
        {
            migrationBuilder.RenameColumn(
                name: "Articulo",
                table: "Tbl_Articulo",
                newName: "Titulo");
        }

        /// <inheritdoc />
        protected override void Down(MigrationBuilder migrationBuilder)
        {
            migrationBuilder.RenameColumn(
                name: "Titulo",
                table: "Tbl_Articulo",
                newName: "Articulo");
        }
    }
}
