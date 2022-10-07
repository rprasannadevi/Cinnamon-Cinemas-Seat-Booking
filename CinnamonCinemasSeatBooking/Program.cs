// See https://aka.ms/new-console-template for more information
using System.Collections;
using System.Runtime.CompilerServices;
using CinnamonCinemasSeatBooking.Models;
using CinnamonCinemasSeatBooking.SeatBookingManager;

Console.WriteLine("Hello, World!");

var _MovieTheatre = new MovieTheatre(3, 5);
var _BookingManager =  new BookingManager(_MovieTheatre);

_BookingManager.SetCapacity();

Random randomNumber = new Random();
int randNumber;
bool isSeatsAvailable = true;

while (isSeatsAvailable)
{
    randNumber = randomNumber.Next(1, 4);
    isSeatsAvailable = _BookingManager.BookTicketsUsingOnlyLinq(randNumber);
    if (isSeatsAvailable == false)
    {
        Console.WriteLine("Theatre is full. No Seats Available. Cannot book Tickets Further.");
        break;
    }
}

/*Console.WriteLine(" Available Seats are: ");
foreach (string Key in BookingManager.AvailableSeatsInfo.Keys)
    Console.WriteLine(String.Format("{0} : {1}", Key, BookingManager.AvailableSeatsInfo[Key]));*/
