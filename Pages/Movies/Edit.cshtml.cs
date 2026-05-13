using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;
using Microsoft.AspNetCore.Mvc;
using Microsoft.AspNetCore.Mvc.RazorPages;
using Microsoft.AspNetCore.Mvc.Rendering;
using Microsoft.EntityFrameworkCore;
using RazorPagesMovie.Data;
using RazorPagesMovie.Models;

namespace RazorPagesMovie.Pages.Movies
{
    public class EditModel : PageModel
    {
        private readonly RazorPagesMovie.Data.RazorPagesMovieContext _context;

        public EditModel(RazorPagesMovie.Data.RazorPagesMovieContext context)
        {
            _context = context;
        }

        [BindProperty]
        public Movie Movie { get; set; } = default!;

        [BindProperty]
        public List<int> SelectedActorIds { get; set; } = new();

        public MultiSelectList ActorOptions { get; set; } = default!;

        public async Task<IActionResult> OnGetAsync(int? id)
        {
            if (id == null)
            {
                return NotFound();
            }

            var movie =  await _context.Movie
                .Include(m => m.MovieActors)
                .FirstOrDefaultAsync(m => m.Id == id);
            if (movie == null)
            {
                return NotFound();
            }
            Movie = movie;
            SelectedActorIds = movie.MovieActors.Select(movieActor => movieActor.ActorId).ToList();
            PopulateActorsDropDownList();
            return Page();
        }

        // To protect from overposting attacks, enable the specific properties you want to bind to.
        // For more information, see https://aka.ms/RazorPagesCRUD.
        public async Task<IActionResult> OnPostAsync()
        {
            if (!ModelState.IsValid)
            {
                PopulateActorsDropDownList();
                return Page();
            }

            var movieToUpdate = await _context.Movie
                .Include(movie => movie.MovieActors)
                .FirstOrDefaultAsync(movie => movie.Id == Movie.Id);

            if (movieToUpdate == null)
            {
                return NotFound();
            }

            movieToUpdate.Title = Movie.Title;
            movieToUpdate.ReleaseDate = Movie.ReleaseDate;
            movieToUpdate.Genre = Movie.Genre;
            movieToUpdate.Price = Movie.Price;
            movieToUpdate.Director = Movie.Director;
            movieToUpdate.Cast = Movie.Cast;
            movieToUpdate.ImdbRating = Movie.ImdbRating;
            movieToUpdate.BoxOfficeRevenue = Movie.BoxOfficeRevenue;
            movieToUpdate.ReleaseCountry = Movie.ReleaseCountry;

            movieToUpdate.MovieActors.Clear();
            foreach (var actorId in SelectedActorIds)
            {
                movieToUpdate.MovieActors.Add(new MovieActor { MovieId = movieToUpdate.Id, ActorId = actorId });
            }

            try
            {
                await _context.SaveChangesAsync();
            }
            catch (DbUpdateConcurrencyException)
            {
                if (!MovieExists(Movie.Id))
                {
                    return NotFound();
                }
                else
                {
                    throw;
                }
            }

            return RedirectToPage("./Index");
        }

        private bool MovieExists(int id)
        {
            return _context.Movie.Any(e => e.Id == id);
        }

        private void PopulateActorsDropDownList()
        {
            ActorOptions = new MultiSelectList(
                _context.Actor.AsNoTracking().OrderBy(actor => actor.Name),
                "Id",
                "Name",
                SelectedActorIds);
        }
    }
}
