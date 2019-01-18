using System.Collections.Generic;
using System.Linq;
using Microsoft.AspNetCore.Mvc;
using Movies.Api.Models;
using NUnit.Framework;

namespace Movies.Tests.Filter
{
    public class WhenGettingMoviesFilteredByTitle
    {
        ActionResult<IEnumerable<Movie>> _result;

        [OneTimeSetUp]
        public void SetUp()
        {
            var context = new MoviesControllerTestContext();

            _result = context.FilterMovies(title: "Death");
        }

        [Test]
        public void ShouldOnlyReturnMoviesThatMatchFilter() =>
            Assert.That(_result.Value.Single().Title, Is.EqualTo("Death from above"));
    }
}