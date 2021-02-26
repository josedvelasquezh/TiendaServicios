using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;

namespace TiendasServicios.Api.Autor.Modelos
{
    public class GradoAcademico
    {
        public int GradoAcademicoId { get; set; }
        public String Nombre { get; set; }
        public String CentroAcademico { get; set; }
        public DateTime? FechaGrado { get; set; }
        public int AutorLibroId { get; set; }
        public AutorLibro AutorLibro { get; set; }
        public string GradoAcademicoGuid { get; set; }
    }
}
