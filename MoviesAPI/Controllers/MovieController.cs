using Microsoft.AspNetCore.Mvc;
using MoviesAPI.Model;
using MoviesAPI.Reposistory;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;

// For more information on enabling Web API for empty projects, visit https://go.microsoft.com/fwlink/?LinkID=397860

namespace MoviesAPI.Controllers
{
    [Route("api/[controller]")]
    [ApiController]
    public class MovieController : ControllerBase
    {
        private readonly IMovieReposistory _movieReposistory;
        public MovieController(IMovieReposistory movieReposistory)
        {
            _movieReposistory = movieReposistory;
        }
        // GET: api/<MovieController>
        [HttpGet]
        public async Task<ICollection<Movie>> Get()
        {
            return await  _movieReposistory.GetMovies();
        }

        // GET api/<MovieController>/5
        [HttpGet("{id}")]
        public async Task<Movie> Get(int id)
        {
            if(id==0 )
            {
                return null;
            }
            return await _movieReposistory.GetMovieById(id);
        }

        // POST api/<MovieController>
        [HttpPost]
        public async Task<bool> Post([FromBody] Movie movie)
        {
            if (movie == null)
            {
                return false;
            }
            return await _movieReposistory.AddMovie(movie);

        }

        // PUT api/<MovieController>/5
        [HttpPut("{id}")]
        public async Task<bool> Put(int id, [FromBody] Movie movie)
        {
            if (movie == null)
            {
                return false;
            }
            return await _movieReposistory.UpdateMovie(movie,id);
        }

        // DELETE api/<MovieController>/5
        [HttpDelete("{id}")]
        public async Task<bool> Delete(int id)
        {
            if (id == 0)
            {
                return false;
            }
            return await _movieReposistory.DeleteMovie(id);
        }
    }
}
