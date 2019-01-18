using System.Collections.Generic;
using System.Linq;
using Microsoft.AspNetCore.Mvc;
using Movies.Api.Models;
using NUnit.Framework;

namespace Movies.Tests.Filter
{
    public class WhenGettingMoviesFilteredByYear
    {
        ActionResult<IEnumerable<Movie>> _result;

        [OneTimeSetUp]
        public void SetUp()
        {
            var context = new MoviesControllerTestContext();

            _result = context.FilterMovies(year: 2012);
        }

        [Test]
        public void ShouldOnlyReturnMoviesThatMatchYear() 
            => Assert.That(_result.Value.Single().Title, Is.EqualTo("Hope for love"));
    }
}