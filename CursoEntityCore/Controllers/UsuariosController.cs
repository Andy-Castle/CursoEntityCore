using CursoEntityCore.Datos;
using CursoEntityCore.Models;
using Microsoft.AspNetCore.Mvc;
using Microsoft.EntityFrameworkCore;


namespace CursoEntityCore.Controllers
{
    public class UsuariosController : Controller
    {
        public readonly ApplicationDbContext _context;

        public UsuariosController(ApplicationDbContext context)
        {
                _context = context;
        }
        public IActionResult Index()
        {

            List<Usuario> listaUsuarios = _context.Usuario.ToList();
            return View(listaUsuarios);
        }

        [HttpGet]
        public IActionResult Crear()
        {
            return View();
        }

        [HttpPost]
        [ValidateAntiForgeryToken]
        public IActionResult Crear(Usuario usuario)
        {
            if (ModelState.IsValid)
            {
                _context.Usuario.Add(usuario);
                _context.SaveChanges();
                return RedirectToAction(nameof(Index));
            }
            return View();
        }


        [HttpGet]
        public IActionResult Editar (int? id)
        {
            if (id == null)
            {
                return View();
            }

            var usuario = _context.Usuario.FirstOrDefault(usuario => usuario.Id == id);
            return View(usuario);
        }


        [HttpPost]
        [ValidateAntiForgeryToken]
        public IActionResult Editar(Usuario usuario)
        {
            if (ModelState.IsValid)
            {
                _context.Usuario.Update(usuario);
                _context.SaveChanges();
                return RedirectToAction(nameof(Index));
            }

            return View(usuario);
        }

        [HttpGet]
        public IActionResult Borrar(int? id)
        {
            var usuario = _context.Usuario.FirstOrDefault(usuario => usuario.Id == id);
            _context.Usuario.Remove(usuario);
            _context.SaveChanges();
            return RedirectToAction(nameof(Index));
        }


        [HttpGet]
        public IActionResult Detalle(int? id)
        {
            if (id == null)
            {
                return View();
            }

            var usuario = _context.Usuario.Include(detalle => detalle.DetalleUsuario).FirstOrDefault(usuario => usuario.Id == id);
            if (usuario == null)
            {
                return NotFound();  
            }

            return View(usuario);
        }

        [HttpPost]

        public IActionResult AgregarDetalle(Usuario usuario)
        {
         
            if (usuario.DetalleUsuario.DetalleUsuario_Id == 0)
            {

                //Crear los registros de detalles
                _context.DetalleUsuario.Add(usuario.DetalleUsuario);
                _context.SaveChanges();

                //Despues de crear el detalle del usuario, se obtiene el usuario de la base de datos
                // y se actualiza el campo "DetalleUsuario_Id"
                var usuarioBd = _context.Usuario.FirstOrDefault(user => user.Id == usuario.Id);
                usuarioBd.DetalleUsuario_Id = usuario.DetalleUsuario.DetalleUsuario_Id;
                _context.SaveChanges();

          
            }

            return RedirectToAction(nameof(Index));
        }



    }
}
