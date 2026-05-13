using Microsoft.EntityFrameworkCore;
using RazorPagesMovie.Models;

namespace RazorPagesMovie.Data;

public static class DbInitializer
{
    public static void Seed(RazorPagesMovieContext context)
    {
        var actors = context.Actor
            .AsNoTracking()
            .OrderBy(actor => actor.Id)
            .Take(12)
            .ToList();

        var movies = new List<Movie>
        {
            new()
            {
                Title = "Black Panther",
                ReleaseDate = new DateTime(2018, 2, 16),
                Genre = "Action",
                Price = 9.99M,
                Director = "Ryan Coogler",
                Cast = "Chadwick Boseman, Michael B. Jordan, Lupita Nyong'o",
                ImdbRating = 7.3M,
                BoxOfficeRevenue = 1347000000M,
                ReleaseCountry = "United States"
            },
            new()
            {
                Title = "The Woman King",
                ReleaseDate = new DateTime(2022, 9, 16),
                Genre = "Drama",
                Price = 8.99M,
                Director = "Gina Prince-Bythewood",
                Cast = "Viola Davis, Thuso Mbedu, Lashana Lynch",
                ImdbRating = 6.9M,
                BoxOfficeRevenue = 97000000M,
                ReleaseCountry = "United States"
            },
            new()
            {
                Title = "King of Boys",
                ReleaseDate = new DateTime(2018, 10, 26),
                Genre = "Crime",
                Price = 6.99M,
                Director = "Kemi Adesoye",
                Cast = "Sola Sobowale, Remilekun Safaru, Adesua Etomi",
                ImdbRating = 6.4M,
                BoxOfficeRevenue = 244000000M,
                ReleaseCountry = "Nigeria"
            },
            new()
            {
                Title = "The Dark Knight",
                ReleaseDate = new DateTime(2008, 7, 18),
                Genre = "Action",
                Price = 7.99M,
                Director = "Christopher Nolan",
                Cast = "Christian Bale, Heath Ledger, Aaron Eckhart",
                ImdbRating = 9.0M,
                BoxOfficeRevenue = 1006000000M,
                ReleaseCountry = "United States"
            },
            new()
            {
                Title = "Inception",
                ReleaseDate = new DateTime(2010, 7, 16),
                Genre = "Sci-Fi",
                Price = 8.49M,
                Director = "Christopher Nolan",
                Cast = "Leonardo DiCaprio, Joseph Gordon-Levitt, Elliot Page",
                ImdbRating = 8.8M,
                BoxOfficeRevenue = 839000000M,
                ReleaseCountry = "United States"
            },
            new()
            {
                Title = "Lionheart",
                ReleaseDate = new DateTime(2018, 9, 7),
                Genre = "Comedy",
                Price = 5.99M,
                Director = "Genevieve Nnaji",
                Cast = "Genevieve Nnaji, Nkem Owoh, Pete Edochie",
                ImdbRating = 5.7M,
                BoxOfficeRevenue = 21000000M,
                ReleaseCountry = "Nigeria"
            }
        };

        var existingTitles = context.Movie
            .AsNoTracking()
            .Select(movie => movie.Title)
            .ToHashSet(StringComparer.OrdinalIgnoreCase);

        movies = movies
            .Where(movie => movie.Title != null && !existingTitles.Contains(movie.Title))
            .ToList();

        if (movies.Count == 0)
        {
            return;
        }

        context.Movie.AddRange(movies);
        context.SaveChanges();

        if (actors.Count == 0)
        {
            return;
        }

        var movieActors = new List<MovieActor>();
        for (var movieIndex = 0; movieIndex < movies.Count; movieIndex++)
        {
            foreach (var actor in actors.Skip(movieIndex * 2).Take(2))
            {
                movieActors.Add(new MovieActor
                {
                    MovieId = movies[movieIndex].Id,
                    ActorId = actor.Id
                });
            }
        }

        context.MovieActor.AddRange(movieActors);
        context.SaveChanges();
    }
}
