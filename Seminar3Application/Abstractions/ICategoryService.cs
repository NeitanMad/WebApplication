namespace Seminar3Application.Abstractions;

using CategoryDto = DataBase.Repositories.DTOModels.Category;

public interface ICategoryService
{
    IEnumerable<CategoryDto> GetCategories();
    int AddCategory(CategoryDto category);
}
