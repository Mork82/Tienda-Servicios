﻿using AutoMapper;
using MediatR;
using Microsoft.EntityFrameworkCore;
using System;
using System.Linq;
using System.Threading;
using System.Threading.Tasks;
using TiendaServicios.Api.Libro.Modelo;
using TiendaServicios.Api.Libro.Persitencia;

namespace TiendaServicios.Api.Libro.Aplicacion
{
    public class ConsultaFiltro
    {

        public class LibroUnico : IRequest<LibreriaMaterialDTO>
        {
            public Guid? LibroId { get; set; }
        }

        public class Manejador : IRequestHandler<LibroUnico, LibreriaMaterialDTO> { 

            private readonly ContextoLibreria _contexto;
            private readonly IMapper _mapper;

            public Manejador(ContextoLibreria contexto, IMapper mapper)
            {
                _contexto = contexto;
                _mapper = mapper;
            }
        
            public async Task<LibreriaMaterialDTO> Handle(LibroUnico request, CancellationToken cancellationToken)
        {
                var libro = await _contexto.LibreriaMaterial.Where(x => x.LibreriaMaterialId == request.LibroId).FirstOrDefaultAsync();

                if (libro == null)
                {
                    throw new Exception("No se ha encontrado el libro ");
                }

                var libroDto = _mapper.Map<LibreriaMaterial, LibreriaMaterialDTO>(libro);


                return libroDto;
        }
    }
}
}
