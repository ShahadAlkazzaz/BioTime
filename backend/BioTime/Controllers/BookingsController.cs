using BioTime.DTOs;
using BioTime.Models;
using Microsoft.AspNetCore.Mvc;
using Microsoft.EntityFrameworkCore;
using System.Linq;

namespace BioTime.Controllers
{
    [ApiController]
    [Route("api/[controller]")]
    public class BookingsController : ControllerBase
    {
        private readonly AppDbContext _context;

        public BookingsController(AppDbContext context)
        {
            _context = context;
        }

        [HttpGet("{bookingNumber}")]
        public IActionResult GetBooking(string bookingNumber)
        {
            var booking = _context.Bookings
                .Include(b => b.Showtime)
                    .ThenInclude(st => st.Movie)
                .Include(b => b.Showtime)
                    .ThenInclude(st => st.Hall)
                .Include(b => b.Seats)
                .FirstOrDefault(b => b.BookingNumber == bookingNumber);

            if (booking == null)
                return NotFound("Booking not found");

            return Ok(new
            {
                booking.BookingNumber,
                booking.Fornamn,
                booking.Efternamn,
                booking.Email,
                booking.Telefon,

                Movie = booking.Showtime!.Movie!.Title,
                Hall = booking.Showtime!.Hall!.Name,
                Time = booking.Showtime!.StartTime,

                Seats = booking.Seats.Select(s => s.SeatNumber)
            });
        }

        [HttpPost]
        public IActionResult CreateBooking(CreateBookingDto dto)
        {
            // 1. نجيب المقاعد من الداتابيس
            var seats = _context.Seats
                .Where(s => dto.SeatIds.Contains(s.Id) && s.BookingId == null)
                .ToList();

            // 2. نتأكد المقاعد مو محجوزة
            if (seats.Count != dto.SeatIds.Count)
                return BadRequest("Some seats are already booked!");

            // 3. نسوي الحجز
            var booking = new Booking
            {
                Fornamn = dto.Fornamn,
                Efternamn = dto.Efternamn,
                Telefon = dto.Telefon,
                Email = dto.Email,
                ShowtimeId = dto.ShowtimeId, // 🔥 هذا المهم
                Seats = seats
            };

            // 4. نخزن
            _context.Bookings.Add(booking);
            _context.SaveChanges();

            _context.Entry(booking)
    .Reference(b => b.Showtime)
    .Query()
    .Include(st => st.Movie)
    .Include(st => st.Hall)
    .Load();

            // 5. نرجع رقم الحجز
            return Ok(new
            {
                booking.BookingNumber,
                booking.Fornamn,
                booking.Efternamn,
                booking.Telefon,
                booking.Email,

                Movie = booking.Showtime?.Movie?.Title,
                Hall = booking.Showtime?.Hall?.Name,
                Time = booking.Showtime?.StartTime,

                Seats = seats.Select(s => s.SeatNumber)
            });
        }
    }
}