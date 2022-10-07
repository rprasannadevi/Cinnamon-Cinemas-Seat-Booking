using System;
using System.Collections;
using System.Collections.Generic;
using System.Linq;
using System.Text;

namespace CinnamonCinemasSeatBooking.Models
{
    public interface IMovieTheatre
    {
        int NoOfRows { get; }
        int NoOfSeatsInARow { get; }
        int TotalCapacity { get; }
    }
}