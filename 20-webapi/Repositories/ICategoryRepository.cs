using _14_efcore_northwind.Entities;

namespace _20_webapi.Repositories;

public interface ICategoryRepository {
  Task<Category?> CreateAsync(Category c);
  Task<IEnumerable<Category>> GetAllAsync();
  Task<Category?> GetAsync(int id);
  Task<Category?> UpdateAsync (int id, Category c);
  Task<bool?> DeleteAsync(int id);
}