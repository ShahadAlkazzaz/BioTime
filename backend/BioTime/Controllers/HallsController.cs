using BioTime.Models;
using Microsoft.AspNetCore.Mvc;

namespace BioTime.Controllers
{
    [Route("api/[controller]")]
    [ApiController]
    public class HallsController : ControllerBase
    {
        private readonly AppDbContext _context;

        public HallsController(AppDbContext context)
        {
            _context = context;
        }

        [HttpGet]
        public IActionResult GetAll()
        {
            return Ok(_context.Halls.ToList());
        }

        [HttpPost]
        public IActionResult Create(Hall hall)
        {
            _context.Halls.Add(hall);
            _context.SaveChanges();
            return Ok(hall);
        }
    }
}