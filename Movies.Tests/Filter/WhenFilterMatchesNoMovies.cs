using System.Collections.Generic;
using Microsoft.AspNetCore.Mvc;
using Movies.Api.Models;
using NUnit.Framework;

namespace Movies.Tests.Filter
{
    public class WhenFilterMatchesNoMovies
    {
        ActionResult<IEnumerable<Movie>> _result;

        [OneTimeSetUp]
        public void SetUp()
        {
            var context = new MoviesControllerTestContext();

            _result = context.FilterMovies("Non-existent movie title");
        }

        [Test]
        public void ShouldReturnNotFoundObjectResult() 
            => Assert.That(_result.Result, Is.InstanceOf<NotFoundObjectResult>());
    }
}