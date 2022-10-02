using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace CinnamonCinemasSeatBooking.Models
{
    public class MovieTheatre : IMovieTheatre
    {
        public int NoOfRows { get;  set; }
        public int NoOfSeatsInARow { get;  set; }

        public int TotalCapacity { get; set; }

        public void SetCapacity(int NoOfRows, int NoOfSeatsInaRow)
        {
            TotalCapacity = NoOfRows * NoOfSeatsInaRow;
        }

        public void AvailableSeatsInfo()
        {

        }
    }
}
