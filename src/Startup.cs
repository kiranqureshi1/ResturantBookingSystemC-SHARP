using System;
using Microsoft.AspNetCore.Hosting;
using Microsoft.AspNetCore.Http;
using Microsoft.Extensions.DependencyInjection;
using Microsoft.AspNetCore.Builder;
using controllers.BookingController;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;
using src.repository.bookingRepository;
using Microsoft.AspNetCore.Session;
using Microsoft.AspNetCore.Authentication;
using Microsoft.AspNetCore.StaticFiles;
using src.repositories.bookingRepository;


// using Microsoft.Extensions.DependencyInjection.ServiceDescriptor;

namespace src
{
    class Startup
    {
        // public HellowWorldController hellowWorldController;
        // static void ConfigureServices(IServiceCollection services)
        // {
        // }

         static void ConfigureServices(IServiceCollection services)
        {
            services.AddSingleton<IBookingRepository, BookingRepository>();
            services.AddMvc();
        }

        public void Configure(IApplicationBuilder app, IHostingEnvironment env)
        {
            app.Run(async(context) => 
            {
                //  var hellowWorldController = new HellowWorldController();
                // var index = hellowWorldController.Index();
                // await context.Response.WriteAsync("Hello World");
                //  await context.Response.WriteAsync(index);
                //  this.hellowWorldController.Index();
                // var bookingController = new BookingController();
                // var index = bookingController.getString();
                //  await context.Response.WriteAsync(index);
                var hellowWorldController = new HellowWorldController();
                var hashes = hellowWorldController.Index();
                 await context.Response.WriteAsync(hashes);
                // app.UseStatusCodePages();
                // app.UseDeveloperExceptionPage();
                // app.UseStaticFiles();
                // app.UseMvcWithDefaultRoute();

            });
        }   

        // public void Configure(IApplicationBuilder app)
        // {
        //     app.Run(async(context) => 
        //     {
        //         // await context.Response.WriteAsync("Hello World");
        //         var hellowWorldController = new HellowWorldController();
        //         var index = hellowWorldController.Index();
        //          await context.Response.WriteAsync(index);
        //     });
        // }   

    }
}