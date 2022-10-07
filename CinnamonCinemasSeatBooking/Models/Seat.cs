using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace CinnamonCinemasSeatBooking.Models
{
    public class Seat : ISeat
    {
        public bool IsAvailable { get; set; }
        public char RowName { get; protected set; }
        public string SeatNumber { get; protected set;  }

        public Seat(bool isavailable, char rowname, string seatnumber)
        {
            IsAvailable = isavailable;
            RowName = rowname;
            SeatNumber = seatnumber;
        }
    }
}
