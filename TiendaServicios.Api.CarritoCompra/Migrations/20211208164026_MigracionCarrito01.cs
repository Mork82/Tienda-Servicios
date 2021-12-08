using System;
using Microsoft.EntityFrameworkCore.Migrations;
using Npgsql.EntityFrameworkCore.PostgreSQL.Metadata;

namespace TiendaServicios.Api.CarritoCompra.Migrations
{
    public partial class MigracionCarrito01 : Migration
    {
        protected override void Up(MigrationBuilder migrationBuilder)
        {
            migrationBuilder.CreateTable(
                name: "carritoSesion",
                columns: table => new
                {
                    carritoSesionId = table.Column<int>(nullable: false)
                        .Annotation("Npgsql:ValueGenerationStrategy", NpgsqlValueGenerationStrategy.IdentityByDefaultColumn),
                    fechaCreacion = table.Column<DateTime>(nullable: true)
                },
                constraints: table =>
                {
                    table.PrimaryKey("PK_carritoSesion", x => x.carritoSesionId);
                });

            migrationBuilder.CreateTable(
                name: "carritoSesionDetalle",
                columns: table => new
                {
                    carritoSesionDetalleId = table.Column<int>(nullable: false)
                        .Annotation("Npgsql:ValueGenerationStrategy", NpgsqlValueGenerationStrategy.IdentityByDefaultColumn),
                    fechaCreacion = table.Column<DateTime>(nullable: true),
                    productoSeleccionado = table.Column<string>(nullable: true),
                    carritoSesionId = table.Column<int>(nullable: false)
                },
                constraints: table =>
                {
                    table.PrimaryKey("PK_carritoSesionDetalle", x => x.carritoSesionDetalleId);
                    table.ForeignKey(
                        name: "FK_carritoSesionDetalle_carritoSesion_carritoSesionId",
                        column: x => x.carritoSesionId,
                        principalTable: "carritoSesion",
                        principalColumn: "carritoSesionId",
                        onDelete: ReferentialAction.Cascade);
                });

            migrationBuilder.CreateIndex(
                name: "IX_carritoSesionDetalle_carritoSesionId",
                table: "carritoSesionDetalle",
                column: "carritoSesionId");
        }

        protected override void Down(MigrationBuilder migrationBuilder)
        {
            migrationBuilder.DropTable(
                name: "carritoSesionDetalle");

            migrationBuilder.DropTable(
                name: "carritoSesion");
        }
    }
}
