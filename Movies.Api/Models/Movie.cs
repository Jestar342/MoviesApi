using System.Collections.Generic;
using System.Linq;

namespace Movies.Api.Models
{
    public class Movie
    {
        public Movie()
        {}

        public Movie(string title, int year, IEnumerable<string> genres, IEnumerable<Rating> ratings)
        {
            Title = title;
            Year = year;
            Genres = genres;
            Ratings = ratings;
        }

        public string Title { get; set; }
        public int Year { get; set; }
        public IEnumerable<string> Genres { get; set; }
        public IEnumerable<Rating> Ratings { get; set; }
        public bool HasRatings => Ratings?.Any() == true;

        public decimal? AverageRating
            => HasRatings
                ? Ratings.Average(rating => rating.Score)
                : (decimal?) null;

        public decimal? AverageRatingByUser(int userId)
        {
            if (!HasRatings || Ratings.All(x => x.UserId != userId))
                return null;

            return Ratings
                .Where(rating => rating.UserId == userId)
                .Average(rating => rating.Score);
        }
    }
}