using Microsoft.Extensions.Logging;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Net.Http;
using System.Text.Json;
using System.Threading.Tasks;
using TiendasServicios.Api.CarritoCompra.ModeloRemoto;
using TiendasServicios.Api.CarritoCompra.RemoteInterface;

namespace TiendasServicios.Api.CarritoCompra.RemoteService
{
    public class LibrosService : ILibrosService
    {
        private readonly IHttpClientFactory _httpClient;
        private readonly ILogger<LibrosService> _logger;

        public LibrosService(IHttpClientFactory httpClient, ILogger<LibrosService> logger)
        {
            _httpClient = httpClient;
            _logger = logger;
        }

        public async Task<(bool resultado, LibroRemoto libro, string errorMessage)> GetLibro(Guid LibroId)
        {
            try
            {
                //Declarado en StartUp
                var cliente = _httpClient.CreateClient("Libros");

                var response = await cliente.GetAsync($"api/LibroMaterial/{LibroId}");

                if (response.IsSuccessStatusCode)
                {
                    var contenido = await response.Content.ReadAsStringAsync();
                    var options = new JsonSerializerOptions()
                    {
                        PropertyNameCaseInsensitive = true //No de problemas con mayusculas y minusculas
                    };
                    var resultado = JsonSerializer.Deserialize<LibroRemoto>(contenido, options);
                    return (true, resultado, null);
                }

                return (false, null, response.ReasonPhrase);
            }
            catch (Exception ex)
            {
                _logger?.LogError(ex.ToString());
                return (false, null, ex.Message);
            }
        }
    }
}
