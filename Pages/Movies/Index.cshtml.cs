using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;
using Microsoft.AspNetCore.Mvc;
using Microsoft.AspNetCore.Mvc.RazorPages;
using Microsoft.EntityFrameworkCore;
using RazorPagesMovie.Data;
using RazorPagesMovie.Models;

namespace RazorPagesMovie.Pages.Movies
{
    public class IndexModel : PageModel
    {
        private readonly RazorPagesMovie.Data.RazorPagesMovieContext _context;

        public IndexModel(RazorPagesMovie.Data.RazorPagesMovieContext context)
        {
            _context = context;
        }

        public IList<Movie> Movie { get;set; } = default!;

        [BindProperty(SupportsGet = true)]
        public string? SearchString { get; set; }

        public async Task OnGetAsync()
        {
            var movies = _context.Movie
                .Include(movie => movie.MovieActors)
                .ThenInclude(movieActor => movieActor.Actor)
                .AsQueryable();

            if (!string.IsNullOrWhiteSpace(SearchString))
            {
                movies = movies.Where(movie =>
                    (movie.Title != null && movie.Title.Contains(SearchString)) ||
                    (movie.Genre != null && movie.Genre.Contains(SearchString)) ||
                    (movie.Director != null && movie.Director.Contains(SearchString)) ||
                    (movie.ReleaseCountry != null && movie.ReleaseCountry.Contains(SearchString)));
            }

            Movie = await movies.ToListAsync();
        }
    }
}
