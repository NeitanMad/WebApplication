using DataBase;
using DataBase.Repositories.Abstraction;
using DataBase.Repositories.DTOModels;
using Microsoft.AspNetCore.Mvc;
using WebApplication1.Models;

namespace WebApplication1.Controllers;

[ApiController]
[Route("[controller]")]
public class ProductController : ControllerBase
{
    private readonly IProductRepository _productRepository;

    public ProductController(IProductRepository productRepository)
    {
        _productRepository = productRepository;
    }

    [HttpGet("GetProducts")]
    public IActionResult GetProducts()
    {
        var products = _productRepository.GetProducts();
        if (products == null)
            return StatusCode(500);

        return Ok(products);
    }

    [HttpPost("AddProduct")]
    public IActionResult AddProduct([FromBody] ProductDTO productDto)
    {
        var result = _productRepository.AddProduct(productDto);
        return Ok(result);
    }

    [HttpDelete("DeleteProduct")]
    public async Task<IActionResult> DeleteCategoryAsync(ProductResponse productResponse)
    {
        try
        {
            using (var context = new DataContext())
            {
                var temp = context.Categories.Find(productResponse.Id);
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

    [HttpPut("UpdateCoast")]
    public async Task<IActionResult> UpdateProductCoastAsync(CoastResponse productResponse)
    {
        try
        {
            using (var context = new DataContext())
            {
                var temp = context.Products.Find(productResponse.Id);
                if (temp != null)
                {
                    temp.Cost = productResponse.Cost;
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
}