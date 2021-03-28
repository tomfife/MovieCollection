using System;
using Microsoft.EntityFrameworkCore;

namespace MovieCollection.Models
{
    public class MovieListContext : DbContext
    {
        public MovieListContext(DbContextOptions<MovieListContext> options) : base (options)
        {

        }

        // Import Table into ASP.net
        public DbSet<AddMovieResponse> Movies { get; set; }
    }
}
