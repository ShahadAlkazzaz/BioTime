using BioTime.Models;
using BioTime.Services;
using Microsoft.AspNetCore.Mvc;

namespace BioTime.Controllers
{
    [Route("api/[controller]")]
    [ApiController]
    public class MoviesController : ControllerBase
    {
        private readonly MovieService _service;

        public MoviesController(MovieService service)
        {
            _service = service;
        }

        // GET
        [HttpGet]
        public IActionResult GetMovies()
        {
            return Ok(_service.GetAll());
        }

        // POST
        [HttpPost]
        public IActionResult AddMovie(Movie movie)
        {
            return Ok(_service.Add(movie));
        }

        // GET BY ID
        [HttpGet("{id}")]
        public IActionResult GetMovie(int id)
        {
            var movie = _service.GetById(id);

            if (movie == null)
                return NotFound();

            return Ok(movie);
        }

        // UPDATE
        [HttpPut("{id}")]
        public IActionResult UpdateMovie(int id, Movie updatedMovie)
        {
            var movie = _service.Update(id, updatedMovie);

            if (movie == null)
                return NotFound();

            return Ok(movie);
        }

        // DELETE
        [HttpDelete("{id}")]
        public IActionResult DeleteMovie(int id)
        {
            var result = _service.Delete(id);

            if (!result)
                return NotFound();

            return Ok("Deleted successfully");
        }
    }
}