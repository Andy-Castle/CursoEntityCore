﻿// <auto-generated />
using System;
using CursoEntityCore.Datos;
using Microsoft.EntityFrameworkCore;
using Microsoft.EntityFrameworkCore.Infrastructure;
using Microsoft.EntityFrameworkCore.Metadata;
using Microsoft.EntityFrameworkCore.Storage.ValueConversion;

#nullable disable

namespace CursoEntityCore.Migrations
{
    [DbContext(typeof(ApplicationDbContext))]
    partial class ApplicationDbContextModelSnapshot : ModelSnapshot
    {
        protected override void BuildModel(ModelBuilder modelBuilder)
        {
#pragma warning disable 612, 618
            modelBuilder
                .HasAnnotation("ProductVersion", "9.0.0")
                .HasAnnotation("Relational:MaxIdentifierLength", 128);

            SqlServerModelBuilderExtensions.UseIdentityColumns(modelBuilder);

            modelBuilder.Entity("CursoEntityCore.Models.Articulo", b =>
                {
                    b.Property<int>("Articulo_Id")
                        .ValueGeneratedOnAdd()
                        .HasColumnType("int");

                    SqlServerPropertyBuilderExtensions.UseIdentityColumn(b.Property<int>("Articulo_Id"));

                    b.Property<double>("Calificacion")
                        .HasColumnType("float");

                    b.Property<int>("Categoria_Id")
                        .HasColumnType("int");

                    b.Property<string>("Descripcion")
                        .IsRequired()
                        .HasMaxLength(500)
                        .HasColumnType("nvarchar(500)");

                    b.Property<DateTime>("Fecha")
                        .HasColumnType("datetime2");

                    b.Property<string>("TituloArticulo")
                        .IsRequired()
                        .HasMaxLength(20)
                        .HasColumnType("nvarchar(20)")
                        .HasColumnName("Titulo");

                    b.HasKey("Articulo_Id");

                    b.HasIndex("Categoria_Id");

                    b.ToTable("Tbl_Articulo");
                });

            modelBuilder.Entity("CursoEntityCore.Models.ArticuloEtiqueta", b =>
                {
                    b.Property<int>("Etiqueta_Id")
                        .HasColumnType("int");

                    b.Property<int>("Articulo_Id")
                        .HasColumnType("int");

                    b.HasKey("Etiqueta_Id", "Articulo_Id");

                    b.HasIndex("Articulo_Id");

                    b.ToTable("ArticuloEtiqueta");
                });

            modelBuilder.Entity("CursoEntityCore.Models.Categoria", b =>
                {
                    b.Property<int>("Categoria_Id")
                        .ValueGeneratedOnAdd()
                        .HasColumnType("int");

                    SqlServerPropertyBuilderExtensions.UseIdentityColumn(b.Property<int>("Categoria_Id"));

                    b.Property<bool>("Activo")
                        .HasColumnType("bit");

                    b.Property<DateTime>("FechaCreacion")
                        .HasColumnType("datetime2");

                    b.Property<string>("Nombre")
                        .IsRequired()
                        .HasColumnType("nvarchar(max)");

                    b.HasKey("Categoria_Id");

                    b.ToTable("Categoria");

                    b.HasData(
                        new
                        {
                            Categoria_Id = 34,
                            Activo = false,
                            FechaCreacion = new DateTime(2024, 12, 29, 0, 0, 0, 0, DateTimeKind.Unspecified),
                            Nombre = "Categoria 6"
                        });
                });

            modelBuilder.Entity("CursoEntityCore.Models.DetalleUsuario", b =>
                {
                    b.Property<int>("DetalleUsuario_Id")
                        .ValueGeneratedOnAdd()
                        .HasColumnType("int");

                    SqlServerPropertyBuilderExtensions.UseIdentityColumn(b.Property<int>("DetalleUsuario_Id"));

                    b.Property<string>("Cedula")
                        .IsRequired()
                        .HasColumnType("nvarchar(max)");

                    b.Property<string>("Deporte")
                        .HasColumnType("nvarchar(max)");

                    b.Property<string>("Mascota")
                        .HasColumnType("nvarchar(max)");

                    b.HasKey("DetalleUsuario_Id");

                    b.ToTable("DetalleUsuario");
                });

            modelBuilder.Entity("CursoEntityCore.Models.Etiqueta", b =>
                {
                    b.Property<int>("Etiqueta_Id")
                        .ValueGeneratedOnAdd()
                        .HasColumnType("int");

                    SqlServerPropertyBuilderExtensions.UseIdentityColumn(b.Property<int>("Etiqueta_Id"));

                    b.Property<DateTime>("Fecha")
                        .HasColumnType("datetime2");

                    b.Property<string>("Titulo")
                        .HasColumnType("nvarchar(max)");

                    b.HasKey("Etiqueta_Id");

                    b.ToTable("Etiqueta");
                });

            modelBuilder.Entity("CursoEntityCore.Models.Usuario", b =>
                {
                    b.Property<int>("Id")
                        .ValueGeneratedOnAdd()
                        .HasColumnType("int");

                    SqlServerPropertyBuilderExtensions.UseIdentityColumn(b.Property<int>("Id"));

                    b.Property<int>("DetalleUsuario_Id")
                        .HasColumnType("int");

                    b.Property<string>("Direccion")
                        .HasColumnType("nvarchar(max)");

                    b.Property<string>("Email")
                        .HasColumnType("nvarchar(max)");

                    b.Property<string>("NombreUsuario")
                        .HasColumnType("nvarchar(max)");

                    b.HasKey("Id");

                    b.HasIndex("DetalleUsuario_Id")
                        .IsUnique();

                    b.ToTable("Usuario");
                });

            modelBuilder.Entity("CursoEntityCore.Models.Articulo", b =>
                {
                    b.HasOne("CursoEntityCore.Models.Categoria", "Categoria")
                        .WithMany("Articulo")
                        .HasForeignKey("Categoria_Id")
                        .OnDelete(DeleteBehavior.Cascade)
                        .IsRequired();

                    b.Navigation("Categoria");
                });

            modelBuilder.Entity("CursoEntityCore.Models.ArticuloEtiqueta", b =>
                {
                    b.HasOne("CursoEntityCore.Models.Articulo", "Articulo")
                        .WithMany("articuloEtiqueta")
                        .HasForeignKey("Articulo_Id")
                        .OnDelete(DeleteBehavior.Cascade)
                        .IsRequired();

                    b.HasOne("CursoEntityCore.Models.Etiqueta", "Etiqueta")
                        .WithMany("articuloEtiqueta")
                        .HasForeignKey("Etiqueta_Id")
                        .OnDelete(DeleteBehavior.Cascade)
                        .IsRequired();

                    b.Navigation("Articulo");

                    b.Navigation("Etiqueta");
                });

            modelBuilder.Entity("CursoEntityCore.Models.Usuario", b =>
                {
                    b.HasOne("CursoEntityCore.Models.DetalleUsuario", "DetalleUsuario")
                        .WithOne("Usuario")
                        .HasForeignKey("CursoEntityCore.Models.Usuario", "DetalleUsuario_Id")
                        .OnDelete(DeleteBehavior.Cascade)
                        .IsRequired();

                    b.Navigation("DetalleUsuario");
                });

            modelBuilder.Entity("CursoEntityCore.Models.Articulo", b =>
                {
                    b.Navigation("articuloEtiqueta");
                });

            modelBuilder.Entity("CursoEntityCore.Models.Categoria", b =>
                {
                    b.Navigation("Articulo");
                });

            modelBuilder.Entity("CursoEntityCore.Models.DetalleUsuario", b =>
                {
                    b.Navigation("Usuario");
                });

            modelBuilder.Entity("CursoEntityCore.Models.Etiqueta", b =>
                {
                    b.Navigation("articuloEtiqueta");
                });
#pragma warning restore 612, 618
        }
    }
}
