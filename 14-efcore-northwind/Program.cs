using System.Linq;
using System.Threading.Tasks.Dataflow;
using _14_efcore_northwind;
using _14_efcore_northwind.Entities;
using Microsoft.EntityFrameworkCore;
using Microsoft.EntityFrameworkCore.Infrastructure;
using Microsoft.EntityFrameworkCore.Metadata.Internal;
using Microsoft.EntityFrameworkCore.Query;
using Microsoft.EntityFrameworkCore.Query.SqlExpressions;
using Microsoft.Extensions.Logging;

Console.WriteLine("Hello From EFCore!");
QueryingCategories();
// FilteringQueries();
// FilterAndSort();
// QueryingWithLike();


void QueryingCategories() {
  using(Northwind db = new Northwind()) {

    ILoggerFactory loggerFactory = db.GetService<ILoggerFactory>();
    loggerFactory.AddProvider(new ConsoleLoggerProvider());
    
    Console.WriteLine("Categorories and how many products they have");
    IQueryable<Category>? categories;

    db.ChangeTracker.LazyLoadingEnabled = false;

    Console.Write("Enable Eager Loading? Y/N: ");
    bool eagerLoading = (Console.ReadKey().Key == ConsoleKey.Y);
    bool explicitLoading = false;

    Console.WriteLine();

    if (eagerLoading) {
      categories = db.Categories?.Include(c => c.Products);
    } else {
      categories = db.Categories;

      Console.Write("Enable Explicit Loading? Y/N: ");
      explicitLoading = Console.ReadKey().Key == ConsoleKey.Y;
      Console.WriteLine();
    }

    if(categories is null) {
      Console.WriteLine("No categories found.");
      return;
    }

    foreach (Category category in categories)
    {
      
    if (explicitLoading) {
      Console.Write($"Explicitly load products for {category.CategoryName}? Y/N: ");
      Console.WriteLine();
      if (Console.ReadKey().Key == ConsoleKey.Y) {
        var products = db.Entry(category).Collection(c => c.Products);
        if (!products.IsLoaded) {
          products.Load();
        }
      }
    } else {
      db.ChangeTracker.LazyLoadingEnabled = true;
    }
      Console.WriteLine($"{category.CategoryName} has {category.Products.Count} products.");
    }
  }
}

void FilteringQueries() {
  using(Northwind db = new ()) {
    Console.WriteLine("Type the minimum stock number for listing the units in stock.");
    bool success = Int16.TryParse(Console.ReadLine() ?? "10", out short unitsInStock );
    if (success) {
      IIncludableQueryable<Category, IEnumerable<Product>>? categories = db.Categories.Include(c => c.Products.Where(p => p.Stock >= unitsInStock));

      if(categories is null) {
        Console.WriteLine("No categories found.");
        return;
      }

      foreach (Category category in categories) {
        Console.WriteLine($"{category.CategoryName} has {category.Products.Count} products with a minimum of {unitsInStock} units in stock.");

        foreach (Product product in category.Products) {
          Console.WriteLine($"    {product.ProductName} has {product.Stock} units in stock");
        }
      }
    } else {
      Console.WriteLine("Type something more meaningful.");
      return;
    }
  }
}

void FilterAndSort() {
  using( Northwind db = new()) {
    Console.WriteLine("Products that cost more than a proce, highest at the top.");

    decimal price;

    do
    {
      Console.Write("Enter a product price: ");     
    } while (!decimal.TryParse(Console.ReadLine(), out price));

    var products = db.Products.Where(p => p.Cost > price).OrderByDescending(p => p.Cost);
    
    if(products is null) {
      Console.WriteLine("No products found.");
      return;
    }

    Console.WriteLine(products.ToQueryString());

    foreach (var product in products)
    {
      Console.WriteLine($"{product.ProductName} costs {product.Cost} and has {product.Stock} in the stock.");
    }
  }
}
void QueryingWithLike()
{
  using (Northwind db = new ()) {
    ILoggerFactory loggerFactory = db.GetService<ILoggerFactory>();
    loggerFactory.AddProvider(new ConsoleLoggerProvider());

    Console.WriteLine("Enter part of a product name: ");
    string? input = Console.ReadLine();

    var filteredProducts = db.Products?.Where(p => EF.Functions.Like(p.ProductName, $"%{input}%"));

    if (filteredProducts is null) {
      Console.WriteLine("No products found in matched pattern.");
      return;
    }

    foreach (var product in filteredProducts)
    {
      Console.WriteLine($"{product.ProductName} has {product.Stock} units in stock. Discontinued? {product.Discontinued}");
    }
  }
}