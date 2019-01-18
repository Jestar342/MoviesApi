using System.Collections.Generic;
using System.Linq;
using Microsoft.AspNetCore.Mvc;
using Movies.Api.Models;
using NUnit.Framework;

namespace Movies.Tests.Filter
{
    public class WhenGettingMoviesFilteredByGenre
    {
        ActionResult<IEnumerable<Movie>> _result;

        [OneTimeSetUp]
        public void SetUp()
        {
            var context = new MoviesControllerTestContext();

            _result = context.FilterMovies(genres: "Comedy");
        }

        [Test]
        public void ShouldOnlyReturnMoviesThatMatchGenre()
            => Assert.That(_result.Value.Single().Title, Is.EqualTo("Make you wanna smile"));
    }
}