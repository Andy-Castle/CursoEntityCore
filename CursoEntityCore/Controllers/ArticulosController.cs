using CursoEntityCore.Datos;
using CursoEntityCore.Models;
using CursoEntityCore.ViewModels;
using Microsoft.AspNetCore.Mvc;
using Microsoft.AspNetCore.Mvc.Rendering;
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
            //List<Articulo> listaArticulos = _context.Articulo.Include(articulo => articulo.Categoria).ToList();

            //foreach (var articulo in listaArticulos)
            //{
            //    //Opción2: carga manual se generan muchas consultas SQL, no es muy eficiente
            //    //si necesitamos cargar más propiedades
            //    //articulo.Categoria = _context.Categoria.FirstOrDefault(categoria => categoria.Categoria_Id == articulo.Categoria_Id);

            //    //Opción 3: (Explicit loading)
            //    //Carga explicita
            //    _context.Entry(articulo).Reference(categoria => categoria.Categoria).Load();
            //}

            //Opción 4: Carga diligente (Eager Loading)
            List<Articulo> listaArticulos = _context.Articulo.Include(categoria => categoria.Categoria).ToList();


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

        [HttpGet]
        public IActionResult AdministrarEtiquetas(int id)
        {
            // Se crea un objeto del ViewModel ArticuloEtiquetaVM para manejar datos relacionados con el artículo y sus etiquetas.
            ArticuloEtiquetaVM articuloEtiquetas = new ArticuloEtiquetaVM
            {
                // Lista de ArticuloEtiqueta (relaciones entre artículos y etiquetas) asociadas al artículo con el ID proporcionado.
                // Incluye información detallada de las etiquetas relacionadas.
                // Incluye información detallada de los artículos relacionados.
                // Filtra solo las relaciones del artículo con el ID especificado.
                ListaArticuloEtiquetas = _context.ArticuloEtiqueta.Include(etiqueta => etiqueta.Etiqueta).Include(articulo => articulo.Articulo)
                .Where(a => a.Articulo_Id == id),

                // Inicializa un nuevo objeto ArticuloEtiqueta para capturar futuras relaciones entre el artículo y etiquetas.
                ArticuloEtiqueta = new ArticuloEtiqueta()
                {
                    Articulo_Id = id
                },
                // Obtiene los detalles del artículo específico usando el ID.
                Articulo = _context.Articulo.FirstOrDefault(a => a.Articulo_Id == id)
            };

            // Obtiene una lista de IDs de etiquetas ya asociadas al artículo.
            List<int> listaTemporalEtiquetasArticulo = articuloEtiquetas.ListaArticuloEtiquetas.Select(e => e.Etiqueta_Id).ToList();

            //Obtener todas las etiquetas cuyos id's no esten en la listaTemporalEtiquetasArticulo
            //Crear un NOT In usando LINQ
            var listaTemporal = _context.Etiqueta.Where(e => !listaTemporalEtiquetasArticulo.Contains(e.Etiqueta_Id)).ToList();

            //Crear lista de etiquetas para el dropdown
            articuloEtiquetas.ListaEtiquetas = listaTemporal.Select(i => new SelectListItem 
            {
                Text = i.Titulo,
                Value = i.Etiqueta_Id.ToString()
            
            });

            return View(articuloEtiquetas);
        }


        [HttpPost]
        public IActionResult AdministrarEtiquetas (ArticuloEtiquetaVM articuloEtiquetas)
        {
            // Verifica que los IDs del artículo y la etiqueta no sean cero (asegurándose de que haya datos válidos).
            if (articuloEtiquetas.ArticuloEtiqueta.Articulo_Id != 0 && articuloEtiquetas.ArticuloEtiqueta.Etiqueta_Id != 0)
            {
                // Agrega una nueva relación entre el artículo y la etiqueta en la base de datos.
                _context.ArticuloEtiqueta.Add(articuloEtiquetas.ArticuloEtiqueta);
                _context.SaveChanges();

            }

            // Redirige al método AdministrarEtiquetas para actualizar la vista con las relaciones actualizadas.
            // Pasa como parámetro el ID del artículo actual para recargar sus datos.
            return RedirectToAction(nameof(AdministrarEtiquetas), new {@id = articuloEtiquetas.ArticuloEtiqueta.Articulo_Id});
        }


        [HttpPost]
        public IActionResult EliminarEtiquetas(int idEtiqueta,ArticuloEtiquetaVM articuloEtiquetas)
        {
            // Obtiene el ID del artículo desde el modelo recibido.
            int idArticulo = articuloEtiquetas.Articulo.Articulo_Id;
            // Busca en la base de datos la relación(ArticuloEtiqueta) que coincide con el ID de la etiqueta y el ID del artículo.
                ArticuloEtiqueta articuloEtiqueta = _context.ArticuloEtiqueta.FirstOrDefault(
                u=>u.Etiqueta_Id == idEtiqueta && u.Articulo_Id == idArticulo);

                _context.ArticuloEtiqueta.Remove(articuloEtiqueta);
                _context.SaveChanges();

            // Redirige al método AdministrarEtiquetas para actualizar la vista con las relaciones restantes.
            // Pasa como parámetro el ID del artículo actual para recargar sus datos.
            return RedirectToAction(nameof(AdministrarEtiquetas), new { @id = idArticulo });
        }

    }
}



