using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;

namespace TiendasServicios.Api.Gateway.LibroRemoto
{
    public class LibroModeloRemoto
    {
        public Guid? LibreriaMaterialId { get; set; }
        public String Titulo { get; set; }
        public DateTime? FechaPublicacion { get; set; }
        public Guid? AutorLibro { get; set; }
        public AutorModeloRemote AutorDatos { get; set; }
    }
}
