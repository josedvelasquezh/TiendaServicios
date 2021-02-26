using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;

namespace TiendasServicios.Api.Autor.Modelos
{
    public class AutorLibro
    {
        public int AutorLibroId { get; set; }
        public String Nombre { get; set; }
        public String Apellido { get; set; }
        public DateTime? FechaNacimiento { get; set; }
        public ICollection<GradoAcademico> ListaGradoAcademico { get; set; }
        public string AutorLibroGuid { get; set; }
    }
}
