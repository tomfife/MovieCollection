using System;
using System.Collections.Generic;
using System.Diagnostics;
using System.Linq;
using System.Threading.Tasks;
using Microsoft.AspNetCore.Mvc;
using Microsoft.Extensions.Logging;
using MovieCollection.Models;
using MovieCollection.Models.ViewModels;

namespace MovieCollection.Controllers
{
    public class HomeController : Controller
    {
        private MovieListContext context { get; set; }

        public HomeController(MovieListContext con)
        {
            context = con;
        }

        // Removed this from previous project - i think this had to do with saving the context
        //private readonly ILogger<HomeController> _logger;

        //public HomeController(ILogger<HomeController> logger)
        //{
        //    _logger = logger;
        //}

        public IActionResult Index()
        {
            return View();
        }

        public IActionResult MyPodcasts()
        {
            return View();
        }

        [HttpGet]
        public IActionResult AddMovies()
        {
            return View();
        }

        [HttpPost]
        public IActionResult AddMovies(AddMovieResponse newMovie)
        {
            if (ModelState.IsValid)
            {
                // Update the database
                context.Movies.Add(newMovie);
                // Save changes in the database
                context.SaveChanges();

                return View("Confirmation", newMovie);
            }
            else
            {
                return View();
            }
        }

        [HttpGet]
        public IActionResult MovieCollection()
        {
            return View(new MoviesViewModel
            {
                Movies = context.Movies
            });
        }

        // Edit Movies from the Database
            // Pass to the edit page
        [HttpGet]
        [Route("edit/{id}")]
        public IActionResult Edit(int id)
        {
            var movie = (context.Movies.Find(id));
            return View("EditMovie", movie);
        }

            // Make the changes
        [HttpPost]
        [Route("edit/{id}")]
        public IActionResult Edit(int id, AddMovieResponse movie)
        {
            context.Entry(movie).State = Microsoft.EntityFrameworkCore.EntityState.Modified;
            context.SaveChanges();
            return RedirectToAction("MovieCollection");
        }

        // Delete Movies from the Database
        [HttpGet]
        [Route("delete/{id}")]
        public IActionResult Delete(int id)
        {
            context.Movies.Remove(context.Movies.Find(id));
            context.SaveChanges();
            return RedirectToAction("MovieCollection");
        }

        public IActionResult Privacy()
        {
            return View();
        }

        [ResponseCache(Duration = 0, Location = ResponseCacheLocation.None, NoStore = true)]
        public IActionResult Error()
        {
            return View(new ErrorViewModel { RequestId = Activity.Current?.Id ?? HttpContext.TraceIdentifier });
        }
    }
}
