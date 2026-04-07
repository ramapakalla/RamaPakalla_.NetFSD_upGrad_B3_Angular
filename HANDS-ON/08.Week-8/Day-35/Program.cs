using WebApplication8.Models;
using WebApplication8.Repository;

namespace WebApplication8
{
    public class Program
    {
        public static void Main(string[] args)
        {
            var builder = WebApplication.CreateBuilder(args);

            // Register DapperContext and Repository
            builder.Services.AddSingleton<DapperContext>();
            builder.Services.AddScoped<IContactRepository, ContactRepository>();

            // Add MVC services
            builder.Services.AddControllersWithViews();

            var app = builder.Build();

            // Configure pipeline
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