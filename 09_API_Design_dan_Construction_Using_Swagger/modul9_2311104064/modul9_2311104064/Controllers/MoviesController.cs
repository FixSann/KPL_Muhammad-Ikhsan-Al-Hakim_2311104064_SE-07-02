using Microsoft.AspNetCore.Mvc;
using modul9_2311104064.Models;

namespace modul9_2311104064.Controllers;

[ApiController]
[Route("api/[controller]")]
public class MoviesController : ControllerBase
{
    private static List<Movie> movies = new()
    {
        new Movie {
            Title = "The Shawshank Redemption",
            Director = "Frank Darabont",
            Stars = new List<string> { "Tim Robbins", "Morgan Freeman" },
            Description = "Two imprisoned men bond over a number of years."
        },
        new Movie {
            Title = "The Godfather",
            Director = "Francis Ford Coppola",
            Stars = new List<string> { "Marlon Brando", "Al Pacino" },
            Description = "The aging patriarch of an organized crime dynasty transfers control."
        },
        new Movie {
            Title = "The Dark Knight",
            Director = "Christopher Nolan",
            Stars = new List<string> { "Christian Bale", "Heath Ledger" },
            Description = "Batman faces the Joker, a criminal mastermind."
        }
    };

    [HttpGet]
    public ActionResult<List<Movie>> GetAll() => Ok(movies);

    [HttpGet("{id}")]
    public ActionResult<Movie> Get(int id)
    {
        if (id < 0 || id >= movies.Count) return NotFound();
        return Ok(movies[id]);
    }

    [HttpPost]
    public IActionResult Add(Movie movie)
    {
        movies.Add(movie);
        return Ok("Movie berhasil ditambahkan.");
    }

    [HttpDelete("{id}")]
    public IActionResult Delete(int id)
    {
        if (id < 0 || id >= movies.Count) return NotFound();
        movies.RemoveAt(id);
        return Ok("Movie berhasil dihapus.");
    }
}
