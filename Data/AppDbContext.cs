using Microsoft.EntityFrameworkCore;
using Stok_Takip.Models;
using System.Reflection.Emit;

namespace Stok_Takip.Data
{
    public class AppDbContext:DbContext
    {
        public AppDbContext(DbContextOptions<AppDbContext> options) :base(options)
        {
            
        }
        public DbSet<StockUnit> StockUnits_Tbl  { get; set; }   
        public DbSet<Currency> Currencies_Tbl { get; set; }
        public DbSet<StockType> StockTypes_Tbl { get; set; }
        public DbSet<StockClass> StockClasses_Tbl { get; set; }
        public DbSet<Stock> Stocks_Tbl { get; set; }
        public DbSet<QuantityUnit> QuantityUnits_Tbl { get; set; }

        protected override void OnModelCreating(ModelBuilder builder)
        {
            builder.Entity<StockType>()
            .HasIndex(x => x.Name)
            .IsUnique();
            builder.Entity<QuantityUnit>()
                .HasIndex(x => x.Name)
                .IsUnique();
            builder.Entity<Currency>()
                .HasIndex(x => x.Name)
                .IsUnique();
            builder.Entity<StockClass>()
                .HasIndex(x => x.Name)
                .IsUnique();
            builder.Entity<StockUnit>()
                .HasIndex(x => x.UnitCode)
                .IsUnique();
        }
    
    }
}
