using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;
using CRUDDemoAPI.Models;
using Microsoft.AspNetCore.Builder;
using Microsoft.AspNetCore.Hosting;
using Microsoft.AspNetCore.HttpsPolicy;
using Microsoft.AspNetCore.Mvc;
using Microsoft.EntityFrameworkCore;
using Microsoft.Extensions.Configuration;
using Microsoft.Extensions.DependencyInjection;
using Microsoft.Extensions.Hosting;
using Microsoft.Extensions.Logging;

namespace CRUDDemo
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
            //dependancy inject
            services.AddDbContext<EmployeeDetailContext>(options => options.UseSqlServer(Configuration.GetConnectionString("ConnectString")));
            //document employee API
            services.AddSwaggerGen(config => {
                config.SwaggerDoc("v1", new Microsoft.OpenApi.Models.OpenApiInfo
                {
                    Title = "Employee Details API",
                    Version = "v1",
                    Description = "Used for CRUD demo application"
                });
            });

            services.AddControllers();

        }

        // This method gets called by the runtime. Use this method to configure the HTTP request pipeline.
        public void Configure(IApplicationBuilder app, IWebHostEnvironment env)
        {
            if (env.IsDevelopment())
            {
                app.UseDeveloperExceptionPage();
               
            }

            app.UseSwagger();

            app.UseSwaggerUI(config => {
                config.SwaggerEndpoint("/swagger/v1/swagger.json", "Employee Details API");
            } );

            app.UseHttpsRedirection();

            app.UseRouting();

            app.UseAuthorization();

            app.UseEndpoints(endpoints =>
            {
                endpoints.MapControllers();
            });
        }
    }
}
