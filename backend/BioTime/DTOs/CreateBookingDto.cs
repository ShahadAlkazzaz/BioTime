using System.Collections.Generic;

namespace BioTime.DTOs
{
    public class CreateBookingDto
    {
        public string? Fornamn { get; set; }
        public string? Efternamn { get; set; }
        public string? Telefon { get; set; }
        public string? Email { get; set; }


        public List<int> SeatIds { get; set; } = new();

        public int ShowtimeId { get; set; }

    }
}