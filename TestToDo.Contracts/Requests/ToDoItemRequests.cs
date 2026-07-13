using TestToDo.Enums;

namespace TestToDo.Contracts.Requests;

public readonly record struct ChangeTitleRequest(string Title);
public readonly record struct ChangeDescriptionRequest(string Description);
public readonly record struct ChangePriorityRequest(EPriority Priority);
public readonly record struct ChangeDeadlineRequest(DateTime Deadline);
public readonly record struct SearchToDoItemsRequest(
    string? SearchTerm, 
    Guid? CategoryId,
    EPriority[]? Priority,
    DateTime? StartDateCreated, DateTime? EndDateCreated,
    DateTime? StartDateDeadline, DateTime? EndDateDeadline,
    DateTime? StartDateCompleted, DateTime? EndDateCompleted,
    bool? Completed,
    int Page, int PageSize);