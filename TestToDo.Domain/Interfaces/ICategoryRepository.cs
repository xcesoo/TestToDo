using TestToDo.Entities;

namespace TestToDo.Interfaces;

public interface ICategoryRepository
{
    Task<IReadOnlyCollection<Category>> GetCategoriesAsync(CancellationToken cancellationToken);
    Task<Category?> GetCategoryByIdAsync(Guid? id, CancellationToken cancellationToken);
    Task<IReadOnlyCollection<Category>> SearchCategoriesByNameAsync(string categoryName, CancellationToken cancellationToken);
    Task<Category?> GetCategoryByNameAsync(string categoryName, CancellationToken cancellationToken);
    Task AddCategoryAsync(Category category, CancellationToken cancellationToken);
    Task DeleteCategoryAsync(Guid id, CancellationToken cancellationToken);
    Task SaveChangesAsync(CancellationToken cancellationToken);
}