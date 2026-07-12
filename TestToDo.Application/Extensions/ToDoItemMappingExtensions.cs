using TestToDo.Application.DTOs;
using TestToDo.Entities;

namespace TestToDo.Application.Extensions;

public static class ToDoItemMappingExtensions
{
    public static ToDoItemDto ToDto(this ToDoItem item)
    {
        return new ToDoItemDto(
            Id: item.Id,
            Title: item.Title,
            Description: item?.Description,
            Category: item?.Category?.Name,
            CreatedAt: item!.CreatedAt,
            Deadline: item.Deadline,
            Priority: item.Priority,
            IsCompleted: item.IsCompleted
            );
    }

    public static IReadOnlyCollection<ToDoItemDto> ToDtoCollection(this IEnumerable<ToDoItem> items)
    {
        return items.Select(i=> i.ToDto()).ToArray();
    }
}