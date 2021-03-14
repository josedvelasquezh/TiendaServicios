using Microsoft.Extensions.Logging;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Net.Http;
using System.Text.Json;
using System.Threading.Tasks;
using TiendasServicios.Api.Gateway.InterfaceRemote;
using TiendasServicios.Api.Gateway.LibroRemoto;

namespace TiendasServicios.Api.Gateway.ImplementRemote
{
    public class AutorRemote : IAutorRemote
    {
        private readonly IHttpClientFactory _httpClient;
        private readonly ILogger<AutorRemote> _logger;

        public AutorRemote(IHttpClientFactory httpClient, ILogger<AutorRemote> logger)
        {
            _httpClient = httpClient;
            _logger = logger;
        }

        public async Task<(bool resultado, AutorModeloRemote autor, string message)> GetAutor(Guid AutorId)
        {
            try
            {
                var cliente = _httpClient.CreateClient("AutorService");

                var response = await cliente.GetAsync($"/Autor/{AutorId}");

                if (response.IsSuccessStatusCode)
                {
                    string contenido = await response.Content.ReadAsStringAsync();

                    JsonSerializerOptions options = new JsonSerializerOptions { PropertyNameCaseInsensitive = true };

                    AutorModeloRemote reultado = JsonSerializer.Deserialize<AutorModeloRemote>(contenido, options);

                    return (true, reultado, null);
                }

                return (false, null, response.ReasonPhrase);
            }
            catch (Exception ex)
            {
                _logger.LogError(ex.ToString());
                return (false, null, ex.Message);
            }
        }
    }
}
