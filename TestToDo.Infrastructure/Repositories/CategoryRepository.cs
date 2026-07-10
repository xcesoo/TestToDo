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

    public async Task<IReadOnlyCollection<Category>> GetCategoriesAsync(CancellationToken cancellationToken)
    {
        return await _context.Categories.AsNoTracking().ToListAsync(cancellationToken);
    }

    public async Task<Category?> GetCategoryByIdAsync(Guid? id, CancellationToken cancellationToken)
    {
        return await _context.Categories.Where(c=>c.Id==id).FirstOrDefaultAsync(cancellationToken);
    }

    public async Task<IReadOnlyCollection<Category>> SearchCategoriesByNameAsync(string categoryName, CancellationToken cancellationToken)
    {
        return await _context.Categories.AsNoTracking().Where(c=>EF.Functions.ILike(c.Name, $"%{categoryName}%")).ToListAsync(cancellationToken);
    }

    public async Task<Category?> GetCategoryByNameAsync(string categoryName, CancellationToken cancellationToken)
    {
        return await _context.Categories.Where(c=>c.Name==categoryName).FirstOrDefaultAsync(cancellationToken);
    }

    public async Task AddCategoryAsync(Category category, CancellationToken cancellationToken)
    {
        ArgumentNullException.ThrowIfNull(category);
        await _context.Categories.AddAsync(category, cancellationToken);
    }

    public async Task DeleteCategoryAsync(Guid id, CancellationToken cancellationToken)
    {
        await _context.Categories.Where(c=>c.Id ==id).ExecuteDeleteAsync(cancellationToken);
    }

    public async Task SaveChangesAsync(CancellationToken cancellationToken)
    {
        await _context.SaveChangesAsync(cancellationToken);
    }
}