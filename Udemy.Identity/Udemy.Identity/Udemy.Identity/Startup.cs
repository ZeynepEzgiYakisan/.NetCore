using Microsoft.AspNetCore.Builder;
using Microsoft.AspNetCore.Hosting;
using Microsoft.AspNetCore.Http;
using Microsoft.EntityFrameworkCore;
using Microsoft.Extensions.DependencyInjection;
using Microsoft.Extensions.FileProviders;
using Microsoft.Extensions.Hosting;
using System;
using System.Collections.Generic;
using System.IO;
using System.Linq;
using System.Threading.Tasks;
using Udemy.Identity.Context;
using Udemy.Identity.CustomDescriber;
using Udemy.Identity.Entities;

namespace Udemy.Identity
{
    public class Startup
    {
        // This method gets called by the runtime. Use this method to add services to the container.
        // For more information on how to configure your application, visit https://go.microsoft.com/fwlink/?LinkID=398940
        public void ConfigureServices(IServiceCollection services)
        {
         
            services.AddIdentity<AppUser, AppRole>( opt=>
            {
                opt.Password.RequireDigit = false;
                opt.Password.RequiredLength = 1;
                opt.Password.RequireLowercase = false;
                opt.Password.RequireUppercase = false;
                opt.Password.RequireNonAlphanumeric = false;
                opt.SignIn.RequireConfirmedEmail = false;
                opt.Lockout.MaxFailedAccessAttempts = 3;

            }).AddErrorDescriber<CustomErrorDescriber>().AddEntityFrameworkStores<UdemyContext>();

            services.ConfigureApplicationCookie(opt =>
            {
                opt.Cookie.HttpOnly = true; //document.cookie yazýnca ulaþýlamýyor .js aracýlýðýyla çekilemiyor
                opt.Cookie.SameSite = SameSiteMode.Strict; //ilgili domain'de kullanýlýr.
                opt.Cookie.SecurePolicy = CookieSecurePolicy.SameAsRequest;//Https ile çalýþsýn 
                opt.Cookie.Name = "UdemyCookie"; //ilgili tarayýcýmda cookie'nin ismi gözüksün 
                opt.ExpireTimeSpan = TimeSpan.FromDays(25);//kullanýýcýn bilgisi 25 gün boyunca dursun istiyoruz
                opt.LoginPath = new PathString("/Home/SignIn");
                opt.AccessDeniedPath = new PathString("/Home/AccessDenied");
            });

            services.AddDbContext<UdemyContext>(opt =>
            {
                opt.UseSqlServer("server=.\\SQLEXPRESS;database=IdentityDb;integrated security=true;");
            });

            services.AddControllersWithViews();
        }

        // This method gets called by the runtime. Use this method to configure the HTTP request pipeline.
        public void Configure(IApplicationBuilder app, IWebHostEnvironment env)
        {
            if (env.IsDevelopment())
            {
                app.UseDeveloperExceptionPage();
            }
            app.UseStaticFiles();

            app.UseStaticFiles(
                  new StaticFileOptions
                  {
                      FileProvider = new PhysicalFileProvider(Path.Combine(Directory.GetCurrentDirectory(), "node_modules")),
                      RequestPath = "/node_modules"
                  });

            app.UseRouting();

            app.UseAuthentication();
            app.UseAuthorization();

            app.UseEndpoints(endpoints =>
            {
                endpoints.MapDefaultControllerRoute();
            });
        }
    }
}
