using System;
using System.Collections.Generic;
using System.Linq;
using Movies.Api.Models;
using NUnit.Framework;

namespace Movies.Tests.Ratings
{
    public class WhenGettingTop5MoviesBySpecificUserRatings
    {
        IEnumerable<Movie> _result;

        [OneTimeSetUp]
        public void SetUp()
        {
            var context = new MoviesControllerTestContext();

            _result = context.GetTop5RatedMoviesByUser(2);
        }

        [Test]
        public void ShouldReturnOnlyMoviesThatHaveBeenRatedByThatUser()
            => Assert.That(_result, Is.All.Matches<Movie>(movie => movie.Ratings.Any(rating => rating.UserId == 2)));

        [Test]
        public void ShouldReturnMoviesInRatingOrderDescending()
            => Assert.That(_result, Is.Ordered.Descending.Using(ComparisonByUserRatingForUser(2)));

        static Comparison<Movie> ComparisonByUserRatingForUser(int userId) => (x, y) =>
        {
            var xRating = x.AverageRatingByUser(userId);
            var yRating = y.AverageRatingByUser(userId);

            if (xRating == yRating)
                return string.Compare(x.Title, y.Title, StringComparison.Ordinal);

            if (xRating < yRating)
                return -1;

            return 1;
        };
    }
}