﻿using CursoEntityCore.Models;
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

        //Agregamos dbset para la tabla de relación ArticuloEtiqueta
        public DbSet<ArticuloEtiqueta> ArticuloEtiqueta { get; set; }

        //Desde vista SQL
        public DbSet<CategoriaDesdeVista> CategoriaDesdeVistas { get; set; }


        protected override void OnModelCreating(ModelBuilder modelBuilder)
        {
            //modelBuilder.Entity<ArticuloEtiqueta>().HasKey(articuloEtiqueta => new { articuloEtiqueta.Etiqueta_Id, articuloEtiqueta.Articulo_Id});

            //Siembra de datos se hace aqui
            //var categoria5 = new Categoria() { Categoria_Id = 33, Nombre = "Categoria 5", FechaCreacion = new DateTime(2024, 11, 28), Activo = true };
            //var categoria6 = new Categoria() { Categoria_Id = 34, Nombre = "Categoria 6", FechaCreacion = new DateTime(2024, 12, 29), Activo = false };

            //modelBuilder.Entity<Categoria>().HasData(new Categoria[] {  categoria6});
             
            //Fluent API para Categoria
            modelBuilder.Entity<Categoria>().HasKey(category => category.Categoria_Id); //Indicamos que es una llave primaria
            modelBuilder.Entity<Categoria>().Property(category => category.Nombre).IsRequired(); //Indicamos que la propiedad nombre es requerido
            modelBuilder.Entity<Categoria>().Property(category => category.FechaCreacion).HasColumnType("date"); // Indicamos que la la FechaCreacion es de tipo date


            //Fluent API para Articulo
            modelBuilder.Entity<Articulo>().HasKey(article => article.Articulo_Id);
            modelBuilder.Entity<Articulo>().Property(article => article.TituloArticulo).IsRequired().HasMaxLength(20);
            modelBuilder.Entity<Articulo>().Property(article => article.Descripcion).IsRequired().HasMaxLength(500);
            modelBuilder.Entity<Articulo>().Property(article => article.Fecha).HasColumnType("date");


            modelBuilder.Entity<Articulo>().ToTable("Tbl_Articulo");
            modelBuilder.Entity<Articulo>().Property(article => article.TituloArticulo).HasColumnName("Titulo");



            //Fluent API para Usuario
            modelBuilder.Entity<Usuario>().HasKey(user => user.Id);
            modelBuilder.Entity<Usuario>().Ignore(user => user.Edad);// el no mapeado 


            //Fluent API para DetalleUsuario
            modelBuilder.Entity<DetalleUsuario>().HasKey(detailsUser => detailsUser.DetalleUsuario_Id);
            modelBuilder.Entity<DetalleUsuario>().Property(detailsUser => detailsUser.Cedula).IsRequired();


            //Fluent API para Etiqueta
            modelBuilder.Entity<Etiqueta>().HasKey(tag => tag.Etiqueta_Id);
            modelBuilder.Entity<Etiqueta>().Property(tag => tag.Fecha).HasColumnType("date");

            //Fluent API: Relación Uno a Uno Usuario-DetalleUusario 
            //Usuario es la entidad padre
            modelBuilder.Entity<Usuario>().HasOne(u => u.DetalleUsuario)
                .WithOne(u => u.Usuario).HasForeignKey<Usuario>("DetalleUsuario_Id");

            //Fluent API: Relación Uno a Muchos Categoria-Articulos
            modelBuilder.Entity<Articulo>().HasOne(c => c.Categoria)
                .WithMany(c => c.Articulo).HasForeignKey(c => c.Categoria_Id);

            //Fluent API: Relación Muchos a Muchos Articulos-Etiquetas
            modelBuilder.Entity<ArticuloEtiqueta>().HasKey(ae => new { ae.Etiqueta_Id, ae.Articulo_Id });
            modelBuilder.Entity<ArticuloEtiqueta>().HasOne(a => a.Articulo).WithMany(a => a.ArticuloEtiqueta).HasForeignKey(a => a.Articulo_Id);
            modelBuilder.Entity<ArticuloEtiqueta>().HasOne(a => a.Etiqueta).WithMany(a => a.ArticuloEtiqueta).HasForeignKey(a => a.Etiqueta_Id);

            //Carga desde una vista SQL sin llave primaria
            modelBuilder.Entity<CategoriaDesdeVista>().HasNoKey().ToView("ObtenerCategorias");


            base.OnModelCreating(modelBuilder);
        }

    }
}
