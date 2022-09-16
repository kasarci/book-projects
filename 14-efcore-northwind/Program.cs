using _14_efcore_northwind;
using _14_efcore_northwind.Entities;
using Microsoft.EntityFrameworkCore;

Console.WriteLine("Hello From EFCore!");
QueryingCategories();

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