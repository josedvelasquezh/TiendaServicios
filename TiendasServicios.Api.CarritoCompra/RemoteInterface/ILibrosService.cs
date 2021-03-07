using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;
using TiendasServicios.Api.CarritoCompra.ModeloRemoto;

namespace TiendasServicios.Api.CarritoCompra.RemoteInterface
{
    public interface ILibrosService
    {
        Task<(bool resultado, LibroRemoto libro, string errorMessage)> GetLibro(Guid LibroId);
    }
}
