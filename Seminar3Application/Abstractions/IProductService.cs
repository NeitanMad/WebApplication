using DataBase.Repositories.DTOModels;

namespace Seminar3Application.Abstractions;

public interface IProductService
{
    IEnumerable<ProductDTO> GetProducts();
    int AddProduct(ProductDTO product);
}