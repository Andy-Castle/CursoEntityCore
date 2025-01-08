using Microsoft.EntityFrameworkCore.Migrations;

#nullable disable

namespace CursoEntityCore.Migrations
{
    /// <inheritdoc />
    public partial class RelacionMuchosAMuchosArticuloEtiquetaBD : Migration
    {
        /// <inheritdoc />
        protected override void Up(MigrationBuilder migrationBuilder)
        {
            migrationBuilder.CreateTable(
                name: "ArticuloEtiqueta",
                columns: table => new
                {
                    Articulo_Id = table.Column<int>(type: "int", nullable: false),
                    Etiqueta_Id = table.Column<int>(type: "int", nullable: false)
                },
                constraints: table =>
                {
                    table.PrimaryKey("PK_ArticuloEtiqueta", x => new { x.Etiqueta_Id, x.Articulo_Id });
                    table.ForeignKey(
                        name: "FK_ArticuloEtiqueta_Etiqueta_Etiqueta_Id",
                        column: x => x.Etiqueta_Id,
                        principalTable: "Etiqueta",
                        principalColumn: "Etiqueta_Id",
                        onDelete: ReferentialAction.Cascade);
                    table.ForeignKey(
                        name: "FK_ArticuloEtiqueta_Tbl_Articulo_Articulo_Id",
                        column: x => x.Articulo_Id,
                        principalTable: "Tbl_Articulo",
                        principalColumn: "Articulo_Id",
                        onDelete: ReferentialAction.Cascade);
                });

            migrationBuilder.CreateIndex(
                name: "IX_ArticuloEtiqueta_Articulo_Id",
                table: "ArticuloEtiqueta",
                column: "Articulo_Id");
        }

        /// <inheritdoc />
        protected override void Down(MigrationBuilder migrationBuilder)
        {
            migrationBuilder.DropTable(
                name: "ArticuloEtiqueta");
        }
    }
}
