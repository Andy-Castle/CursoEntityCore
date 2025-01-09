using CursoEntityCore.Datos;
using CursoEntityCore.Models;
using Microsoft.AspNetCore.Mvc;

namespace CursoEntityCore.Controllers
{
    public class ArticulosController : Controller
    {

        public readonly ApplicationDbContext _context;

        public ArticulosController(ApplicationDbContext context)
        {
            _context = context;
        }


        public IActionResult Index()
        {
            List<Articulo> listaArticulos = _context.Articulo.ToList();

            return View(listaArticulos);
        }
    }
}
