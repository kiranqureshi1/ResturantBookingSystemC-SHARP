using System;
using Microsoft.AspNetCore.Hosting;
using Microsoft.AspNetCore.Http;
using Microsoft.Extensions.DependencyInjection;
using Microsoft.AspNetCore.Builder;
using controllers.BookingController;
using System.Collections.Generic;
using Microsoft.EntityFrameworkCore;
using System.Linq;
using System.Threading.Tasks;
using src.repository.bookingRepository;
using Microsoft.AspNetCore.Session;
using Microsoft.AspNetCore.Authentication;
using Microsoft.AspNetCore.StaticFiles;
using src.repositories.bookingRepository;
using src.model;
using Microsoft.Extensions.Configuration;


// using Microsoft.Extensions.DependencyInjection.ServiceDescriptor;

namespace src
{

     class Startup
    {

         static void ConfigureServices(IServiceCollection services, IConfiguration configuration)
        {
             services.AddDbContext<BookingDBContext>(options => options.UseNpgsql(configuration.GetConnectionString("DefaultConnection")));
            services.AddTransient<IBookingRepository, BookingRepository>();
        }

        public static void SeedData(IApplicationBuilder app)
        {
           var context = app.ApplicationServices.GetService<BookingDBContext>();
            {
                context.Database.Migrate();
            }
        }

        public void Configure(IApplicationBuilder app, IHostingEnvironment env)
        {
            app.Run(async(context) => 
            {
                var bookingController = new BookingController();
                var index = bookingController.getString();
                 await context.Response.WriteAsync(index);
                 SeedData(app);

            });
        }  
  

    }
//     class Startup
//     {
//         // public HellowWorldController hellowWorldController;
//         // static void ConfigureServices(IServiceCollection services)
//         // {
//         // }

//          static void ConfigureServices(IServiceCollection services, IConfiguration configuration)
//         {
//             // services.AddSingleton<IBookingRepository, BookingRepository>();
//             // services.AddDbContext<BookingDBContext>(options => options.UseSqlServer(configuration.GetConnectionString("Default")));
//              services.AddDbContext<BookingDBContext>(options => options.UseNpgsql(configuration.GetConnectionString("DefaultConnection")));
//             // services.AddIdentity<Booking, BookingRepository>()
//             // .AddDefaultTokenProviders();
//             services.AddTransient<IBookingRepository, BookingRepository>();
//             services.AddMvc();
//     //         services.ConfigureApplicationCookie(options =>
//     // {
//     //     options.Cookie.HttpOnly = true;
//     //     options.LoginPath = "/Login";
//     //     options.LogoutPath = "/Logout";
//     // });

//         //    var context = app.ApplicationServices.GetService<BookingDBContext>();
//         //     {
//         //         context.Database.Migrate();
//         //     }
//         }

//         public static void SeedData(IApplicationBuilder app)
//         {
//            var context = app.ApplicationServices.GetService<BookingDBContext>();
//             {
//                 context.Database.Migrate();
//             }
//         }

//         public void Configure(IApplicationBuilder app, IHostingEnvironment env)
//         {
//             app.Run(async(context) => 
//             {
//                 //  var hellowWorldController = new HellowWorldController();
//                 // var index = hellowWorldController.Index();
//                 // await context.Response.WriteAsync("Hello World");
//                 //  await context.Response.WriteAsync(index);
//                 //  this.hellowWorldController.Index();
//                 var bookingController = new BookingController();
//                 var index = bookingController.getString();
//                  await context.Response.WriteAsync(index);
//                  SeedData(app);
//                 // var hellowWorldController = new HellowWorldController();
//                 // var hashes = hellowWorldController.Index();
//                 //  await context.Response.WriteAsync(hashes);
//                 // app.UseStatusCodePages("text/plain", "status code page, status code: {0}");
//                 // app.UseDeveloperExceptionPage();
//                 // app.UseStaticFiles();
//                 // app.UseMvcWithDefaultRoute();

//             });
//         }  

// //         public void Configure(IApplicationBuilder app, IHostingEnvironment env, BookingDBContext db, SignInManager<User> s)
// // {
// //     if (env.IsDevelopment())
// //     {
// //         app.UseDeveloperExceptionPage();
// //         app.UseBrowserLink();
             
// //         if (s.UserManager.FindByNameAsync("dev").Result == null)
// //         {
// //             var result = s.UserManager.CreateAsync(new Booking{booking_id = 1, Name = "Table One Booked", Date = "24/3/2019"}, "Aut94L#G-a").Result;
// //         }
// //     }
 
// //     app.UseAuthentication();
// //     app.UseStaticFiles();
// //     app.UseMvc(routes =>
// //     {
// //         routes.MapRoute("default", "{controller=Home}/{action=Index}/{id?}");
// //         routes.MapSpaFallbackRoute("spa-fallback", new {controller = "Home", action = "Index"});
// //     });
// // } 

//         // public void Configure(IApplicationBuilder app)
//         // {
//         //     app.Run(async(context) => 
//         //     {
//         //         // await context.Response.WriteAsync("Hello World");
//         //         var hellowWorldController = new HellowWorldController();
//         //         var index = hellowWorldController.Index();
//         //          await context.Response.WriteAsync(index);
//         //     });
//         // }   

//     }
}