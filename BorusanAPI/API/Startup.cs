using Business.Abstract;
using Business.Concrete;
using DataAccess.Abstract;
using DataAccess.Concrete;
using Microsoft.AspNetCore.Builder;
using Microsoft.AspNetCore.Hosting;
using Microsoft.AspNetCore.Http;
using Microsoft.Extensions.DependencyInjection;
using Microsoft.Extensions.Hosting;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;

namespace API
{
    public class Startup
    {
        // This method gets called by the runtime. Use this method to add services to the container.
        // For more information on how to configure your application, visit https://go.microsoft.com/fwlink/?LinkID=398940
        public void ConfigureServices(IServiceCollection services)
        {
            services.AddControllers(); //add controllers

            #region InterfaceList
            services.AddSingleton<IOrderService, OrderService>();
            services.AddSingleton<IOrderRepository, OrderRepository>();
            services.AddSingleton<IStatusService, StatusService>();
            services.AddSingleton<IStatusRepository, StatusRepository>();
            services.AddSingleton<IMaterialService, MaterialService>();
            services.AddSingleton<IMaterialRepository, MaterialRepository>();
            #endregion
        }

        // This method gets called by the runtime. Use this method to configure the HTTP request pipeline.
        public void Configure(IApplicationBuilder app, IWebHostEnvironment env)
        {
            if (env.IsDevelopment())
            {
                app.UseDeveloperExceptionPage();
            }

            app.UseRouting();

            app.UseEndpoints(endpoints =>
            {
                endpoints.MapControllers(); //use controllers for route
                /*
                 endpoints.MapGet("/", async context =>
                 {
                     await context.Response.WriteAsync("Hello World!");
                 });
                */
            });
        }
    }
}
