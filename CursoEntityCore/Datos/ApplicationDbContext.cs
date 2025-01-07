using CursoEntityCore.Models;
using Microsoft.EntityFrameworkCore;

namespace CursoEntityCore.Datos
{
    public class ApplicationDbContext : DbContext
    {
        //Esto es un constructor
        //ctor --mas tab para crear el constructor
        public ApplicationDbContext(DbContextOptions<ApplicationDbContext> opciones) : base(opciones)
        {
        }

        //Escribimos los modelos
        public DbSet<Categoria> Categoria {  get; set; }




        //Cuando crear migraciones (buenas prácticas)
        //1 - Cuando se cree una nueva clase (tabla en la bd)
        //2 - Cuando agregue una nueva propiedad (crear un campo nuevo en la bd)
        //3 - Modifique un valor de campo en la clase (modificiar campo en bd) 

        public DbSet<Usuario> Usuario { get; set; }

        public DbSet<Articulo> Articulo { get; set; }

    }
}
