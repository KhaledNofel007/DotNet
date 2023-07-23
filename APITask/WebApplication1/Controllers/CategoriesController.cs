using Microsoft.AspNetCore.Mvc;
using System.Collections.Generic;

[Route("api/[controller]")]
[ApiController]
public class CategoriesController : ControllerBase
{
    private static List<Category> categories = new List<Category>();

    // Create a Category
    [HttpPost]
    public IActionResult CreateCategory(Category category)
    {
        categories.Add(category);
        return CreatedAtAction(nameof(GetCategoryById), new { id = category.Id }, category);
    }

    // Read all Categories
    [HttpGet]
    public IActionResult GetAllCategories()
    {
        return Ok(categories);
    }

    // Read a Category by ID
    [HttpGet("{id}")]
    public IActionResult GetCategoryById(string id)
    {
        var category = categories.Find(c => c.Id == id);
        if (category == null)
            return NotFound();
        return Ok(category);
    }

    // Update a Category by ID
    [HttpPut("{id}")]
    public IActionResult UpdateCategory(string id, Category updatedCategory)
    {
        var category = categories.Find(c => c.Id == id);
        if (category == null)
            return NotFound();

        category.Name = updatedCategory.Name;
        return NoContent();
    }

    // Delete a Category by ID
    [HttpDelete("{id}")]
    public IActionResult DeleteCategory(string id)
    {
        var category = categories.Find(c => c.Id == id);
        if (category == null)
            return NotFound();

        categories.Remove(category);
        return NoContent();
    }
}
