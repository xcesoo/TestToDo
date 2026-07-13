using TestToDo.Enums;

namespace TestToDo.Filters;

public readonly record struct ToDoItemSearchFilter(
    string? SearchTerm,
    Guid? CategoryId,
    EPriority[]? Priority,
    DateTime? StartDateCreated,
    DateTime? EndDateCreated,
    DateTime? StartDateDeadline,
    DateTime? EndDateDeadline,
    DateTime? StartDateCompleted,
    DateTime? EndDateCompleted,
    bool? Completed);