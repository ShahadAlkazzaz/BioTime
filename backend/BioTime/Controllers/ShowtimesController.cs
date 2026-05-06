using BioTime.Models;
using Microsoft.AspNetCore.Mvc;
using Microsoft.EntityFrameworkCore;

namespace BioTime.Controllers
{
    [Route("api/[controller]")]
    [ApiController]
    public class ShowtimesController : ControllerBase
    {
        private readonly AppDbContext _context;

        public ShowtimesController(AppDbContext context)
        {
            _context = context;
        }

        // GET all showtimes

        [HttpGet]
        public IActionResult GetAll()
        {
            var showtimes = _context.Showtimes
                .Include(s => s.Movie)
                .Include(s => s.Hall)
                .ToList();

            return Ok(showtimes);
        }

        // POST create showtime
        [HttpPost]
        public IActionResult Create(Showtime showtime)
        {
            _context.Showtimes.Add(showtime);
            _context.SaveChanges();

            var result = _context.Showtimes
                .Where(s => s.Id == showtime.Id)
                .Include(s => s.Movie)
                .Include(s => s.Hall)
                .FirstOrDefault();

            return Ok(result);
        }
    }
}