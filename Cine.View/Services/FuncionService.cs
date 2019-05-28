using Cine.View.Services.ModelDtos;
using Microsoft.Extensions.Options;
using System;
using System.Collections.Generic;
using System.Net.Http;
using System.Threading.Tasks;

namespace Cine.View.Services
{
    public class FuncionService : IFuncionService
    {
        private readonly IOptions<AppSettings> _settings;
        private readonly HttpClient _apiClient;
        private readonly string _funcionesUrl;
        private readonly string _movieUrl;

        public FuncionService(HttpClient httpClient, IOptions<AppSettings> settings)
        {
            _apiClient = httpClient;
            _settings = settings;
            _funcionesUrl = $"{_settings.Value.CineApiUrl}1";
        }
        public Task<List<FuncionDto>> GetFunciones(decimal movieId)
        {
            throw new NotImplementedException();
        }
    }
}
