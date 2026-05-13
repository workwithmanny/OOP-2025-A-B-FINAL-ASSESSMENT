using Bogus;
using Microsoft.EntityFrameworkCore;
using RazorPagesMovie.Models;

namespace RazorPagesMovie.Data
{
    public class RazorPagesMovieContext : DbContext
    {
        public RazorPagesMovieContext (DbContextOptions<RazorPagesMovieContext> options)
            : base(options)
        {
        }

        public DbSet<Movie> Movie { get; set; } = default!;

        public DbSet<Actor> Actor { get; set; } = default!;

        public DbSet<MovieActor> MovieActor { get; set; } = default!;

        protected override void OnModelCreating(ModelBuilder modelBuilder)
        {
            base.OnModelCreating(modelBuilder);

            modelBuilder.Entity<MovieActor>()
                .HasKey(movieActor => new { movieActor.MovieId, movieActor.ActorId });

            modelBuilder.Entity<MovieActor>()
                .HasOne(movieActor => movieActor.Movie)
                .WithMany(movie => movie.MovieActors)
                .HasForeignKey(movieActor => movieActor.MovieId);

            modelBuilder.Entity<MovieActor>()
                .HasOne(movieActor => movieActor.Actor)
                .WithMany(actor => actor.MovieActors)
                .HasForeignKey(movieActor => movieActor.ActorId);

            Randomizer.Seed = new Random(20260513);
            var actors = new Faker<Actor>()
                .RuleFor(actor => actor.Id, faker => faker.IndexFaker + 1)
                .RuleFor(actor => actor.Name, faker => faker.Name.FullName())
                .RuleFor(actor => actor.DateOfBirth, faker => faker.Date.BetweenDateOnly(new DateOnly(1940, 1, 1), new DateOnly(2004, 12, 31)).ToDateTime(TimeOnly.MinValue))
                .Generate(100);

            modelBuilder.Entity<Actor>().HasData(actors);
        }
    }
}
