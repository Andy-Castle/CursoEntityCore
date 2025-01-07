using Microsoft.EntityFrameworkCore.Migrations;

#nullable disable

namespace CursoEntityCore.Migrations
{
    /// <inheritdoc />
    public partial class AgregadoRangoEnArticuloBD : Migration
    {
        /// <inheritdoc />
        protected override void Up(MigrationBuilder migrationBuilder)
        {
            migrationBuilder.AddColumn<double>(
                name: "Calificacion",
                table: "Tbl_Articulo",
                type: "float",
                nullable: false,
                defaultValue: 0.0);
        }

        /// <inheritdoc />
        protected override void Down(MigrationBuilder migrationBuilder)
        {
            migrationBuilder.DropColumn(
                name: "Calificacion",
                table: "Tbl_Articulo");
        }
    }
}
