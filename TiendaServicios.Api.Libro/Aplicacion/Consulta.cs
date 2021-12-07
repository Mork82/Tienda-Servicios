using AutoMapper;
using MediatR;
using Microsoft.EntityFrameworkCore;
using System.Collections.Generic;
using System.Threading;
using System.Threading.Tasks;
using TiendaServicios.Api.Libro.Modelo;
using TiendaServicios.Api.Libro.Persitencia;

namespace TiendaServicios.Api.Libro.Aplicacion
{
    public class Consulta

    {
        public class Ejecuta : IRequest<List<LibreriaMaterialDTO>>
        {

        }

        public class Manejador : IRequestHandler<Ejecuta, List<LibreriaMaterialDTO>>
        {

            private readonly IMapper _mapper;
            private readonly ContextoLibreria _contexto;

            public Manejador(ContextoLibreria contexto, IMapper mapper)
            {
                _contexto = contexto;
                _mapper = mapper;

            }

            public async Task<List<LibreriaMaterialDTO>> Handle(Ejecuta request, CancellationToken cancellationToken)
            {
                var libros = await _contexto.LibreriaMaterial.ToListAsync();
               var librosDto = _mapper.Map<List<LibreriaMaterial>, List<LibreriaMaterialDTO>>(libros);

                return librosDto;
            }
        }

    }
}
