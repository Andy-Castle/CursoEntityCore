﻿// <auto-generated />
using System;
using CursoEntityCore.Datos;
using Microsoft.EntityFrameworkCore;
using Microsoft.EntityFrameworkCore.Infrastructure;
using Microsoft.EntityFrameworkCore.Metadata;
using Microsoft.EntityFrameworkCore.Migrations;
using Microsoft.EntityFrameworkCore.Storage.ValueConversion;

#nullable disable

namespace CursoEntityCore.Migrations
{
    [DbContext(typeof(ApplicationDbContext))]
    [Migration("20250107215220_RelacionUnoAunoUsuarioDetalleUsuarioDB")]
    partial class RelacionUnoAunoUsuarioDetalleUsuarioDB
    {
        /// <inheritdoc />
        protected override void BuildTargetModel(ModelBuilder modelBuilder)
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

            modelBuilder.Entity("CursoEntityCore.Models.Categoria", b =>
                {
                    b.Property<int>("Categoria_Id")
                        .ValueGeneratedOnAdd()
                        .HasColumnType("int");

                    SqlServerPropertyBuilderExtensions.UseIdentityColumn(b.Property<int>("Categoria_Id"));

                    b.Property<string>("Nombre")
                        .IsRequired()
                        .HasColumnType("nvarchar(max)");

                    b.HasKey("Categoria_Id");

                    b.ToTable("Categoria");
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
                        .IsRequired()
                        .HasColumnType("nvarchar(max)");

                    b.Property<string>("Mascota")
                        .IsRequired()
                        .HasColumnType("nvarchar(max)");

                    b.HasKey("DetalleUsuario_Id");

                    b.ToTable("DetalleUsuario");
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
                        .IsRequired()
                        .HasColumnType("nvarchar(max)");

                    b.Property<string>("Email")
                        .IsRequired()
                        .HasColumnType("nvarchar(max)");

                    b.Property<string>("NombreUsuario")
                        .IsRequired()
                        .HasColumnType("nvarchar(max)");

                    b.HasKey("Id");

                    b.HasIndex("DetalleUsuario_Id")
                        .IsUnique();

                    b.ToTable("Usuario");
                });

            modelBuilder.Entity("CursoEntityCore.Models.Articulo", b =>
                {
                    b.HasOne("CursoEntityCore.Models.Categoria", "Categoria")
                        .WithMany()
                        .HasForeignKey("Categoria_Id")
                        .OnDelete(DeleteBehavior.Cascade)
                        .IsRequired();

                    b.Navigation("Categoria");
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

            modelBuilder.Entity("CursoEntityCore.Models.DetalleUsuario", b =>
                {
                    b.Navigation("Usuario")
                        .IsRequired();
                });
#pragma warning restore 612, 618
        }
    }
}
