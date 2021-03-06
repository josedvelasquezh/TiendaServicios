using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading;
using System.Threading.Tasks;
using MediatR;
using TiendasServicios.Api.Autor.Modelos;
using TiendasServicios.Api.Autor.Persistencia;
using Microsoft.EntityFrameworkCore;
using AutoMapper;

namespace TiendasServicios.Api.Autor.Aplicacion
{
    public class ConsultaFiltro
    {
        public class AutorUnico : IRequest<AutorDto>
        {
            public String AutorGuid { get; set; }
        }

        public class Manejador : IRequestHandler<AutorUnico, AutorDto>
        {
            private const string Message = "No se encontro autor";
            private readonly ContextoAutor _contexto;
            private readonly IMapper _mapper;

            public Manejador(ContextoAutor contexto, IMapper mapper)
            {
                _contexto = contexto;
                _mapper = mapper;
            }

            public async Task<AutorDto> Handle(AutorUnico request, CancellationToken cancellationToken)
            {
                var autor = await _contexto.AutorLibros.Where(k => k.AutorLibroGuid == request.AutorGuid).FirstOrDefaultAsync();

                if (autor == null)
                    throw new Exception(Message);

                var autorDto = _mapper.Map<AutorLibro, AutorDto>(autor);

                return autorDto;
            }
        }
    }
}
