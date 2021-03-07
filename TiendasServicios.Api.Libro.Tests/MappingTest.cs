using AutoMapper;
using System;
using System.Collections.Generic;
using System.Text;
using TiendasServicios.Api.Libro.Aplicacion;
using TiendasServicios.Api.Libro.Modelo;

namespace TiendasServicios.Api.Libro.Tests
{
    public class MappingTest : Profile
    {
        public MappingTest()
        {
            CreateMap<LibreriaMaterial, LibroMaterialDto>();
        }    
    }
}
