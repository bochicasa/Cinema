using Cine.View.ViewModel.Movie;
using Microsoft.Extensions.Options;
using Newtonsoft.Json;
using System.Collections.Generic;
using System.Linq;
using System.Net.Http;
using System.Threading.Tasks;

namespace Cine.View.Services
{
    public class MovieService : IMovieService
    {
        private readonly IOptions<AppSettings> _settings;
        private readonly HttpClient _apiClient;
        private readonly string _movieByPassUrl;
        private readonly string _movieUrl;

        public MovieService(HttpClient httpClient, IOptions<AppSettings> settings)
        {
            _apiClient = httpClient;
            _settings = settings;
           // _movieByPassUrl = $"{_settings.Value.CineApiUrl}&sort_by=popularity.desc&inc lude_adult=false&include_video=false&page=1";
            _movieByPassUrl = $"{_settings.Value.MovieDBUrl}{_settings.Value.MovieDBKey}&sort_by=popularity.desc&inc lude_adult=false&include_video=false&page=1";
        }

        public async Task<List<Movie>> GetPeliculas()
        {
            var json = await _apiClient.GetStringAsync(_movieByPassUrl);
            Rootobject result = JsonConvert.DeserializeObject<Rootobject>(json);
            List<Movie> movies = result.results.ToList();

            return movies;
        }

        //public async Task<string> GetPeliculaImage(string posterPath)
        //{
        //    try
        //    {
        //        //var url = UrlMovieDbApi + posterPath;
        //        //var httpClient = new HttpClient();
        //        //var json = httpClient.GetStringAsync(url).Result;
        //        //string result = JsonConvert.DeserializeObject<string>(json);


        //        return result;
        //    }
        //    catch (Exception ex)
        //    {
        //        return string.Empty;
        //    }
        //}
    }
}
