using _14_efcore_northwind.Entities;
using Microsoft.EntityFrameworkCore;

namespace _14_efcore_northwind;

public class Northwind : DbContext {

  public DbSet<Category>? Categories { get; set; }
  public DbSet<Product>? Products { get; set; }

  protected override void OnConfiguring(DbContextOptionsBuilder optionsBuilder)
  {
    base.OnConfiguring(optionsBuilder);

    optionsBuilder.UseLazyLoadingProxies();

    if( ProjectConstants.DatabaseProvider == "SQLite") {
      string path = @"C:\sqlite\Northwind\Northwind.db";
      Console.WriteLine($"Using {path} as a database file. ");

      optionsBuilder.UseSqlite($"Filename={path}");
    } else {
      string connectionString = "Data Source = .;" +
                                "Initial Catalog = Northwind;" +
                                "Integrated Security = true;" +
                                "MultipleActiveResultSets = true;";

      optionsBuilder.UseSqlServer(connectionString);                                
    }
  }

  protected override void OnModelCreating(ModelBuilder modelBuilder)
  {
    base.OnModelCreating(modelBuilder);
    modelBuilder.Entity<Category>()
                .Property(x => x.CategoryName)
                .IsRequired()
                .HasMaxLength(15);
    
    modelBuilder.Entity<Product>()
                .Property(x => x.Cost)
                .HasConversion<double>();
    // In EFCore 3.0 and later, decimal type is not supported by SQLite.
    //We can fix this by telling the model that decimal values can be converted to double values.
  }
}