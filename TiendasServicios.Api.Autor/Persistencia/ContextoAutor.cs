using Microsoft.EntityFrameworkCore;
using TiendasServicios.Api.Autor.Modelos;

namespace TiendasServicios.Api.Autor.Persistencia
{
    public class ContextoAutor : DbContext
    {
        public ContextoAutor(DbContextOptions<ContextoAutor> options) : base(options) { }
            
        public DbSet<AutorLibro> AutorLibros { get; set; }

        public DbSet<GradoAcademico> GradoAcademicos { get; set; }
    }
}
