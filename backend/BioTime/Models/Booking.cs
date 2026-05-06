using System;
using System.Collections.Generic;

namespace BioTime.Models
{
    public class Booking
    {
        public int Id { get; set; }

        public string? Fornamn { get; set; }
        public string? Efternamn { get; set; }
        public string? Telefon { get; set; }
        public string? Email { get; set; }


        public string BookingNumber { get; set; } = Guid.NewGuid().ToString();

        public List<Seat> Seats { get; set; } = new();

        public int? ShowtimeId { get; set; }
        public Showtime? Showtime { get; set; }
    }
}