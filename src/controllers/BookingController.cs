using System;
using System.Data;
using System.Linq;
using System.Web.Mvc;
using System.Web;
using Microsoft.AspNetCore.Http;
using src.model;
using src.repositories.bookingRepository;
using PagedList;
using Microsoft.AspNetCore.Hosting;
using src.repository.bookingRepository;
using Microsoft.EntityFrameworkCore;
using System.Collections.Generic;

namespace controllers.BookingController
{
    // [RoutePrefix("api/bookings")]
    public class BookingController : Controller
    {

        private IBookingRepository bookingRepository;
        public BookingController()
        {
          this.bookingRepository = new BookingRepository(new BookingDBContext());
        }
        public BookingController(BookingRepository bookingRepository)
        {
            this.bookingRepository = bookingRepository;
        }

        [Route("bookings")]
        [HttpGet]

        public IEnumerable<Booking> Index() => bookingRepository.GetBookings();
     public string getString()
        {
            return "This is my default action..";
        }

      //    public ViewResult Index(string sortOrder, string currentFilter, string searchString, int? page)
      // {
      //    ViewBag.CurrentSort = sortOrder;
      //    ViewBag.NameSortParm = String.IsNullOrEmpty(sortOrder) ? "name_desc" : "";
      //    ViewBag.DateSortParm = sortOrder == "Date" ? "date_desc" : "Date";

      //    if (searchString != null)
      //    {
      //       page = 1;
      //    }
      //    else
      //    {
      //       searchString = currentFilter;
      //    }
      //    ViewBag.CurrentFilter = searchString;

      //    var bookings = from s in bookingRepository.GetBookings()
      //                   select s;
      //    if (!String.IsNullOrEmpty(searchString))
      //    {
      //       bookings = bookings.Where(s => s.Name.ToUpper().Contains(searchString.ToUpper()));
      //    }
      //    switch (sortOrder)
      //    {
      //       case "name_desc":
      //          bookings = bookings.OrderByDescending(s => s.Name);
      //          break;
      //       case "Date":
      //          bookings = bookings.OrderBy(s => s.Date);
      //          break;
      //       case "date_desc":
      //          bookings = bookings.OrderByDescending(s => s.Date);
      //          break;
      //       default:  // Name ascending
      //          bookings = bookings.OrderBy(s => s.Name);
      //          break;
      //    }

      //    // int pageSize = 3;
      //    int pageNumber = (page ?? 1);
      //    return View(bookings.ToList());
      // }

      //
      // GET: /Student/Details/5
      [Route("{id:int}")]
      [HttpGet]
      public ViewResult Details(int id)
      {
         Booking booking = bookingRepository.GetBookingByID(id);
         return View(booking);
      }

    }

}
