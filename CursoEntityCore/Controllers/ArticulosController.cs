using CursoEntityCore.Datos;
using CursoEntityCore.Models;
using CursoEntityCore.ViewModels;
using Microsoft.AspNetCore.Mvc;
using Microsoft.EntityFrameworkCore;

namespace CursoEntityCore.Controllers
{
    public class ArticulosController : Controller
    {

        public readonly ApplicationDbContext _context;

        public ArticulosController(ApplicationDbContext context)
        {
            _context = context;
        }

        [HttpGet]
        public IActionResult Index()
        {
            //Carga Ansiosa, debemos especificar que se deben de cargar entidades relacionadas con .Include
            List<Articulo> listaArticulos = _context.Articulo.Include(articulo => articulo.Categoria).ToList();

            return View(listaArticulos);
        }

        [HttpGet]
        public IActionResult Crear()
        {
            //Aqui creamos la instancia
            ArticuloCategoriaVM articuloCategorias = new ArticuloCategoriaVM();

            //Aqui de articulosCategorias seleccionamos el Nombre de la cateogira y su Id lo pasamos a string
            articuloCategorias.ListaCategorias = _context.Categoria.Select(i => new Microsoft.AspNetCore.Mvc.Rendering.SelectListItem
            {
                Text = i.Nombre,
                Value = i.Categoria_Id.ToString()
            });


            return View(articuloCategorias);
        }

        [HttpPost]
        [ValidateAntiForgeryToken]
        public IActionResult Crear(Articulo articulo)
        {
            if (ModelState.IsValid)
            {
                _context.Articulo.Add(articulo);
                _context.SaveChanges();
                return RedirectToAction(nameof(Index));
                
            }

            return View();
        }
    }
}
