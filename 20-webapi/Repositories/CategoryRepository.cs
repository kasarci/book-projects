using System.Collections.Concurrent;
using _14_efcore_northwind;
using _14_efcore_northwind.Entities;
using Microsoft.EntityFrameworkCore.ChangeTracking;


namespace _20_webapi.Repositories;

public class CategoryRepository : ICategoryRepository
{

  private static ConcurrentDictionary<int, Category>? categoriesCache;

  private Northwind db;

  public CategoryRepository(Northwind injectedContext) {
    db = injectedContext;

    if (categoriesCache is null) {
      categoriesCache = new ConcurrentDictionary<int, Category>(db.Categories.ToDictionary(c => c.CategoryId));
    }
  }
  public async Task<Category?> CreateAsync(Category c)
  {
    EntityEntry<Category>? added = await db.Categories.AddAsync(c);
    int affected = await db.SaveChangesAsync();
    if (affected == 1) {
      if (categoriesCache is null) {
        return c;
      }
      return categoriesCache.AddOrUpdate(c.CategoryId, c, UpdateCache);
    } else {
       return null; 
    }
  }
  public async Task<bool?> DeleteAsync(int id)
  {
    Category? c = await db.Categories.FindAsync(id);
    if (c is null) { 
      return null;
    }
    db.Categories.Remove(c);
    int affected = await db.SaveChangesAsync();

    if(affected == 1) {
      if(categoriesCache is null) {
        return true;
      }
      return categoriesCache.TryRemove(id, out c);
    } else {
      return null;
    }
  }

  public Task<IEnumerable<Category>> GetAllAsync()
  {
    return Task.FromResult(categoriesCache is null ?
                          Enumerable.Empty<Category>() :
                          categoriesCache.Values);
  }

  public Task<Category?> GetAsync(int id)
  {
    if (categoriesCache is null) {
      return null!;
    }
    categoriesCache.TryGetValue(id, out Category c);
    return Task.FromResult(c);
  }

  public async Task<Category?> UpdateAsync(int id, Category c)
  {
    db.Categories.Update(c);
    int affected = await db.SaveChangesAsync();
    if (affected == 1)
    {
      if (categoriesCache is null) {
        return c;
      }
      return UpdateCache(id, c);
    } else {
      return null;
    }
  }

  private Category UpdateCache(int id, Category c)
  {
    Category? old;
    if (categoriesCache is not null) { 
      if(categoriesCache.TryGetValue(id, out old)) {
        if(categoriesCache.TryUpdate(id, c, old)) {
          return c;
        }
      }
    }
    return null;
  }

}