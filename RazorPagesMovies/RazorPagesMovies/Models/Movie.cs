using System.ComponentModel.DataAnnotations;

namespace RazorPagesMovies.Models;

public class Movie
{
    public int Id { get; set; }
    public string? Name { get; set; }
    [DataType(DataType.Date)]
    public DateTime ReleaseDate { get; set; }
    public string? Genre {  get; set; }
    public decimal Fare { get; set; }
}
