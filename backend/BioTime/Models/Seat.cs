namespace BioTime.Models
{
    public class Seat
    {
        public int Id { get; set; }

        public int SeatNumber { get; set; }

        // كل مقعد مربوط بوقت عرض معين
        public int ShowtimeId { get; set; }
        public Showtime? Showtime { get; set; }

        public int? BookingId { get; set; }
        public Booking? Booking { get; set; }
    }
}