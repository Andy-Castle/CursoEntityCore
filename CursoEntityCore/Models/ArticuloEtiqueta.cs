using System.ComponentModel.DataAnnotations;
using System.ComponentModel.DataAnnotations.Schema;

namespace CursoEntityCore.Models
{
    public class ArticuloEtiqueta
    {
        //[Key] - Esto no se puede
        [ForeignKey("Articulo")]
        public int Articulo_Id { get; set; }

        //[Key] - Esto no se puede
        [ForeignKey("Etiqueta")]

        public int Etiqueta_Id { get; set; }

        public Articulo Articulo { get; set; }

        public Etiqueta Etiqueta { get; set; }
    }
}
