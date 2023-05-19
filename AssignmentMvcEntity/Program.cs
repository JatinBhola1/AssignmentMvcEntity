using AssignmentMvcEntity.Context;
using AssignmentMvcEntity.Repository;
using Microsoft.EntityFrameworkCore;

namespace AssignmentMvcEntity
{
    public class Program
    {
        public static void Main(string[] args)
        {
            var builder = WebApplication.CreateBuilder(args);

            // Add services to the container.
            builder.Services.AddControllersWithViews();
            builder.Services.AddDbContext<InventoryDbContext>(options =>
            {
                options.UseSqlServer(builder.Configuration.GetConnectionString("InventoryDbConnection"));

            });
            //builder.Services.AddTransient<UserRepository>();

            builder.Services.AddTransient<IInventoryInterface, InventoryRepository>();
            builder.Services.AddTransient<ISupplierInterface, SupplierRepository>();
            var app = builder.Build();

            // Configure the HTTP request pipeline.
            if (!app.Environment.IsDevelopment())
            {
                app.UseExceptionHandler("/Home/Error");
            }
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