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
            
            //Opcioón 1 sin datos relacionado (solo trae el ID de la categoría)

            //Carga Ansiosa, debemos especificar que se deben de cargar entidades relacionadas con .Include
            List<Articulo> listaArticulos = _context.Articulo.Include(articulo => articulo.Categoria).ToList();

            foreach (var articulo in listaArticulos)
            {
                //Opción2: carga manual se generan muchas consultas SQL, no es muy eficiente
                //si necesitamos cargar más propiedades
                //articulo.Categoria = _context.Categoria.FirstOrDefault(categoria => categoria.Categoria_Id == articulo.Categoria_Id);

                //Opción 3: (Explicit loading)
                //Carga explicita
                _context.Entry(articulo).Reference(categoria => categoria.Categoria).Load();
            }



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

       
            ArticuloCategoriaVM articuloCategorias = new ArticuloCategoriaVM();
            articuloCategorias.ListaCategorias = _context.Categoria.Select(i => new Microsoft.AspNetCore.Mvc.Rendering.SelectListItem
            {
                Text = i.Nombre,
                Value = i.Categoria_Id.ToString()
            });


            return View(articuloCategorias);
        }


        [HttpGet]
        public IActionResult Editar(int? id)
        {
            if (id == null)
            {
                return View();
            }

            //Aqui creamos la instancia
            ArticuloCategoriaVM articuloCategorias = new ArticuloCategoriaVM();

            //Aqui de articulosCategorias seleccionamos el Nombre de la cateogira y su Id lo pasamos a string
            articuloCategorias.ListaCategorias = _context.Categoria.Select(i => new Microsoft.AspNetCore.Mvc.Rendering.SelectListItem
            {
                Text = i.Nombre,
                Value = i.Categoria_Id.ToString()
            });

            articuloCategorias.Articulo = _context.Articulo.FirstOrDefault(articulo => articulo.Articulo_Id == id);

            if (articuloCategorias == null)
            {
                return NotFound();
            }

            return View(articuloCategorias);
        }

        [HttpPost]
        [ValidateAntiForgeryToken]
        public IActionResult Editar(ArticuloCategoriaVM articuloVM)
        {
            if (articuloVM.Articulo.Articulo_Id == 0)
            {
                return View(articuloVM.Articulo);
            }
            else 
            {
                _context.Articulo.Update(articuloVM.Articulo);
                _context.SaveChanges();
                return RedirectToAction(nameof(Index));
            }
        }

        [HttpGet]
        public IActionResult Borrar(int? id)
        {
            var articulo = _context.Articulo.FirstOrDefault(articulo => articulo.Articulo_Id == id);
            _context.Articulo.Remove(articulo);
            _context.SaveChanges();
            return RedirectToAction(nameof(Index));
        }
    }
}


