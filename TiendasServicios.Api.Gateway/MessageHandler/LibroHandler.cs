using Microsoft.Extensions.Logging;
using System;
using System.Collections.Generic;
using System.Diagnostics;
using System.Linq;
using System.Net.Http;
using System.Text.Json;
using System.Threading;
using System.Threading.Tasks;
using TiendasServicios.Api.Gateway.InterfaceRemote;
using TiendasServicios.Api.Gateway.LibroRemoto;

namespace TiendasServicios.Api.Gateway.MessageHandler
{
    public class LibroHandler : DelegatingHandler
    {
        private readonly ILogger<LibroHandler> _logger;

        private readonly IAutorRemote _autorRemote;
        public LibroHandler(ILogger<LibroHandler> logger, IAutorRemote  autorRemote)
        {
            _logger = logger;
            _autorRemote = autorRemote;
        }

        protected override async Task<HttpResponseMessage> SendAsync(HttpRequestMessage request, CancellationToken cancellationToken)
        {
            var tiempo = new Stopwatch();

            tiempo.Start();

            _logger.LogInformation("Inicia el Request");

            var response = await base.SendAsync(request, cancellationToken);

            if (response.IsSuccessStatusCode)
            {
                string contenido = await response.Content.ReadAsStringAsync();

                JsonSerializerOptions options = new JsonSerializerOptions{PropertyNameCaseInsensitive = true };

                LibroModeloRemoto resultado = JsonSerializer.Deserialize<LibroModeloRemoto>(contenido, options);

                var responseAutor = await _autorRemote.GetAutor(resultado.AutorLibro ?? Guid.Empty);

                if (responseAutor.resultado)
                {
                    resultado.AutorDatos = responseAutor.autor;

                    String resultadoStr = JsonSerializer.Serialize(resultado);

                    response.Content = new StringContent(resultadoStr, System.Text.Encoding.UTF8, "application/json");
                }
            }

            _logger.LogInformation($"El proceso demoro {tiempo.ElapsedMilliseconds}ms");

            return response;
        }
    }
}
