using Microsoft.AspNetCore.Mvc;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;
using Microsoft.AspNetCore.Builder;
using Microsoft.AspNetCore.Hosting;
using Microsoft.AspNetCore.Http;
using Microsoft.Extensions.DependencyInjection;
using Microsoft.Extensions.Configuration;
using BetAPI.Services;
using Microsoft.EntityFrameworkCore;

namespace BetAPI
{
    public class Startup
    {
        // This method gets called by the runtime. Use this method to add services to the container.
        // For more information on how to configure your application, visit https://go.microsoft.com/fwlink/?LinkID=398940
        // IServiceCollection: contains all the services already registered in the "Main" method, and it allows 
        // to add additional services. 

        // One way to access configuration values from the Startup class is to inject the IConfiguration interface
        // in the constructor and assign a property to the recieved configuration

        public Startup(IConfiguration configuration) =>
            Configuration = configuration;
        public IConfiguration Configuration { get; }

        
        public void ConfigureServices(IServiceCollection services)
        {
            services.AddDbContext<UserDbContext>(o =>
                   o.UseSqlServer(Configuration.GetConnectionString("DefaultConnection")));
            
            services.AddMvc();
        }

        // This method gets called by the runtime. Use this method to configure the HTTP request pipeline.
        
        // IHostingEnvironment: allows you to access the name of the envitonment (EnvironmentName), 
        // the root path for the web content files (the subdirectory wwwroot)

        // IApplicationBuilder: interface is used to add middleware to the HTTP request pipeline. When you 
        // invoke the "Use" method of this interface, you can build the HTTP request pipeline to define what
        // shuld be done in answer to a request. 

        //  UserDbContext: different provider to setup the database.
        public void Configure(IApplicationBuilder app, IHostingEnvironment env,
               UserDbContext userDbContext)
        {
            // Production environment the user doesn't see detail information on the exception (if any).
            if (env.IsDevelopment())
            {
                app.UseDeveloperExceptionPage();
            }
            
            // Will include HTML files that are inside wwwroot filer. Example:
            // localhost:5000/Hello.html
            app.UseStaticFiles();

            // Call the extension method to populate the user table (if not already populated).
            userDbContext.CreateSeedData();

            app.UseMvc();
        }
    }
}
