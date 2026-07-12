using Microsoft.EntityFrameworkCore;
using TestToDo.Application.Extensions;
using TestToDo.Entities;
using TestToDo.Enums;
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

    public async Task<IReadOnlyCollection<ToDoItem>> GetToDoItemsAsync(Guid userId, int page, int pageSize,
        CancellationToken cancellationToken)
    {
        return await _context.ToDoItems.AsNoTracking()
            .Where(i => i.UserId == userId)
            .OrderBy(i => i.CreatedAt)
            .Skip((page - 1) * pageSize)
            .Take(pageSize)
            .ToListAsync(cancellationToken);
    }

    public async Task<IReadOnlyCollection<ToDoItem>> SearchToDoItemsAsync(
        Guid userId,
        string? searchTerm, 
        Guid? categoryId,
        EPriority[]? priority,
        DateTime? startDateCreated, DateTime? endDateCreated,
        DateTime? startDateDeadline, DateTime? endDateDeadline,
        DateTime? startDateCompleted, DateTime? endDateCompleted,
        bool? completed,
        int page, int pageSize, CancellationToken cancellationToken)
    {
        return await _context.ToDoItems.AsNoTracking()
            .Where(i => i.UserId == userId)
            
            .WhereIf(!string.IsNullOrWhiteSpace(searchTerm), i => 
                EF.Functions.ILike(i.Title, $"%{searchTerm}%")
                || (i.Description != null  && EF.Functions.ILike(i.Description, $"%{searchTerm}%")))
            
            .WhereIf(categoryId is not null, i => i.CategoryId == categoryId)
            
            .WhereIf(priority is not null && priority.Any(), i => priority!.Contains(i.Priority))
            
            .WhereIf(startDateCreated is not null, i => i.CreatedAt >= startDateCreated)
            .WhereIf(endDateCreated is not null, i => i.CreatedAt <= endDateCreated)
            
            .WhereIf(startDateDeadline is not null, i => i.Deadline >= startDateDeadline)
            .WhereIf(endDateDeadline is not null, i => i.Deadline <= endDateDeadline)
            
            .WhereIf(startDateCompleted is not null, i => i.CompletedAt >= startDateCompleted)
            .WhereIf(endDateCompleted is not null, i => i.CompletedAt <= endDateCompleted)
            
            .WhereIf(completed is not null, i => i.IsCompleted == completed)
            
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