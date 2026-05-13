using System.ComponentModel.DataAnnotations;
using System.Text.Json.Serialization;

namespace RazorPagesMovie.Models;

public class Actor
{
    public int Id { get; set; }

    [Required]
    public string Name { get; set; } = string.Empty;

    [DataType(DataType.Date)]
    [Display(Name = "Date of Birth")]
    public DateTime DateOfBirth { get; set; }

    [JsonIgnore]
    public List<MovieActor> MovieActors { get; set; } = new();
}
