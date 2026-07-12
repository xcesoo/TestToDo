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
    
    public async Task<IReadOnlyCollection<ToDoItem>> GetToDoItemsAsync(Guid userId, CancellationToken cancellationToken)
    {
        return await _context.ToDoItems.AsNoTracking().Where(i=>i.UserId == userId).ToListAsync(cancellationToken);
    }

    public async Task<ToDoItem?> GetToDoItemByIdAsync(Guid id, Guid userId,  CancellationToken cancellationToken)
    {
        return await
            _context.ToDoItems.Where(i => i.Id == id && i.UserId == userId).FirstOrDefaultAsync(cancellationToken);
    }
    public async Task AddToDoItemAsync(ToDoItem toDoItem, CancellationToken cancellationToken)
    {
        ArgumentNullException.ThrowIfNull(toDoItem);
        await _context.ToDoItems.AddAsync(toDoItem, cancellationToken);
    }
    
    public async Task DeleteToDoItemAsync(Guid id, Guid userId, CancellationToken cancellationToken)
    {
        await _context.ToDoItems.Where(i => i.Id == id && i.UserId == userId).ExecuteDeleteAsync(cancellationToken);
    }

    public async Task SaveChangesAsync(CancellationToken cancellationToken)
    {
        await _context.SaveChangesAsync(cancellationToken);
    }
}