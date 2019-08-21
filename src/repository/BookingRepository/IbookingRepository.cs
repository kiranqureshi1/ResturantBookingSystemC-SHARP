using System;
using System.Collections.Generic;
using src.model;

namespace src.repository.bookingRepository
{
    public interface IBookingRepository : IDisposable
    {
      IEnumerable<Booking> GetBookings();
      Booking GetBookingByID(int bookingId);
      void InsertBooking(Booking booking);
      void DeleteBooking(int bookingId);

      void UpdateBooking(Booking booking);
       void Save();
        
    }
}