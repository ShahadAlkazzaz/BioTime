using BioTime.Models;
using Microsoft.EntityFrameworkCore;

namespace BioTime.Services
{
    public class BookingService
    {
        private readonly AppDbContext _context;

        public BookingService(AppDbContext context)
        {
            _context = context;
        }

        // 🔥 إنشاء حجز
        public Booking CreateBooking(string fornamn, string efternamn, string telefon, string email, List<int> seatIds)
        {
            var seats = _context.Seats
                .Where(s => seatIds.Contains(s.Id))
                .ToList();

            if (seats.Any(s => s.BookingId != null))
                throw new Exception("One or more seats already booked");

            var booking = new Booking
            {
                Fornamn = fornamn,
                Efternamn = efternamn,
                Telefon = telefon,
                Email = email,
                Seats = seats
            };

            _context.Bookings.Add(booking);

            foreach (var seat in seats)
            {
                seat.Booking = booking;
            }

            _context.SaveChanges();

            return booking;
        }

        // 🔍 البحث عن الحجز
        public Booking? GetByBookingNumber(string bookingNumber)
        {
            return _context.Bookings
                .Include(b => b.Seats)
                .FirstOrDefault(b => b.BookingNumber == bookingNumber);
        }

        // ❌ إلغاء الحجز
        public bool CancelBooking(string bookingNumber)
        {
            var booking = _context.Bookings
                .Include(b => b.Seats)
                .FirstOrDefault(b => b.BookingNumber == bookingNumber);

            if (booking == null)
                return false;

            foreach (var seat in booking.Seats)
            {
                seat.BookingId = null;
            }

            _context.Bookings.Remove(booking);
            _context.SaveChanges();

            return true;
        }
    }
}