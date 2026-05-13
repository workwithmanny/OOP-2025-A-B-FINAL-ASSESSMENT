using Microsoft.AspNetCore.Mvc.RazorPages;
using Microsoft.EntityFrameworkCore;
using RazorPagesMovie.Data;
using RazorPagesMovie.Models;

namespace RazorPagesMovie.Pages;

public class IndexModel : PageModel
{
    private readonly RazorPagesMovieContext _context;

    public IndexModel(RazorPagesMovieContext context)
    {
        _context = context;
    }

    public int MovieCount { get; set; }
    public int ActorCount { get; set; }
    public decimal AverageRating { get; set; }
    public IList<Movie> FeaturedMovies { get; set; } = new List<Movie>();

    public async Task OnGetAsync()
    {
        MovieCount = await _context.Movie.CountAsync();
        ActorCount = await _context.Actor.CountAsync();

        if (MovieCount > 0)
        {
            AverageRating = await _context.Movie.AverageAsync(movie => movie.ImdbRating);
        }

        var movies = await _context.Movie
            .Include(movie => movie.MovieActors)
            .ThenInclude(movieActor => movieActor.Actor)
            .ToListAsync();

        FeaturedMovies = movies
            .OrderByDescending(movie => movie.ImdbRating)
            .ThenBy(movie => movie.Title)
            .Take(3)
            .ToList();
    }
}
