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

            services.AddRazorPages();

            services.AddDistributedMemoryCache();

            services.AddSession();
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

            app.UseSession();

            app.UseRouting();

            app.UseEndpoints(endpoints =>
            {
                endpoints.MapControllerRoute("typepage",
                    "{bookCategory}/Page{pageNum}",
                    new { Controller = "Home", action = "Index" });

                //make the urls pretty
                endpoints.MapControllerRoute("pagination",
                    "Page{pageNum}",
                    new { Controller = "Home", action = "Index" });

                endpoints.MapControllerRoute("type",
                    "{bookCategory}",
                    new { Controller = "Home", action = "Index", pageNum = 1 }); 
                
                
                //just use default controller endpoints
                endpoints.MapDefaultControllerRoute();

                endpoints.MapRazorPages();
            });
        }
    }
}
