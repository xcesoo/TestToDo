using TestToDo.Entities;

namespace TestToDo.Interfaces;

public interface ICategoryRepository
{
    Task<IReadOnlyCollection<Category>> GetCategories(CancellationToken cancellationToken);
    Task<Category?> GetCategoryById(Guid? id, CancellationToken cancellationToken);
    Task AddCategory(Category category, CancellationToken cancellationToken);
    Task DeleteCategory(Guid id, CancellationToken cancellationToken);
    Task SaveChangesAsync(CancellationToken cancellationToken);
}