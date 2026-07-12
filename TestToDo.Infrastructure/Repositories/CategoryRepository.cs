using Microsoft.EntityFrameworkCore;
using TestToDo.Entities;
using TestToDo.Infrastructure.Persistence;
using TestToDo.Interfaces;

namespace TestToDo.Infrastructure.Repositories;

public class CategoryRepository : ICategoryRepository
{
    private readonly ToDoContext _context;
    
    public CategoryRepository(ToDoContext context)
    {
        _context = context;
    }

    public async Task<IReadOnlyCollection<Category>> GetCategoriesAsync(Guid userId, CancellationToken cancellationToken)
    {
        return await _context.Categories.AsNoTracking().Where(c=>c.UserId == userId).ToListAsync(cancellationToken);
    }

    public async Task<Category?> GetCategoryByIdAsync(Guid? id, Guid userId, CancellationToken cancellationToken)
    {
        return await _context.Categories.Where(c=>c.Id==id && c.UserId == userId).FirstOrDefaultAsync(cancellationToken);
    }

    public async Task<IReadOnlyCollection<Category>> SearchCategoriesByNameAsync(string categoryName, Guid userId, CancellationToken cancellationToken)
    {
        return await _context.Categories.AsNoTracking()
            .Where(c=>EF.Functions.ILike(c.Name, $"%{categoryName}%"))
            .Where(c=>c.UserId==userId)
            .ToListAsync(cancellationToken);
    }

    public async Task<Category?> GetCategoryByNameAsync(string categoryName, Guid userId, CancellationToken cancellationToken)
    {
        return await _context.Categories.Where(c=>c.Name==categoryName && c.UserId == userId).FirstOrDefaultAsync(cancellationToken);
    }

    public async Task AddCategoryAsync(Category category, CancellationToken cancellationToken)
    {
        ArgumentNullException.ThrowIfNull(category);
        await _context.Categories.AddAsync(category, cancellationToken);
    }

    public async Task DeleteCategoryAsync(Guid id, Guid userId, CancellationToken cancellationToken)
    {
        await _context.Categories.Where(c=>c.Id ==id && c.UserId == userId).ExecuteDeleteAsync(cancellationToken);
    }

    public async Task SaveChangesAsync(CancellationToken cancellationToken)
    {
        await _context.SaveChangesAsync(cancellationToken);
    }
}