using BioTime.Models;

namespace BioTime.Services
{
    public class SeatService
    {
        private readonly AppDbContext _context;

        public SeatService(AppDbContext context)
        {
            _context = context;
        }

        // كل المقاعد حسب وقت العرض
        public List<Seat> GetSeatsByShowtime(int showtimeId)
        {
            return _context.Seats
                .Where(s => s.ShowtimeId == showtimeId)
                .ToList();
        }

        // إنشاء مقاعد لوقت عرض معين
        public void CreateSeats(int showtimeId, int numberOfSeats)
        {
            var seats = new List<Seat>();

            for (int i = 1; i <= numberOfSeats; i++)
            {
                seats.Add(new Seat
                {
                    SeatNumber = i,
                    ShowtimeId = showtimeId
                });
            }

            _context.Seats.AddRange(seats);
            _context.SaveChanges();
        }
    }
}