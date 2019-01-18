using System;
using System.Collections.Generic;
using System.Linq;
using Movies.Api.Models;

namespace Movies.Api
{
    public static class MovieMaker
    {
        static readonly string[] FirstPartOfNames = 
            {"Tales of the", "Adventures of", "The", "Total", "Incredible", ""};

        static readonly string[] SecondPartOfNames =
            {"Death", "Love", "Hope", "Grimuldan", "Halflok", "Race", "Journey"};

        static readonly string[] Genres =
        {
            "Action", "Adventure", "Fantasy", "Drama", "Romance", "Comedy", "Thriller", "Family", "Fighting", "Historic"
        };

        static readonly Random Rand = new Random();

        static string RandomPart(string[] parts) => parts.ElementAt(Rand.Next(parts.Length - 1));

        static string RandomTitle => $"{RandomPart(FirstPartOfNames)} {RandomPart(SecondPartOfNames)}";

        static string[] RandomGenres => Enumerable.Range(0, Rand.Next(3))
            .Select(_ => Genres[Rand.Next(Genres.Length - 1)])
            .ToArray();

        static Rating[] RandomRatings => Enumerable.Range(0, Rand.Next(3))
            .Select(userId => new Rating(Rand.Next(50) / 10m, userId))
            .ToArray();

        public static IEnumerable<Movie> RandomMovies =>
            Enumerable.Range(0, 20)
                .Select(_ => new Movie(RandomTitle, Rand.Next(1960, 2019), RandomGenres, RandomRatings));
    }
}