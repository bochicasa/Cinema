using Cine.View.ViewModel.Movie;
using System.Collections.Generic;
using System.Threading.Tasks;

namespace Cine.View.Services
{
    public interface IMovieService
    {
        Task<List<Movie>> GetPeliculas();
        //Task<string> GetPeliculaImage(string posterPath);
    }
}
