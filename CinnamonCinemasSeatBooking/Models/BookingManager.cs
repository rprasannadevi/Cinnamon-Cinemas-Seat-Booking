using System;
using System.Collections;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace CinnamonCinemasSeatBooking.Models
{
    public class BookingManager
    {
        public Seat? Seat { get; set; }

        List<Seat> SeatsList = new List<Seat>();
        public static Hashtable AvailableSeatsInfo = new Hashtable();

        public void SetCapacity(int NoOfRows, int NoOfSeatsInaRow)
        {
            char maxRowName = Convert.ToChar(65 + NoOfRows);
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



        /*public bool BookSeats(int NoOfSeats, Hashtable AvailableSeats)
        {
            Console.WriteLine(" Inside Book Seats: HASHTABLE OUTPUT");
            foreach (string Key in AvailableSeats.Keys)
                Console.WriteLine(String.Format("{0} : {1}", Key, AvailableSeats[Key]));
            return true;
        }*/

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
                //Console.WriteLine($"Row Name: {s.Key}");
                foreach (var seat in s)
                {
                    //Console.WriteLine($"\t Hello, my name is {seat.SeatNumber}");
                    seatsInfo += seat.SeatNumber + "/";
                }
                seatsInfo = seatsInfo.Substring(0, seatsInfo.Length - 1);
                //Console.WriteLine($"SeatInfo  {seatsInfo}");
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
            for (var c = 'A'; c <= 'C'; c++)
            {
                if (AvailableSeatsInfo.Count > 0)
                {
                    if (AvailableSeatsInfo.ContainsKey(c.ToString()))
                    {
                        SeatNames = AvailableSeatsInfo[c.ToString()]!.ToString();
                        String[] SeatList = SeatNames!.Split("/");
                        //Console.WriteLine($"SeatList.Count():  {SeatList.Count()}");
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
                        /*else
                        {
                            Console.WriteLine("No Seats Available");
                            return false;
                        }*/
                    }
                }
                else
                {
                    Console.WriteLine("Theatre is full. No Seats Available. Cannot book Tickets.");
                    return false;
                }
            }
            return true;
        }

    }
}
