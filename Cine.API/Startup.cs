using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;
//using Cine.API.Models;
using Microsoft.AspNetCore.Builder;
using Microsoft.AspNetCore.Hosting;
using Microsoft.AspNetCore.HttpsPolicy;
using Microsoft.AspNetCore.Mvc;
using Microsoft.Extensions.Configuration;
using Microsoft.Extensions.DependencyInjection;
using Microsoft.Extensions.Logging;
using Microsoft.Extensions.Options;
using Microsoft.EntityFrameworkCore;
using Cine.API.Repositories.Interfaces;
using Cine.API.Repositories;
using Cine.API.Models;

namespace Cine.API
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
            services.AddDbContext<CineContext>(options => options.UseSqlServer(Configuration.GetConnectionString("DefaultConnection")));
            services.AddMvc().SetCompatibilityVersion(CompatibilityVersion.Version_2_2);
            services.AddTransient<IFuncionesRepository, FuncionesRepository>();
            services.AddTransient<IReservaRepository, ReservaRepository>();
            services.AddSingleton(Configuration);

            services.AddSwaggerGen(options =>
            {
                options.DescribeAllEnumsAsStrings();
                options.SwaggerDoc("v1", new Swashbuckle.AspNetCore.Swagger.Info()
                {
                    Title = "Cine - Cinema HTTP API",
                    Version = "v1",
                    Description = "Cinema Api",
                    TermsOfService = "Cine"
                });
            });
        }

        // This method gets called by the runtime. Use this method to configure the HTTP request pipeline.
        public void Configure(IApplicationBuilder app, IHostingEnvironment env, ILoggerFactory loggerFactory)
        {
            if (env.IsDevelopment())
            {
                loggerFactory.AddConsole(Configuration.GetSection("Logging"));
                app.UseDeveloperExceptionPage();
            }
            else
            {
                // The default HSTS value is 30 days. You may want to change this for production scenarios, see https://aka.ms/aspnetcore-hsts.
                app.UseHsts();
            }
            //loggerFactory.AddFile(Configuration.GetValue<string>("CineConfig:LogPath"));
            app.UseSwagger().UseSwaggerUI(c => {
                c.SwaggerEndpoint($"/swagger/v1/swagger.json", "Cine API V1");
            });


            app.UseHttpsRedirection();
            app.UseMvc();
        }
    }
}
