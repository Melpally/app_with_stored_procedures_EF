using DBSD.CW2._13768._14055._13287.DAL.Infrastructure;
using Microsoft.EntityFrameworkCore;

namespace DBSD.CW2._13768._14055._13287
{
    public class Program
    {
        public static void Main(string[] args)
        {
            var builder = WebApplication.CreateBuilder(args);

            IConfiguration config = builder.Configuration;
            string connStr = config.GetConnectionString("DBSD_CW2")
                .Replace("|DataDirectory|", builder.Environment.ContentRootPath);

            builder.Services.AddDbContext<DataContext>(options =>
            options.UseSqlServer(connStr));

            builder.Services.AddControllersWithViews();

            var app = builder.Build();

            
            if (!app.Environment.IsDevelopment())
            {
                app.UseExceptionHandler("/Home/Error");
                
                app.UseHsts();
            }

            app.UseHttpsRedirection();
            app.UseStaticFiles();

            app.UseRouting();

            app.UseAuthorization();

            app.MapControllerRoute(
                name: "default",
                pattern: "{controller=Home}/{action=Index}/{id?}");

            app.Run();
        }
    }
}
