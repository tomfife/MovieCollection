using System;
using System.Collections.Generic;
using MovieCollection.Models;

namespace MovieCollection.Models.ViewModels
{
    // Creates a list of movies to be used in the view
    public class MoviesViewModel
    {
        public IEnumerable<AddMovieResponse> Movies { get; set; }
    }
}
