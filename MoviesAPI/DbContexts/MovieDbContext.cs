using System;
using System.Collections.Generic;
using System.Linq;
using Microsoft.EntityFrameworkCore;
using System;
using System.Collections.Generic;
using System.Text;
using System.Threading;
using System.Threading.Tasks;
using System.Threading.Tasks;
using MoviesAPI.Model;

namespace MoviesAPI.DbContexts
{
    public class MovieDbContext : DbContext
    {
        public DbSet<Movie> Movies { get; set; }
        public DbSet<Actor> Actors { get; set; }
        public DbSet<Producer> Producers { get; set; }
        public DbSet<ActorMovie> ActorMovies { get; set; }

        public MovieDbContext(DbContextOptions<MovieDbContext> options) : base(options)
        {

        }


        protected override void OnModelCreating(ModelBuilder modelBuilder)
        {
            modelBuilder.Entity<ActorMovie>()
                .HasKey(s => new { s.ActorId, s.MovieId });

            modelBuilder.Entity<ActorMovie>()
                .HasOne(s => s.Movie)
                .WithMany(d=>d.ActorMovies).HasForeignKey(s => s.MovieId);

            modelBuilder.Entity<ActorMovie>()
                .HasOne(s => s.Actor)
                .WithMany(d=>d.ActorMovies).HasForeignKey(s => s.ActorId);
            
        }
    }
}
