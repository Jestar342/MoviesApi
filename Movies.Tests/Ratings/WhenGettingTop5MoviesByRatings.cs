using System.Collections.Generic;
using System.Linq;
using Movies.Api.Models;
using NUnit.Framework;

namespace Movies.Tests.Ratings
{
    public class WhenGettingTop5MoviesByRatings
    {
        IEnumerable<Movie> _result;

        [OneTimeSetUp]
        public void SetUp()
        {
            var context = new MoviesControllerTestContext();

            _result = context.GetTop5RatedMovies();
        }

        [Test]
        public void ShouldReturn5Movies() => Assert.That(_result.Count(), Is.EqualTo(5));

        [Test]
        public void ShouldReturnMoviesInDescendingRatingsOrder() 
            => Assert.That(_result, Is.Ordered.Descending.By(nameof(Movie.AverageRating)));
    }
}