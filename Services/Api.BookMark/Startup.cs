using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;
using Microsoft.AspNetCore.Builder;
using Microsoft.AspNetCore.Hosting;
using Microsoft.AspNetCore.HttpsPolicy;
using Microsoft.AspNetCore.Mvc;
using Microsoft.EntityFrameworkCore;
using Microsoft.Extensions.Configuration;
using Microsoft.Extensions.DependencyInjection;
using Microsoft.Extensions.Hosting;
using Microsoft.Extensions.Logging;

namespace Api.BookMark
{
    public class Startup
    {
        public Startup(IConfiguration configuration)
        {
            Configuration = configuration;
        }

        public IConfiguration Configuration { get; }

        // This method gets called by the runtime. Use this method to add services to the container.
        public void ConfigureServices(IServiceCollection services)
        {
            //// MSSQL server  
            //services.AddDbContext<AppDbContext>(options =>
            //   options.UseSqlServer(Configuration["ConnectionStrings:DefaultConnection"]));

            //// SqlLite
            //services.AddDbContext<AppDbContext>(options =>
            //   options.UseSqlite(Configuration["ConnectionStrings:sqllite-connection"]));

            // In memory database
            //services.AddDbContext<AppDbContext>(options => options.UseInMemoryDatabase(databaseName: "arcoda-bookmarks"));

            // Add Postgress
            services.AddDbContext<AppDbContext>(options =>
                options.UseNpgsql(Configuration["ConnectionStrings:postgres-connection"]));

            services.AddControllers();

            // Allow anything till prod
            services.AddCors(options =>
            {
                services.AddCors(options =>
                {
                    options.AddPolicy("EnableCORS",
                       builder => builder.AllowAnyOrigin()
                       .AllowAnyMethod()
                       .AllowAnyHeader());
                });
            });
        }

        // This method gets called by the runtime. Use this method to configure the HTTP request pipeline.
        public void Configure(IApplicationBuilder app, IWebHostEnvironment env)
        {
            if (env.IsDevelopment())
            {
                app.UseDeveloperExceptionPage();
            }

            //app.UseHttpsRedirection();
            app.UseRouting();
            app.UseCors("EnableCORS");

            //app.UseAuthentication();
            app.UseAuthorization();

            app.UseEndpoints(endpoints =>
            {
                endpoints.MapControllers();
            });
        }
    }
}
