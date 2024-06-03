using DataBase.Repositories.DTOModels;

namespace Seminar3Application.Abstractions;

public interface IStorageFilling
{
    IEnumerable<ProductDTO> GetProducts(int storeId);
}