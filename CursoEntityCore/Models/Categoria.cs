using System.ComponentModel.DataAnnotations;
using System.ComponentModel.DataAnnotations.Schema;

namespace CursoEntityCore.Models
{
    public class Categoria
    {
        //[Key]
        //[DatabaseGenerated(DatabaseGeneratedOption.Identity)]
        public int Id { get; set; }

        [DisplayFormat(ConvertEmptyStringToNull = true, NullDisplayText = "[NULL]")]
        public string Nombre { get; set; }

    }
}
