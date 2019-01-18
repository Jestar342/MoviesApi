using System.Collections.Generic;
using System.Linq;
using Microsoft.AspNetCore.Mvc;
using Movies.Api.Models;

namespace Movies.Api.Controllers
{
    [ApiController]
    [Route("api/[controller]")]
    public class MoviesController : ControllerBase
    {
        readonly IEnumerable<Movie> _movies;

        public MoviesController(IEnumerable<Movie> movies)
        {
            _movies = movies;
        }

        [HttpGet]
        public ActionResult<IEnumerable<Movie>> Get(string title, int? year, [FromQuery] params string[] genres)
        {
            if (string.IsNullOrWhiteSpace(title) && !year.HasValue && !genres.Any())
                return BadRequest("You must provide at least one filter for title, year, or genres");

            var movies = _movies;

            if (!string.IsNullOrWhiteSpace(title))
                movies = movies.Where(movie => movie.Title.Contains(title));

            if (year.HasValue)
                movies = movies.Where(movie => movie.Year == year);

            if (genres.Any())
                movies = movies.Where(movie => movie.Genres.Any(genres.Contains));

            if (!movies.Any())
                return NotFound("No movies match the given filter criteria");

            return movies.ToArray();
        }

        [HttpGet("top5")]
        public IEnumerable<Movie> GetTop5RatedMovies()
            => _movies
                .OrderByDescending(movie => movie.AverageRating)
                .ThenBy(movie => movie.Title)
                .Take(5);

        [HttpGet]
        [Route("top5/user/{userId}")]
        [Route("user/{userId}/top5")]
        public IEnumerable<Movie> GetTop5RatedMovies(int userId)
            => _movies
                .OrderByDescending(movie => movie.AverageRatingByUser(userId))
                .ThenBy(movie => movie.Title)
                .Take(5).ToArray();
    }
}