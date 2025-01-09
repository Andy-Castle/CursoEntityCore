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

        public DbSet<DetalleUsuario> DetalleUsuario { get; set; }

        public DbSet<Etiqueta> Etiqueta { get; set; }

        protected override void OnModelCreating(ModelBuilder modelBuilder)
        {
            modelBuilder.Entity<ArticuloEtiqueta>().HasKey(articuloEtiqueta => new { articuloEtiqueta.Etiqueta_Id, articuloEtiqueta.Articulo_Id});

            //Siembra de datos se hace aqui
            var categoria5 = new Categoria() { Categoria_Id = 33, Nombre = "Categoria 5", FechaCreacion = new DateTime(2024, 11, 28), Activo = true };
            var categoria6 = new Categoria() { Categoria_Id = 34, Nombre = "Categoria 6", FechaCreacion = new DateTime(2024, 12, 29), Activo = false };

            modelBuilder.Entity<Categoria>().HasData(new Categoria[] {  categoria6});

            base.OnModelCreating(modelBuilder);
        }



    }
}
