using Microsoft.EntityFrameworkCore;
using TestToDo.Application.Extensions;
using TestToDo.Entities;
using TestToDo.Filters;
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

    public async Task<IReadOnlyCollection<ToDoItem>> SearchToDoItemsAsync(
        Guid userId,
        ToDoItemSearchFilter filter,
        int page, int pageSize, CancellationToken cancellationToken)
    {
        return await _context.ToDoItems.AsNoTracking()
            .Where(i => i.UserId == userId)
            
            .WhereIf(!string.IsNullOrWhiteSpace(filter.SearchTerm), i => 
                EF.Functions.ILike(i.Title, $"%{filter.SearchTerm}%")
                || (i.Description != null  && EF.Functions.ILike(i.Description, $"%{filter.SearchTerm}%")))
            
            .WhereIf(filter.CategoryId is not null, i => i.CategoryId == filter.CategoryId)
            
            .WhereIf(filter.Priority is not null && filter.Priority.Any(), i => filter.Priority!.Contains(i.Priority))
            
            .WhereIf(filter.StartDateCreated is not null, i => i.CreatedAt >= filter.StartDateCreated)
            .WhereIf(filter.EndDateCreated is not null, i => i.CreatedAt <= filter.EndDateCreated)
            
            .WhereIf(filter.StartDateDeadline is not null, i => i.Deadline >= filter.StartDateDeadline)
            .WhereIf(filter.EndDateDeadline is not null, i => i.Deadline <= filter.EndDateDeadline)
            
            .WhereIf(filter.StartDateCompleted is not null, i => i.CompletedAt >= filter.StartDateCompleted)
            .WhereIf(filter.EndDateCompleted is not null, i => i.CompletedAt <= filter.EndDateCompleted)
            
            .WhereIf(filter.Completed is not null, i => i.IsCompleted == filter.Completed)
            
            .OrderBy(i => i.CreatedAt)
            .Skip((page - 1) * pageSize)
            .Take(pageSize)
            .ToListAsync(cancellationToken);
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