using _14_efcore_northwind;
using _14_efcore_northwind.Entities;
using Microsoft.EntityFrameworkCore;
using Microsoft.EntityFrameworkCore.Query;

Console.WriteLine("Hello From EFCore!");
QueryingCategories();
FilteringQueries();

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