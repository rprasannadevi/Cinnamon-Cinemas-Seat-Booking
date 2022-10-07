using System;
using System.Collections;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using CinnamonCinemasSeatBooking.Models;

namespace CinnamonCinemasSeatBooking.SeatBookingManager
{
    public class BookingManager
    {
        private readonly IMovieTheatre _MovieTheatre;
        private char maxRowName { get; set; }
        public Seat? Seat { get; set; }

        public BookingManager(IMovieTheatre MovieTheatre)
        {
            _MovieTheatre = MovieTheatre;
            maxRowName = Convert.ToChar(65 + _MovieTheatre.NoOfRows);
        }
        
        List<Seat> SeatsList = new List<Seat>();
        public static Hashtable AvailableSeatsInfo = new Hashtable();

        public void SetCapacity()
        {
            var NoOfRows = _MovieTheatre.NoOfRows;
            var NoOfSeatsInaRow = _MovieTheatre.NoOfSeatsInARow;
            string SeatNumber = "";

            for (var c = 'A'; c < maxRowName; c++)
            {
                for (var sCount = 1; sCount <= NoOfSeatsInaRow; sCount++)
                {
                    SeatNumber = c.ToString() + sCount.ToString();
                    SeatsList.Add(new Seat(true, c, SeatNumber));
                }
            }
        }

        public void AvailableSeatsInformation()
        {
            string seatsInfo = "";
            var getAvailableSeats = SeatsList
                                    .Where(seat => seat.IsAvailable == true)
                                    .OrderBy(seat => seat.RowName)
                                    .GroupBy(seat => seat.RowName);

            foreach (var s in getAvailableSeats)
            {
                seatsInfo = "";
                foreach (var seat in s)
                {
                    seatsInfo += seat.SeatNumber + "/";
                }
                seatsInfo = seatsInfo.Substring(0, seatsInfo.Length - 1);
                if (AvailableSeatsInfo.ContainsKey(s.Key.ToString()))
                    AvailableSeatsInfo[s.Key.ToString()] = seatsInfo;
                else
                    AvailableSeatsInfo.Add(s.Key.ToString(), seatsInfo);
            }
        }
        
        public bool BookTickets(int NoOfTickets)
        {
            Console.WriteLine($"NoOfTickets:  {NoOfTickets}");
            string? SeatNames = "";
            for (var c = 'A'; c <= maxRowName; c++)
            {
                if (AvailableSeatsInfo.Count > 0)
                {
                    if (AvailableSeatsInfo.ContainsKey(c.ToString()))
                    {
                        SeatNames = AvailableSeatsInfo[c.ToString()]!.ToString();
                        string[] SeatList = SeatNames!.Split("/");
                        if (SeatList.Count() > NoOfTickets)
                        {
                            for (int i = 0; i < NoOfTickets; i++)
                            {
                                var snumber = SeatList[i];
                                Console.WriteLine($"Allocated SeatNumber:  {snumber}");
                                var updateSeat = SeatsList
                                                 .First(seat => seat.SeatNumber == snumber);
                                updateSeat.IsAvailable = false;
                            }
                            AvailableSeatsInformation();
                            return true;
                        }
                        else if (SeatList.Count() <= NoOfTickets)
                        {
                            for (int i = 0; i < SeatList.Count(); i++)
                            {
                                var snumber = SeatList[i];
                                Console.WriteLine($"Allocated SeatNumber:  {snumber}");
                                var updateSeat = SeatsList
                                                 .First(seat => seat.SeatNumber == snumber);
                                updateSeat.IsAvailable = false;
                            }
                            AvailableSeatsInfo.Remove(c.ToString());
                            AvailableSeatsInformation();
                            NoOfTickets -= SeatList.Count();
                            continue;
                        }
                    }
                }
                else
                {
                    Console.WriteLine("Theatre is full. No Seats Available. Cannot book Tickets Further.");
                    return false;
                }
            }
            return true;
        }
        public bool BookTicketsUsingOnlyLinq(int NoOfTickets)
        {
            Console.WriteLine($"NoOfTickets:  {NoOfTickets}");
            var bookedTickets = 0;
            var getAvailableSeats = SeatsList
                                    .Where(seat => seat.IsAvailable == true)
                                    .OrderBy(seat => seat.RowName)
                                    .GroupBy(seat => seat.RowName);
            if (getAvailableSeats.Count() != 0)
            {
                foreach (var s in getAvailableSeats)
                {
                    foreach (var seat in s)
                    {
                        seat.IsAvailable = false;
                        Console.WriteLine($"Allocated SeatNumber:  {seat.SeatNumber}");
                        bookedTickets += 1;
                        if (bookedTickets == NoOfTickets)
                            return true;
                        else
                            continue;
                    }
                }
            }
            else
                return false;

            if (bookedTickets < NoOfTickets || getAvailableSeats.Count() == NoOfTickets)
                return false;

            return true;
        }
    }
}
