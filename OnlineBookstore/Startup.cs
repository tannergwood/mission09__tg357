using Microsoft.AspNetCore.Builder;
using Microsoft.AspNetCore.Hosting;
using Microsoft.AspNetCore.Http;
using Microsoft.EntityFrameworkCore;
using Microsoft.Extensions.Configuration;
using Microsoft.Extensions.DependencyInjection;
using Microsoft.Extensions.Hosting;
using OnlineBookstore.Models;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;

namespace OnlineBookstore
{
    public class Startup
    {
        public IConfiguration Configuration { get; set; }

        public Startup (IConfiguration temp)
        {
            Configuration = temp;
        }


        public void ConfigureServices(IServiceCollection services)
        {
            //Add in Usage of Controllers
            services.AddControllersWithViews();

            //Connect up with the Database
            services.AddDbContext<BookstoreContext>(options =>
            {
                options.UseSqlite(Configuration["ConnectionStrings:BookstoreDBConnection"]);
            });

            services.AddScoped<IBookstoreRepository, EFBookstoreRepository>();
        }

        //This configures the HTTP Pipeline
        public void Configure(IApplicationBuilder app, IWebHostEnvironment env)
        {
            if (env.IsDevelopment())
            {
                app.UseDeveloperExceptionPage();
            }
            //allow usage of wwwroot folder
            app.UseStaticFiles();

            app.UseRouting();

            app.UseEndpoints(endpoints =>
            {
                //make the urls pretty
                endpoints.MapControllerRoute("pagination",
                    "Page{pageNum}",
                    new { Controller = "Home", action = "Index" });
                //just use default controller endpoints
                endpoints.MapDefaultControllerRoute();
            });
        }
    }
}
