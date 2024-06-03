using DataBase.Repositories.DTOModels;

namespace Seminar3Application.Abstractions;

public interface IStorageService
{
    IEnumerable<StorageDTO> GetStorages();
    int AddStorage(StorageDTO storage);
}