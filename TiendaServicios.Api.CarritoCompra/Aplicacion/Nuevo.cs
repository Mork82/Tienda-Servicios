using MediatR;
using System;
using System.Collections.Generic;
using System.Threading;
using System.Threading.Tasks;
using TiendaServicios.Api.CarritoCompra.Modelo;
using TiendaServicios.Api.CarritoCompra.Persistencia;

namespace TiendaServicios.Api.CarritoCompra.Aplicacion
{
    public class Nuevo
    {
        public class Ejecuta : IRequest
        {
            public DateTime fechaCreacionSesion { get; set; }

            public List<String> productoLista { get; set; }
        }

        public class Manejador : IRequestHandler<Ejecuta>
        {
            private readonly CarritoContext _context;

            public Manejador(CarritoContext context)
            {
                _context = context;
            }

            public async Task<Unit> Handle(Ejecuta request, CancellationToken cancellationToken)
            {
                var carritosesion = new CarritoSesion
                {
                    fechaCreacion = request.fechaCreacionSesion,

                };
                _context.carritoSesion.Add(carritosesion);
                var value = await _context.SaveChangesAsync();


                if (value == 0)
                {

                    throw new Exception("No se puedo insertar");
                }

                int id = carritosesion.carritoSesionId;

                foreach (var obj in request.productoLista)
                {
                    var detalleSesion = new CarritoSesionDetalle
                    {
                        fechaCreacion = DateTime.Now,
                        carritoSesionId = id,
                        productoSeleccionado = obj
                    };

                    _context.carritoSesionDetalle.Add(detalleSesion);
                }
                value = await _context.SaveChangesAsync();

                if (value > 0)
                {
                    return Unit.Value;
                }
                throw new Exception("No se pudo insetar el detalle del carrito de compra");
            }
        }
    }

}

