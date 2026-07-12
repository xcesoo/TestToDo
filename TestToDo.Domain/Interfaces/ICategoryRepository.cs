using TestToDo.Entities;

namespace TestToDo.Interfaces;

public interface ICategoryRepository
{
    Task<IReadOnlyCollection<Category>> GetCategoriesAsync(Guid userId, CancellationToken cancellationToken);
    Task<Category?> GetCategoryByIdAsync(Guid? id, Guid userId, CancellationToken cancellationToken);
    Task<IReadOnlyCollection<Category>> SearchCategoriesByNameAsync(string categoryName,  Guid userId, CancellationToken cancellationToken);
    Task<Category?> GetCategoryByNameAsync(string categoryName, Guid userId, CancellationToken cancellationToken);
    Task AddCategoryAsync(Category category, CancellationToken cancellationToken);
    Task DeleteCategoryAsync(Guid id, Guid userId, CancellationToken cancellationToken);
    Task SaveChangesAsync(CancellationToken cancellationToken);
}