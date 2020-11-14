using System.Collections.Generic;
using System.Diagnostics;
using Eagle_Eye.Data;
using Eagle_Eye.Models;
using Microsoft.AspNetCore.Mvc;

namespace Eagle_Eye.Controllers
{
    public class MoviesController : Controller
    {
        private readonly IMovieRepository _repository;
        public MoviesController(IMovieRepository repository)
        {
            _repository = repository;
        }

        [HttpGet]
        [Route("/movies/stats")]
        public ActionResult<IEnumerable<Movie>> GetAllMovies()
        {
            var movies = _repository.GetMovies();

            return Ok(movies);
        }

        [HttpGet]
        [Route("/metadata/{movieId}")]
        public ActionResult<Movie> GetMovieById(int movieId)
        {
            var movie = _repository.GetMovieById(movieId);

            return Ok(movie);
        }

        [HttpPost]
        [Route("/metadata")]
        public void AddMovieToList(Movie movie)
        {
            _repository.AddMovie(movie);
        }
    }
}