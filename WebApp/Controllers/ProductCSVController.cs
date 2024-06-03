using DataBase.Repositories.Abstraction;
using Microsoft.AspNetCore.Mvc;
using System.Globalization;
using System.Text;

namespace WebApplication1.Controllers
{
    [ApiController]
    [Route("api/products")]
    public class ProductCSVController : ControllerBase
    {
        private readonly IProductRepository _productRepository;

        public ProductCSVController(IProductRepository productRepository)
        {
            _productRepository = productRepository;
        }

        [HttpGet("csv")]
        public IActionResult GetProductsAsCsv()
        {
            var products = _productRepository.GetProducts();

            var csvBuilder = new StringBuilder();
            csvBuilder.AppendLine("Id,Name,Description,Price");

            foreach (var product in products)
            {
                csvBuilder.AppendLine(
                    $"{product.Id},{EscapeCsvField(product.Name)},{EscapeCsvField(product.Description)},{product.Cost.ToString("F2", CultureInfo.InvariantCulture)}");
            }

            var csvData = csvBuilder.ToString();
            var csvBytes = Encoding.UTF8.GetBytes(csvData);

            return CustomFile(csvBytes, "text/csv", "products.csv");
        }

        private string EscapeCsvField(string? field)
        {
            if (string.IsNullOrEmpty(field))
            {
                return string.Empty;
            }

            if (field.Contains(",") || field.Contains("\""))
            {
                return $"\"{field.Replace("\"", "\"\"")}\"";
            }

            return field;
        }

        private IActionResult CustomFile(byte[] fileBytes, string contentType, string fileName)
        {
            var directoryPath = Path.Combine(Directory.GetCurrentDirectory(), "wwwroot");
            Directory.CreateDirectory(directoryPath);
            var filePath = Path.Combine(directoryPath, fileName);

            if (!System.IO.File.Exists(filePath))
            {
                System.IO.File.WriteAllBytes(filePath, fileBytes);
            }

            var fileContentResult = new FileContentResult(fileBytes, contentType)
            {
                FileDownloadName = fileName
            };

            return fileContentResult;
        }
    }
}