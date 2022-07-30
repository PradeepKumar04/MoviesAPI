using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;

namespace MoviesAPI.Model
{
    public class Movie
    {
        public int Id { get; set; }
        public string MovieName { get; set; }
        public Producer Producer { get; set; }
        public  IEnumerable<ActorMovie> ActorMovies { get; set; }
    }
}
