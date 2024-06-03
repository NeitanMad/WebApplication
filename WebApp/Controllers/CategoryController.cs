using DataBase;
using DataBase.Repositories.Abstraction;
using DataBase.Repositories.DTOModels;
using Microsoft.AspNetCore.Mvc;
using WebApplication1.Models;

namespace WebApplication1.Controllers;

[ApiController]
[Route("[controller]")]
public class CategoryController : ControllerBase
{
    private readonly IProductRepository _productRepository;

    public CategoryController(IProductRepository productRepository)
    {
        _productRepository = productRepository;
    }


    [HttpDelete("DeleteCategory")]
    public async Task<IActionResult> DeleteCategoryAsync(CategoryResponse categoryResponse)
    {
        try
        {
            using (var context = new DataContext())
            {
                var temp = context.Categories.Find(categoryResponse.Id);
                if (temp != null)
                {
                    context.Categories.Remove(temp);
                    await context.SaveChangesAsync();
                }
            }
        }
        catch (Exception e)
        {
            Console.WriteLine(e);
            return StatusCode(500);
        }

        return Ok();
    }


    [HttpGet("GetCategories")]
    public async Task<IActionResult> GetCategoriesAsync()
    {
        var categories = await Task.Run(() => _productRepository.GetCategories());
        return Ok(categories);
    }

    [HttpGet("AddCategory")]
    public async Task<IActionResult> AddCategoryAsync(Category categoryResponse)
    {
        var result = await Task.Run(() => _productRepository.AddCategory(categoryResponse));
        return Ok(result);
    }
}