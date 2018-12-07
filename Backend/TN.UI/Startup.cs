using System;
using Microsoft.AspNetCore.Builder;
using Microsoft.AspNetCore.Identity;
using Microsoft.EntityFrameworkCore;
using Microsoft.AspNetCore.Hosting;
using Microsoft.Extensions.Configuration;
using Microsoft.Extensions.DependencyInjection;
using Microsoft.AspNetCore.Localization;
using System.Globalization;
using Microsoft.AspNetCore.Http;
using Serilog;
using Microsoft.Extensions.Logging;
using TN.Infrastructure;
using TN.Domain.Model;
using TN.Infrastructure.Interfaces;
using TN.Infrastructure.Repositories;
using TN.UI.Extensions;
using Newtonsoft.Json.Serialization;
using Newtonsoft.Json;
using Microsoft.AspNetCore.ResponseCompression;
using Microsoft.Extensions.Options;
using Microsoft.AspNetCore.Mvc;

namespace TN.UI
{
    public class Startup
    {
        public IConfigurationRoot _iConfigurationRoot { get; }
        public Startup(IHostingEnvironment iHostingEnvironment)
        {
            var builder = new ConfigurationBuilder()
              .SetBasePath(iHostingEnvironment.ContentRootPath)
              .AddJsonFile("appsettings.json", optional: true, reloadOnChange: true)
              .AddJsonFile("appsettings.Base.json", optional: true, reloadOnChange: true)
              .AddJsonFile("appsettings.Email.json", optional: true, reloadOnChange: true)
              .AddJsonFile("appsettings.Log.json", optional: true, reloadOnChange: true).AddEnvironmentVariables();
            if(iHostingEnvironment.IsDevelopment())
            {
                Serilog.Log.Logger = new LoggerConfiguration().MinimumLevel.Information().WriteTo.RollingFile(System.IO.Path.Combine("logs/log-{Date}.txt")).CreateLogger();
            }
           else
            {
                Serilog.Log.Logger = new LoggerConfiguration().MinimumLevel.Error().WriteTo.RollingFile(System.IO.Path.Combine("logs/log-{Date}.txt")).CreateLogger();
            }
            _iConfigurationRoot = builder.Build();
        }

        // This method gets called by the runtime. Use this method to add services to the container.
        public void ConfigureServices(IServiceCollection services)
        {
            services.Configure<CookiePolicyOptions>(options =>
            {
                // This lambda determines whether user consent for non-essential cookies is needed for a given request.
                options.CheckConsentNeeded = context => true;
                options.MinimumSameSitePolicy = SameSiteMode.None;
            });


            services.AddDbContext<ApplicationContext>(options => options.UseSqlServer(_iConfigurationRoot.GetConnectionString("DefaultConnection")), ServiceLifetime.Scoped);
            services.AddIdentity<ApplicationUser, ApplicationRole>().AddEntityFrameworkStores<ApplicationContext>().AddDefaultTokenProviders();
            // Add Custom Claims processor
            services.AddScoped<IUserClaimsPrincipalFactory<ApplicationUser>, CustomClaimsPrincipalFactory>();
            services.Configure<BaseSettings>(_iConfigurationRoot.GetSection("BaseSettings"));
            services.Configure<LogSettings>(_iConfigurationRoot.GetSection("LogSettings"));
            services.Configure<EmailSettings>(_iConfigurationRoot.GetSection("EmailSettings"));

            services.AddMemoryCache();

            services.AddSession(options =>
            {
                options.IdleTimeout = TimeSpan.FromMinutes(30);
            });

            services.Configure<IdentityOptions>(options =>
            {
                // Password settings
                options.Password.RequireDigit = true;
                options.Password.RequiredLength = 8;
                options.Password.RequireNonAlphanumeric = false;
                options.Password.RequireUppercase = true;
                options.Password.RequireLowercase = false;
                options.Password.RequiredUniqueChars = 6;

                // Lockout settings
                options.Lockout.DefaultLockoutTimeSpan = TimeSpan.FromMinutes(30);
                options.Lockout.MaxFailedAccessAttempts = 10;
                options.Lockout.AllowedForNewUsers = true;

                // User settings
                options.User.RequireUniqueEmail = true;
            });

            services.ConfigureApplicationCookie(options =>
            {
                // Cookie settings
                options.Cookie.HttpOnly = true;
                options.Cookie.Expiration = TimeSpan.FromDays(150);
                options.LoginPath = "/Login"; // If the LoginPath is not set here, ASP.NET Core will default to /Account/Login
                options.LogoutPath = "/Logout"; // If the LogoutPath is not set here, ASP.NET Core will default to /Account/Logout
                options.AccessDeniedPath = "/Admin/AccessDenied"; // If the AccessDeniedPath is not set here, ASP.NET Core will default to /Account/AccessDenied
                options.SlidingExpiration = true;
            });

            services.Configure<RequestLocalizationOptions>(options =>
            {
                var supportedCultures = new[]
                {
                    new CultureInfo("vi")
                    //new CultureInfo("en")
                };
                options.DefaultRequestCulture = new RequestCulture(culture: "vi", uiCulture: "vi");
                options.SupportedCultures = supportedCultures;
                options.SupportedUICultures = supportedCultures;
            });
            // Ngôn ngữ End
            // Add application services.
            services.AddScoped<IEmailSenderRepository, EmailSenderRepository>();
            services.AddScoped<IUserRepository, UserRepository>();
            services.AddScoped<IRoleAreaRepository, RoleAreaRepository>();
            services.AddScoped<IRoleGroupRepository, RoleGroupRepository>();
            services.AddScoped<IRoleControllerRepository, RoleControllerRepository>();
            services.AddScoped<IRoleControllerRepository, RoleControllerRepository>();
            services.AddScoped<IRoleActionRepository, RoleActionRepository>();
            services.AddScoped<IRoleDetailRepository, RoleDetailRepository>();
            services.AddScoped<ILogRepository, LogRepository>();
            services.AddScoped<IEmailSenderRepository, EmailSenderRepository>();
            services.AddScoped<IFileRepository, FileRepository>(); 
            services.AddScoped<IRoleRepository, RoleRepository>();
            //Gzip
            services.Configure<GzipCompressionProviderOptions>(options => options.Level = System.IO.Compression.CompressionLevel.Optimal);
            services.AddResponseCompression(options =>
            {
                options.MimeTypes = new[]
                {
                    "text/plain",
                    "text/css",
                    "application/javascript",
                    "text/html",
                    "application/xml",
                    "text/xml",
                    "application/json",
                    "text/json",
                    "image/svg+xml"
                };
            });

            services.AddMvc().AddJsonOptions(options =>
            {
                options.SerializerSettings.ContractResolver = new CamelCasePropertyNamesContractResolver();
                options.SerializerSettings.ReferenceLoopHandling = ReferenceLoopHandling.Ignore;
            }).SetCompatibilityVersion(CompatibilityVersion.Version_2_1);
        }

        // This method gets called by the runtime. Use this method to configure the HTTP request pipeline.
        public void Configure(IApplicationBuilder app, IHostingEnvironment env, ILoggerFactory loggerFactory)
        {
            loggerFactory.AddConsole(_iConfigurationRoot.GetSection("Logging"));
            loggerFactory.AddSerilog();
            loggerFactory.AddDebug();

            if (env.IsDevelopment())
            {
                app.UseDeveloperExceptionPage();
                app.UseDatabaseErrorPage();
            }
            else
            {
                app.UseExceptionHandler("/Home/Error");
                app.UseHsts();
            }
            app.UseSession();
            //Gzip
            app.UseResponseCompression();
            var localizationOption = app.ApplicationServices.GetService<IOptions<RequestLocalizationOptions>>();
            app.UseRequestLocalization(localizationOption.Value);

            AppHttpContext.Services = app.ApplicationServices;

            app.UseHttpsRedirection();
            app.UseStaticFiles();
            app.UseCookiePolicy();

            app.UseAuthentication();
            app.UseMvc(routes =>
            {
                routes.MapRoute(
                name: "areas",
                template: "Admin/{area:exists}/{controller=Home}/{action=Index}/{id?}"
              );
                routes.MapRoute(
                    name: "default",
                    template: "{controller=Home}/{action=Index}/{id?}");
            });

        }
    }
}
