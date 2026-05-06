using BioTime.DTOs;
using BioTime.Models;
using BioTime.Services;
using Microsoft.AspNetCore.Mvc;
using System.Linq;

namespace BioTime.Controllers
{
    [Route("api/[controller]")]
    [ApiController]
    public class SeatsController : ControllerBase
    {
        private readonly AppDbContext _context;
        private readonly SeatService _service;

        public SeatsController(AppDbContext context, SeatService service)
        {
            _context = context;
            _service = service;
        }

        // ✅ GET seats with status (Available / Booked)
        [HttpGet("{showtimeId}")]
        public IActionResult GetSeats(int showtimeId)
        {
            var seats = _context.Seats
                .Where(s => s.ShowtimeId == showtimeId)
               .Select(s => new SeatDto
               {
                   Id = s.Id, // 🔥 مهم
                   SeatNumber = s.SeatNumber,
                   IsBooked = s.BookingId != null
               })
                .ToList();

            return Ok(seats);
        }

        // ✅ POST create seats
        [HttpPost]
        public IActionResult CreateSeats(int showtimeId, int numberOfSeats)
        {
            _service.CreateSeats(showtimeId, numberOfSeats);
            return Ok("Seats created");
        }
    }
}