using Microsoft.AspNetCore.Authentication.Cookies;
using Microsoft.AspNetCore.Builder;
using Microsoft.AspNetCore.Hosting;
using Microsoft.EntityFrameworkCore;
using Microsoft.Extensions.Configuration;
using Microsoft.Extensions.DependencyInjection;
using Microsoft.Extensions.Hosting;
using Okul.BL.Abstract;
using Okul.BL.Concrete;
using Okul.DAL.Abstract;
using Okul.DAL.EfCore;
using Okul.Domain;
using System;

namespace WebUI
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
            services.AddControllersWithViews();
            services.AddDbContext<OkulDbContext>(options => options.UseSqlServer(@"Data Source=(localdb)\MSSQLLocalDB;Initial Catalog=OkulVTl;Integrated Security=True;Connect Timeout=30;Encrypt=False;TrustServerCertificate=False;ApplicationIntent=ReadWrite;MultiSubnetFailover=False"));


            // AutoMapper Entegrasyonu
            services.AddAutoMapper(typeof(Startup));


            // DAL Katmanindaki Servislerin Register Edilmesi
            services.AddScoped<IBransRepository, BransRepository>();
            services.AddScoped<IKullanicilarRepository, KullanicilarRepsitory>();
            services.AddScoped<IOgrencilerRepository, OgrencilerRepository>();
            services.AddScoped<IOgretmenlerRepository, OgretmenlerRepository>();
            services.AddScoped<IPlanRepository, PlanRepository>();
            services.AddScoped<ISinifRepository, SinifRepository>();
            services.AddScoped<IYoklamaRepository, YoklamaRepository>();


            //Manager siniflarinin register edilmesi 
            services.AddScoped<IBransManager, BransManager>();
            services.AddScoped<IKullaniciManager, KullaniciManager>();
            services.AddScoped<IOgrenciManager, OgrenciManager>();
            services.AddScoped<IOgretmenManager, OgretmenManager>();

            services.AddScoped<ISinifManager, SinifManager>();

            #region Cookie Base Authentication Ayarlari
            services.AddAuthentication(CookieAuthenticationDefaults.AuthenticationScheme)
                .AddCookie(x =>
                {
                    x.LoginPath = "/Kullanici/Giris"; //Giris Sayfasi
                    x.LogoutPath = "/Kullanici/Cikis"; // Cikis 
                    x.AccessDeniedPath = "/Kullanici/YetkiHatasi";
                    x.Cookie.HttpOnly = true;
                    x.Cookie.Name = "BilgeAdam";
                    x.Cookie.SameSite = Microsoft.AspNetCore.Http.SameSiteMode.Strict;
                    x.Cookie.SecurePolicy = Microsoft.AspNetCore.Http.CookieSecurePolicy.SameAsRequest;
                    x.ExpireTimeSpan = TimeSpan.FromMinutes(20); // Cookie'nin ömrünü belirler.
                });
            #endregion




        }

        // This method gets called by the runtime. Use this method to configure the HTTP request pipeline.
        public void Configure(IApplicationBuilder app, IWebHostEnvironment env)
        {
            if (env.IsDevelopment())
            {
                app.UseDeveloperExceptionPage();
            }
            else
            {
                app.UseExceptionHandler("/Home/Error");
            }
            app.UseStaticFiles();

            app.UseRouting();

            app.UseAuthentication();

            app.UseAuthorization();
            app.UseStatusCodePages();


            app.UseEndpoints(endpoints =>
            {

                endpoints.MapControllerRoute(
                    name: "areas",
                    pattern: "{area:exists}/{controller=Home}/{action=Index}/{id?}");


                endpoints.MapControllerRoute(
                    name: "default",
                    pattern: "{controller=Home}/{action=Index}/{id?}");
            });
        }
    }
}
