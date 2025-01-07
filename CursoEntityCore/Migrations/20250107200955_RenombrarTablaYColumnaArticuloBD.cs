using Microsoft.EntityFrameworkCore.Migrations;

#nullable disable

namespace CursoEntityCore.Migrations
{
    /// <inheritdoc />
    public partial class RenombrarTablaYColumnaArticuloBD : Migration
    {
        /// <inheritdoc />
        protected override void Up(MigrationBuilder migrationBuilder)
        {
            migrationBuilder.DropPrimaryKey(
                name: "PK_Articulo",
                table: "Articulo");

            migrationBuilder.RenameTable(
                name: "Articulo",
                newName: "Tbl_Articulo");

            migrationBuilder.RenameColumn(
                name: "TituloArticulo",
                table: "Tbl_Articulo",
                newName: "Articulo");

            migrationBuilder.AddPrimaryKey(
                name: "PK_Tbl_Articulo",
                table: "Tbl_Articulo",
                column: "ArticuloId");
        }

        /// <inheritdoc />
        protected override void Down(MigrationBuilder migrationBuilder)
        {
            migrationBuilder.DropPrimaryKey(
                name: "PK_Tbl_Articulo",
                table: "Tbl_Articulo");

            migrationBuilder.RenameTable(
                name: "Tbl_Articulo",
                newName: "Articulo");

            migrationBuilder.RenameColumn(
                name: "Articulo",
                table: "Articulo",
                newName: "TituloArticulo");

            migrationBuilder.AddPrimaryKey(
                name: "PK_Articulo",
                table: "Articulo",
                column: "ArticuloId");
        }
    }
}
