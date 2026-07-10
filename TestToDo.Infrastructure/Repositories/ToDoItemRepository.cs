using Microsoft.EntityFrameworkCore;
using TestToDo.Entities;
using TestToDo.Infrastructure.Persistence;
using TestToDo.Interfaces;

namespace TestToDo.Infrastructure.Repositories;

public class ToDoItemRepository : IToDoItemRepository
{
    private readonly ToDoContext _context;
    
    public ToDoItemRepository(ToDoContext context)
    {
        _context = context ?? throw new ArgumentNullException(nameof(context));
    }
    
    public async Task<IReadOnlyCollection<ToDoItem>> GetToDoItemsAsync(CancellationToken cancellationToken)
    {
        return await _context.ToDoItems.AsNoTracking().ToListAsync(cancellationToken);
    }

    public async Task<ToDoItem?> GetToDoItemByIdAsync(Guid id, CancellationToken cancellationToken)
    {
        return await
            _context.ToDoItems.Where(i => i.Id == id).FirstOrDefaultAsync(cancellationToken);
    }
    public async Task AddToDoItemAsync(ToDoItem toDoItem, CancellationToken cancellationToken)
    {
        ArgumentNullException.ThrowIfNull(toDoItem);
        await _context.ToDoItems.AddAsync(toDoItem, cancellationToken);
    }
    
    public async Task DeleteToDoItemAsync(Guid id, CancellationToken cancellationToken)
    {
        await _context.ToDoItems.Where(i => i.Id == id).ExecuteDeleteAsync(cancellationToken);
    }

    public async Task SaveChangesAsync(CancellationToken cancellationToken)
    {
        await _context.SaveChangesAsync(cancellationToken);
    }
}