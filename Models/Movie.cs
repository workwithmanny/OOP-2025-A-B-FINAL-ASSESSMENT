using System.ComponentModel.DataAnnotations;
using System.ComponentModel.DataAnnotations.Schema;

namespace RazorPagesMovie.Models;

public class Movie
{
    public int Id { get; set; }
    public string? Title { get; set; }

    [DataType(DataType.Date)]
    public DateTime ReleaseDate { get; set; }

    public string? Genre { get; set; }

    public decimal Price { get; set; }

    public string? Director { get; set; }

    public string? Cast { get; set; }

    [Display(Name = "IMDb Rating")]
    [Column(TypeName = "decimal(3,1)")]
    public decimal ImdbRating { get; set; }

    [Display(Name = "Box Office Revenue")]
    [Column(TypeName = "decimal(18,2)")]
    public decimal BoxOfficeRevenue { get; set; }

    [Display(Name = "Release Country")]
    public string? ReleaseCountry { get; set; }

    public List<MovieActor> MovieActors { get; set; } = new();
}
