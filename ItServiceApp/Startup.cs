using System;
using System.IO;
using ItServiceApp.Data;
using ItServiceApp.MapperProfiles;
using ItServiceApp.Models.Identity;
using ItServiceApp.Services;
using Microsoft.AspNetCore.Builder;
using Microsoft.AspNetCore.Hosting;
using Microsoft.AspNetCore.Http;
using Microsoft.AspNetCore.Identity;
using Microsoft.EntityFrameworkCore;
using Microsoft.Extensions.Configuration;
using Microsoft.Extensions.DependencyInjection;
using Microsoft.Extensions.FileProviders;
using Microsoft.Extensions.Hosting;
using Newtonsoft.Json;

namespace ItServiceApp
{
    public class Startup
    {
        public Startup(IConfiguration configuration)
        {
            Configuration = configuration;
        }

        public IConfiguration Configuration { get; }
        public void ConfigureServices(IServiceCollection services)
        {
            services.AddDbContext<MyContext>(options =>
            {
                options.UseSqlServer(Configuration.GetConnectionString("SqlConnection"));
            });

            services.AddIdentity<ApplicationUser, ApplicationRole>(options =>
             {
                 options.Password.RequireUppercase = false;
                 options.Password.RequireLowercase = false;
                 options.Password.RequireDigit = true;
                 options.Password.RequiredLength = 5;

                 // Lockout settings
                 options.Lockout.DefaultLockoutTimeSpan = TimeSpan.FromMinutes(5);
                 options.Lockout.MaxFailedAccessAttempts = 3;
                 options.Lockout.AllowedForNewUsers = false;

                 // User settings
                 options.User.AllowedUserNameCharacters = "abcdefghijklmnopqrstuvwxyzABCDEFGHIJKLMNOPQRSTUVWXYZ0123456789-._@+";
                 options.User.RequireUniqueEmail = true;

                 //options.SignIn.RequireConfirmedEmail = true;

             }).AddEntityFrameworkStores<MyContext>().AddDefaultTokenProviders();

            services.ConfigureApplicationCookie(options =>
            {
                // Cookie settings
                options.ExpireTimeSpan = TimeSpan.FromMinutes(5);
                options.LoginPath = "/Account/Login";
                options.AccessDeniedPath = "/Account/AccessDenied";
                options.SlidingExpiration = true;
            });

            services.AddTransient<IEmailSender, EmailSender>();// loose coupling

            services.AddScoped<IPaymentService, IyzicoPaymentService>();// loose coupling

            services.AddAutoMapper(options =>
            {
                options.AddProfile<PaymentProfile>();
                //options.AddProfile(typeof(PaymentProfile));
            });

            services.AddControllersWithViews()
                .AddNewtonsoftJson(options =>
                {
                    options.SerializerSettings.ReferenceLoopHandling = ReferenceLoopHandling.Ignore;
                });
        }

        // This method gets called by the runtime. Use this method to configure the HTTP request pipeline.
        public void Configure(IApplicationBuilder app, IWebHostEnvironment env)
        {
            if (env.IsDevelopment())
            {
                app.UseDeveloperExceptionPage();
            }

            app.UseHttpsRedirection(); //https - güvenli sertifika ile çalýþmasý için
            app.UseStaticFiles(); //wwwroot klasöründeki statik dosyalara eriþmek için
            app.UseStaticFiles(new StaticFileOptions()
            {
                FileProvider = new PhysicalFileProvider(Path.Combine(Directory.GetCurrentDirectory(),@"node_modules")),
                RequestPath =new PathString("/vendor")
            });

            app.UseAuthentication();// login logout kullanabilmek için
            app.UseRouting(); //rooting mekanizmasý için
            app.UseAuthorization();//authorization  attribute kullanabilmek için

            app.UseEndpoints(endpoints =>
            {
                endpoints.MapControllerRoute(
                        name: "default",
                        pattern: "{controller=Home}/{action=Index}/{id?}"
                    );
                endpoints.MapAreaControllerRoute(
                        name:"admin",
                        areaName:"admin",
                        pattern:"admin/{controller=Manage}/{action=Index}/{id?}"
                    );
            });//default routing nasýl olacaðýný belitmek için
        }
    }
}
