using _14_efcore_northwind.Entities;
using _20_webapi.Repositories;
using Microsoft.AspNetCore.Localization;
using Microsoft.AspNetCore.Mvc;
using Microsoft.EntityFrameworkCore;
using Microsoft.EntityFrameworkCore.Storage;

namespace _20_webapi.Controllers;

public class CategoriesContoller : ControllerBase {
  private readonly ICategoryRepository _categoriesRepository;

  public CategoriesContoller(ICategoryRepository categoriesRepository) {
    _categoriesRepository = categoriesRepository;
  }

  [HttpGet]
  [ProducesResponseType(200, Type = typeof(IEnumerable<Category>))]
  public async Task<IEnumerable<Category>> GetCategories() {
    return await _categoriesRepository.GetAllAsync();
  }

  [HttpGet("{id}", Name = nameof(GetCategories))]
  [ProducesResponseType(200, Type = typeof(Category))]
  [ProducesResponseType(404)]
  public async Task<IActionResult> GetCategory (int id) {
    Category? c = await _categoriesRepository.GetAsync(id);
    if (c is null) {
      return NotFound();
    }
    return Ok(c);
  }

  [HttpPost]
  [ProducesResponseType(201, Type= typeof(Category))]
  [ProducesResponseType(400)]
  public async Task<IActionResult> CreateCategory ([FromBody] Category c) {
    if (c is null) {
      return BadRequest();
    }

    Category? addedCategory = await _categoriesRepository.CreateAsync(c);

    if(addedCategory is null) {
      return BadRequest("Repository failed to create category.");
    } else {
      return CreatedAtRoute(routeName: nameof(GetCategory),
                            routeValues: new { id = addedCategory.CategoryId},
                            value: addedCategory);
    }
  }

  [HttpPut("{id}")]
  [ProducesResponseType(204)]
  [ProducesResponseType(400)]
  [ProducesResponseType(404)]
  public async Task<IActionResult> Update(string id, [FromBody] Category c) {
    if ( c is null || c.CategoryId.ToString() != id) {
      return BadRequest();
    }

    Category? existing = await _categoriesRepository.GetAsync(Convert.ToInt32(id));
    if (existing is null) {
      return NotFound();
    }

    await _categoriesRepository.UpdateAsync(Convert.ToInt32(id), c);

    return new NoContentResult();
  }

  [HttpDelete("{id}")]
  [ProducesResponseType(204)]
  [ProducesResponseType(400)]
  [ProducesResponseType(404)]
  public async Task<IActionResult> Delete (string id) {
    Category? existing = await _categoriesRepository.GetAsync(Convert.ToInt32(id));

    if (existing is null) {
      return NotFound();
    }

    bool? deleted = await _categoriesRepository.DeleteAsync(Convert.ToInt32(id));

    if (deleted.HasValue && deleted.Value) {
      return new NoContentResult();
    } else {
      return BadRequest($"Category {id} was found but failed to delete.");
    }
  }

}