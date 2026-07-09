using MediatR;
using Microsoft.AspNetCore.Mvc;
using TestToDo.Application.Commands.ToDoItems;
using TestToDo.Application.DTOs;
using TestToDo.Application.Queries.ToDoItems;
using TestToDo.Enums;

namespace TestToDo.Api.Controllers;
[ApiController]
[Route("api/[controller]")]
public class ToDoItemsController(IMediator mediator) : ControllerBase
{
    //GET
    [HttpGet("{id:guid}")]
    public async Task<ActionResult<ToDoItemDto>> GetById(Guid id, CancellationToken cancellationToken)
    {
        var item = await mediator.Send(new GetToDoItemByIdQuery(id), cancellationToken);
        return item is null ? NotFound() : Ok(item);
    }

    [HttpGet]
    public async Task<ActionResult<IReadOnlyCollection<ToDoItemDto>>> GetAll(CancellationToken cancellationToken)
    {
        var items = await mediator.Send(new GetAllToDoItemsQuery(), cancellationToken);
        return Ok(items);
    }
    //GET

    //POST
    [HttpPost]
    public async Task<ActionResult<ToDoItemDto>> Create([FromBody] CreateToDoItemCommand command,  CancellationToken cancellationToken)
    {
        var item = await mediator.Send(command, cancellationToken);
        return CreatedAtAction(nameof(GetById), new { id = item.Id }, item);
    }
    //POST
    
    //PATCH
    [HttpPatch("{id:guid}/title")]
    public async Task<IActionResult> ChangeTitle(Guid id, [FromBody]ChangeTitleRequest request, CancellationToken cancellationToken)
    {
        await mediator.Send(new ChangeTitleToDoItemCommand(id, request.Title), cancellationToken);
        return NoContent();
    }
    
    [HttpPatch("{id:guid}/description")]
    public async Task<IActionResult> ChangeDescription(Guid id, [FromBody]ChangeDescriptionRequest request, CancellationToken cancellationToken)
    {
        await mediator.Send(new ChangeDescriptionToDoItemCommand(id, request.Description), cancellationToken);
        return NoContent();
    }
    
    [HttpPatch("{id:guid}/category/{categoryId:guid}")]
    public async Task<IActionResult> ChangeCategory(Guid id, Guid categoryId, CancellationToken cancellationToken)
    {
        await mediator.Send(new ChangeCategoryToDoItemCommand(id, categoryId), cancellationToken);
        return NoContent();
    }
    
    [HttpPatch("{id:guid}/category/default")]
    public async Task<IActionResult> ChangeCategory(Guid id, CancellationToken cancellationToken)
    {
        await mediator.Send(new ChangeCategoryToDoItemCommand(id, Guid.Empty), cancellationToken);
        return NoContent();
    }
    
    [HttpPatch("{id:guid}/priority")]
    public async Task<IActionResult> ChangePriority(Guid id, [FromBody] ChangePriorityRequest request, CancellationToken cancellationToken)
    {
        await mediator.Send(new ChangePriorityToDoItemCommand(id, request.Priority), cancellationToken);
        return NoContent();
    }
    
    [HttpPatch("{id:guid}/deadline")]
    public async Task<IActionResult> ChangeDeadline(Guid id, [FromBody] ChangeDeadlineRequest request, CancellationToken cancellationToken)
    {
        await mediator.Send(new ChangeDeadlineToDoItemCommand(id, request.Deadline), cancellationToken);
        return NoContent();
    }
    
    [HttpPatch("{id:guid}/complete")]
    public async Task<IActionResult> Complete(Guid id, CancellationToken cancellationToken)
    {
        await mediator.Send(new CompleteToDoItemCommand(id), cancellationToken);
        return NoContent();
    }
    
    [HttpPatch("{id:guid}/reopen")]
    public async Task<IActionResult> Reopen(Guid id, CancellationToken cancellationToken)
    {
        await mediator.Send(new ReopenToDoItemCommand(id), cancellationToken);
        return NoContent();
    }
    //PATCH
    
    //DELETE
    [HttpDelete("{id:guid}")]
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
//REQUESTS RECORDS