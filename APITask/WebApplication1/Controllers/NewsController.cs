using System;
using System.Collections.Generic;
using Microsoft.AspNetCore.Mvc;

[Route("api/[controller]")]
[ApiController]
public class CategoriesController : ControllerBase
{
    private readonly List<Category> _categories;

    public CategoriesController()
    {
        // For simplicity, we'll use an in-memory list as the database.
        // In a real-world scenario, you would use a database context (Entity Framework Core).
        _categories = new List<Category>
        {
            new Category { ID = 1, Title = "Category 1", Date = DateTime.Now, CId = 101, Description = "Description of Category 1" },
            new Category { ID = 2, Title = "Category 2", Date = DateTime.Now, CId = 102, Description = "Description of Category 2" },
            new Category { ID = 3, Title = "Category 3", Date = DateTime.Now, CId = 103, Description = "Description of Category 3" },
            new Category { ID = 4, Title = "Category 4", Date = DateTime.Now, CId = 104, Description = "Description of Category 4" },
            new Category { ID = 5, Title = "Category 5", Date = DateTime.Now, CId = 105, Description = "Description of Category 5" }
        };
    }

    // GET: api/Categories
    [HttpGet]
    public ActionResult<IEnumerable<Category>> GetCategories()
    {
        return _categories;
    }

    // GET: api/Categories/5
    [HttpGet("{id}")]
    public ActionResult<Category> GetCategory(int id)
    {
        var category = _categories.Find(c => c.ID == id);

        if (category == null)
        {
            return NotFound();
        }

        return category;
    }

    // POST: api/Categories
    [HttpPost]
    public ActionResult<Category> CreateCategory(Category category)
    {
        // For simplicity, we won't perform validation or database operations here.
        // In a real-world scenario, you would use Entity Framework Core to save the category to the database.
        _categories.Add(category);

        return CreatedAtAction(nameof(GetCategory), new { id = category.ID }, category);
    }

    // PUT: api/Categories/5
    [HttpPut("{id}")]
    public IActionResult UpdateCategory(int id, Category updatedCategory)
    {
        // For simplicity, we won't perform validation or database operations here.
        // In a real-world scenario, you would use Entity Framework Core to update the category in the database.
        var existingCategory = _categories.Find(c => c.ID == id);

        if (existingCategory == null)
        {
            return NotFound();
        }

        existingCategory.Title = updatedCategory.Title;
        existingCategory.Date = updatedCategory.Date;
        existingCategory.CId = updatedCategory.CId;
        existingCategory.Description = updatedCategory.Description;

        return NoContent();
    }

    // DELETE: api/Categories/5
    [HttpDelete("{id}")]
    public IActionResult DeleteCategory(int id)
    {
        // For simplicity, we won't perform database operations here.
        // In a real-world scenario, you would use Entity Framework Core to delete the category from the database.
        var category = _categories.Find(c => c.ID == id);

        if (category == null)
        {
            return NotFound();
        }

        _categories.Remove(category);

        return NoContent();
    }
}
