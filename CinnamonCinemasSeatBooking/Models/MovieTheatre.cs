using System;
using System.Collections;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace CinnamonCinemasSeatBooking.Models
{
    public class MovieTheatre : IMovieTheatre
    {
        public int NoOfRows { get;  private set; }
        public int NoOfSeatsInARow { get;  private set; }
        public int TotalCapacity { get; private set; }

        public MovieTheatre(int iNoOfRows, int iNoOfSeatsInARow)
        {
            NoOfRows = iNoOfRows;
            NoOfSeatsInARow = iNoOfSeatsInARow;
            TotalCapacity = NoOfRows * NoOfSeatsInARow;
        }

    }  
}
