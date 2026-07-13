using MediatR;
using Microsoft.AspNetCore.Authorization;
using Microsoft.AspNetCore.Mvc;
using TestToDo.Application.Commands.ToDoItems;
using TestToDo.Application.DTOs;
using TestToDo.Application.Queries.ToDoItems;
using TestToDo.Enums;
using TestToDo.Filters;

namespace TestToDo.Api.Controllers;
[ApiController]
[Route("api/[controller]")]
public class ToDoItemsController(IMediator mediator) : ControllerBase
{
    //GET
    [HttpGet("{id:guid}")]
    [Authorize]
    public async Task<ActionResult<ToDoItemDto>> GetById(Guid id, CancellationToken cancellationToken)
    {
        var item = await mediator.Send(new GetToDoItemByIdQuery(id), cancellationToken);
        return item is null ? NotFound() : Ok(item);
    }
    
    [HttpGet]
    [Authorize]
    public async Task<ActionResult<IReadOnlyCollection<ToDoItemDto>>> Search([FromQuery] SearchToDoItemsRequest request, CancellationToken cancellationToken)
    {
        var filter = new ToDoItemSearchFilter
        (
            SearchTerm: request.SearchTerm,
            CategoryId: request.CategoryId,
            StartDateCreated: request.StartDateCreated,
            EndDateCreated: request.EndDateCreated,
            StartDateDeadline: request.StartDateDeadline,
            EndDateDeadline: request.EndDateDeadline,
            StartDateCompleted: request.StartDateCompleted,
            EndDateCompleted: request.EndDateCompleted,
            Priority: request.Priority,
            Completed: request.Completed
        );
        
        var pagination = new PaginationFilter(
            page: request.Page,
            pageSize: request.PageSize);
        
        
        var items = await mediator.Send(
            new SearchToDoItemsQuery(filter, pagination), 
            cancellationToken);
        return Ok(items);
    }
    //GET

    //POST
    [HttpPost]
    [Authorize]
    public async Task<ActionResult<ToDoItemDto>> Create([FromBody] CreateToDoItemCommand command,  CancellationToken cancellationToken)
    {
        var item = await mediator.Send(command, cancellationToken);
        return CreatedAtAction(nameof(GetById), new { id = item.Id }, item);
    }
    //POST
    
    //PATCH
    [HttpPatch("{id:guid}/title")]
    [Authorize]
    public async Task<IActionResult> ChangeTitle(Guid id, [FromBody]ChangeTitleRequest request, CancellationToken cancellationToken)
    {
        await mediator.Send(new ChangeTitleToDoItemCommand(id, request.Title), cancellationToken);
        return NoContent();
    }
    
    [HttpPatch("{id:guid}/description")]
    [Authorize]
    public async Task<IActionResult> ChangeDescription(Guid id, [FromBody]ChangeDescriptionRequest request, CancellationToken cancellationToken)
    {
        await mediator.Send(new ChangeDescriptionToDoItemCommand(id, request.Description), cancellationToken);
        return NoContent();
    }
    
    [HttpPatch("{id:guid}/category/{categoryId:guid}")]
    [Authorize]
    public async Task<IActionResult> ChangeCategory(Guid id, Guid categoryId, CancellationToken cancellationToken)
    {
        await mediator.Send(new ChangeCategoryToDoItemCommand(id, categoryId), cancellationToken);
        return NoContent();
    }
    
    [HttpPatch("{id:guid}/category/default")]
    [Authorize]
    public async Task<IActionResult> ChangeCategory(Guid id, CancellationToken cancellationToken)
    {
        await mediator.Send(new ChangeCategoryToDoItemCommand(id, null), cancellationToken);
        return NoContent();
    }
    
    [HttpPatch("{id:guid}/priority")]
    [Authorize]
    public async Task<IActionResult> ChangePriority(Guid id, [FromBody] ChangePriorityRequest request, CancellationToken cancellationToken)
    {
        await mediator.Send(new ChangePriorityToDoItemCommand(id, request.Priority), cancellationToken);
        return NoContent();
    }
    
    [HttpPatch("{id:guid}/deadline")]
    [Authorize]
    public async Task<IActionResult> ChangeDeadline(Guid id, [FromBody] ChangeDeadlineRequest request, CancellationToken cancellationToken)
    {
        await mediator.Send(new ChangeDeadlineToDoItemCommand(id, request.Deadline), cancellationToken);
        return NoContent();
    }
    
    [HttpPatch("{id:guid}/complete")]
    [Authorize]
    public async Task<IActionResult> Complete(Guid id, CancellationToken cancellationToken)
    {
        await mediator.Send(new CompleteToDoItemCommand(id), cancellationToken);
        return NoContent();
    }
    
    [HttpPatch("{id:guid}/reopen")]
    [Authorize]
    public async Task<IActionResult> Reopen(Guid id, CancellationToken cancellationToken)
    {
        await mediator.Send(new ReopenToDoItemCommand(id), cancellationToken);
        return NoContent();
    }
    //PATCH
    
    //DELETE
    [HttpDelete("{id:guid}")]
    [Authorize]
    public async Task<ActionResult> Delete(Guid id, CancellationToken cancellationToken)
    {
        await mediator.Send(new DeleteToDoItemCommand(id), cancellationToken);
        return NoContent();
    }
    //DELETE
}

//REQUESTS RECORDS //todo change location to contracts
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
//REQUESTS RECORDS