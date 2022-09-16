using System.ComponentModel.DataAnnotations;
using System.ComponentModel.DataAnnotations.Schema;

namespace _14_efcore_northwind.Entities;

public class Product{
  public int ProductId { get; set; }
  
  [Required]
  [StringLength(40)]
  public string ProductName { get; set; }

  [Column("UnitPrice", TypeName = "money")]
  public decimal? Cost { get; set; }
  [Column("UnitsInStock")]
  public short Stock { get; set; }
  public bool Discontinued { get; set; }

  // These two define the foreign key relationship to the Categories table.
  public int CategoryId { get; set; }
  public virtual Category Category { get; set; }

  // Category.Products and Product.Category marked as virtual.
  // This allows EFCore to to inherit and override the properties to provide extra features. Such as lazy loading.

}