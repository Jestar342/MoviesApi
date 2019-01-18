using System.Collections.Generic;
using Microsoft.AspNetCore.Mvc;
using Movies.Api.Models;
using NUnit.Framework;

namespace Movies.Tests.Filter
{
    public class WhenGettingMoviesWithNoFilterSpecified
    {
        ActionResult<IEnumerable<Movie>> _result;

        [OneTimeSetUp]
        public void Setup()
        {
            var context = new MoviesControllerTestContext();
            _result = context.FilterMovies();
        }

        [Test]
        public void ShouldRejectWithBadRequest() 
            => Assert.That(_result.Result, Is.InstanceOf<BadRequestObjectResult>());
    }
}