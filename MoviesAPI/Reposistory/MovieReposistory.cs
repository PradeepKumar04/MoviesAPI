using Microsoft.EntityFrameworkCore;
using MoviesAPI.DbContexts;
using MoviesAPI.Model;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;

namespace MoviesAPI.Reposistory
{
    public class MovieReposistory : IMovieReposistory
    {
        private readonly MovieDbContext _dbContext;
        public MovieReposistory(MovieDbContext dbContext)
        {
            _dbContext = dbContext;
        }
        public async Task<bool> AddMovie(Movie movie)
        {
            try
            {
                _dbContext.Movies.Add(movie);
                var result =await  _dbContext.SaveChangesAsync();
                return result > 0;
            }
            catch (Exception)
            {

                throw;
            }
        }

        public async Task<bool> DeleteMovie(int id)
        {
            try
            {
              var movie = await  _dbContext.Movies.FindAsync(id);
                _dbContext.Movies.Remove(movie);
                var result = await _dbContext.SaveChangesAsync();
                return result > 0;
            }
            catch (Exception)
            {

                throw;
            }
        }

        public async Task<Movie> GetMovieById(int id)
        {
            try
            {
                var movie = await _dbContext.Movies.FindAsync(id);
                return movie;
            }
            catch (Exception)
            {

                throw;
            }
        }

        public async Task<ICollection<Movie>> GetMovies()
        {
            try
            {
                var movies = await _dbContext.Movies.ToListAsync();
                return movies;
            }
            catch (Exception)
            {

                throw;
            }
        }

        public async Task<bool> UpdateMovie(Movie movie, int id)
        {
            try
            {
                movie.Id = id;
                _dbContext.Movies.Update(movie);
                var result = await _dbContext.SaveChangesAsync();
                return result > 0;
            }
            catch (Exception)
            {

                throw;
            }
        }
    }
}
