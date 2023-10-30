﻿// <auto-generated />
using System;
using Microsoft.EntityFrameworkCore;
using Microsoft.EntityFrameworkCore.Infrastructure;
using Microsoft.EntityFrameworkCore.Metadata;
using Microsoft.EntityFrameworkCore.Migrations;
using Microsoft.EntityFrameworkCore.Storage.ValueConversion;
using Proyecto1_Progra5.Data;

#nullable disable

namespace Proyecto1_Progra5.Migrations
{
    [DbContext(typeof(AppDbContext))]
    [Migration("20231030222911_PruebaRelacionesDb")]
    partial class PruebaRelacionesDb
    {
        /// <inheritdoc />
        protected override void BuildTargetModel(ModelBuilder modelBuilder)
        {
#pragma warning disable 612, 618
            modelBuilder
                .HasAnnotation("ProductVersion", "7.0.12")
                .HasAnnotation("Relational:MaxIdentifierLength", 128);

            SqlServerModelBuilderExtensions.UseIdentityColumns(modelBuilder);

            modelBuilder.Entity("Proyecto1_Progra5.Models.Bitacora", b =>
                {
                    b.Property<int>("Id")
                        .ValueGeneratedOnAdd()
                        .HasColumnType("int");

                    SqlServerPropertyBuilderExtensions.UseIdentityColumn(b.Property<int>("Id"));

                    b.Property<string>("Descripcion")
                        .IsRequired()
                        .HasColumnType("nvarchar(max)");

                    b.Property<DateTime>("FechaHora")
                        .HasColumnType("datetime2");

                    b.Property<int>("UsuarioId")
                        .HasColumnType("int");

                    b.HasKey("Id");

                    b.HasIndex("UsuarioId");

                    b.ToTable("Bitacoras");
                });

            modelBuilder.Entity("Proyecto1_Progra5.Models.Carrito", b =>
                {
                    b.Property<int>("Id")
                        .ValueGeneratedOnAdd()
                        .HasColumnType("int");

                    SqlServerPropertyBuilderExtensions.UseIdentityColumn(b.Property<int>("Id"));

                    b.Property<bool>("Computador")
                        .HasColumnType("bit");

                    b.Property<int>("Estado")
                        .HasColumnType("int");

                    b.Property<bool>("Proyector")
                        .HasColumnType("bit");

                    b.Property<bool>("Realizado")
                        .HasColumnType("bit");

                    b.Property<int>("ReservaId")
                        .HasColumnType("int");

                    b.Property<int>("UsuarioId")
                        .HasColumnType("int");

                    b.HasKey("Id");

                    b.HasIndex("ReservaId");

                    b.HasIndex("UsuarioId");

                    b.ToTable("Carritos");
                });

            modelBuilder.Entity("Proyecto1_Progra5.Models.ElementosCarrito", b =>
                {
                    b.Property<int>("Id")
                        .ValueGeneratedOnAdd()
                        .HasColumnType("int");

                    SqlServerPropertyBuilderExtensions.UseIdentityColumn(b.Property<int>("Id"));

                    b.Property<int>("Cantidad")
                        .HasColumnType("int");

                    b.Property<int>("CarritoId")
                        .HasColumnType("int");

                    b.Property<int>("ProductosId")
                        .HasColumnType("int");

                    b.Property<int>("SubTotal")
                        .HasColumnType("int");

                    b.HasKey("Id");

                    b.HasIndex("CarritoId");

                    b.HasIndex("ProductosId");

                    b.ToTable("ElementosCarritos");
                });

            modelBuilder.Entity("Proyecto1_Progra5.Models.Producto", b =>
                {
                    b.Property<int>("Id")
                        .ValueGeneratedOnAdd()
                        .HasColumnType("int");

                    SqlServerPropertyBuilderExtensions.UseIdentityColumn(b.Property<int>("Id"));

                    b.Property<string>("Descripcion")
                        .IsRequired()
                        .HasColumnType("nvarchar(max)");

                    b.Property<string>("Foto")
                        .IsRequired()
                        .HasColumnType("nvarchar(max)");

                    b.Property<string>("Nombre")
                        .IsRequired()
                        .HasColumnType("nvarchar(max)");

                    b.Property<float>("Precio")
                        .HasColumnType("real");

                    b.HasKey("Id");

                    b.ToTable("Productos");
                });

            modelBuilder.Entity("Proyecto1_Progra5.Models.Reserva", b =>
                {
                    b.Property<int>("Id")
                        .ValueGeneratedOnAdd()
                        .HasColumnType("int");

                    SqlServerPropertyBuilderExtensions.UseIdentityColumn(b.Property<int>("Id"));

                    b.Property<DateTime>("FechaFinalPago")
                        .HasColumnType("datetime2");

                    b.Property<DateTime>("FechaReserva")
                        .HasColumnType("datetime2");

                    b.Property<float>("Monto")
                        .HasColumnType("real");

                    b.Property<int>("UsuarioId")
                        .HasColumnType("int");

                    b.HasKey("Id");

                    b.HasIndex("UsuarioId");

                    b.ToTable("Reservas");
                });

            modelBuilder.Entity("Proyecto1_Progra5.Models.Rol", b =>
                {
                    b.Property<int>("Id")
                        .ValueGeneratedOnAdd()
                        .HasColumnType("int");

                    SqlServerPropertyBuilderExtensions.UseIdentityColumn(b.Property<int>("Id"));

                    b.Property<string>("Nombre")
                        .IsRequired()
                        .HasColumnType("nvarchar(max)");

                    b.HasKey("Id");

                    b.ToTable("Roles");
                });

            modelBuilder.Entity("Proyecto1_Progra5.Models.TipoProducto", b =>
                {
                    b.Property<int>("Id")
                        .ValueGeneratedOnAdd()
                        .HasColumnType("int");

                    SqlServerPropertyBuilderExtensions.UseIdentityColumn(b.Property<int>("Id"));

                    b.Property<string>("Nombre")
                        .IsRequired()
                        .HasColumnType("nvarchar(max)");

                    b.HasKey("Id");

                    b.ToTable("TiposProducto");
                });

            modelBuilder.Entity("Proyecto1_Progra5.Models.Usuario", b =>
                {
                    b.Property<int>("Id")
                        .ValueGeneratedOnAdd()
                        .HasColumnType("int");

                    SqlServerPropertyBuilderExtensions.UseIdentityColumn(b.Property<int>("Id"));

                    b.Property<string>("Clave")
                        .IsRequired()
                        .HasColumnType("nvarchar(max)");

                    b.Property<string>("Correo")
                        .IsRequired()
                        .HasColumnType("nvarchar(max)");

                    b.Property<string>("NombreCompleto")
                        .IsRequired()
                        .HasColumnType("nvarchar(max)");

                    b.Property<int>("RolId")
                        .HasColumnType("int");

                    b.Property<string>("Telefono")
                        .IsRequired()
                        .HasColumnType("nvarchar(max)");

                    b.HasKey("Id");

                    b.HasIndex("RolId");

                    b.ToTable("Usuarios");
                });

            modelBuilder.Entity("Proyecto1_Progra5.Models.Bitacora", b =>
                {
                    b.HasOne("Proyecto1_Progra5.Models.Usuario", "Usuario")
                        .WithMany("Bitacoras")
                        .HasForeignKey("UsuarioId")
                        .OnDelete(DeleteBehavior.Cascade)
                        .IsRequired();

                    b.Navigation("Usuario");
                });

            modelBuilder.Entity("Proyecto1_Progra5.Models.Carrito", b =>
                {
                    b.HasOne("Proyecto1_Progra5.Models.Reserva", "Reserva")
                        .WithMany()
                        .HasForeignKey("ReservaId")
                        .OnDelete(DeleteBehavior.Cascade)
                        .IsRequired();

                    b.HasOne("Proyecto1_Progra5.Models.Usuario", "Usuario")
                        .WithMany("Carrito")
                        .HasForeignKey("UsuarioId")
                        .OnDelete(DeleteBehavior.Cascade)
                        .IsRequired();

                    b.Navigation("Reserva");

                    b.Navigation("Usuario");
                });

            modelBuilder.Entity("Proyecto1_Progra5.Models.ElementosCarrito", b =>
                {
                    b.HasOne("Proyecto1_Progra5.Models.Carrito", "Carrito")
                        .WithMany("ElementosCarrito")
                        .HasForeignKey("CarritoId")
                        .OnDelete(DeleteBehavior.Cascade)
                        .IsRequired();

                    b.HasOne("Proyecto1_Progra5.Models.Producto", "Productos")
                        .WithMany("ElementosCarrito")
                        .HasForeignKey("ProductosId")
                        .OnDelete(DeleteBehavior.Cascade)
                        .IsRequired();

                    b.Navigation("Carrito");

                    b.Navigation("Productos");
                });

            modelBuilder.Entity("Proyecto1_Progra5.Models.Reserva", b =>
                {
                    b.HasOne("Proyecto1_Progra5.Models.Usuario", "Usuario")
                        .WithMany("Reservas")
                        .HasForeignKey("UsuarioId")
                        .OnDelete(DeleteBehavior.Cascade)
                        .IsRequired();

                    b.Navigation("Usuario");
                });

            modelBuilder.Entity("Proyecto1_Progra5.Models.Usuario", b =>
                {
                    b.HasOne("Proyecto1_Progra5.Models.Rol", "Rol")
                        .WithMany("Usuarios")
                        .HasForeignKey("RolId")
                        .OnDelete(DeleteBehavior.Cascade)
                        .IsRequired();

                    b.Navigation("Rol");
                });

            modelBuilder.Entity("Proyecto1_Progra5.Models.Carrito", b =>
                {
                    b.Navigation("ElementosCarrito");
                });

            modelBuilder.Entity("Proyecto1_Progra5.Models.Producto", b =>
                {
                    b.Navigation("ElementosCarrito");
                });

            modelBuilder.Entity("Proyecto1_Progra5.Models.Rol", b =>
                {
                    b.Navigation("Usuarios");
                });

            modelBuilder.Entity("Proyecto1_Progra5.Models.Usuario", b =>
                {
                    b.Navigation("Bitacoras");

                    b.Navigation("Carrito");

                    b.Navigation("Reservas");
                });
#pragma warning restore 612, 618
        }
    }
}