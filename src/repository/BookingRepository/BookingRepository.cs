using System;
using System.Collections.Generic;
using System.Linq;
using System.Data;
using src.model;
using Microsoft.EntityFrameworkCore;
using src.repository.bookingRepository;

namespace src.repositories.bookingRepository
{
    public class BookingRepository : IBookingRepository, IDisposable
    {
        private BookingDBContext context;

        public BookingRepository(BookingDBContext context)
        {
            this.context = context;
        }
        public IEnumerable<Booking> GetBookings()
        {
            return context.Bookings.ToList();
        }

        public Booking GetBookingByID(int id)
        {
            return context.Bookings.Find(id);
        }

        public void InsertBooking(Booking booking)
        {
            context.Bookings.Add(booking);
        }

        public void DeleteBooking(int bookingID)
        {
            Booking booking = context.Bookings.Find(bookingID);
            context.Bookings.Remove(booking);
        }

        public void UpdateBooking(Booking booking)
        {
            context.Entry(booking).State = EntityState.Modified;
        }

        public void Save()
        {
            context.SaveChanges();
        }

        private bool disposed = false;

        protected virtual void Dispose(bool disposing)
        {
            if (!this.disposed)
            {
                if(disposing)
                {
                    context.Dispose();
                }
            }
            this.disposed = true;
        }

        public void Dispose()
        {
            Dispose(true);
            GC.SuppressFinalize(this);
        }
      
    }
}