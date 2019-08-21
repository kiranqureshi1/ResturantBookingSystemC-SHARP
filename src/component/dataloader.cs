using System;
using System.IO;
using Microsoft.AspNetCore.Hosting;
using Microsoft.EntityFrameworkCore;
using Microsoft.Extensions.DependencyInjection;
using src.model;
using src.repositories.bookingRepository;

namespace src.component
{
public class SaveToDataBase
    {
      static void LoadData()
        {
            // using(var db = new BookingDBContext())
            // {
            //   db.Bookings.Add(new Booking{booking_id = 1, Name = "Table One Booked", Date = "24/3/2019"});

       using (var context = new BookingDBContext())
          {
            // iBookingRepository IBookingRepository;
       var bookingRepository = new BookingRepository(context);
       var booking = new Booking{booking_id = 1, Name = "Table One Booked", Date = "24/3/2019"};
      //  IBookingRepository.save();
      bookingRepository.InsertBooking(booking);
       bookingRepository.Save();
        context.Bookings.Add(booking);
        context.SaveChanges();


        // db.Bookings.Add(new Booking{Name = "Table One Booked"});
              // db.SaveChanges();
              // var count = db.SaveChanges();

          }

        }

    }

}