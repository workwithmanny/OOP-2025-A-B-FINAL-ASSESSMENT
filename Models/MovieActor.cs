using System.Text.Json.Serialization;

namespace RazorPagesMovie.Models;

public class MovieActor
{
    public int MovieId { get; set; }

    [JsonIgnore]
    public Movie Movie { get; set; } = default!;

    public int ActorId { get; set; }
    public Actor Actor { get; set; } = default!;
}
