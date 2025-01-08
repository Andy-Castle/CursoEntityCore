using CursoEntityCore.Datos;
using CursoEntityCore.Models;
using Microsoft.AspNetCore.Mvc;


namespace CursoEntityCore.Controllers
{
    public class CategoriasController : Controller
    {
        public readonly ApplicationDbContext _context;

        public CategoriasController(ApplicationDbContext context)
        {
                _context = context;
        }
        public IActionResult Index()
        {
            List<Categoria> listaCategorias = _context.Categoria.ToList();
            return View(listaCategorias);
        }
    }
}
