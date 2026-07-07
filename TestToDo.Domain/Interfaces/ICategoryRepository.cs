using TestToDo.Entities;

namespace TestToDo.Interfaces;

public interface ICategoryRepository
{
    Task<IEnumerable<Category>> GetCategories();
    Task<Category> GetCategoryById(int id);
    Task<Category> AddCategory(Category category);
    Task<Category> UpdateCategory(Category category);
    Task DeleteCategory(int id);
}