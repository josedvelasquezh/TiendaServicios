using AutoMapper;
using MediatR;
using Microsoft.EntityFrameworkCore;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading;
using System.Threading.Tasks;
using TiendasServicios.Api.CarritoCompra.Modelo;
using TiendasServicios.Api.CarritoCompra.Persistencia;
using TiendasServicios.Api.CarritoCompra.RemoteInterface;

namespace TiendasServicios.Api.CarritoCompra.Aplicacion
{
    public class Consulta
    {
        public class Ejecuta : IRequest<CarritoDto>
        {
            public int CarritoSesionId { get; set; }
        }

        public class Manejador : IRequestHandler<Ejecuta, CarritoDto>
        {
            private readonly CarritoContexto _contexto;
            private readonly ILibrosService _libroService;

            public Manejador(CarritoContexto contexto, ILibrosService libroService)
            {
                _contexto = contexto;
                _libroService = libroService;
            }

            public async Task<CarritoDto> Handle(Ejecuta request, CancellationToken cancellationToken)
            {
                var carritoSesion = await _contexto.CarritoSesion.FirstOrDefaultAsync(
                    x => x.CarritoSesionId == request.CarritoSesionId
                    );

                var carritoSessionDetalle = await _contexto.CarritoSesionDetalle.Where(
                     x => x.CarritoSesionId == request.CarritoSesionId
                    ).ToListAsync();

                List<CarritoDetalleDto> listaCarritoDto = new List<CarritoDetalleDto>();

                foreach (var libro in carritoSessionDetalle)
                {
                    var response = await _libroService.GetLibro(new Guid(libro.ProductoSeleccionado));

                    if (response.resultado)
                    {
                        CarritoDetalleDto carritoDetalleDto = new CarritoDetalleDto
                        {
                            TituloLibro = response.libro.Titulo,
                            FechaPublicacion = response.libro.FechaPublicacion,
                            LibrooId = response.libro.LibreriaMaterialId
                        };

                        listaCarritoDto.Add(carritoDetalleDto);
                    }
                }

                CarritoDto carritoDto = new CarritoDto
                {
                    CarritoId = carritoSesion.CarritoSesionId,
                    FechaCreacionSesion = carritoSesion.FechaCreacion,
                    ListaProductos = listaCarritoDto
                };

                return carritoDto;
            }
        }
    }
}
