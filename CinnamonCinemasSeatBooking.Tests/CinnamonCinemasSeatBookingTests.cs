using CinnamonCinemasSeatBooking.Models;
using FluentAssertions;

namespace CinnamonCinemasSeatBooking.Tests;

public class CinnamonCinemasSeatBookingTests
{
    private MovieTheatre _MovieTheatre;
    private BookingManager _BookingManager;

    [SetUp]
    public void Setup()
    {
        _MovieTheatre = new MovieTheatre();
        _BookingManager = new BookingManager();
    }

    [Test]
    public void Get_the_Capacity_Of_Movie_Theater()
    {
        _MovieTheatre.SetCapacity(3, 5);
        _MovieTheatre.TotalCapacity.Should().Be(15);
        //AvailableSeatsInfo - May be Hashtable with (Row, NoOfSeatsinthisRowAvailable)
    }

    [Test]
    public void Book_Seats_According_To_Random_Number()
    {
        Random randomNumber = new Random();
        randomNumber.Next(1,4);
        _BookingManager.BookSeats(2).Should().Be(true);
    }
}