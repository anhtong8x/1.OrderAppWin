using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using Microsoft.AspNetCore.Authentication.JwtBearer;
using Microsoft.AspNetCore.Builder;
using Microsoft.AspNetCore.Hosting;
using Microsoft.AspNetCore.HttpsPolicy;
using Microsoft.AspNetCore.Identity;
using Microsoft.AspNetCore.Mvc;
using Microsoft.EntityFrameworkCore;
using Microsoft.Extensions.Configuration;
using Microsoft.Extensions.DependencyInjection;
using Microsoft.Extensions.Logging;
using Microsoft.Extensions.Options;
using Microsoft.IdentityModel.Tokens;
using Serilog;
using TN.API.Extention;
using TN.API.Services;
using TN.Domain.Model;
using TN.Infrastructure;
using TN.Infrastructure.Interfaces;
using TN.Infrastructure.Interfaces.Manager;
using TN.Infrastructure.Repositories;
using TN.Infrastructure.Repositories.Manager;

namespace TN.API
{
    public class Startup
    {
        private readonly IConfiguration Configuration;

        public Startup(IHostingEnvironment iHostingEnvironment)
        {
            var builder = new ConfigurationBuilder()
             .SetBasePath(iHostingEnvironment.ContentRootPath)
             .AddJsonFile("appsettings.json", optional: true, reloadOnChange: true)
             .AddJsonFile("appsettings.Api.json", optional: true, reloadOnChange: true)
             .AddJsonFile("appsettings.Email.json", optional: true, reloadOnChange: true)
             .AddJsonFile("appsettings.Log.json", optional: true, reloadOnChange: true)
             .AddEnvironmentVariables();
            if (iHostingEnvironment.IsDevelopment())
            {
                Serilog.Log.Logger = new LoggerConfiguration().MinimumLevel.Information().WriteTo.RollingFile(System.IO.Path.Combine("logs/log-{Date}.txt")).CreateLogger();
            }
            else
            {
                Serilog.Log.Logger = new LoggerConfiguration().MinimumLevel.Error().WriteTo.RollingFile(System.IO.Path.Combine("logs/log-{Date}.txt")).CreateLogger();
            }
            Configuration = builder.Build();
        }

        // This method gets called by the runtime. Use this method to add services to the container.
        public void ConfigureServices(IServiceCollection services)
        {
            string a = Configuration["EmailSettings:Email"];
            // Add Custom Claims processor
            services.Configure<ApiSettings>(Configuration.GetSection("ApiSettings"));
            services.Configure<LogSettings>(Configuration.GetSection("LogSettings"));
            services.Configure<EmailSettings>(Configuration.GetSection("EmailSettings"));

            services.AddDbContext<ApplicationContext>(options => options.UseSqlServer(Configuration.GetConnectionString("DefaultConnection")), ServiceLifetime.Scoped);
            services.AddIdentity<ApplicationUser, ApplicationRole>().AddEntityFrameworkStores<ApplicationContext>().AddDefaultTokenProviders();

            services.AddAuthentication(options =>
            {
                options.DefaultAuthenticateScheme = JwtBearerDefaults.AuthenticationScheme;
                options.DefaultChallengeScheme = JwtBearerDefaults.AuthenticationScheme;
            })
             .AddJwtBearer(options =>
             {
                 options.TokenValidationParameters =
                      new TokenValidationParameters
                      {
                          ValidateIssuer = true,
                          ValidateAudience = true,
                          ValidateLifetime = true,
                          ValidateIssuerSigningKey = true,

                          ValidIssuer = Configuration["ApiSettings:TokenIssuer"],
                          ValidAudience = Configuration["ApiSettings:TokenAudience"],
                          IssuerSigningKey = new SymmetricSecurityKey(Encoding.ASCII.GetBytes(Configuration["ApiSettings:TokenKey"]))
                      };
             });

            services.AddScoped<IUserRepository, UserRepository>();
            services.AddScoped<IUserManagerSevice, UserManagerSevice>();
            services.AddScoped<ILogRepository, LogRepository>();

            services.AddScoped<IEmailSenderRepository, EmailSenderRepository>();
            services.AddScoped<IFileRepository, FileRepository>();

			// khai bao them service ------------------
			services.AddScoped<ITableRepository, TableRepository>();
			services.AddScoped<ITableSevice, TableSevice>();

			services.AddScoped<IBillRepository, BillRepository>();
			services.AddScoped<IBillService, BillService>();

			services.AddScoped<IBillDetailRepository, BillDetailRepository>();
			services.AddScoped<IBillDetailService, BillDetailService>();


			services.AddMvc().SetCompatibilityVersion(CompatibilityVersion.Version_2_1);
        }

        // This method gets called by the runtime. Use this method to configure the HTTP request pipeline.
        public void Configure(IApplicationBuilder app, IHostingEnvironment env, ILoggerFactory loggerFactory)
        {
            loggerFactory.AddConsole(Configuration.GetSection("Logging"));
            loggerFactory.AddSerilog();
            loggerFactory.AddDebug();
            app.UseAuthentication();
            if (env.IsDevelopment())
            {
                app.UseDeveloperExceptionPage();
            }
            else
            {
                app.UseExceptionHandler("/Error");
                app.UseHsts();
            }
            app.UseHttpsRedirection();
            app.UseMvc();
        }
    }
}
