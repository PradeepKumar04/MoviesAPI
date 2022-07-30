using MoviesAPI.Model;
using System.Collections.Generic;
using System.Threading.Tasks;

namespace MoviesAPI.Reposistory
{
    public interface IMovieReposistory
    {
        Task<bool> AddMovie(Movie movie);
        Task<bool> UpdateMovie(Movie movie,int id);
        Task<ICollection<Movie>> GetMovies();
        Task<Movie> GetMovieById(int id);
        Task<bool> DeleteMovie(int id);
    }
}
