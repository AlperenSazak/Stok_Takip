using Microsoft.EntityFrameworkCore;
using Stok_Takip.Data;
using Stok_Takip.Repository;
using Stok_Takip.Repository.CurrencyRepo;
using Stok_Takip.Repository.QuantityUnitRepo;
using Stok_Takip.Repository.StockClassRepo;
using Stok_Takip.Repository.StockRepo;
using Stok_Takip.Repository.StockTypeRepo;
using Stok_Takip.Repository.StockUnitRepo;

namespace Stok_Takip
{
    public class Program
    {
        public static void Main(string[] args)
        {
            var builder = WebApplication.CreateBuilder(args);

            // Add services to the container.
            builder.Services.AddControllersWithViews();
            builder.Services.AddDbContext<AppDbContext>(options => options.UseSqlServer(
                builder.Configuration.GetConnectionString("DefaultConnection")
                ));
            builder.Services.AddScoped(typeof(IRepository<>), typeof(GenericRepository<>));
            builder.Services.AddScoped<IStockTypeRepository, StockTypeRepository>();
            builder.Services.AddScoped<IStockUnitRepository, StockUnitRepository>();
            builder.Services.AddScoped<IStockRepository, StockRepository>();
            builder.Services.AddScoped<IStockClassRepository, StockClassRepository>();
            builder.Services.AddScoped<IQuantityUnitRepository, QuantityUnitRepository>();
            builder.Services.AddScoped<ICurrencyRepository, CurrencyRepository>();

            log4net.Config.XmlConfigurator.Configure();
            var app = builder.Build();

            // Configure the HTTP request pipeline.
            if (!app.Environment.IsDevelopment())
            {
                app.UseExceptionHandler("/Home/Error");
                // The default HSTS value is 30 days. You may want to change this for production scenarios, see https://aka.ms/aspnetcore-hsts.
                app.UseHsts();
            }

            app.UseHttpsRedirection();
            app.UseStaticFiles();

            app.UseRouting();

            app.UseAuthorization();

            app.MapControllerRoute(
                name: "default",
                pattern: "{controller=StockType}/{action=Index}/{id?}");

            app.Run();
        }
    }
}