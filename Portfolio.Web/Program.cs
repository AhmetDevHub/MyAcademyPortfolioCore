using Microsoft.AspNetCore.Authentication.Cookies;
using Microsoft.AspNetCore.Mvc.Authorization;
using Portfolio.Web.Context;

namespace Portfolio.Web
{
	public class Program
	{
		public static void Main(string[] args)
		{
			var builder = WebApplication.CreateBuilder(args);

			// Add services to the container.

			//IOC Container

			//builder.Services.AddScoped<PortfolioContext>();
			//context s�n�f�n� programcs e tan�t�yoruz yukar�daki de ayn� sonu� farkl� i�lem !!!
			builder.Services.AddDbContext<PortfolioContext>();

            builder.Services.AddDistributedMemoryCache();  //Haf�zadatutmak i�in


            builder.Services.AddSession(options =>
            {
                options.IdleTimeout = TimeSpan.FromMinutes(30);
                options.Cookie.HttpOnly = true;
                options.Cookie.IsEssential = true;
            });

            builder.Services.AddControllersWithViews(opt =>
			{
				opt.Filters.Add(new AuthorizeFilter());
			});

			

			

			builder.Services.AddAuthentication(CookieAuthenticationDefaults.AuthenticationScheme)
				.AddCookie(options =>
				{
					options.Cookie.Name = "PortfolioCookie";
					options.LoginPath = "/Auth/Login";
					options.LogoutPath = "/Auth/Logout";
					options.ExpireTimeSpan = TimeSpan.FromMinutes(30);
					options.SlidingExpiration = true;
				});

            var app = builder.Build();

            if (!app.Environment.IsDevelopment())
            {
                app.UseExceptionHandler("/Home/Error");
                app.UseHsts();
            }

            app.UseHttpsRedirection();
            app.UseStaticFiles(); // Statik dosyalar� y�kle
            app.UseRouting();

            app.UseAuthentication();
            app.UseAuthorization();

            app.UseSession();

            app.MapControllerRoute(
                name: "default",
                pattern: "{controller=Home}/{action=Index}/{id?}");

            app.Run();

        }
    }
}
