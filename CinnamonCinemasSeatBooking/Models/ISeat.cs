using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace CinnamonCinemasSeatBooking.Models
{
    public interface ISeat
    {
        bool isAvailable { get; }
        char RowName { get; }
        string SeatNumber { get; }

    }
}
