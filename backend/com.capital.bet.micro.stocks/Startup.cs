using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;
using com.capital.bet.data;
using com.capital.bet.micro.stocks.Services;
using Microsoft.AspNetCore.Builder;
using Microsoft.AspNetCore.Hosting;
using Microsoft.AspNetCore.Http;
using Microsoft.Extensions.Configuration;
using Microsoft.Extensions.DependencyInjection;
using Microsoft.Extensions.Hosting;

namespace com.capital.bet.micro.stocks
{
    public class Startup
    {

        private IWebHostEnvironment _env { get; }
        public IConfiguration Configuration { get; }
        

        public Startup(IConfiguration configuration, IWebHostEnvironment env)
        {
            _env = env;
            Configuration = configuration;
        }

        // This method gets called by the runtime. Use this method to add services to the container.
        // For more information on how to configure your application, visit https://go.microsoft.com/fwlink/?LinkID=398940
        public void ConfigureServices(IServiceCollection services)
        {
            // Add Cache
            services.AddMemoryCache();
            // Add Services
            services.AddHostedService<StockPuller>();
            // Add Cors
            services.AddCors();

            services.Configure<ServiceConfiguration>(Configuration.GetSection("ServiceConfiguration"));
        }

        // This method gets called by the runtime. Use this method to configure the HTTP request pipeline.
        public void Configure(IApplicationBuilder app, IWebHostEnvironment env)
        {
            if (env.IsDevelopment())
            {
                app.UseDeveloperExceptionPage();
            }

            app.UseCors(builder => builder
                .AllowAnyOrigin()
                .AllowAnyHeader()
                .AllowAnyMethod());

            app.UseRouting();

            app.UseEndpoints(endpoints =>
            {
                endpoints.MapGet("/", async context =>
                {
                    await context.Response.WriteAsync("Capital Bet V 1.0");
                });
                
            });
        }
    }
}
