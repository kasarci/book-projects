using System.Linq;
using _14_efcore_northwind;
using _14_efcore_northwind.Entities;
using Microsoft.EntityFrameworkCore;
using Microsoft.EntityFrameworkCore.Metadata.Internal;
using Microsoft.EntityFrameworkCore.Query;

Console.WriteLine("Hello From EFCore!");
QueryingCategories();
FilteringQueries();
FilterAndSort();

void QueryingCategories() {
  using(Northwind db = new Northwind()) {
    Console.WriteLine("Categorories and how many products they have");
    IQueryable<Category>? categories = db.Categories.Include(c => c.Products);

    if(categories is null) {
      Console.WriteLine("No categories found.");
      return;
    }

    foreach (Category category in categories)
    {
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