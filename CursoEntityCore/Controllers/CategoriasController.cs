using CursoEntityCore.Datos;
using CursoEntityCore.Models;
using Microsoft.AspNetCore.Mvc;
using Microsoft.EntityFrameworkCore;


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
            //Consulta inicial con todos los datos
            //List<Categoria> listaCategorias = _context.Categoria.ToList();

            //Consulta filtrando por fecha
            //DateTime fechaComparacion = new DateTime(2025, 01, 08);
            //List<Categoria> listaCategorias = _context.Categoria.Where(fecha => fecha.FechaCreacion >= fechaComparacion).OrderByDescending(fecha => fecha.FechaCreacion).ToList();

            //return View(listaCategorias);

            //Seleccionar columnas especificas
            //var categorias = _context.Categoria.Where(nombre => nombre.Nombre == "Test 5").Select(n => n).ToList();

            //List<Categoria> listaCategorias = _context.Categoria.ToList();

            //Agrupando Registros
            //var listaCategorias = _context.Categoria
            //    .GroupBy(categoria => new { categoria.Activo })
            //    .Select(categoria => new { categoria.Key, Count = categoria.Count() }).ToList();

            //Paginanción Registros: take y skip
            //List<Categoria> listaCategorias = _context.Categoria.Skip(3).Take(2).ToList();

            //Consultas SQL convencionales
            //List<Categoria> listaCategorias = _context.Categoria.FromSqlRaw("select * from Categoria where Nombre like 'Categoria%' and Activo = 1").ToList();

            //Interpolacion de string (string interpolation), para proteger nuestra aplicación
            //int id = 31;
            //var categoria = _context.Categoria.FromSqlRaw($"select * from Categoria where Categoria_Id = {id}");
            List<Categoria> listaCategorias = _context.Categoria.ToList();
            return View(listaCategorias);
        }

        [HttpGet]
        public IActionResult Crear()
        {
            return View();
        }

        [HttpPost]
        [ValidateAntiForgeryToken]
        public IActionResult Crear(Categoria categoria)
        {
            if (ModelState.IsValid)
            {
                _context.Categoria.Add(categoria);
                _context.SaveChanges();
                return RedirectToAction(nameof(Index));
            }
            return View();
        }

        [HttpGet]
        public IActionResult CrearMultipleOpcion2()
        {
            List<Categoria> categorias = new List<Categoria>();
            for (int i = 0; i < 2; i++)
            {
                categorias.Add(new Categoria { Nombre = Guid.NewGuid().ToString() });
                //_context.Categoria.Add(new Categoria { Nombre = Guid.NewGuid().ToString() });
            }
            _context.Categoria.AddRange(categorias);
            _context.SaveChanges();
            return RedirectToAction(nameof(Index));
        }

        [HttpGet]
        public IActionResult CrearMultipleOpcion5()
        {
            List<Categoria> categorias = new List<Categoria>();
            for (int i = 0; i < 5; i++)
            {
                categorias.Add(new Categoria { Nombre = Guid.NewGuid().ToString() });
                //_context.Categoria.Add(new Categoria { Nombre = Guid.NewGuid().ToString() });
            }

            _context.Categoria.AddRange(categorias);
            _context.SaveChanges();
            return RedirectToAction(nameof(Index));
        }

        [HttpGet]

        public IActionResult VistaCrearMultipleOpcionFormulario()
        {
            return View();
        }

        [HttpPost]
        [ValidateAntiForgeryToken]
        public IActionResult CrearMultipleOpcionFormulario()
        {
            string categoriasForm = Request.Form["Nombre"];
            var listaCategorias = from val in categoriasForm.Split(new[] {","}, StringSplitOptions.RemoveEmptyEntries) select (val);

            List<Categoria> categorias = new List<Categoria>();

            foreach (var categoria in listaCategorias)
            {
                categorias.Add(new Categoria 
                {
                    Nombre = categoria
                });
            }

            _context.Categoria.AddRange(categorias);
            _context.SaveChanges();
            return RedirectToAction(nameof(Index));
        }

        [HttpGet]
        public IActionResult Editar (int? id)
        {
            if (id == null)
            {
                return View();
            }

            var categoria = _context.Categoria.FirstOrDefault(categoria => categoria.Categoria_Id == id);
            return View(categoria);
        }


        [HttpPost]
        [ValidateAntiForgeryToken]
        public IActionResult Editar(Categoria categoria)
        {
            if (ModelState.IsValid)
            {
                _context.Categoria.Update(categoria);
                _context.SaveChanges();
                return RedirectToAction(nameof(Index));
            }

            return View(categoria);
        }

        [HttpGet]
        public IActionResult Borrar(int? id)
        {
            var categoria = _context.Categoria.FirstOrDefault(categoria => categoria.Categoria_Id == id);
            _context.Categoria.Remove(categoria);
            _context.SaveChanges();
            return RedirectToAction(nameof(Index));
        }

        [HttpGet]
        public IActionResult BorrarMultiple2()
        {
            IEnumerable<Categoria> categorias = _context.Categoria.OrderByDescending(categoria => categoria.Categoria_Id).Take(2);
            _context.Categoria.RemoveRange(categorias);
            _context.SaveChanges();
            return RedirectToAction(nameof(Index));
        }

        [HttpGet]
        public IActionResult BorrarMultiple5()
        {
            IEnumerable<Categoria> categorias = _context.Categoria.OrderByDescending(categoria => categoria.Categoria_Id).Take(5);
            _context.Categoria.RemoveRange(categorias);
            _context.SaveChanges();
            return RedirectToAction(nameof(Index));
        }

        //Ejecución diferida
        /* Las consultas de EF Core no se ejecutan cuando son creadas. Se 
         * ejecutan segun los siguientes escenarios
         * Más información: https://learn.microsoft.com/es-es/dotnet/standard/linq/deferred-execution-lazy-evaluation
         */
        [HttpGet]
        public void EjecucionDiferida()
        {
            //1-Cuando se hace una iteración sobre ellos Ejemplo:
            //1 - Iteración diferida:
            var categorias = _context.Categoria; // Aquí se define la consulta, pero no se ejecuta todavía.

            foreach (var categoria in categorias)  // La ejecución de la consulta ocurre en este punto.
            {
                var nombreCat = "";
                nombreCat = categoria.Nombre; // Accede al nombre de cada categoría.
            }

            /*
             * Cuando se define var categorias = _context.Categoria, no se ejecuta la consulta inmediatamente.
                La ejecución ocurre cuando se inicia el foreach, ya que es aquí donde se necesitan los datos.

                Es eficiente porque se ejecuta solo cuando los datos se requieren.
             */

            //2-Cuando se llama a cualquiera de los métodos: To Dictionary, ToList, ToArray
            //Forzar ejecución con ToList()
            var categorias2 = _context.Categoria.ToList();// Se ejecuta la consulta aquí y se cargan los datos en memoria.

            foreach (var categoria in categorias2) // Se itera sobre los datos ya cargados.
            {
                var nombreCat = "";
                nombreCat = categoria.Nombre; // Accede al nombre de cada categoría.
            }

            /*
             * Cuando se llama a ToList(), la consulta se ejecuta inmediatamente y los datos se cargan en memoria.
                Al iterar sobre categorias2, ya no se consulta la base de datos porque los datos están disponibles localmente.

                La diferencia con el caso de arriba, es que los datos se obtienen de la base de datos durante la iteración.
                Aquí, todos los datos se cargan antes de iterar.
             
             */


            //3-Cuando se llama cualquier método que retorna un solo objeto:
            //First, Single, Count , Max, etc.
            //Métodos que devuelven un solo objeto
            var categorias3 = _context.Categoria; // Consulta diferida (no ejecutada aún).

            var totalCategorias2 = _context.Categoria.Count(); // Ejecuta la consulta para contar las categorías.

            var test = "";

            //Nota: Métodos como First(), Single(), Max() o Count() fuerzan la ejecución porque necesitan un resultado específico.

            /*La iteración diferida es util(1) para manejar grandes conjuntos de datos
             * sin cargar todo en memoria.
             * Y la ejecución inmediata: Métodos como ToList() o Count() fuerzan la ejecución
             * inmediatamente(2 y 3). Esto es util cuando se necesita trabajar con los datos cargados en memoria
             */
        }

        public void TestIEnumerable()
        {
            //1- Código con IEnumerable
            //IEnumerable<Categoria> - se utiliza para representar una colección de objetos

            IEnumerable<Categoria> listaCategorias = _context.Categoria;
            var categoriasActivas = listaCategorias.Where(c => c.Activo == true).ToList();
          

            //2-Consulta resultante
            /*
             * SELECT [c].[Categoria_Id], [c].[Activo], [c].[FechaCreacion], [c].[Nombre]
             * FROM [Categoria] AS[c]
             */
            //El filtro del where se aplica en memoria
        }


        public void TestIQueryable()
        {
            //1- Código con IQueryable
            //IQueryable hereda de IEnumerable
            //Todo lo que se puede hacer con IEnumerable se puede hacer con IQueryable
            IQueryable<Categoria> listaCategorias = _context.Categoria;
            var categoriasActivas = listaCategorias.Where(c => c.Activo == true).ToList();
            //Consulta resultante
            /*
             * SELECT [c].[Categoria_Id], [c].[Activo], [c].[FechaCreacion], [c].[Nombre]
               FROM [Categoria] AS [c]
               WHERE [c].[Activo] = CAST(1 AS bit)
             */
        }
        
        [HttpGet]
        public IActionResult CategoriasActivas()
        {  
            IQueryable<Categoria> listaCategoriasActivas = _context.Categoria;
            var categoriasActivas = listaCategoriasActivas.Where(c => c.Activo == true).ToList();

            return View("Index", categoriasActivas);
        }

        public void TestUpdate()
        {
            //Código 
            // Obtiene el usuario con ID 2, incluyendo su relación con 'DetalleUsuario'
            var datoUsuario = _context.Usuario.Include(u => u.DetalleUsuario).FirstOrDefault(d => d.Id == 2); // Carga los detalles relacionados y encuentra el primer usuario cuyo Id sea 2
            // Cambia el valor de la propiedad 'Deporte' en 'DetalleUsuario' asociado al usuario encontrado
            datoUsuario.DetalleUsuario.Deporte = "Natación";
            _context.Update(datoUsuario);
            _context.SaveChanges();
        }

        //public void TestAttach()
        //{
        //    //Código 
        //    var datoUsuario = _context.Usuario.Include(u => u.DetalleUsuario).FirstOrDefault(d => d.Id == 2);
        //    datoUsuario.DetalleUsuario.Deporte = "Ciclismo";
        //    _context.Attach(datoUsuario);
        //    _context.SaveChanges();
        //}



    }
}
