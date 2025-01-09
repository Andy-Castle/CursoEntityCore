using CursoEntityCore.Models;
using Microsoft.AspNetCore.Mvc.Rendering;

namespace CursoEntityCore.ViewModels
{
    /*
     Aqui se creo una clase en la cual queremos obtener las Categorias_Id
    y el Nombre de estas para poder mostrarlas en el front
     */
    public class ArticuloCategoriaVM
    {
        public Articulo Articulo { get; set; }
        public IEnumerable<SelectListItem> ListaCategorias { get; set; }
    }
}
