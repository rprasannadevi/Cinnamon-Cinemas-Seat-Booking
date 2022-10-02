using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace CinnamonCinemasSeatBooking.Models
{
    public class BookingManager : MovieTheatre
    {
        public Seat Seat { get; set; }

        public bool BookSeats(int NoOfSeats)
        {
            return true;
        }
    }
}
