using System.Collections.Generic;
using System.Linq;
using Microsoft.AspNetCore.Mvc;
using Movies.Api.Controllers;
using Movies.Api.Models;

namespace Movies.Tests
{
    public class MoviesControllerTestContext
    {
        readonly MoviesController _moviesController;

        public MoviesControllerTestContext()
        {
            _moviesController = new MoviesController(TestMovies);
        }

        public static IEnumerable<Movie> TestMovies { get; } = new[]
        {
            new Movie("Death from above", 2010, new[] {"Thriller", "Action"}, new [] { new Rating(3.5m, 1), new Rating(2.9m, 2), new Rating(2m, 3),  }),
            new Movie("Hope for love", 2012, new[] {"Romance", "Tragedy"}, new [] { new Rating(5m,1), new Rating(4.1m, 2) }),
            new Movie("Make you wanna smile", 2009, new[] {"Comedy", "Family"}, new [] {new Rating(2m, 1), new Rating(2.9m,3)}),
            new Movie("Here we go again", 2013, new[] {"Historic", "Family"}, new [] {new Rating(4m, 2), new Rating(4m, 3) }),
            new Movie("Take it to the top", 1985, new[] {"Business", "Drama"}, new []{new Rating(1.3m, 1), new Rating(1.1m,2),new Rating(1.9m,3)  }),
            new Movie("There's only one way to go", 1969, new[] {"Adventure" }, Enumerable.Empty<Rating>()),
            new Movie("Brutal", 1991, new[] {"Fighting", "Action", "Horror" }, new []{ new Rating(2.5m,1), new Rating(5m, 2), new Rating(3m,3),  }),
            new Movie("Tales of the weird one", 1996, new[] { "Fantasy" }, Enumerable.Empty<Rating>()),
            new Movie("Ha, fooled you!", 2014, new[] { "Whodunnit", "Historic" }, Enumerable.Empty<Rating>()),
            new Movie("My story", 2016, new[] { "Biopic", "Musical" }, Enumerable.Empty<Rating>()),
        };

        public ActionResult<IEnumerable<Movie>> FilterMovies(string title = null, int? year = null, params string[] genres)
            => _moviesController.Get(title, year, genres);

        public IEnumerable<Movie> GetTop5RatedMovies()
            => _moviesController.GetTop5RatedMovies();

        public IEnumerable<Movie> GetTop5RatedMoviesByUser(int userId)
            => _moviesController.GetTop5RatedMovies(userId);
    }
}