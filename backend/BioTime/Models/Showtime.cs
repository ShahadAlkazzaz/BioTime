using System;

namespace BioTime.Models
{
    public class Showtime
    {
        public int Id { get; set; }

        public DateTime StartTime { get; set; }

        // العلاقات
        public int MovieId { get; set; }
        public Movie? Movie { get; set; }

        public int HallId { get; set; }
        public Hall? Hall { get; set; }     
    }
}