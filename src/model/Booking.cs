using System;
// using System.Data.Entity.Core.Objects.ObjectQuery;
using Microsoft.EntityFrameworkCore;
using System.ComponentModel.DataAnnotations;
using Microsoft.AspNetCore.Hosting;
using Microsoft.Extensions.DependencyInjection;
using System.ComponentModel.DataAnnotations.Schema;

namespace src.model
{
    [Table("Booking")]
    public class Booking
    {
        [Key, Required]
         public int booking_id{ get; set;}

        [Required, MaxLength(1024)]
        public String Date { get; set;}
        // public Course course{get; set;}
        // public Customer course{get; set;}

        [Required, MaxLength(128)]
        public String Name { get; set;}

    }

    public class BookingDBContext : DbContext 
    {
        public DbSet<Booking> Bookings {get; set;}

        protected override void OnConfiguring(DbContextOptionsBuilder optionsBuilder)
        {
            optionsBuilder.UseSqlite("Data Source=booking.db");
        }
    }

}