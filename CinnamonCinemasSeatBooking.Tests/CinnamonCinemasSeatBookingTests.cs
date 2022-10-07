using System.Collections;
using CinnamonCinemasSeatBooking.Models;
using FluentAssertions;

namespace CinnamonCinemasSeatBooking.Tests;

public class CinnamonCinemasSeatBookingTests
{
    private MovieTheatre _MovieTheatre;
    private BookingManager _BookingManager;
    public Hashtable? AvailableSeats;

    [SetUp]
    public void Setup()
    {
        var noOfrows = 3;
        var noOfSeatsInARow = 5;
        _MovieTheatre = new MovieTheatre(noOfrows, noOfSeatsInARow);
        _BookingManager = new BookingManager(_MovieTheatre);
        _BookingManager.SetCapacity();
        _BookingManager.AvailableSeatsInformation();
    }

    [Test]
    public void Get_the_Capacity_Of_Movie_Theater()
    {
        _MovieTheatre.TotalCapacity.Should().Be(15);
    }

    [Test]
    public void Print_The_Available_Seats()
    {
        _BookingManager.AvailableSeatsInformation();
        Console.WriteLine(" Avaiable Seats are: ");
        foreach (string Key in BookingManager.AvailableSeatsInfo.Keys)
            Console.WriteLine(String.Format("{0} : {1}", Key, BookingManager.AvailableSeatsInfo[Key]));
    }

    [Test]
    public void Book_Seats_According_To_Random_Number()
    {
        Random randomNumber = new Random();
        int randNumber;
        bool isSeatsAvailable = true;
        while(isSeatsAvailable)
        {
            randNumber = randomNumber.Next(1, 4);
            isSeatsAvailable = _BookingManager.BookTickets(randNumber);
            //var ex = Assert.Throws<Exception>(() => _BookingManager.BookTickets(randNumber));
            //Assert.That(ex.Message, Is.EqualTo("Theatre is full. No Seats Available. Cannot book Tickets."));
            if (isSeatsAvailable == false)
               break;
        }
        _BookingManager.AvailableSeatsInformation();
        foreach (string Key in BookingManager.AvailableSeatsInfo.Keys)
            Console.WriteLine(String.Format("{0} : {1}", Key, BookingManager.AvailableSeatsInfo[Key]));
    }
}