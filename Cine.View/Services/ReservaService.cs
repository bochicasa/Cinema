using Cine.View.Services.ModelDtos;
using Microsoft.Extensions.Options;
using Newtonsoft.Json;
using System.Collections.Generic;
using System.Net.Http;
using System.Threading.Tasks;

namespace Cine.View.Services
{
    public class ReservaService : IReservaService
    {
        private readonly IOptions<AppSettings> _settings;
        private readonly HttpClient _apiClient;
        private readonly string _movieUrl;
        private readonly string _funcionesUrl;

        private readonly string _bffUrl;

        public ReservaService(HttpClient httpClient, IOptions<AppSettings> settings)
        {
            _apiClient = httpClient;
            _settings = settings;

            _funcionesUrl = $"{_settings.Value.CineApiUrl}/api/Reserva";

        }
        public async Task<List<FuncionDto>> GetFuncionesByMovie(decimal id)
        {
            string url = $"{ _funcionesUrl }/{id}";
            var json = await _apiClient.GetStringAsync(url);
            List<FuncionDto> result = JsonConvert.DeserializeObject<List<FuncionDto>>(json);

            return result;
        }

        public async Task<List<SillaLocalidadMapaDto>> GetSilaByFuncion(decimal funcionId)
        {
            string url = $"{ _funcionesUrl }/silla/{funcionId}";
            var json = await _apiClient.GetStringAsync(url);
            List<SillaLocalidadMapaDto> result = JsonConvert.DeserializeObject<List<SillaLocalidadMapaDto>>(json);

            return result;
        }

        public async Task<decimal> GetCostoByFuncion(decimal funcionId)
        {
            string url = $"{ _funcionesUrl }/costo/{funcionId}";
            var json = await _apiClient.GetStringAsync(url);
            decimal  result = JsonConvert.DeserializeObject<decimal>(json);

            return result;
        }

        public async Task<HttpResponseMessage> PostReserva(ReservaDto reserva)
        {
            HttpResponseMessage result = new HttpResponseMessage();
        string url = $"{ _funcionesUrl }/PostReserva";
            var content = Newtonsoft.Json.JsonConvert.SerializeObject((dynamic)reserva);
            result = await _apiClient.PostAsync(url, new StringContent(content, System.Text.Encoding.UTF8, "application/json"));

            return result;
        }
        public async Task<HttpResponseMessage> PostCancelReserva(ReservaDto reserva)
        {
            HttpResponseMessage result = new HttpResponseMessage();
            string url = $"{ _funcionesUrl }/PostCancelReserva";
            var content = Newtonsoft.Json.JsonConvert.SerializeObject((dynamic)reserva);
            result = await _apiClient.PostAsync(url, new StringContent(content, System.Text.Encoding.UTF8, "application/json"));

            return result;
        }
    }
}
