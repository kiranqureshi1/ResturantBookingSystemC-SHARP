using System;
using Microsoft.AspNetCore.Hosting;
using Microsoft.AspNetCore.Http;
using Microsoft.Extensions.DependencyInjection;
using Microsoft.AspNetCore.Builder;
// using Microsoft.Extensions.DependencyInjection.ServiceDescriptor;

namespace src
{
    class Startup
    {
        static void ConfigureServices(IServiceCollection services)
        {
        }

        public void Configure(IApplicationBuilder app)
        {
            app.Run(async(context) => 
            {
                await context.Response.WriteAsync("Hello World");
            });
        }
        

    }
}