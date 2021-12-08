﻿// <auto-generated />
using System;
using Microsoft.EntityFrameworkCore;
using Microsoft.EntityFrameworkCore.Infrastructure;
using Microsoft.EntityFrameworkCore.Storage.ValueConversion;
using Npgsql.EntityFrameworkCore.PostgreSQL.Metadata;
using TiendaServicios.Api.CarritoCompra.Persistencia;

namespace TiendaServicios.Api.CarritoCompra.Migrations
{
    [DbContext(typeof(CarritoContext))]
    partial class CarritoContextModelSnapshot : ModelSnapshot
    {
        protected override void BuildModel(ModelBuilder modelBuilder)
        {
#pragma warning disable 612, 618
            modelBuilder
                .HasAnnotation("Npgsql:ValueGenerationStrategy", NpgsqlValueGenerationStrategy.IdentityByDefaultColumn)
                .HasAnnotation("ProductVersion", "3.1.20")
                .HasAnnotation("Relational:MaxIdentifierLength", 63);

            modelBuilder.Entity("TiendaServicios.Api.CarritoCompra.Modelo.CarritoSesion", b =>
                {
                    b.Property<int>("carritoSesionId")
                        .ValueGeneratedOnAdd()
                        .HasColumnType("integer")
                        .HasAnnotation("Npgsql:ValueGenerationStrategy", NpgsqlValueGenerationStrategy.IdentityByDefaultColumn);

                    b.Property<DateTime?>("fechaCreacion")
                        .HasColumnType("timestamp without time zone");

                    b.HasKey("carritoSesionId");

                    b.ToTable("carritoSesion");
                });

            modelBuilder.Entity("TiendaServicios.Api.CarritoCompra.Modelo.CarritoSesionDetalle", b =>
                {
                    b.Property<int>("carritoSesionDetalleId")
                        .ValueGeneratedOnAdd()
                        .HasColumnType("integer")
                        .HasAnnotation("Npgsql:ValueGenerationStrategy", NpgsqlValueGenerationStrategy.IdentityByDefaultColumn);

                    b.Property<int>("carritoSesionId")
                        .HasColumnType("integer");

                    b.Property<DateTime?>("fechaCreacion")
                        .HasColumnType("timestamp without time zone");

                    b.Property<string>("productoSeleccionado")
                        .HasColumnType("text");

                    b.HasKey("carritoSesionDetalleId");

                    b.HasIndex("carritoSesionId");

                    b.ToTable("carritoSesionDetalle");
                });

            modelBuilder.Entity("TiendaServicios.Api.CarritoCompra.Modelo.CarritoSesionDetalle", b =>
                {
                    b.HasOne("TiendaServicios.Api.CarritoCompra.Modelo.CarritoSesion", "carritoSesion")
                        .WithMany("listaDetalle")
                        .HasForeignKey("carritoSesionId")
                        .OnDelete(DeleteBehavior.Cascade)
                        .IsRequired();
                });
#pragma warning restore 612, 618
        }
    }
}