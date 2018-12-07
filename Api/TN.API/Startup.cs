using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;
using Microsoft.AspNetCore.Builder;
using Microsoft.AspNetCore.Hosting;
using Microsoft.EntityFrameworkCore;
using Microsoft.Extensions.Configuration;
using Microsoft.Extensions.DependencyInjection;
using Microsoft.Extensions.Logging;
using Microsoft.Extensions.Options;
using Serilog;
using TN.API.EF;
using TN.API.Models;

namespace TN.API
{
    public class Startup
    {
        public IConfigurationRoot _IConfigurationRoot { get; }

        public Startup(IHostingEnvironment iHostingEnvironment)
        {
            var builder = new ConfigurationBuilder()
            .SetBasePath(iHostingEnvironment.ContentRootPath)
            .AddJsonFile("appsettings.json", optional: true, reloadOnChange: true)
            .AddJsonFile("appsettings.Base.json", optional: true, reloadOnChange: true);
            Log.Logger = new LoggerConfiguration()
           .MinimumLevel.Information()
          // .MinimumLevel.Error()
          .WriteTo.RollingFile(System.IO.Path.Combine("logs/log-{Date}.txt"))
           .CreateLogger();
            _IConfigurationRoot = builder.Build();
        }

        // This method gets called by the runtime. Use this method to add services to the container.
        public void ConfigureServices(IServiceCollection services)
        {
            services.AddDbContext<TNFingerContext>(options => options.UseSqlServer(_IConfigurationRoot.GetConnectionString("DefaultConnection")), ServiceLifetime.Scoped);
            services.Configure<BaseSettings>(_IConfigurationRoot.GetSection("BaseSettings"));
            services.AddMvc();
        }

        // This method gets called by the runtime. Use this method to configure the HTTP request pipeline.
        public void Configure(IApplicationBuilder app, IHostingEnvironment env, ILoggerFactory loggerFactory)
        {
            if (env.IsDevelopment())
            {
                app.UseDeveloperExceptionPage();
            }
            loggerFactory.AddConsole(_IConfigurationRoot.GetSection("Logging"));
            loggerFactory.AddSerilog();

            // Shows UseCors with CorsPolicyBuilder.
            app.UseCors(builder =>
               builder.WithOrigins("http://localhost:8055","http://hocsinh.ebms.vn","http://localhost:8050"));
            app.UseMvc();
        }
    }
}
