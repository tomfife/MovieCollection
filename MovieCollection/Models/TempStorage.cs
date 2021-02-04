using System;
using System.Collections.Generic;

namespace MovieCollection.Models
{
    public class TempStorage
    {
        private static List<AddMovieResponse> movies = new List<AddMovieResponse>();

        public static IEnumerable<AddMovieResponse> Movies => movies;

        public static void AddMovie(AddMovieResponse movie)
        {
            movies.Add(movie);
        }
    }
}
