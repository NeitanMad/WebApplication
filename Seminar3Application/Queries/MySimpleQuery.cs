using DataBase.Repositories.DTOModels;
using Seminar3Application.Abstractions;
using Category = DataBase.Repositories.DTOModels.Category;

namespace Seminar3Application.Queries;

public class MySimpleQuery
{
    public IEnumerable<ProductDTO> GetProducts([Service] IProductService service) => service.GetProducts();
    public IEnumerable<ProductDTO> GetProductsById([Service] IStorageFilling service, int storeId) => service.GetProducts(storeId);
    public IEnumerable<StorageDTO> GetStorages([Service] IStorageService service) => service.GetStorages();
    public IEnumerable<Category> GetCategories([Service] ICategoryService service) => service.GetCategories();
}