using Microsoft.EntityFrameworkCore.Migrations;

#nullable disable

namespace CursoEntityCore.Migrations
{
    /// <inheritdoc />
    public partial class CampoEdadUsuarioNoMapeadoYDireccionBD : Migration
    {
        /// <inheritdoc />
        protected override void Up(MigrationBuilder migrationBuilder)
        {
            migrationBuilder.AddColumn<string>(
                name: "Direccion",
                table: "Usuario",
                type: "nvarchar(max)",
                nullable: false,
                defaultValue: "");
        }

        /// <inheritdoc />
        protected override void Down(MigrationBuilder migrationBuilder)
        {
            migrationBuilder.DropColumn(
                name: "Direccion",
                table: "Usuario");
        }
    }
}
