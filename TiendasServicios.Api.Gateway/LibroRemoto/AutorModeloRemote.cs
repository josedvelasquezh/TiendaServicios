using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;

namespace TiendasServicios.Api.Gateway.LibroRemoto
{
    public class AutorModeloRemote
    {
        public String Nombre { get; set; }
        public String Apellido { get; set; }
        public DateTime? FechaNacimiento { get; set; }
        public string AutorLibroGuid { get; set; }
    }
}
