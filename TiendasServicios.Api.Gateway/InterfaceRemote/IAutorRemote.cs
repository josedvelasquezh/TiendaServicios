using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;
using TiendasServicios.Api.Gateway.LibroRemoto;

namespace TiendasServicios.Api.Gateway.InterfaceRemote
{
    public interface IAutorRemote
    {
       Task<(bool resultado, AutorModeloRemote autor, string message)> GetAutor(Guid AutorId);
    }
}
