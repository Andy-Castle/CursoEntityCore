using System.ComponentModel.DataAnnotations;

namespace CursoEntityCore.Models
{
    public class Etiqueta
    {
        [Key]
        public int Etiqueta_Id { get; set; }

        public string Titulo { get; set; }

        [DataType(DataType.Date)]
        public DateTime Fecha { get; set; }

        //Para relacion muchos a muchos
        public ICollection<ArticuloEtiqueta> articuloEtiqueta { get; set; }

    }
}
