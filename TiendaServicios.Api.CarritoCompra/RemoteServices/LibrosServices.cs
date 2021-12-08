using Microsoft.Extensions.Logging;
using System;
using System.Net.Http;
using System.Threading.Tasks;
using TiendaServicios.Api.CarritoCompra.RemoteInterface;
using TiendaServicios.Api.CarritoCompra.RemoteModel;

namespace TiendaServicios.Api.CarritoCompra.RemoteServices
{
    public class LibrosServices : ILibrosService
    {
        private readonly IHttpClientFactory _httpClient;

        public readonly ILogger<LibrosServices> _logger;

        public LibrosServices(IHttpClientFactory httpClientFactory, ILogger<LibrosServices> logger)
        {
            _httpClient = httpClientFactory;
            _logger = logger;
        }

        public async Task<(bool resultado, LibroRemote libro, string errorMessage)> getLibro(Guid libroId)
        {
            try
            {
                var cliente = _httpClient.CreateClient("Libros");
               var response =  await cliente.GetAsync($"api/LibroMaterial/{libroId}");
            }
            catch (Exception e)
            {
            }
        }
    }
}
