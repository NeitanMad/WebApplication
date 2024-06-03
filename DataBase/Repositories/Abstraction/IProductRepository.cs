using DataBase.Repositories.DTOModels;

namespace DataBase.Repositories.Abstraction;

public interface IProductRepository
{
    public int AddCategory(Category group);

    public IEnumerable<Category>? GetCategories();

    public int AddProduct(ProductDTO product);

    public IEnumerable<ProductDTO>? GetProducts();
}